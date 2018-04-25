/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-02
 * 时间: 12:27
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using NHibernate;
using NHibernate.Cfg;
using DomainModel;
using System.Data.SQLite;
using DAL;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace BLL
{
	/// <summary>
	/// Description of WareHouseBLL.
	/// </summary>
	public class WareHouseBLL
	{
		public WareHouseBLL()
		{
		}
		
		
		//添加新仓库
		public static void AddWareHouse(WareHouse tp)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				session.Save(tp);
				tx.Commit();
				session.Close();				
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
				tx.Rollback();
				session.Close();
			}
		}
		
		
		//修改
		public static void UpdateWareHouse(WareHouse tp)
		{
			ISession session = NHibernateHelper.OpenSession();
			try
			{				
				ITransaction tx = session.BeginTransaction();
				WareHouse t1 = session.Get<WareHouse>(tp.WareHouseID);
				t1.WareHouseName = tp.WareHouseName;
				tx.Commit();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
		}
		
		//指定的仓库能删除？
		private static bool CanDelWareHouse(int iWareHouseID)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			int i_rtn = 0;
			
			
			//查询，在Receipt表中是否有
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM Receipt WHERE WareHouseID = @WareHouseID",iWareHouseID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的仓库在入库单中存在，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			//查询，在OutStock表中是否有？
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM OutStock WHERE WareHouseID = @WareHouseID",iWareHouseID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的仓库在入库单中存在，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			session.Close();
			return true;
		}
		
		//删除
		public static void DelWareHouse(int  iWareHouseID)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			WareHouse toDelete = session.Get<WareHouse>(iWareHouseID);
				
			try
			{
				if(!CanDelWareHouse(iWareHouseID))
				{
					session.Close();
					return;
				}
				session.Delete(toDelete);
				tx.Commit();
				session.Close();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
				tx.Rollback();
				session.Close();
			}
		}
		
		
		//填充本地DataSet
		public static void FillWareHouse()
		{
			LocalData.FillWareHouses();
		}
		
		//查询全部WareHouse,用SQL直接获取
		public static DataSet GetAllWareHouse()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT WareHouseID,WareHouseName FROM WareHouses");
			return ds;				
		}
		
		//获取指定MoneyTypeID的MoneyType
		public static WareHouse GetWareHouse(int i_WareHouseID)
		{
			ISession session = NHibernateHelper.OpenSession();
			WareHouse tClass = new WareHouse();
			try
			{
				tClass = session.Get<WareHouse>(i_WareHouseID);
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
			return tClass;
		}
		
		
		//指定的货品能加入指定的WareHouseStock吗？
		private static bool IsWareHouseStockHas(int i_WareHouseID,int i_GoodsID)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			int i_rtn = 0;
			
			
			//查询，在WareHouseStock表中是否有
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM WareHouseStock WHERE WareHouseID = @WareHouseID AND GoodsID=@GoodsID",i_WareHouseID,i_GoodsID));
			if(i_rtn > 0)
			{
				session.Close();
				return true;
			}
			
			
			session.Close();
			return false;
		}
		
		//加入WareHouseStock
		public static void AddWareHouseStock(WareHouseStock tNew)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				if(IsWareHouseStockHas(tNew.Pk.WareHouseID,tNew.Pk.GoodsID))
				{
					session.Close();
					return;
				}
				session.Save(tNew);
				tx.Commit();
				session.Close();	
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
				tx.Rollback();
				session.Close();
			}
		}
		
		//查询指定WareHouseID的货品,用SQL直接获取
		public static DataSet GetGoods(int i_WareHouseID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.GoodsID,A.WareHouseID,A.LastPrice,A.Number,A.Price,A.Amount,B.GoodsName,B.GoodsSpec,B.GoodsUnit FROM WareHouseStock A,Goods B WHERE A.GoodsID=B.GoodsID AND A.WareHouseID=@WareHouseID",i_WareHouseID);
			return ds;				
		}			

		
		//查询指定GoodsID的货品,用SQL直接获取
		public static DataSet GetGoods1(int i_GoodsID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT GoodsID,WareHouseID,LastPrice,Number,Price,Amount FROM WareHouseStock WHERE GoodsID=@GoodsID",i_GoodsID);
			return ds;				
		}	
		
		//按照指定周期查询已经结算的出入库数据汇总
		public static DataSet GetStock(string sBillCycle)
		{
			DataSet ds = new DataSet();
			string sSQL = @"SELECT B.[GoodsID],B.[GoodsName],B.GoodsSpec,B.GoodsUnit,B.GoodsTypeID,SUM(A.LastQtyIn) LastQtyIn,SUM(A.LastAmtIn) LastAmtIn,SUM(A.LastQtyOut) LastQtyOut,SUM(A.LastAmtOut) LastAmtOut,SUM(A.ThisQtyIn) ThisQtyIn,SUM(A.ThisAmtIn) ThisAmtIn,SUM(A.ThisQtyOut) ThisQtyOut,SUM(A.ThisAmtOut) ThisAmtOut,SUM(A.[LastQtyIn])-SUM(A.[LastQtyOut]) AS LastQty,SUM(LastAmtIn)-SUM(LastAmtOut) As LastAmt,SUM(LastQtyIn)-SUM(LastQtyOut)+SUM(ThisQtyIn)-SUM(ThisQtyOut) As EndQty,SUM(LastAmtIn)-SUM(LastAmtOut)+SUM(ThisAmtIn)-SUM(ThisAmtOut) As EndAmt 
							FROM Goods B LEFT JOIN (SELECT C.GoodsID,C.GoodsName,C.GoodsSpec,C.GoodsUnit, 0 as LastQtyIn, 0 as LastAmtIn,C.GoodsQty LastQtyOut,C.GoodsAmt LastAmtOut,0 As ThisQtyIn,0 As ThisAmtIn,0 As ThisQtyOut, 0 As ThisAmtOut      
							FROM OutStockItems C,OutStock D 
							WHERE C.OutStockID=D.OutStockID AND D.recordStatus='已结算' AND D.BillCycle<@BillCycle
							UNION ALL 
							SELECT G.GoodsID,G.GoodsName,G.GoodsSpec,G.GoodsUnit, 0 as LastQtyIn, 0 as LastAmtIn,0 As LastQtyOut,0 As LastAmtOut,0 As ThisQtyIn,0 As ThisAmtIn,G.GoodsQty As ThisQtyOut, G.GoodsAmt As ThisAmtOut      
							FROM OutStockItems G,OutStock H 
							WHERE G.OutStockID=H.OutStockID AND H.recordStatus='已结算' AND H.BillCycle=@BillCycle
							UNION ALL 
							SELECT E.GoodsID,E.GoodsName,E.GoodsSpec,E.GoodsUnit, E.GoodsQty LastQtyIn, E.GoodsAmt as LastAmtIn,0 as LastQtyOut,0 as LastAmtOut，,0 As ThisQtyIn,0 As ThisAmtIn,0 As ThisQtyOut, 0 As ThisAmtOut
							FROM ReceiptItems E,Receipt F 
							WHERE E.ReceiptID=F.ReceiptID AND F.RecordStatus='已结算' AND F.BillCycle<@BillCycle
							UNION ALL
							SELECT I.GoodsID,I.GoodsName,I.GoodsSpec,I.GoodsUnit, 0 As LastQtyIn, 0 As LastAmtIn,0 as LastQtyOut,0 as LastAmtOut，,I.GoodsQty As ThisQtyIn,I.GoodsAmt As ThisAmtIn,0 As ThisQtyOut, 0 As ThisAmtOut
							FROM ReceiptItems I,Receipt J 
							WHERE I.ReceiptID=J.ReceiptID AND J.RecordStatus='已结算' AND J.BillCycle=@BillCycle) AS A ON A.[GoodsID]=B.[GoodsID] 
							GROUP BY B.GoodsID";

			ds = SQLiteHelper.ExecuteDataSet(sSQL,sBillCycle);
			return ds;
		}
		
		public static DataSet GetStock(string sBillCycle,int iWareHouseID)
		{
			DataSet ds = new DataSet();
			string sSQL = @"SELECT B.[GoodsID],B.[GoodsName],B.GoodsSpec,B.GoodsUnit,B.GoodsTypeID,SUM(A.LastQtyIn) LastQtyIn,SUM(A.LastAmtIn) LastAmtIn,SUM(A.LastQtyOut) LastQtyOut,SUM(A.LastAmtOut) LastAmtOut,SUM(A.ThisQtyIn) ThisQtyIn,SUM(A.ThisAmtIn) ThisAmtIn,SUM(A.ThisQtyOut) ThisQtyOut,SUM(A.ThisAmtOut) ThisAmtOut,SUM(A.[LastQtyIn])-SUM(A.[LastQtyOut]) AS LastQty,SUM(LastAmtIn)-SUM(LastAmtOut) As LastAmt,SUM(LastQtyIn)-SUM(LastQtyOut)+SUM(ThisQtyIn)-SUM(ThisQtyOut) As EndQty,SUM(LastAmtIn)-SUM(LastAmtOut)+SUM(ThisAmtIn)-SUM(ThisAmtOut) As EndAmt 
							FROM Goods B LEFT JOIN (SELECT C.GoodsID,C.GoodsName,C.GoodsSpec,C.GoodsUnit, 0 as LastQtyIn, 0 as LastAmtIn,C.GoodsQty LastQtyOut,C.GoodsAmt LastAmtOut,0 As ThisQtyIn,0 As ThisAmtIn,0 As ThisQtyOut, 0 As ThisAmtOut      
							FROM OutStockItems C,OutStock D 
							WHERE C.OutStockID=D.OutStockID AND D.recordStatus='已结算' AND D.WareHouseID = " + iWareHouseID.ToString() + @" AND D.BillCycle<@BillCycle
							UNION ALL 
							SELECT G.GoodsID,G.GoodsName,G.GoodsSpec,G.GoodsUnit, 0 as LastQtyIn, 0 as LastAmtIn,0 As LastQtyOut,0 As LastAmtOut,0 As ThisQtyIn,0 As ThisAmtIn,G.GoodsQty As ThisQtyOut, G.GoodsAmt As ThisAmtOut      
							FROM OutStockItems G,OutStock H 
							WHERE G.OutStockID=H.OutStockID AND H.recordStatus='已结算' AND H.WareHouseID = " + iWareHouseID.ToString() + @" AND H.BillCycle=@BillCycle
							UNION ALL 
							SELECT E.GoodsID,E.GoodsName,E.GoodsSpec,E.GoodsUnit, E.GoodsQty LastQtyIn, E.GoodsAmt as LastAmtIn,0 as LastQtyOut,0 as LastAmtOut，,0 As ThisQtyIn,0 As ThisAmtIn,0 As ThisQtyOut, 0 As ThisAmtOut
							FROM ReceiptItems E,Receipt F 
							WHERE E.ReceiptID=F.ReceiptID AND F.RecordStatus='已结算' AND F.WareHouseID = " + iWareHouseID.ToString() + @" AND F.BillCycle<@BillCycle
							UNION ALL
							SELECT I.GoodsID,I.GoodsName,I.GoodsSpec,I.GoodsUnit, 0 As LastQtyIn, 0 As LastAmtIn,0 as LastQtyOut,0 as LastAmtOut，,I.GoodsQty As ThisQtyIn,I.GoodsAmt As ThisAmtIn,0 As ThisQtyOut, 0 As ThisAmtOut
							FROM ReceiptItems I,Receipt J 
							WHERE I.ReceiptID=J.ReceiptID AND J.RecordStatus='已结算' AND J.WareHouseID = " + iWareHouseID.ToString() + @" AND J.BillCycle=@BillCycle) AS A ON A.[GoodsID]=B.[GoodsID] 
							GROUP BY B.GoodsID";

			ds = SQLiteHelper.ExecuteDataSet(sSQL,sBillCycle);
			return ds;
		}
		
		//查询已结算最后周期以及“已记账”的数据
		public static DataSet GetStockCurrent(string sBillCycle)
		{
			DataSet ds = new DataSet();
			string sSQL = @"SELECT B.[GoodsID],B.[GoodsName],B.GoodsSpec,B.GoodsUnit,B.GoodsTypeID,SUM(A.LastQtyIn) LastQtyIn,SUM(A.LastAmtIn) LastAmtIn,SUM(A.LastQtyOut) LastQtyOut,SUM(A.LastAmtOut) LastAmtOut,SUM(A.ThisQtyIn) ThisQtyIn,SUM(A.ThisAmtIn) ThisAmtIn,SUM(A.ThisQtyOut) ThisQtyOut,SUM(A.ThisAmtOut) ThisAmtOut,SUM(A.[LastQtyIn])-SUM(A.[LastQtyOut]) AS LastQty,SUM(LastAmtIn)-SUM(LastAmtOut) As LastAmt,SUM(LastQtyIn)-SUM(LastQtyOut)+SUM(ThisQtyIn)-SUM(ThisQtyOut) As EndQty,SUM(LastAmtIn)-SUM(LastAmtOut)+SUM(ThisAmtIn)-SUM(ThisAmtOut) As EndAmt 
							FROM Goods B LEFT JOIN (SELECT C.GoodsID,C.GoodsName,C.GoodsSpec,C.GoodsUnit, 0 as LastQtyIn, 0 as LastAmtIn,C.GoodsQty LastQtyOut,C.GoodsAmt LastAmtOut,0 As ThisQtyIn,0 As ThisAmtIn,0 As ThisQtyOut, 0 As ThisAmtOut      
							FROM OutStockItems C,OutStock D 
							WHERE C.OutStockID=D.OutStockID AND D.recordStatus='已结算' AND D.BillCycle<=@BillCycle
							UNION ALL 
							SELECT G.GoodsID,G.GoodsName,G.GoodsSpec,G.GoodsUnit, 0 as LastQtyIn, 0 as LastAmtIn,0 As LastQtyOut,0 As LastAmtOut,0 As ThisQtyIn,0 As ThisAmtIn,G.GoodsQty As ThisQtyOut, G.GoodsAmt As ThisAmtOut      
							FROM OutStockItems G,OutStock H 
							WHERE G.OutStockID=H.OutStockID AND H.recordStatus='已记账'
							UNION ALL 
							SELECT E.GoodsID,E.GoodsName,E.GoodsSpec,E.GoodsUnit, E.GoodsQty LastQtyIn, E.GoodsAmt as LastAmtIn,0 as LastQtyOut,0 as LastAmtOut，,0 As ThisQtyIn,0 As ThisAmtIn,0 As ThisQtyOut, 0 As ThisAmtOut
							FROM ReceiptItems E,Receipt F 
							WHERE E.ReceiptID=F.ReceiptID AND F.RecordStatus='已结算' AND F.BillCycle<=@BillCycle
							UNION ALL
							SELECT I.GoodsID,I.GoodsName,I.GoodsSpec,I.GoodsUnit, 0 As LastQtyIn, 0 As LastAmtIn,0 as LastQtyOut,0 as LastAmtOut，,I.GoodsQty As ThisQtyIn,I.GoodsAmt As ThisAmtIn,0 As ThisQtyOut, 0 As ThisAmtOut
							FROM ReceiptItems I,Receipt J 
							WHERE I.ReceiptID=J.ReceiptID AND J.RecordStatus='已记账') AS A ON A.[GoodsID]=B.[GoodsID] 
							GROUP BY B.GoodsID";

			ds = SQLiteHelper.ExecuteDataSet(sSQL,sBillCycle);
			return ds;
		}
		
		public static DataSet GetStockCurrent(string sBillCycle,int iWareHouseID)
		{
			DataSet ds = new DataSet();
			string sSQL = @"SELECT B.[GoodsID],B.[GoodsName],B.GoodsSpec,B.GoodsUnit,B.GoodsTypeID,SUM(A.LastQtyIn) LastQtyIn,SUM(A.LastAmtIn) LastAmtIn,SUM(A.LastQtyOut) LastQtyOut,SUM(A.LastAmtOut) LastAmtOut,SUM(A.ThisQtyIn) ThisQtyIn,SUM(A.ThisAmtIn) ThisAmtIn,SUM(A.ThisQtyOut) ThisQtyOut,SUM(A.ThisAmtOut) ThisAmtOut,SUM(A.[LastQtyIn])-SUM(A.[LastQtyOut]) AS LastQty,SUM(LastAmtIn)-SUM(LastAmtOut) As LastAmt,SUM(LastQtyIn)-SUM(LastQtyOut)+SUM(ThisQtyIn)-SUM(ThisQtyOut) As EndQty,SUM(LastAmtIn)-SUM(LastAmtOut)+SUM(ThisAmtIn)-SUM(ThisAmtOut) As EndAmt 
							FROM Goods B LEFT JOIN (SELECT C.GoodsID,C.GoodsName,C.GoodsSpec,C.GoodsUnit, 0 as LastQtyIn, 0 as LastAmtIn,C.GoodsQty LastQtyOut,C.GoodsAmt LastAmtOut,0 As ThisQtyIn,0 As ThisAmtIn,0 As ThisQtyOut, 0 As ThisAmtOut      
							FROM OutStockItems C,OutStock D 
							WHERE C.OutStockID=D.OutStockID AND D.recordStatus='已结算' AND D.WareHouseID = "+ iWareHouseID.ToString() + @" AND D.BillCycle<=@BillCycle
							UNION ALL 
							SELECT G.GoodsID,G.GoodsName,G.GoodsSpec,G.GoodsUnit, 0 as LastQtyIn, 0 as LastAmtIn,0 As LastQtyOut,0 As LastAmtOut,0 As ThisQtyIn,0 As ThisAmtIn,G.GoodsQty As ThisQtyOut, G.GoodsAmt As ThisAmtOut      
							FROM OutStockItems G,OutStock H 
							WHERE G.OutStockID=H.OutStockID AND H.recordStatus='已记账' AND H.WareHouseID = " +iWareHouseID.ToString() + @"
							UNION ALL 
							SELECT E.GoodsID,E.GoodsName,E.GoodsSpec,E.GoodsUnit, E.GoodsQty LastQtyIn, E.GoodsAmt as LastAmtIn,0 as LastQtyOut,0 as LastAmtOut，,0 As ThisQtyIn,0 As ThisAmtIn,0 As ThisQtyOut, 0 As ThisAmtOut
							FROM ReceiptItems E,Receipt F 
							WHERE E.ReceiptID=F.ReceiptID AND F.RecordStatus='已结算' AND F.WareHouseID = " + iWareHouseID.ToString() + @" AND F.BillCycle<=@BillCycle
							UNION ALL
							SELECT I.GoodsID,I.GoodsName,I.GoodsSpec,I.GoodsUnit, 0 As LastQtyIn, 0 As LastAmtIn,0 as LastQtyOut,0 as LastAmtOut，,I.GoodsQty As ThisQtyIn,I.GoodsAmt As ThisAmtIn,0 As ThisQtyOut, 0 As ThisAmtOut
							FROM ReceiptItems I,Receipt J 
							WHERE I.ReceiptID=J.ReceiptID AND J.RecordStatus='已记账' AND J.WareHouseID = " + iWareHouseID.ToString() + @") AS A ON A.[GoodsID]=B.[GoodsID] 
							GROUP BY B.GoodsID";

			ds = SQLiteHelper.ExecuteDataSet(sSQL,sBillCycle);
			return ds;
		}
		
		
		//获得所有入库或出库的周期全部
		public static DataSet GetAllBillCycle()
		{
			DataSet ds = new DataSet();
			string sSql = @"SELECT DISTINCT(A.BillCycle) 
							FROM (SELECT BillCycle FROM OutStock UNION ALL SELECT BillCycle FROM Receipt) A";
			ds = SQLiteHelper.ExecuteDataSet(sSql);
			return ds;
		}
		
		//获得已经完成结算的最大周期
		public static string GetMaxJSCycle()
		{
			//DataSet ds = new DataSet();
			object obj = new object();
			string sSql = @"SELECT MAX(BillCycle) AS MaxCycle FROM 
						(SELECT DISTINCT(BillCycle),RecordStatus From OutStock
						Union All
						SELECT DISTINCT(BillCycle),RecordStatus From Receipt) As A 
						WHERE A.RecordStatus='已结算'";
			obj = SQLiteHelper.ExecuteScalar(sSql);
			return obj.ToString();
		}
		

		
	}
}
