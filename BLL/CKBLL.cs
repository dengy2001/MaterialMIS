/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-07-14
 * 时间: 15:14
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
	/// Description of CKBLL.
	/// </summary>
	public class CKBLL
	{
		public CKBLL()
		{
		}
		
		//获取OutStockItem
		public static DataSet GetOutStockItems(int i_OutStockID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ItemsID,A.OutStockID,A.GoodsQty,A.GoodsPrc,A.GoodsAmt,A.UsePosition,B.GoodsID,B.GoodsName,A.GoodsSpec,B.GoodsUnit,C.GoodsTypeName,C.GoodsTypeID FROM OutStockItems A,Goods B,GoodsType C WHERE A.GoodsID=B.GoodsID AND B.GoodsTypeID=C.GoodsTypeID AND A.OutStockID = @ID",i_OutStockID);
			return ds;
		}
		
		//查询指定ProjectID和CompanyID还没有结算的
		public static DataSet GetOutStocks(int i_ProjectID,int i_CompanyID,string s_RecordStatus)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT OutStockID,OutStockDate,OutStockNum,OutStockType,OutBillAmt,OutBillRemark,ProjectID,CompanyID,WareHouseID,BillCycle,RecordStatus,OutMan,UseMan FROM OutStock WHERE ProjectID=@ProjectID AND CompanyID = @CompanyID AND RecordStatus = @RecordStatus",i_ProjectID,i_CompanyID,s_RecordStatus);
			return ds;				
		}
		
		public static DataSet GetOutStocks(int i_ProjectID,int i_CompanyID,string s_RecordStatus,string s_BillCycle)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT OutStockID,OutStockDate,OutStockNum,OutStockType,OutBillAmt,OutBillRemark,ProjectID,CompanyID,WareHouseID,BillCycle,RecordStatus,OutMan,UseMan FROM OutStock WHERE ProjectID=@ProjectID AND CompanyID = @CompanyID AND RecordStatus = @RecordStatus AND BillCycle=@BillCycle ORDER BY OutStockDate",i_ProjectID,i_CompanyID,s_RecordStatus,s_BillCycle);
			return ds;				
		}
		
		//查询指定ProjectID和CompanyID还没有结算的
		public static DataSet GetOutStockItems(int i_ProjectID,int i_CompanyID,string s_RecordStatus)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ItemsID,OutStockID,GoodsID,GoodsName,GoodsSpec,GoodsUnit,GoodsQty,GoodsPrc,GoodsAmt,Useposition FROM OutStockItems WHERE OutStockID IN (SELECT OutStockID FROM OutStock WHERE ProjectID=@ProjectID AND CompanyID = @CompanyID AND RecordStatus = @RecordStatus)",i_ProjectID,i_CompanyID,s_RecordStatus);
			return ds;				
		}
		
		public static DataSet GetOutStockItems(int i_ProjectID,int i_CompanyID,string s_RecordStatus,string s_BillCycle)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ItemsID,A.OutStockID,A.GoodsID,A.GoodsName,A.GoodsSpec,A.GoodsUnit,A.GoodsQty,A.GoodsPrc,A.GoodsAmt,A.Useposition,B.UseMan,B.OutMan,B.OutStockDate FROM OutStockItems A,OutStock B WHERE A.OutStockID = B.OutStockID AND B.ProjectID=@ProjectID AND B.CompanyID = @CompanyID AND B.RecordStatus = @RecordStatus AND B.BillCycle=@BillCycle ORDER BY B.OutStockDate",i_ProjectID,i_CompanyID,s_RecordStatus,s_BillCycle);
			return ds;				
		}
		
		//获取全部OutStock
		public static DataSet GetAllOutStock()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.OutStockID,A.OutStockDate,A.OutStockNum,A.OutBillAmt,A.OutBillRemark,A.ProjectID,A.WareHouseID,A.BillCycle,A.RecordStatus,A.OutMan,A.UseMan,B.CompanyID,B.CompanyName FROM OutStock A,Companies B WHERE A.CompanyID=B.CompanyID");
			return ds;
		}
		
		//获取已记账或已结算OutStock
		public static DataSet GetAllOutStock(string sRecordStatus)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.OutStockID,A.OutStockDate,A.OutStockNum,A.OutBillAmt,A.OutBillRemark,A.ProjectID,A.WareHouseID,A.BillCycle,A.RecordStatus,A.OutMan,A.UseMan,B.CompanyID,B.CompanyName FROM OutStock A,Companies B WHERE (A.CompanyID=B.CompanyID) AND (A.RecordStatus=@RecordStatus)",sRecordStatus);
			//ds = SQLiteHelper.ExecuteDataSet("SELECT A.OutStockID,A.OutStockDate,A.OutStockNum,A.OutBillAmt,A.OutBillRemark,A.ProjectID,A.WareHouseID,A.BillCycle,A.RecordStatus,A.OutMan,A.UseMan,B.CompanyID,B.CompanyName FROM OutStock A,Companies B WHERE A.CompanyID=B.CompanyID AND A.RecordStatus = '已记账'");
			return ds;
		}
		
		//获取指定的OutStock
		public static OutStock GetOutStock(int i_OutStockID)
		{
			DataSet ds = new DataSet();
			OutStock tO = new OutStock();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.OutStockID,A.OutStockDate,A.OutStockNum,A.OutStockType,A.OutBillAmt,A.OutBillRemark,A.OutMan,A.UseMan,B.CompanyID,B.CompanyName,C.ProjectID,C.ProjectName,D.WareHouseID,D.WareHouseName FROM OutStock A,Companies B,Projects C,WareHouses D WHERE A.CompanyID=B.CompanyID AND A.ProjectID=C.ProjectID AND A.WareHouseID=D.WareHouseID AND A.OutStockID=@ID",i_OutStockID);
			foreach(DataRow mDr in ds.Tables[0].Rows )
			{
				tO.CompanyID = Convert.ToInt32(mDr["CompanyID"].ToString());
				tO.ProjectID = Convert.ToInt32(mDr["ProjectID"].ToString());
				tO.OutBillAmt = Convert.ToDecimal(mDr["OutBillAmt"].ToString());
				tO.OutStockDate = Convert.ToDateTime(mDr["OutStockDate"].ToString());
				tO.OutStockID = Convert.ToInt32(mDr["OutStockID"].ToString());
				tO.OutStockNum = mDr["OutStockNum"].ToString();
				tO.OutStockType = Convert.ToInt32(mDr["OutStockType"].ToString());
				tO.OutBillRemark = mDr["OutBillRemark"].ToString();
				tO.WareHouseID = Convert.ToInt32(mDr["WareHouseID"].ToString());
				tO.UseMan = mDr["UseMan"].ToString();
				tO.OutMan = mDr["OutMan"].ToString();
			}
			return tO;
				
		}	
		
		//获取指定的OutStock
		public static DataSet GetOutStock1(int i_OutStockID)
		{
			DataSet ds = new DataSet();
			OutStock tO = new OutStock();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.OutStockID,A.OutStockDate,A.OutStockNum,A.OutStockType,A.OutBillAmt,A.OutBillRemark,A.OutMan,A.UseMan,B.CompanyID,B.CompanyName,C.ProjectID,C.ProjectName,D.WareHouseID,D.WareHouseName FROM OutStock A,Companies B,Projects C,WareHouses D WHERE A.CompanyID=B.CompanyID AND A.ProjectID=C.ProjectID AND A.WareHouseID=D.WareHouseID AND A.OutStockID=@ID",i_OutStockID);
			
			return ds;
				
		}				
		
		//获取指定OutStockID的utStockItems的ItemsID的List
		public static List<int> GetItemIDs(int i_OutStockID)
		{
			DataSet ds = new DataSet();
			List<int> tO = new List<int>();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ItemsID FROM OutStockItems WHERE OutStockID=@ID",i_OutStockID);
			foreach(DataRow mDr in ds.Tables[0].Rows )
			{
				tO.Add(Convert.ToInt32(mDr["ItemsID"].ToString()));
				
			}
			return tO;
		}
		
		
		//增加出库单
		public static void AddCKD(OutStock tOutStock,List<OutStockItems> tItemsList)
		{
			//保存数据，注意使用事务进行处理
			//1、出库单号的生成与修改；2、出库单的增加；3、出库单项目的增加
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				//查最后的出库单号
				IList<ProgOptions> Key1 = BLL.ProgOptionsBLL.GetOptions("CKD_LastNumber");
				string s_CKD_LastNo = Key1[0].OptionsValue;
				string s_CKD_NewNo;
				string s_CKD_LastYM;
				string s_CKD_NewYM;
				int LastNo;
				int NewNo;
				string s_NewNo;
				s_CKD_NewYM = DateTime.Today.ToString("yyyyMM");
				if(s_CKD_LastNo.Length == 10)
				{
					//4位年+2位月+4位顺序号
					s_CKD_LastYM = s_CKD_LastNo.Substring(0,6);
					LastNo = Convert.ToInt32(s_CKD_LastNo.Substring(6,4));
					if(s_CKD_NewYM != s_CKD_LastYM)
					{
						NewNo = 1;
					}
					else
					{
						NewNo = LastNo + 1;
					}
				}
				else
				{
					//没有数据
					NewNo = 1;
				}
				s_NewNo = "0000" + NewNo.ToString();
				s_NewNo =s_NewNo.Substring(s_NewNo.Length-4,4);
				//将新的最后编号保存到数据库
				ProgOptions t1 = session.Get<ProgOptions>(Key1[0].OptionsID);
				t1.OptionsID = Key1[0].OptionsID;
				t1.OptionsKey = Key1[0].OptionsKey;
				s_CKD_NewNo = s_CKD_NewYM + s_NewNo;
				t1.OptionsValue = s_CKD_NewNo;
				t1.OptionsRemark = Key1[0].OptionsRemark;

				//保存出库单
				tOutStock.OutStockNum = "CKD-" + t1.OptionsValue;				
				session.Save(tOutStock);	
				
				
				//保存出库单项
				foreach(OutStockItems tOI in tItemsList)
				{
					tOI.OutStockID = tOutStock.OutStockID;
					session.Save(tOI);
					//更新库存
					PKModel pk = new PKModel();
					pk.GoodsID = tOI.GoodsID;
					pk.WareHouseID = tOutStock.WareHouseID;
					WareHouseStock tWH = session.Get<WareHouseStock>(pk);
					if(tWH == null)
					{
						WareHouseStock tWHNew = new WareHouseStock();
						tWHNew.Pk = pk;
					
						tWHNew.Number = - tOI.GoodsQty;
						tWHNew.Price = tOI.GoodsPrc;
						tWHNew.Amount = - tOI.GoodsAmt;
						session.Save(tWHNew);
					}
					else
					{
						tWH.Number -= tOI.GoodsQty;
						tWH.Amount -= tOI.GoodsAmt;
						if(tWH.Number != 0)
						{
							tWH.Price = Math.Round(tWH.Amount / tWH.Number,2);
						}
						session.Flush();
					}
				}				
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
		
		
		//修改出库单
		public static void ModifyCKD(OutStock tOutStock,List<OutStockItems> tItemsList)
		{				
			//修改出库单
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				//得到未变更的出库单
				OutStock tOldOutStock = new OutStock();
				tOldOutStock = BLL.CKBLL.GetOutStock(tOutStock.OutStockID);
				
				//删除OutStockItem中的相关项
				List<int> toDelItemsID = BLL.CKBLL.GetItemIDs(tOldOutStock.OutStockID);
				foreach(int i in toDelItemsID)
				{
					OutStockItems toDel1 = session.Get<OutStockItems>(i);
					session.Delete(toDel1);
					//更新库存
					PKModel pk = new PKModel();
					pk.GoodsID = toDel1.GoodsID;
					pk.WareHouseID = tOldOutStock.WareHouseID;
					WareHouseStock tWH = session.Get<WareHouseStock>(pk);
					if(tWH == null)
					{
						WareHouseStock tWHNew = new WareHouseStock();
						tWHNew.Pk = pk;
					
						tWHNew.Number = - toDel1.GoodsQty;
						tWHNew.Price = toDel1.GoodsPrc;
						tWHNew.Amount = - toDel1.GoodsAmt;
						session.Save(tWHNew);
					}
					else
					{
						tWH.Number += toDel1.GoodsQty;
						tWH.Amount += toDel1.GoodsAmt;
						if(tWH.Number != 0)
						{
							tWH.Price = Math.Round(tWH.Amount / tWH.Number,2);
						}
						session.Flush();
					}
				}
				//保存OutStock的修改
				OutStock toModify = session.Get<OutStock>(tOldOutStock.OutStockID);
				toModify.CompanyID = tOutStock.CompanyID;
				toModify.ProjectID = tOutStock.ProjectID;
				toModify.OutBillAmt = tOutStock.OutBillAmt;
				toModify.OutBillRemark = tOutStock.OutBillRemark;
				toModify.WareHouseID = tOutStock.WareHouseID;	
				toModify.OutStockType = tOutStock.OutStockType;
				
				//将新的OutStockItem加入
				foreach(OutStockItems tOI in tItemsList)
				{
					tOI.OutStockID = tOutStock.OutStockID;
					session.Save(tOI);
					//更新库存
					PKModel pk = new PKModel();
					pk.GoodsID = tOI.GoodsID;
					pk.WareHouseID = tOutStock.WareHouseID;
					WareHouseStock tWH = session.Get<WareHouseStock>(pk);
					if(tWH == null)
					{
						WareHouseStock tWHNew = new WareHouseStock();
						tWHNew.Pk = pk;
					
						tWHNew.Number = - tOI.GoodsQty;
						tWHNew.Price = tOI.GoodsPrc;
						tWHNew.Amount = - tOI.GoodsAmt;
						session.Save(tWHNew);
					}
					else
					{
						tWH.Number -= tOI.GoodsQty;
						tWH.Amount -= tOI.GoodsAmt;
						if(tWH.Number != 0)
						{
							tWH.Price = Math.Round(tWH.Amount / tWH.Number,2);
						}
						session.Flush();
					}
				}		
				
				
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
		
		//删除出库单
		public static void DelCKD(int i_OutStockID)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				OutStock toDel1 = session.Get<OutStock>(i_OutStockID);
				
				
				//删除OutStockItem中的相关项
				List<int> toDelItemsID = BLL.CKBLL.GetItemIDs(toDel1.OutStockID);
				foreach(int i in toDelItemsID)
				{
					OutStockItems toDel2 = session.Get<OutStockItems>(i);
					session.Delete(toDel2);
					//更新库存
					PKModel pk = new PKModel();
					pk.GoodsID = toDel2.GoodsID;
					pk.WareHouseID = toDel1.WareHouseID;
					WareHouseStock tWH = session.Get<WareHouseStock>(pk);
					if(tWH != null)
					{						
						tWH.Number += toDel2.GoodsQty;
						tWH.Amount += toDel2.GoodsAmt;
						if(tWH.Number != 0)
						{
							tWH.Price = Math.Round(tWH.Amount / tWH.Number,2);
						}
						else
						{
							tWH.Price = 0;
						}
						
					}					
				}
				session.Delete(toDel1);
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
		
		//更新出库单状态
		public static void UpdateCKD(int i_ProjectID,int i_CompanyID,string s_RecordStatus,string s_BillCycle,DataGridViewSelectedRowCollection dC)
		{
			decimal dTotal = 0.0M;
			foreach (DataGridViewRow row in dC) 
			{ 	
				int i_OutStockID = Convert.ToInt32(row.Cells["OutStockID"].Value.ToString());
				string s_OutStockNum = row.Cells["OutStockNum"].Value.ToString();
				dTotal += Convert.ToDecimal(row.Cells["OutBillAmt"].Value);
				UpdateOutStock(i_OutStockID,s_RecordStatus,s_BillCycle);				
			}
			//更新到StatementList表中。
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				Projects tP = session.Get<Projects>(i_ProjectID);
				Companies tC = session.Get<Companies>(i_CompanyID);
				StatementList tS = new StatementList();
				tS.CompanyID = i_CompanyID;
				tS.CompanyName = tC.CompanyName;
				tS.ProjectID = i_ProjectID;
				tS.ProjectName = tP.ProjectName;
				tS.BillYS = dTotal;
				tS.BillSS = 0.0M;
				tS.BillYF = 0.0M;
				tS.BillSF = 0.0M;
				tS.StatementType = "出库结算";
				tS.StatementCycle = s_BillCycle;
				tS.MoneyTypeID = 10001;
				tS.MoneyTypeName = "出库结算自动生成";
				tS.StatementMemo = "结算应收款";
				tS.StatementDate = DateTime.Now;
				
				session.Save(tS);
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
		
		public static void UpdateOutStock(int i_OutStockID,string s_RecordStatus,string s_BillCycle)
		{
			SQLiteHelper.ExecuteNonQuery("UPDATE OutStock SET RecordStatus = @RecordStatus,BillCycle = @BillCycle WHERE OutStockID = @OutStockID ",s_RecordStatus,s_BillCycle,i_OutStockID);
		}
		
		public static DataSet GetOutStock(string s_OutStockIDs)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT OutStockID,OutStockDate,OutStockNum,OutStockType,OutBillAmt,OutBillRemark,ProjectID,CompanyID,WareHouseID,BillCycle,RecordStatus,OutMan,UseMan FROM OutStock WHERE OutStockID IN (" + s_OutStockIDs + ") ORDER BY OutStockDate");
			return ds;				
		}
		
		public static DataSet GetOutStockItems(string s_OutStockIDs)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ItemsID,A.OutStockID,A.GoodsID,A.GoodsName,A.GoodsSpec,A.GoodsUnit,A.GoodsQty,A.GoodsPrc,A.GoodsAmt,A.UsePosition,B.UseMan,B.OutMan,B.OutStockDate FROM OutStockItems A,OutStock B WHERE A.OutStockID=B.OutStockID AND A.OutStockID IN (" + s_OutStockIDs + ") ORDER BY B.OutStockDate");
			return ds;				
		}
		
		//月结出库
		public static DataSet GetOutStockYJ(int i_ProjectID,int i_CompanyID, string s_RecordStatus)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT SUM(A.OutBillAmt) AS SUM_OutBillAmt,A.CompanyID,A.ProjectID,A.BillCycle,B.ProjectName,C.CompanyName FROM OutStock A,Projects B,Companies C WHERE A.ProjectID=B.ProjectID AND A.CompanyID=C.CompanyID AND A.ProjectID = @ProjectID AND A.CompanyID=@CompanyID AND A.RecordStatus = @RecordStatus group by A.ProjectID,A.CompanyID,A.BillCycle order by  A.ProjectID,A.CompanyID,A.BillCycle ",i_ProjectID,i_CompanyID,s_RecordStatus);
			return ds;				
		}
		
		//将月结算单从"已结算"变成 "已记账"
		public static void OutStockYJReverse(int i_ProjectID,int i_CompanyID,string s_BillCycle)
		{
			//变出库
			SQLiteHelper.ExecuteNonQuery("UPDATE OutStock SET RecordStatus = '已记账',BillCycle = null WHERE ProjectID = @ProjectID AND CompanyID=@CompanyID AND BillCycle=@BillCycle ",i_ProjectID,i_CompanyID,s_BillCycle);
			SQLiteHelper.ExecuteNonQuery("DELETE FROM StatementList WHERE ProjectID = @ProjectID AND CompanyID=@CompanyID AND StatementCycle=@BillCycle ",i_ProjectID,i_CompanyID,s_BillCycle);
		}
	}
}
