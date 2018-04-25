/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-15
 * 时间: 15:23
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
	/// Description of RKBLL.
	/// </summary>
	public class RKBLL
	{
		public RKBLL()
		{
		}
		
		//获取ReceiptItem
		public static DataSet GetReceiptItems(int i_ReceiptID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ItemsID,A.ReceiptID,A.GoodsQty,A.GoodsPrc,A.GoodsYF,A.GoodsAmt,A.UsePosition,A.GoodsPlan,A.GoodsPlanNo,A.GoodsTaxRate,A.GoodsNoTaxPrice,B.GoodsID,B.GoodsName,B.GoodsSpec,A.MoreSpec,B.GoodsUnit,C.GoodsTypeName,C.GoodsTypeID FROM ReceiptItems A,Goods B,GoodsType C WHERE A.GoodsID=B.GoodsID AND B.GoodsTypeID=C.GoodsTypeID AND A.ReceiptID = @ID",i_ReceiptID);
			return ds;
		}
		
		//获取指定状态的Receipt，“已记账”  “已结算”
		public static DataSet GetAllReceipt(string sRecordStatus)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ReceiptID,A.ReceiptDate,A.ReceiptNum,A.ReceiptBillAmt,A.ReceiptDiscAmt,A.ReceiptDisc,A.Remark,A.PurchName,A.ReceiverName,A.BillCycle,A.RecordStatus,B.CompanyID,B.CompanyName FROM Receipt A,Companies B WHERE A.CompanyID=B.CompanyID AND A.RecordStatus=@RecordStatus",sRecordStatus);
			return ds;
		}
		
		//获取指定的Receipt
		public static Receipt GetReceipt(int i_ReceiptID)
		{
			DataSet ds = new DataSet();
			Receipt tR = new Receipt();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ReceiptID,A.ReceiptDate,A.ReceiptNum,A.ReceiptType,A.ReceiptBillAmt,A.ReceiptDiscAmt,A.ReceiptDisc,A.Remark,B.CompanyID,B.CompanyName,C.ProjectID,A.PurchName,A.ReceiverName,A.BillCycle,A.RecordStatus,C.ProjectName,D.WareHouseID,D.WareHouseName FROM Receipt A,Companies B,Projects C,WareHouses D WHERE A.CompanyID=B.CompanyID AND A.ProjectID=C.ProjectID AND A.WareHouseID=D.WareHouseID AND A.ReceiptID=@ID",i_ReceiptID);
			foreach(DataRow mDr in ds.Tables[0].Rows )
			{
				tR.CompanyID = Convert.ToInt32(mDr["CompanyID"].ToString());
				tR.ProjectID = Convert.ToInt32(mDr["ProjectID"].ToString());
				tR.ReceiptBillAmt = Convert.ToDecimal(mDr["ReceiptBillAmt"].ToString());
				tR.ReceiptDate = Convert.ToDateTime(mDr["ReceiptDate"].ToString());
				tR.ReceiptDisc = Convert.ToDecimal(mDr["ReceiptDisc"].ToString());
				tR.ReceiptDiscAmt = Convert.ToDecimal(mDr["ReceiptDiscAmt"].ToString());
				tR.ReceiptID = Convert.ToInt32(mDr["ReceiptID"].ToString());
				tR.ReceiptNum = mDr["ReceiptNum"].ToString();
				tR.ReceiptType = Convert.ToInt32(mDr["ReceiptType"].ToString());
				tR.Remark = mDr["Remark"].ToString();
				tR.WareHouseID = Convert.ToInt32(mDr["WareHouseID"].ToString());
				tR.PurchName = mDr["PurchName"].ToString();
				tR.ReceiverName = mDr["ReceiverName"].ToString();
				tR.BillCycle = mDr["BillCycle"].ToString();
				tR.RecordStatus = mDr["RecordStatus"].ToString();
			}
			return tR;
				
		}		
		
		//获取指定的Receipt
		public static DataSet GetReceipt1(int i_ReceiptID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ReceiptID,A.ReceiptDate,A.ReceiptNum,A.ReceiptType,A.ReceiptBillAmt,A.ReceiptDiscAmt,A.ReceiptDisc,A.Remark,B.CompanyID,B.CompanyName,C.ProjectID,A.PurchName,A.ReceiverName,A.BillCycle,A.RecordStatus,C.ProjectName,D.WareHouseID,D.WareHouseName FROM Receipt A,Companies B,Projects C,WareHouses D WHERE A.CompanyID=B.CompanyID AND A.ProjectID=C.ProjectID AND A.WareHouseID=D.WareHouseID AND A.ReceiptID=@ID",i_ReceiptID);
		
			return ds;
				
		}		
		
		//获取指定ReceiptID的ReceiptItems的ItemsID的List
		public static List<int> GetItemIDs(int i_ReceiptID)
		{
			DataSet ds = new DataSet();
			List<int> tR = new List<int>();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ItemsID FROM ReceiptItems WHERE ReceiptID=@ID",i_ReceiptID);
			foreach(DataRow mDr in ds.Tables[0].Rows )
			{
				tR.Add(Convert.ToInt32(mDr["ItemsID"].ToString()));
				
			}
			return tR;
		}
		
		//获取入库项信息
		public static DataSet GetInStockItemsAll(int i_ProjectID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ItemsID,A.ReceiptID,A.GoodsID,A.GoodsName,A.GoodsSpec,A.MoreSpec,A.GoodsUnit,A.GoodsQty,A.GoodsPrc,A.GoodsYF,A.GoodsAmt,A.UsePosition,A.GoodsPlan,A.GoodsPlanNo,A.GoodsTaxRate,A.GoodsNoTaxPrice,B.ProjectID,B.ReceiptDate FROM ReceiptItems A Inner Join Receipt B On A.ReceiptID=B.ReceiptID WHERE B.ProjectID=@ProjectID ORDER BY A.GoodsName,B.ReceiptDate Desc",i_ProjectID);
		
			return ds;				
		}	
		
		//获取入库项信息
		public static DataSet GetInStockItems(int i_ProjectID)
		{
			DataSet ds = new DataSet();
			//ds = SQLiteHelper.ExecuteDataSet("SELECT GoodsID,GoodsName，GoodsTypeID,GoodsSpec,MoreSpec,GoodsUnit,GoodsPrc,GoodsTaxRate,GoodsNoTaxPrice,ReceiptDate FROM (SELECT A.ReceiptID,A.GoodsID,A.GoodsName,A.GoodsSpec,A.MoreSpec,A.GoodsUnit,A.GoodsQty,A.GoodsPrc,A.GoodsYF,A.GoodsAmt,A.UsePosition,A.GoodsPlan,A.GoodsPlanNo,A.GoodsTaxRate,A.GoodsNoTaxPrice,B.ProjectID,B.ReceiptDate FROM ReceiptItems A Inner Join Receipt B On A.ReceiptID=B.ReceiptID WHERE B.ProjectID=" + i_ProjectID.ToString() +" AND A.Goods)  T1 WHERE NOT EXISTS (SELECT 1 FROM (SELECT A.ReceiptID,A.GoodsID,A.GoodsName,A.GoodsSpec,A.MoreSpec,A.GoodsUnit,A.GoodsQty,A.GoodsPrc,A.GoodsYF,A.GoodsAmt,A.UsePosition,A.GoodsPlan,A.GoodsPlanNo,A.GoodsTaxRate,A.GoodsNoTaxPrice,B.ProjectID,B.ReceiptDate FROM ReceiptItems A Inner Join Receipt B On A.ReceiptID=B.ReceiptID WHERE B.ProjectID=" + i_ProjectID.ToString() + ") T2 WHERE T1.GoodsID = T2.GoodsID AND T1.MoreSpec = T2.MoreSpec AND T2.ReceiptDate>T1.ReceiptDate)");
			ds = SQLiteHelper.ExecuteDataSet("Select GoodsID,GoodsName,GoodsSpec,MoreSpec,GoodsUnit,GoodsTypeID,GoodsTypeName,GoodsPrc,GoodsTaxRate,GoodsNoTaxPrice,ReceiptDate from (select * from (Select * From Goods A Inner Join GoodsType B On A.GoodsTypeID=B.GoodsTypeID Inner Join ReceiptItems C On A.GoodsID=C.GoodsID) D Inner Join Receipt E On D.ReceiptID=E.ReceiptID WHERE E.[ProjectID] = " + i_ProjectID.ToString() +") T1 WHERE Not Exists (Select 1 from (select * from (Select * From Goods A Inner Join GoodsType B On A.GoodsTypeID=B.GoodsTypeID Inner Join ReceiptItems C On A.GoodsID=C.GoodsID) D Inner Join Receipt E On D.ReceiptID=E.ReceiptID WHERE E.[ProjectID] = " + i_ProjectID.ToString() +") T2 WHERE T1.GoodsID = T2.GoodsID AND T1.MoreSpec = T2.MoreSpec AND T2.ReceiptDate>T1.ReceiptDate)");
			return ds;		
		}
		
		
			
		//增加入库单
		public static void AddRKD(Receipt tReceipt,List<ReceiptItems> tItemsList)
		{
			//保存数据，注意使用事务进行处理
			//1、入库单号的生成与修改；2、入库单的增加；3入库单项目的增加
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				//查最后的入库单号
				IList<ProgOptions> Key1 = BLL.ProgOptionsBLL.GetOptions("RKD_LastNumber");
				string s_RKD_LastNo = Key1[0].OptionsValue;
				string s_RKD_NewNo;
				string s_RKD_LastYM;
				string s_RKD_NewYM;
				int LastNo;
				int NewNo;
				string s_NewNo;
				s_RKD_NewYM = DateTime.Today.ToString("yyyyMM");
				if(s_RKD_LastNo.Length == 10)
				{
					//4位年+2位月+4位顺序号
					s_RKD_LastYM = s_RKD_LastNo.Substring(0,6);
					LastNo = Convert.ToInt32(s_RKD_LastNo.Substring(6,4));
					if(s_RKD_NewYM != s_RKD_LastYM)
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
				s_RKD_NewNo = s_RKD_NewYM + s_NewNo;
				t1.OptionsValue = s_RKD_NewNo;
				t1.OptionsRemark = Key1[0].OptionsRemark;

				//保存入库单
				tReceipt.ReceiptNum = "RKD-" + t1.OptionsValue;				
				session.Save(tReceipt);
				
				//添加应付款
				
				if(tReceipt.ReceiptDiscAmt !=0)
				{	
					Projects tP1 = session.Get<Projects>(tReceipt.ProjectID);
					Companies tC1 = session.Get<Companies>(tReceipt.CompanyID);
					AccountBill tAcc = new AccountBill();					
					tAcc.CompanyID = tReceipt.CompanyID;
					tAcc.CompanyName = tC1.CompanyName;
					tAcc.BillDate = tReceipt.ReceiptDate;
					tAcc.BillMemo = "采购应付款" + tReceipt.ReceiptNum;
					tAcc.BillType = 1;
					tAcc.BillYF = tReceipt.ReceiptDiscAmt;
					tAcc.ProjectID = tReceipt.ProjectID;
					tAcc.ProjectName = tP1.ProjectName;
					tAcc.MoneyTypeID = 100;   //材料购买
					tAcc.MoneyTypeName = "入库单生成";
					tAcc.BillStatus = "已记账";
					session.Save(tAcc);
					
				}
				
				foreach(ReceiptItems tRI in tItemsList)
				{
					//保存进货项
					ReceiptItems tNewReceiptItems = new ReceiptItems();
					tNewReceiptItems.GoodsID = tRI.GoodsID;
					tNewReceiptItems.ReceiptID = tReceipt.ReceiptID;
					tNewReceiptItems.GoodsName = tRI.GoodsName;
					tNewReceiptItems.GoodsAmt = tRI.GoodsAmt;
					tNewReceiptItems.GoodsPlan = tRI.GoodsPlan;
					tNewReceiptItems.GoodsPlanNo = tRI.GoodsPlanNo;
					tNewReceiptItems.GoodsPrc = tRI.GoodsPrc;
					tNewReceiptItems.GoodsQty = tRI.GoodsQty;
					tNewReceiptItems.GoodsSpec = tRI.GoodsSpec;
					tNewReceiptItems.GoodsUnit = tRI.GoodsUnit;
					tNewReceiptItems.GoodsYF = tRI.GoodsYF;
					tNewReceiptItems.GoodsTaxRate = tRI.GoodsTaxRate;
					tNewReceiptItems.GoodsNoTaxPrice = tRI.GoodsNoTaxPrice;
					tNewReceiptItems.MoreSpec = tRI.MoreSpec;
					tNewReceiptItems.UsePosition = tRI.UsePosition;

					session.Save(tNewReceiptItems);
				}
				
				//入库单同货品合并
				List<ReceiptItems> mergeList = new List<ReceiptItems>();
				foreach(ReceiptItems tRI in tItemsList)
				{
					ReceiptItems rtnRItem = mergeList.Find(name=>
					                                       {
					                                       	if(name.GoodsID == tRI.GoodsID)
					                                       	{
					                                       		return true;
					                                       	}
					                                       	else
					                                       	{
					                                       		return false;
					                                       	}
					                                       });
					if(rtnRItem == null)
					{
						mergeList.Add(tRI);
					}
					else
					{
						rtnRItem.GoodsQty += tRI.GoodsQty;
						rtnRItem.GoodsAmt += tRI.GoodsAmt;
						if(rtnRItem.GoodsQty != 0)
						{
							rtnRItem.GoodsPrc = rtnRItem.GoodsAmt / rtnRItem.GoodsQty;
						}
					}
					
				}				
				
				//更新库存
				foreach(ReceiptItems tRI in mergeList)
				{
					PKModel pk = new PKModel();
					pk.GoodsID = tRI.GoodsID;
					pk.WareHouseID = tReceipt.WareHouseID;
					WareHouseStock tWH = session.Get<WareHouseStock>(pk);
					if(tWH == null)
					{
						WareHouseStock tWHNew = new WareHouseStock();
						tWHNew.Pk = pk;
					
						tWHNew.Number = tRI.GoodsQty;
						tWHNew.LastPrice = tRI.GoodsPrc;
						tWHNew.Price = tRI.GoodsPrc;
						tWHNew.Amount = tRI.GoodsAmt;
						session.Save(tWHNew);
					}
					else
					{
						tWH.Number += tRI.GoodsQty;
						tWH.Amount += tRI.GoodsAmt;
						tWH.LastPrice = tRI.GoodsPrc;
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
		
		
		//修改入库单
		public static void ModifyRKD(Receipt tReceipt,List<ReceiptItems> tItemsList)
		{				
			//修改入库单
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				//得到未变更的入库单
				Receipt tOldReceipt = new Receipt();
				tOldReceipt = BLL.RKBLL.GetReceipt(tReceipt.ReceiptID);
				//如果原应付款不为0，则删除AccountBill表的相关数据，并更新Companies表中的相关数据
				if(tOldReceipt.ReceiptDiscAmt != 0)
				{
					AccountBill tAB = BLL.AccountBillBLL.GetAccountBill(tOldReceipt.ProjectID,tOldReceipt.CompanyID,100,"采购应付款" + tOldReceipt.ReceiptNum);
					if(tAB.BillNo == 0)
					{
						tx.Rollback();
						session.Close();
						MessageBox.Show("没有找到可以删除的入库单生成的应付款记录！请检查数据库！","错误信息",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
						
					}
					AccountBill toDelete = session.Get<AccountBill>(tAB.BillNo);
					session.Delete(toDelete);
				}
				//删除ReceiptItem中的相关项
				List<int> toDelItemsID = BLL.RKBLL.GetItemIDs(tOldReceipt.ReceiptID);
				foreach(int i in toDelItemsID)
				{
					ReceiptItems toDel1 = session.Get<ReceiptItems>(i);
					session.Delete(toDel1);
					//更新库存
					PKModel pk = new PKModel();
					pk.GoodsID = toDel1.GoodsID;
					pk.WareHouseID = tOldReceipt.WareHouseID;
					WareHouseStock tWH = session.Get<WareHouseStock>(pk);
					if(tWH == null)
					{
						WareHouseStock tWHNew = new WareHouseStock();
						tWHNew.Pk = pk;
					
						tWHNew.Number = toDel1.GoodsQty;
						tWHNew.Price = toDel1.GoodsPrc;
						tWHNew.Amount = toDel1.GoodsAmt;
						session.Save(tWHNew);
					}
					else
					{
						tWH.Number -= toDel1.GoodsQty;
						tWH.Amount -= toDel1.GoodsAmt;
						if(tWH.Number != 0)
						{
							tWH.Price = Math.Round(tWH.Amount / tWH.Number,2);
						}
						session.Flush();
					}
				}
				//保存Receipt的修改
				Receipt toModify = session.Get<Receipt>(tOldReceipt.ReceiptID);
				toModify.CompanyID = tReceipt.CompanyID;
				toModify.ProjectID = tReceipt.ProjectID;
				toModify.ReceiptType = tReceipt.ReceiptType;
				toModify.ReceiptBillAmt = tReceipt.ReceiptBillAmt;
				toModify.ReceiptDisc = tReceipt.ReceiptDisc;
				toModify.ReceiptDiscAmt = tReceipt.ReceiptDiscAmt;
				toModify.PurchName = tReceipt.PurchName;
				toModify.ReceiverName = tReceipt.ReceiverName;
				toModify.RecordStatus = "已记账";
				toModify.Remark = tReceipt.Remark;
				toModify.WareHouseID = tReceipt.WareHouseID;		
				
				
				//将新的ReceiptItem加入
				foreach(ReceiptItems tRI in tItemsList)
				{
					tRI.ReceiptID = tReceipt.ReceiptID;
					session.Save(tRI);
					//更新库存
					PKModel pk = new PKModel();
					pk.GoodsID = tRI.GoodsID;
					pk.WareHouseID = tReceipt.WareHouseID;
					WareHouseStock tWH = session.Get<WareHouseStock>(pk);
					if(tWH == null)
					{
						WareHouseStock tWHNew = new WareHouseStock();
						tWHNew.Pk = pk;
					
						tWHNew.Number = tRI.GoodsQty;
						tWHNew.Price = tRI.GoodsPrc;
						tWHNew.Amount = tRI.GoodsAmt;
						session.Save(tWHNew);
					}
					else
					{
						tWH.Number += tRI.GoodsQty;
						tWH.Amount += tRI.GoodsAmt;
						if(tWH.Number != 0)
						{
							tWH.Price = Math.Round(tWH.Amount / tWH.Number,2);
						}
						session.Flush();
					}
				}		
				//根据应付款是否为0添加AccountBill记录及更新Companies表
				if(tReceipt.ReceiptDiscAmt !=0)
				{	
					Projects tP1 = session.Get<Projects>(tReceipt.ProjectID);
					Companies tC1 = session.Get<Companies>(tReceipt.CompanyID);					
					AccountBill tAcc = new AccountBill();					
					tAcc.CompanyID = tReceipt.CompanyID;
					tAcc.CompanyName = tC1.CompanyName;
					tAcc.BillDate = tReceipt.ReceiptDate;
					tAcc.BillMemo = "采购应付款" + tReceipt.ReceiptNum;
					tAcc.BillType = 1;
					tAcc.BillYF = tReceipt.ReceiptDiscAmt;
					tAcc.ProjectID = tReceipt.ProjectID;
					tAcc.ProjectName = tP1.ProjectName;
					tAcc.MoneyTypeID = 100;   //材料购买
					tAcc.MoneyTypeName = "入库单生成";
					tAcc.BillStatus = "已记账";
					session.Save(tAcc);
					
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
		
		//删除入库单
		public static void DelRKD(int i_ReceiptID)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				Receipt toDel1 = session.Get<Receipt>(i_ReceiptID);
				
				//更新未付款
				//如果原应付款不为0，则删除AccountBill表的相关数据，并更新WareHouseStock表中的相关数据
				if(toDel1.ReceiptDiscAmt != 0)
				{
					AccountBill tAB = BLL.AccountBillBLL.GetAccountBill(toDel1.ProjectID,toDel1.CompanyID,100,"采购应付款" + toDel1.ReceiptNum);
					if(tAB.BillNo == 0)
					{
						tx.Rollback();
						session.Close();
						MessageBox.Show("没有找到可以删除的入库单生成的应付款记录！请检查数据库！","错误信息",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
						
					}
					AccountBill toDelete = session.Get<AccountBill>(tAB.BillNo);
					session.Delete(toDelete);

				}
				//删除ReceiptItem中的相关项
				List<int> toDelItemsID = BLL.RKBLL.GetItemIDs(toDel1.ReceiptID);
				foreach(int i in toDelItemsID)
				{
					ReceiptItems toDel2 = session.Get<ReceiptItems>(i);
					session.Delete(toDel2);
					//更新库存
					PKModel pk = new PKModel();
					pk.GoodsID = toDel2.GoodsID;
					pk.WareHouseID = toDel1.WareHouseID;
					WareHouseStock tWH = session.Get<WareHouseStock>(pk);
					if(tWH != null)
					{						
						tWH.Number -= toDel2.GoodsQty;
						tWH.Amount -= toDel2.GoodsAmt;
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
		
		public static void UpdateRKD(int i_ProjectID,int i_CompanyID,string s_RecordStatus,string s_BillCycle,DataGridViewSelectedRowCollection dC)
		{
			decimal dTotal = 0.0M;
			
			foreach (DataGridViewRow row in dC) 
			{ 	
				int i_ReceiptID = Convert.ToInt32(row.Cells["ReceiptID"].Value.ToString());
				string s_ReceiptNum = row.Cells["ReceiptNum"].Value.ToString();
				
				dTotal += Convert.ToDecimal(row.Cells["ReceiptDiscAmt"].Value);
				
				UpdateReceipt(i_ReceiptID,s_RecordStatus,s_BillCycle);
				AccountBill tAB = BLL.AccountBillBLL.GetAccountBill(i_ProjectID,i_CompanyID,100,"采购应付款" + s_ReceiptNum);
				tAB.BillCycle = s_BillCycle;
				tAB.BillStatus = s_RecordStatus;
				BLL.AccountBillBLL.UpdateAccountBill(tAB);
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
				tS.BillYS = 0.0M;
				tS.BillSS = 0.0M;
				tS.BillYF = dTotal;
				tS.BillSF = 0.0M;
				tS.StatementType = "入库结算";
				tS.StatementCycle = s_BillCycle;
				tS.MoneyTypeID = 10000;
				tS.MoneyTypeName = "入库结算自动生成";
				tS.StatementMemo = "结算应付款";
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
		
		public static void UpdateReceipt(int i_ReceiptID,string s_RecordStatus,string s_BillCycle)
		{
			SQLiteHelper.ExecuteNonQuery("UPDATE Receipt SET RecordStatus = @RecordStatus,BillCycle = @BillCycle WHERE ReceiptID = @ReceiptID ",s_RecordStatus,s_BillCycle,i_ReceiptID);
		}
		
		//查询指定ProjectID和CompanyID还没有结算的
		public static DataSet GetReceiptItems(int i_ProjectID,int i_CompanyID,string s_RecordStatus)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ItemsID,ReceiptID,GoodsID,GoodsName,GoodsSpec,MoreSpec,GoodsUnit,GoodsQty,GoodsPrc,GoodsYF,GoodsAmt,UsePosition,GoodsPlan,GoodsPlanNo FROM ReceiptItems WHERE ReceiptID IN (SELECT ReceiptID FROM Receipt WHERE ProjectID=@ProjectID AND CompanyID=@CompanyID AND RecordStatus=@RecordStatus)",i_ProjectID,i_CompanyID,s_RecordStatus);
			return ds;				
		}
		
		public static DataSet GetReceiptItems(string s_ReceiptIDs)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ItemsID,A.ReceiptID,A.GoodsID,A.GoodsName,A.GoodsSpec,A.MoreSpec,A.GoodsUnit,A.GoodsQty,A.GoodsPrc,A.GoodsYF,A.GoodsAmt,A.UsePosition,A.GoodsPlan,A.GoodsPlanNo,B.PurchName,B.ReceiverName,B.ReceiptDate FROM ReceiptItems A,Receipt B WHERE A.ReceiptID = B.ReceiptID AND A.ReceiptID IN (" + s_ReceiptIDs + ") ORDER BY B.ReceiptDate");
			return ds;				
		}
		
		public static DataSet GetReceipt(int i_ProjectID,int i_CompanyID,string s_RecordStatus)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT SUM(A.ReceiptBillAmt) AS SUM_ReceiptBillAmt,SUM(A.ReceiptDiscAmt) AS SUM_ReceiptDiscAmt,A.CompanyID,A.ProjectID,A.BillCycle,B.ProjectName,C.CompanyName FROM Receipt A,Projects B,Companies C WHERE A.ProjectID=B.ProjectID AND A.CompanyID=C.CompanyID AND A.ProjectID=@ProjectID AND A.CompanyID=@CompanyID AND A.RecordStatus = @RecordStatus group by A.ProjectID,A.CompanyID,A.BillCycle order by  A.ProjectID,A.CompanyID,A.BillCycle ",i_ProjectID,i_CompanyID,s_RecordStatus);
			return ds;				
		}
		
		//将月结算单从"已结算"变成 "已记账"
		public static void ReceiptYJReverse(int i_ProjectID,int i_CompanyID,string s_BillCycle)
		{
			SQLiteHelper.ExecuteNonQuery("UPDATE Receipt SET RecordStatus = '已记账',BillCycle = null WHERE ProjectID = @ProjectID AND CompanyID=@CompanyID AND BillCycle=@BillCycle ",i_ProjectID,i_CompanyID,s_BillCycle);
			SQLiteHelper.ExecuteNonQuery("UPDATE AccountBill SET BillStatus = '已记账',BillCycle = null WHERE ProjectID = @ProjectID AND CompanyID=@CompanyID AND BillCycle=@BillCycle ",i_ProjectID,i_CompanyID,s_BillCycle);
			SQLiteHelper.ExecuteNonQuery("DELETE FROM StatementList WHERE ProjectID = @ProjectID AND CompanyID=@CompanyID AND StatementCycle=@BillCycle ",i_ProjectID,i_CompanyID,s_BillCycle);
		}
		
	}
}
