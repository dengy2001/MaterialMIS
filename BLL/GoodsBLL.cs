/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-05-16
 * 时间: 12:30
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
	/// Description of GoodsBLL.
	/// </summary>
	public class GoodsBLL
	{
		public GoodsBLL()
		{
		}
		
		//添加货品
		public static void AddGoods(Goods g)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				session.Save(g);
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
				
		//修改货品
		public static void UpdateGoods(Goods g)
		{
			ISession session = NHibernateHelper.OpenSession();
			try
			{				
				ITransaction tx = session.BeginTransaction();
				Goods tGoods = session.Get<Goods>(g.GoodsID);
				tGoods.GoodsName = g.GoodsName;
				tGoods.GoodsNamePY = g.GoodsNamePY;
				tGoods.GoodsPic = g.GoodsPic;
				tGoods.GoodsPrice = g.GoodsPrice;
				tGoods.GoodsSpec = g.GoodsSpec;
				tGoods.GoodsTypeID = g.GoodsTypeID;
				tGoods.GoodsUnit = g.GoodsUnit;
				tGoods.LimitLow = g.LimitLow;
				tGoods.LimitUP = g.LimitUP;
				tx.Commit();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
		}
		
		//合并货品
		public static void MergeGoods(Goods tG1,Goods tG2)
		{
			//更新ReceiptItems表
			string sSQL = "UPDATE ReceiptItems SET GoodsID = " + tG2.GoodsID.ToString() + ",GoodsName = '"
				+ tG2.GoodsName + "', GoodsSpec = '" + tG2.GoodsSpec + "', GoodsUnit = '" + tG2.GoodsUnit 
				+ "' WHERE GoodsID = " + tG1.GoodsID.ToString();
			SQLiteHelper.ExecuteNonQuery(sSQL);
			//更新OutStockItems表
			sSQL = "UPDATE OutStockItems SET GoodsID = " + tG2.GoodsID.ToString() + ",GoodsName = '"
				+ tG2.GoodsName + "', GoodsSpec = '" + tG2.GoodsSpec + "', GoodsUnit = '" + tG2.GoodsUnit 
				+ "' WHERE GoodsID = " + tG1.GoodsID.ToString();
			SQLiteHelper.ExecuteNonQuery(sSQL);
			//更新WareHouseStock表		
			DataSet ds1 = BLL.WareHouseBLL.GetGoods1(tG1.GoodsID);
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				Goods tDelGoods = session.Get<Goods>(tG1.GoodsID);
				foreach(DataRow row1 in ds1.Tables[0].Rows)
				{
					string sGoodsID1 = row1["GoodsID"].ToString();
					string sWareHouseID1 = row1["WareHouseID"].ToString();
					
					PKModel pk = new PKModel();
					pk.GoodsID = tG1.GoodsID;
					pk.WareHouseID = Convert.ToInt32(sWareHouseID1);
					
					PKModel pk2 = new PKModel();
					pk2.GoodsID = tG2.GoodsID;
					pk2.WareHouseID = Convert.ToInt32(sWareHouseID1);
					
					WareHouseStock tWH1 = session.Get<WareHouseStock>(pk);
					WareHouseStock tWH2 = session.Get<WareHouseStock>(pk2);
					
					if(tWH2 == null)
					{
						//合并到的目的此仓库无库存记录
						WareHouseStock tWHNew = new WareHouseStock();
						tWHNew.Pk = pk2;
						tWHNew.Amount = tWH1.Amount;
						tWHNew.LastPrice = tWH1.LastPrice;
						tWHNew.Number = tWH1.Number;
						tWHNew.Price = tWH1.Price;
						session.Save(tWHNew);
						//删除
						session.Delete(tWH1);
					}
					else
					{
						//合并到的目的此仓库有库存记录
						tWH2.Number += tWH1.Number;
						tWH2.Amount += tWH1.Amount;
						if(tWH2.Number != 0)
						{
							tWH2.Price = Math.Round(tWH2.Amount/tWH2.Number,2);
						}
						session.Flush();
						//删除仓库货品
						session.Delete(tWH1);
					}
					
				}
				//删除货品
				session.Delete(tDelGoods);
				//事务提交				
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
		
		//批量修改货品的类别
		public static void UpdateGoodsType(List<int> iGoodsIDs,int iGoodsTypeID)
		{
			ISession session = NHibernateHelper.OpenSession();
			try
			{				
				ITransaction tx = session.BeginTransaction();
				foreach(int iGoods in iGoodsIDs)
				{
					Goods tGoods = session.Get<Goods>(iGoods);
					tGoods.GoodsTypeID = iGoodsTypeID;
					session.Save(tGoods);
				}

				tx.Commit();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
		}
		
		//查询全部Goods，用NHibernate
		public static IList<Goods> GetAllGoods()
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			IQuery query = session.CreateQuery("FROM Goods");
			IList<Goods> eList = query.List<Goods>(); 
//			try
//			{
//				foreach (Goods item in eList) 
//				{ 
//					//添加到DataSet中
//					string s= item.GoodsTypeInfo.GoodsTypeName;
//				} 
//				tx.Commit(); 
//				session.Close();				
//			}
//			catch(Exception e)
//			{
//				Debug.Assert(false,e.Message);
//				tx.Rollback();
//				session.Close();
//
//			}
			session.Close();
			return eList;
		}
		
		//查询全部Goods,用SQL直接获取
		public static DataSet GetAllGoods2()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.GoodsID,A.GoodsName,A.GoodsNamePY,A.GoodsTypeID,B.GoodsTypeName,A.GoodsUnit,A.GoodsSpec,C.LastPrice,C.Number FROM Goods A LEFT JOIN WareHouseStock C  ON A.[GoodsID] = C.GoodsID,GoodsType B WHERE A.GoodsTypeID = B.GoodsTypeID");
			return ds;				
		}
		//查询特定仓库的Goods,用SQL直接获取
		public static DataSet GetAllGoods2(int iWareHouseID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.GoodsID,A.GoodsName,A.GoodsNamePY,A.GoodsTypeID,B.GoodsTypeName,A.GoodsUnit,A.GoodsSpec,C.LastPrice,C.Number FROM Goods A LEFT JOIN WareHouseStock C  ON A.[GoodsID] = C.GoodsID AND C.WareHouseID = @WareHouseID,GoodsType B WHERE A.GoodsTypeID = B.GoodsTypeID ",iWareHouseID);
			return ds;				
		}
		
		//查询全部Goods,用SQL直接获取
		public static DataSet GetAllGoods3()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.GoodsID,A.GoodsName,A.GoodsNamePY,A.GoodsTypeID,B.GoodsTypeName,A.GoodsUnit,A.GoodsSpec,A.GoodsPrice,A.LimitLow,A.LimitUP FROM Goods A,GoodsType B  WHERE A.GoodsTypeID=B.GoodsTypeID ");
			return ds;				
		}
		
		//获取指定GoodsID的Goods
		public static Goods GetGoods(int i_GoodsID)
		{
			ISession session = NHibernateHelper.OpenSession();
			Goods tGoods = new Goods();
			try
			{
				tGoods = session.Get<Goods>(i_GoodsID);
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
			return tGoods;
		}
		
		//指定的商品能删除？
		private static bool CanDelGoods(int iGoodsID)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			int i_rtn = 0;
			//查询商品在库存表中是否存在
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM WareHouseStock WHERE GoodsID = @ID",iGoodsID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的商品在库存表中存在，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			//查询此商品在入库单中是否存在
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM ReceiptItems WHERE GoodsID = @GoodsID",iGoodsID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的商品在入库单中存在，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			//查询此商品在出库单中是否存在
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM OutStockItems WHERE GoodsID = @GoodsID",iGoodsID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的商品在入库单中存在，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			session.Close();
			return true;
		}
		
		
		//删除指定的货品
		public static void DelGoods(int  iGoodsID)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			Goods toDelete = session.Get<Goods>(iGoodsID);
				
			try
			{
				if(!CanDelGoods(iGoodsID))
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
		
	}
}
