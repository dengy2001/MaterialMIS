/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-21
 * Time: 10:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
	/// Description of LeaseBLL.
	/// </summary>
	public class LeaseBLL
	{
		public LeaseBLL()
		{
		}
		
		//添加租赁合同
		public static  void AddLeaseHT(LeaseHT tLeaseHT)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try {
				session.Save(tLeaseHT);
				tx.Commit();
				session.Close();					
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
				tx.Rollback();
				session.Close();
			}

		}
		
		//添加租赁项余数
		public static  void AddLeaseAccountLeft(LeaseAccountLeft tLeaseAccountLeft)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try {
				session.Save(tLeaseAccountLeft);
				tx.Commit();
				session.Close();					
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
				tx.Rollback();
				session.Close();
			}

		}
		
		// 修改租赁合同
		public static void ModifyLeaseHT(LeaseHT tLeaseHT)
		{
			ISession session = NHibernateHelper.OpenSession();
			try {				
				ITransaction tx = session.BeginTransaction();
				LeaseHT t1 = session.Get<LeaseHT>(tLeaseHT.HTID);
				t1.HTNumber = tLeaseHT.HTNumber;
				t1.HTName = tLeaseHT.HTNumber;
				t1.ProjectID = tLeaseHT.ProjectID;
				t1.CompanyID = tLeaseHT.CompanyID;
				t1.IncludeSDate = tLeaseHT.IncludeSDate;
				t1.IncludeEDate = tLeaseHT.IncludeEDate;
				tx.Commit();
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
			}
			session.Close();
		}
		
		
		//删除租赁合同
		public static void DelLeaseHT(int iHTID)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			LeaseHT toDelete = session.Get<LeaseHT>(iHTID);
			//判断是否有租赁项信息，如果有，不允许删除！！！
			int i_rtn = 0;
			//查询租赁项信息表中是否存在
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM LeaseItems WHERE HTID = @HTID", iHTID));
			if (i_rtn > 0) {
				MessageBox.Show("要删除的租赁合同在租赁项表中有使用，不能删除！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				session.Close();
				return;
			}	
				
			try {
				session.Delete(toDelete);
				tx.Commit();
				session.Close();
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
				tx.Rollback();
				session.Close();
			}
		}
		
		//获取指定项目的租赁合同
		public static DataSet GetProjectLease(int i_ProjectID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.HTID,A.HTNumber,A.CompanyID,B.CompanyName,A.ProjectID,A.HTName,A.IncludeSDate,A.IncludeEDate FROM LeaseHT A,Companies B WHERE A.CompanyID=B.CompanyID AND A.ProjectID=@ProjectID", i_ProjectID);
			return ds;
		}
		
		
		
		//获取指定HTID的LeaseHT
		public static LeaseHT GetLeaseHT(int i_HTID)
		{
			ISession session = NHibernateHelper.OpenSession();
			LeaseHT tClass = new LeaseHT();
			try {
				tClass = session.Get<LeaseHT>(i_HTID);
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
			}
			session.Close();
			return tClass;
		}
		
		//获取指定HTID的LeaseHT
		public static LeaseAccountLeft GetLeaseAccountLeft(int i_HTID, int i_ItemsID)
		{
			int i_ALeftID = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT ALeftID FROM LeaseAccountLeft WHERE HTID = @HTID AND ItemsID=@ItemsID", i_HTID, i_ItemsID));

			ISession session = NHibernateHelper.OpenSession();
			LeaseAccountLeft tClass = new LeaseAccountLeft();
			try {
				tClass = session.Get<LeaseAccountLeft>(i_ALeftID);
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
			}
			session.Close();
			return tClass;
		}
		
		//获取指定ProjectID和CompanyID的LeaseHT
		public static LeaseHT GetLeaseHT(int i_ProjectID, int i_CompanyID)
		{
			int i_HTID = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT HTID FROM LeaseHT WHERE ProjectID = @ProjectID AND CompanyID=@CompanyID", i_ProjectID, i_CompanyID));
			ISession session = NHibernateHelper.OpenSession();
			LeaseHT tClass = new LeaseHT();
			try {
				tClass = session.Get<LeaseHT>(i_HTID);
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
			}
			session.Close();
			return tClass;
		}
		
		//添加租赁项信息
		public static  void AddLeaseItem(LeaseItems tLeaseItem)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try {
				session.Save(tLeaseItem);
				tx.Commit();
				session.Close();					
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
				tx.Rollback();
				session.Close();
			}

		}
		
		//添加租赁记录
		public static  void AddLeaseRecord(LeaseRecord tLeaseRecord)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try {
				session.Save(tLeaseRecord);
				tx.Commit();
				session.Close();					
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
				tx.Rollback();
				session.Close();
			}

		}
		
		// 修改租赁项信息
		public static void ModifyLeaseItem(LeaseItems tLeaseItem)
		{
			ISession session = NHibernateHelper.OpenSession();
			try {				
				ITransaction tx = session.BeginTransaction();
				LeaseItems t1 = session.Get<LeaseItems>(tLeaseItem.ItemsID);
				t1.HTID = tLeaseItem.HTID;
				t1.MName = tLeaseItem.MName;
				t1.LeaseClass = tLeaseItem.LeaseClass;
				t1.LeaseUnit = tLeaseItem.LeaseUnit;
				t1.LeasePrice = tLeaseItem.LeasePrice;
				t1.LoadingUnit = tLeaseItem.LoadingUnit;
				t1.LoadingFactor = tLeaseItem.LoadingFactor;
				t1.LoadingPrice = tLeaseItem.LoadingPrice;
				t1.RepairUnit = tLeaseItem.RepairUnit;
				t1.RepairFactor = tLeaseItem.RepairFactor;
				t1.RepairPrice = tLeaseItem.RepairPrice;
				t1.BalanceDate = tLeaseItem.BalanceDate;
				t1.CurLeaseQuality = tLeaseItem.CurLeaseQuality;

				tx.Commit();
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
			}
			session.Close();
		}
		
		// 修改租赁记录
		public static void ModifyLeaseRecord(LeaseRecord tLeaseRecord)
		{
			ISession session = NHibernateHelper.OpenSession();
			try {				
				ITransaction tx = session.BeginTransaction();
				LeaseRecord t1 = session.Get<LeaseRecord>(tLeaseRecord.RID);
				t1.HTID = tLeaseRecord.HTID;
				t1.ItemsID = tLeaseRecord.ItemsID;
				t1.LeaseDate = tLeaseRecord.LeaseDate;
				t1.BalanceDate = tLeaseRecord.BalanceDate;
				t1.Quality = tLeaseRecord.Quality;
				t1.Handler = tLeaseRecord.Handler;
				t1.Abstract = tLeaseRecord.Abstract;

				tx.Commit();
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
			}
			session.Close();
		}
		
		//删除
		public static void DelLeaseItem(int i_LeaseItem)
		{

			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			LeaseItems toDelete = session.Get<LeaseItems>(i_LeaseItem);			
				
			try {
				session.Delete(toDelete);
				tx.Commit();
				session.Close();
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
				tx.Rollback();
				session.Close();
			}
		}
		
		//删除
		public static void DelLeaseRecord(int i_RID)
		{
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			LeaseRecord toDelete = session.Get<LeaseRecord>(i_RID);			
				
			try {
				if (toDelete.LeaseStatus == "已结算") {
					tx.Rollback();
					session.Close();
					MessageBox.Show("已结算，不能删除！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

					return;
				}
				session.Delete(toDelete);
				tx.Commit();
				session.Close();
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
				tx.Rollback();
				session.Close();
			}
		}
		
		//获取指定的租赁项信息
		public static LeaseItems GetLeaseItem(int i_ItemsID)
		{
			ISession session = NHibernateHelper.OpenSession();
			LeaseItems tClass = new LeaseItems();
			try {
				tClass = session.Get<LeaseItems>(i_ItemsID);
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
			}
			session.Close();
			return tClass;
		}
		
		//获取指定的租赁记录
		public static LeaseRecord GetLeaseRecord(int i_RID)
		{
			ISession session = NHibernateHelper.OpenSession();
			LeaseRecord tClass = new LeaseRecord();
			try {
				tClass = session.Get<LeaseRecord>(i_RID);
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
			}
			session.Close();
			return tClass;
		}
		
		//获取指定租赁合同的租赁项
		public static DataSet GetLeaseItemsByHTID(int i_HTID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ItemsID,HTID,MName,LeaseClass,LeaseUnit,LeasePrice,LoadingUnit,LoadingFactor,LoadingPrice,RepairUnit,RepairFactor,RepairPrice,BalanceDate,CurLeaseQuality FROM LeaseItems WHERE HTID=@HTID", i_HTID);
			return ds;
		}
		
		//检查指定项目的公司是否已经存在相应公司的租赁合同
		public static bool HasHT(int i_ProjectID, int i_CompanyID)
		{
			int i_rtn = 0;
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM LeaseHT WHERE ProjectID = @ProjectID AND CompanyID=@CompanyID", i_ProjectID, i_CompanyID));
			if (i_rtn > 0) {
				MessageBox.Show("要添加的单位已经存在租赁合同！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return true;
			} else {
				return false;
			}
		}
		
		//根据项目及公司取得租赁记录
		public static DataSet GetLeaseRecord1(int i_ProjectID, int i_CompanyID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.RID,A.HTID,A.ItemsID,B.MName,B.LeaseUnit,A.Quality,A.BalanceDate,A.LeaseDate,A.LeaseStatus,A.Abstract,A.Handler FROM LeaseRecord A, LeaseItems B,LeaseHT C WHERE A.ItemsID = B.ItemsID AND A.HTID = C.HTID AND C.ProjectID=@ProjectID AND C.CompanyID=@CompanyID ORDER BY A.LeaseDate,B.ItemsID", i_ProjectID, i_CompanyID);
			return ds;
		}
		
		//根据项目及公司取得租赁记录,未结算的
		public static DataSet GetLeaseRecord2(int i_ProjectID, int i_CompanyID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.RID,A.HTID,A.ItemsID,B.MName,B.LeaseUnit,A.Quality,A.BalanceDate,A.LeaseDate,A.LeaseStatus,A.Abstract,A.Handler FROM LeaseRecord A, LeaseItems B,LeaseHT C WHERE A.LeaseStatus = '未结算' AND A.ItemsID = B.ItemsID AND A.HTID = C.HTID AND C.ProjectID=@ProjectID AND C.CompanyID=@CompanyID ORDER BY A.LeaseDate,B.ItemsID", i_ProjectID, i_CompanyID);
			return ds;
		}
		
		//根据项目及公司取得剩余项目的量
		public static DataSet GetLeaseRemain(int i_ProjectID, int i_CompanyID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ALeftID,A.HTID,A.ItemsID,A.QualityLeft,A.LastBillCycle,A.LastEDate,B.MName,B.LeaseUnit FROM LeaseAccountLeft A, LeaseItems B,LeaseHT C WHERE A.ItemsID = B.ItemsID AND A.HTID = C.HTID AND C.ProjectID=@ProjectID AND C.CompanyID=@CompanyID", i_ProjectID, i_CompanyID);
			return ds;
		}
		
		//获取指定的租赁结算单的租赁结算记录
		public static LeaseAccount GetLeaseAccount(int i_BillID)
		{
			ISession session = NHibernateHelper.OpenSession();
			LeaseAccount tClass = new LeaseAccount();
			try {
				tClass = session.Get<LeaseAccount>(i_BillID);
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
			}
			session.Close();
			return tClass;
		}
		
		//获取指定的租赁结算单的租赁结算记录
		public static DataSet GetLeaseAccountDs(int i_BillID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT BillID,ProjectID,ProjectName,CompanyID,CompanyName,CalMethod,BillAmt,IncludeSDate,IncludeEDate,SDate,EDate,BillCycle,Abstract FROM LeaseAccount WHERE BillID = @BillID", i_BillID);
			return ds;
		}
		
		//获取指定的租赁结算单的租赁结算记录
		public static DataSet GetLeaseAccountDs(int i_ProjectID, int i_CompanyID, string s_BillCycle)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT BillID,ProjectID,ProjectName,CompanyID,CompanyName,CalMethod,BillAmt,IncludeSDate,IncludeEDate,SDate,EDate,BillCycle,Abstract FROM LeaseAccount WHERE ProjectID=@ProjectID AND CompanyID=@CompanyID AND BillCycle = @BillCycle", i_ProjectID, i_CompanyID, s_BillCycle);
			return ds;
		}
		
		//获取指定的租赁结算单的租赁详细记录
		public static DataSet GetLeaseAccountList(int i_BillID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ListID,BillID,SNumber,Abstract,SDate,EDate,LeaseUnit,LeaseQuality,LeasePrice,LeaseDays,LeaseAmt,LoadingUnit,LoadingFactor,LoadingQuality,LoadingPrice,LoadingAmt,RepairUnit,RepairFactor,RepairQuality,RepairPrice,RepairAmt,OtherUnit,OtherQuality,OtherPrice,OtherAmt FROM LeaseAccountList WHERE BillID = @BillID", i_BillID);
			return ds;
		}
		//获取指定的租赁结算单的租赁详细记录
		public static DataSet GetLeaseAccountList(int i_LeaseClass, int i_BillID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ItemsID,ItemsName,LeaseUnit,sum(LeaseQuality) as QualityLeft FROM LeaseAccountList WHERE LeaseClass = @LeaseClass AND BillID = @BillID GROUP BY ItemsID", i_LeaseClass, i_BillID);
			return ds;
		}
		//获取指定租赁合同的剩余租赁项
		public static DataSet GetLeaseAccountLeft(int i_HTID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ALeftID,A.HTID,A.ItemsID,B.MName,B.LeaseUnit,A.QualityLeft,A.LastBillCycle,A.LastEDate FROM LeaseAccountLeft A,LeaseItems B WHERE A.HTID = B.HTID AND A.ItemsID = B.ItemsID AND A.HTID = @HTID ORDER BY A.ItemsID", i_HTID);
			return ds;
		}
		
		//添加租赁结算
		public static void AddNewLeaseJS(int i_ProjectID, int i_CompanyID, string s_BillCycle, DateTime d_SDate, DateTime d_EDate, ToolStripLabel labelStatus)
		{
			labelStatus.Text = "现在开始把数据添加到数据库中...";
			Application.DoEvents();
			string[,] ALeaseAccountLeft = new string[50, 2];	//用于保存当前剩余租赁材料
			
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try {
				int i_SNumber = 1;		//租赁结算顺序号
				
				//1.先添加租赁结算单，以得到BillID
				labelStatus.Text = "现在开始添加租赁结算单...";
				Application.DoEvents();	
				
				Projects tProject = BLL.ProjectsBLL.GetProject(i_ProjectID);
				Companies tCompany = BLL.CompanyBLL.GetCompany(i_CompanyID);
				LeaseHT tLeaseHT = BLL.LeaseBLL.GetLeaseHT(i_ProjectID, i_CompanyID);
				int i_IncludeSDate = tLeaseHT.IncludeSDate;		//租金包含开始日
				int i_IncludeEDate = tLeaseHT.IncludeEDate;		//租金包含结束日
				string s_CalMethod = "";		//计算方式
				if (i_IncludeSDate == 0 && i_IncludeEDate == 0) {
					s_CalMethod = "倒扣计算法，头尾都不算";
				}
				if (i_IncludeSDate == 1 && i_IncludeEDate == 0) {
					s_CalMethod = "倒扣计算法，算头不算尾";
				}
				if (i_IncludeSDate == 1 && i_IncludeEDate == 1) {
					s_CalMethod = "倒扣计算法，既算头又算尾";
				}
				if (i_IncludeSDate == 0 && i_IncludeEDate == 1) {
					s_CalMethod = "倒扣计算法，算尾不算头";
				}
				TimeSpan tTS = d_EDate.Subtract(d_SDate);
				int i_Days = tTS.Days + 1;		//结余时租赁天数
			
				LeaseAccount newLeaseAccount = new LeaseAccount();
				newLeaseAccount.ProjectID = i_ProjectID;
				newLeaseAccount.CompanyID = i_CompanyID;
				newLeaseAccount.BillCycle = s_BillCycle;
				newLeaseAccount.SDate = d_SDate;
				newLeaseAccount.EDate = d_EDate;		
				newLeaseAccount.CalMethod = s_CalMethod;
				newLeaseAccount.ProjectName = tProject.ProjectName;
				newLeaseAccount.CompanyName = tCompany.CompanyName;
				newLeaseAccount.IncludeSDate = i_IncludeSDate;
				newLeaseAccount.IncludeEDate = i_IncludeEDate;
				session.Save(newLeaseAccount);
				
				StatementList newStatementList = new StatementList();
				newStatementList.ProjectID = i_ProjectID;
				newStatementList.ProjectName = tProject.ProjectName;
				newStatementList.CompanyID = i_CompanyID;
				newStatementList.CompanyName = tCompany.CompanyName;
				newStatementList.MoneyTypeID = 10000;
				newStatementList.MoneyTypeName = "租赁结算自动生成";
				newStatementList.StatementType = "租赁结算";
				newStatementList.StatementMemo = "应付租金";
				newStatementList.StatementCycle = s_BillCycle;
				newStatementList.StatementDate = DateTime.Now.Date;
				session.Save(newStatementList);
				
				decimal d_BillAmt = 0.0m;
				//2.添加租赁明细单，并计算金额合计，以便完成后填写到LeaseAccount表记录中
				//把保存剩余租赁量的数组数据填好，全部是字符串
				DataSet dsTmp = BLL.LeaseBLL.GetLeaseAccountLeft(tLeaseHT.HTID);
				foreach (DataRow dr in dsTmp.Tables[0].Rows) {
					string s_0 = dr["ItemsID"].ToString();
					string s_1 = dr["QualityLeft"].ToString();
					
					for (int j = 0; j < ALeaseAccountLeft.GetLength(0); j++) {						
						string s0 = ALeaseAccountLeft[j, 0];
						string s1 = ALeaseAccountLeft[j, 1];
						if (ALeaseAccountLeft[j, 0] == null) {
							ALeaseAccountLeft[j, 0] = s_0;
							ALeaseAccountLeft[j, 1] = s_1;
							break;
						}						
					}
				}
				//2.1添加结余租赁明细项目
				dsTmp = BLL.LeaseBLL.GetLeaseItemsByHTID(tLeaseHT.HTID);
				foreach (DataRow dr in dsTmp.Tables[0].Rows) {
					LeaseAccountList newLeaseAccountList = new LeaseAccountList();
					int i_ItemsID = Convert.ToInt32(dr["ItemsID"]);
					LeaseItems tLeaseItem = BLL.LeaseBLL.GetLeaseItem(i_ItemsID);
					LeaseAccountLeft tLeaseAccountLeft = BLL.LeaseBLL.GetLeaseAccountLeft(tLeaseHT.HTID, i_ItemsID);
					if (tLeaseAccountLeft == null) {
						continue;
					}
					newLeaseAccountList.SNumber = i_SNumber;
					newLeaseAccountList.BillID = newLeaseAccount.BillID;
					newLeaseAccountList.ItemsID = tLeaseItem.ItemsID;
					newLeaseAccountList.ItemsName = tLeaseItem.MName;
					newLeaseAccountList.LeaseClass = 3; //将结余类重设
					newLeaseAccountList.Abstract = tLeaseItem.MName + " 上期结余";
					newLeaseAccountList.SDate = d_SDate;
					newLeaseAccountList.EDate = d_EDate;
					newLeaseAccountList.LeaseUnit = tLeaseItem.LeaseUnit;
					newLeaseAccountList.LeaseQuality = tLeaseAccountLeft.QualityLeft;
					newLeaseAccountList.LeasePrice = tLeaseItem.LeasePrice;
					newLeaseAccountList.LeaseDays = i_Days;
					newLeaseAccountList.LeaseAmt = newLeaseAccountList.LeaseQuality * newLeaseAccountList.LeasePrice * i_Days;
					
					d_BillAmt += newLeaseAccountList.LeaseAmt;
					
					session.Save(newLeaseAccountList);
					
					i_SNumber++;
				}
				//2.2按照未结算租赁记录添加租赁结算明细项
				dsTmp = BLL.LeaseBLL.GetLeaseRecord2(i_ProjectID, i_CompanyID);	//未结算的记录
				foreach (DataRow dr in dsTmp.Tables[0].Rows) {
					//检查租赁日期是否在结算日期范围
					int i_RID = Convert.ToInt32(dr["RID"]);
					LeaseRecord tLeaseRecord = session.Get<LeaseRecord>(i_RID);
					
					if (tLeaseRecord.LeaseDate >= d_SDate && tLeaseRecord.LeaseDate <= d_EDate) {
						LeaseAccountList newLeaseAccountList = new LeaseAccountList();
						int i_ItemsID = tLeaseRecord.ItemsID;
						LeaseItems tLeaseItem = session.Get<LeaseItems>(i_ItemsID);	

						
						newLeaseAccountList.SNumber = i_SNumber;
						newLeaseAccountList.BillID = newLeaseAccount.BillID;
						newLeaseAccountList.ItemsID = tLeaseItem.ItemsID;
						newLeaseAccountList.ItemsName = tLeaseItem.MName;
						newLeaseAccountList.LeaseClass = tLeaseItem.LeaseClass;
						if (tLeaseRecord.Abstract.ToString().Length != 0) {
							newLeaseAccountList.Abstract = tLeaseItem.MName + "(" + tLeaseRecord.Abstract + ")";
						} else {
							newLeaseAccountList.Abstract = tLeaseItem.MName;
						}
						DateTime dt1 = tLeaseRecord.LeaseDate;
						newLeaseAccountList.SDate = dt1;
						newLeaseAccountList.EDate = d_EDate;
						TimeSpan tTS1 = d_EDate.Subtract(dt1);
						int tDays = tTS1.Days;						
						if (tLeaseRecord.Quality > 0) {
							if (i_IncludeSDate == 1) {
								tDays++;
							}
						} else {
							if (i_IncludeEDate != 1) {
								tDays++;
							}
						}	
						if (tLeaseItem.LeaseClass == 0) {
							//租赁项
							newLeaseAccountList.LeaseUnit = tLeaseItem.LeaseUnit;
							newLeaseAccountList.LeaseQuality = tLeaseRecord.Quality;
							newLeaseAccountList.LeasePrice = tLeaseItem.LeasePrice;
							newLeaseAccountList.LeaseDays = tDays;
							newLeaseAccountList.LeaseAmt = newLeaseAccountList.LeaseQuality * newLeaseAccountList.LeasePrice * tDays;
							
							d_BillAmt += newLeaseAccountList.LeaseAmt;
							
							newLeaseAccountList.LoadingUnit = tLeaseItem.LoadingUnit;
							newLeaseAccountList.LoadingFactor = Convert.ToDecimal(tLeaseItem.LoadingFactor);
							newLeaseAccountList.LoadingQuality = Math.Abs(newLeaseAccountList.LeaseQuality / newLeaseAccountList.LoadingFactor);
							newLeaseAccountList.LoadingPrice = Convert.ToDecimal(tLeaseItem.LoadingPrice);
							newLeaseAccountList.LoadingAmt = Math.Abs(newLeaseAccountList.LoadingPrice * newLeaseAccountList.LoadingQuality);
							
							d_BillAmt += newLeaseAccountList.LoadingAmt;
							
							if (tLeaseRecord.Quality < 0) {
								newLeaseAccountList.RepairUnit = tLeaseItem.RepairUnit;
								newLeaseAccountList.RepairFactor = Convert.ToDecimal(tLeaseItem.RepairFactor);
								newLeaseAccountList.RepairQuality = Math.Abs(newLeaseAccountList.LeaseQuality / newLeaseAccountList.RepairFactor);
								newLeaseAccountList.RepairPrice = Convert.ToDecimal(tLeaseItem.RepairPrice);
								newLeaseAccountList.RepairAmt = Math.Abs(newLeaseAccountList.RepairPrice * newLeaseAccountList.RepairQuality);
								d_BillAmt += newLeaseAccountList.RepairAmt;
							}
							
							//检查此租赁项是否存在，存在则更新LeaseAccountLeft,否则添加
							string s_0 = tLeaseItem.ItemsID.ToString();
							string s_1 = newLeaseAccountList.LeaseQuality.ToString();						
							for (int j = 0; j < ALeaseAccountLeft.GetLength(0); j++) {
								if (ALeaseAccountLeft[j, 0] == null) {
									ALeaseAccountLeft[j, 0] = s_0;
									ALeaseAccountLeft[j, 1] = s_1;
									break;
								} else {
									if (ALeaseAccountLeft[j, 0] == s_0) {
										//找到了
										decimal d1 = Convert.ToDecimal(s_1) + Convert.ToDecimal(ALeaseAccountLeft[j, 1]);
										ALeaseAccountLeft[j, 1] = d1.ToString();
										break;
									}
									//继续找
								}
							}
						} else {
							//单独结算项
							newLeaseAccountList.LeaseUnit = tLeaseItem.LeaseUnit;
							newLeaseAccountList.OtherUnit = tLeaseItem.LeaseUnit;
							newLeaseAccountList.OtherQuality = tLeaseRecord.Quality;
							newLeaseAccountList.OtherPrice = tLeaseItem.LeasePrice;
							newLeaseAccountList.OtherAmt = newLeaseAccountList.OtherPrice * newLeaseAccountList.OtherQuality;
							d_BillAmt += newLeaseAccountList.OtherAmt;
						}
						
						tLeaseRecord.LeaseStatus = "已结算";
						tLeaseRecord.BalanceDate = DateTime.Now.Date;
						session.Update(tLeaseRecord);
						session.Save(newLeaseAccountList);				
	
						
						i_SNumber++;
					}
					
				}
				
				newLeaseAccount.BillAmt = Convert.ToDecimal(d_BillAmt);
				newStatementList.BillYF = Convert.ToDecimal(d_BillAmt);
				//把LeaseAccountLeft更新
				for (int j = 0; j < ALeaseAccountLeft.GetLength(0); j++) {
					if (ALeaseAccountLeft[j, 0] != null) {
						int iItem = Convert.ToInt32(ALeaseAccountLeft[j, 0]);
						LeaseAccountLeft tLeaseAccountLeft = BLL.LeaseBLL.GetLeaseAccountLeft(tLeaseHT.HTID, iItem);
						if (tLeaseAccountLeft == null) {
							tLeaseAccountLeft = new LeaseAccountLeft();
							tLeaseAccountLeft.HTID = tLeaseHT.HTID;
							tLeaseAccountLeft.ItemsID = iItem;
							tLeaseAccountLeft.QualityLeft = Convert.ToDecimal(ALeaseAccountLeft[j, 1]);
							tLeaseAccountLeft.LastBillCycle = newLeaseAccount.BillCycle;
							tLeaseAccountLeft.LastEDate = DateTime.Now.Date;
							session.Save(tLeaseAccountLeft);
						} else {
							tLeaseAccountLeft.QualityLeft = Convert.ToDecimal(ALeaseAccountLeft[j, 1]);
							tLeaseAccountLeft.LastBillCycle = newLeaseAccount.BillCycle;
							tLeaseAccountLeft.LastEDate = DateTime.Now.Date;
							session.Update(tLeaseAccountLeft);
						}
					} else {
						break;
					}
				}
				tx.Commit();
				session.Close();				
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
				tx.Rollback();
				session.Close();
			}
			labelStatus.Text = "就绪";
		}
		
		
		//查询是否已经结算过了
		public static int GetLeaseJSLine(int i_ProjectID, int i_CompanyID, string s_BillCycle)
		{
			int i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM LeaseAccount WHERE ProjectID = @ProjectID AND CompanyID = @CompanyID AND BillCycle = @BillCycle", i_ProjectID, i_CompanyID, s_BillCycle));
			return i_rtn;
		}
		
		//查询是否已经还要结算时间段前的租赁记录未结算
		public static int GetLeaseRecord(int i_HTID, DateTime d_1)
		{
			int i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM LeaseRecord WHERE LeaseStatus = '未结算' AND HTID = @HTID AND LeaseDate < @Date1", i_HTID, d_1));
			return i_rtn;
		}
		
		//删除租赁结算
		public static void DelLeaseAccount(int i_ProjectID, int i_CompanyID, string s_BillCycle)
		{			
			//1.检查是否是最后的结算周期
			int i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM LeaseAccount WHERE ProjectID=@ProjectID AND CompanyID = @CompanyID AND BillCycle > @BillCycle", i_ProjectID, i_CompanyID, s_BillCycle));
			if (i_rtn > 0) {
				return;
			}
			string[,] ALeaseAccountLeft = new string[50, 2];	//用于保存当前剩余租赁材料
			int i_BillID = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT BillID FROM LeaseAccount WHERE ProjectID=@ProjectID AND CompanyID = @CompanyID AND BillCycle = @BillCycle", i_ProjectID, i_CompanyID, s_BillCycle));
			int i_SID = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT SID FROM StatementList WHERE ProjectID=@ProjectID AND CompanyID = @CompanyID AND StatementCycle = @StatementCycle", i_ProjectID, i_CompanyID, s_BillCycle));
			string s_LastMaxBillCycle = "";		//删除周期前的最大周期
			s_LastMaxBillCycle = SQLiteHelper.ExecuteScalar("SELECT MAX(BillCycle) FROM LeaseAccount WHERE BillCycle < @BillCycle",s_BillCycle).ToString();
			
			LeaseHT tLeaseHT = BLL.LeaseBLL.GetLeaseHT(i_ProjectID, i_CompanyID);
			//把保存剩余租赁量的数组数据填好，全部是字符串
			DataSet dsTmp = BLL.LeaseBLL.GetLeaseAccountLeft(tLeaseHT.HTID);
			foreach (DataRow dr in dsTmp.Tables[0].Rows) {
				string s_0 = dr["ItemsID"].ToString();
				string s_1 = dr["QualityLeft"].ToString();
				
				for (int j = 0; j < ALeaseAccountLeft.GetLength(0); j++) {						
					string s0 = ALeaseAccountLeft[j, 0];
					string s1 = ALeaseAccountLeft[j, 1];
					if (ALeaseAccountLeft[j, 0] == null) {
						ALeaseAccountLeft[j, 0] = s_0;
						ALeaseAccountLeft[j, 1] = s_1;
						break;
					}						
				}
			}		
			
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try {
				//2.删除LeaseAccountList
				dsTmp = BLL.LeaseBLL.GetLeaseAccountList(i_BillID);
				foreach (DataRow dr in dsTmp.Tables[0].Rows) {
					LeaseAccountList tLeaseAccountList = session.Get<LeaseAccountList>(Convert.ToInt32(dr["ListID"]));
					if (tLeaseAccountList.LeaseClass != 0) {
						session.Delete(tLeaseAccountList);	//删除
						continue;
					}
					
					//检查此租赁项是否存在，存在则更新LeaseAccountLeft,否则添加
					string s_0 = tLeaseAccountList.ItemsID.ToString();
					string s_1 = tLeaseAccountList.LeaseQuality.ToString();						
					for (int j = 0; j < ALeaseAccountLeft.GetLength(0); j++) {
						if (ALeaseAccountLeft[j, 0] == null) {
							ALeaseAccountLeft[j, 0] = s_0;
							ALeaseAccountLeft[j, 1] = s_1;
							break;
						} else {
							if (ALeaseAccountLeft[j, 0] == s_0) {
								//找到了
								decimal d1 = -Convert.ToDecimal(s_1) + Convert.ToDecimal(ALeaseAccountLeft[j, 1]);
								ALeaseAccountLeft[j, 1] = d1.ToString();
								break;
							}
							//继续找
						}
					}    
					session.Delete(tLeaseAccountList);	//删除					
				}
				
				//3.改LeaseAccountLeft
				for (int j = 0; j < ALeaseAccountLeft.GetLength(0); j++) {
					if (ALeaseAccountLeft[j, 0] != null) {
						int iItem = Convert.ToInt32(ALeaseAccountLeft[j, 0]);
						LeaseAccountLeft tLeaseAccountLeft = BLL.LeaseBLL.GetLeaseAccountLeft(tLeaseHT.HTID, iItem);
						if (tLeaseAccountLeft == null) {
							tLeaseAccountLeft = new LeaseAccountLeft();
							tLeaseAccountLeft.HTID = tLeaseHT.HTID;
							tLeaseAccountLeft.ItemsID = iItem;
							tLeaseAccountLeft.QualityLeft = Convert.ToDecimal(ALeaseAccountLeft[j, 1]);
							tLeaseAccountLeft.LastBillCycle = s_LastMaxBillCycle;
							tLeaseAccountLeft.LastEDate = DateTime.Now.Date;
							session.Save(tLeaseAccountLeft);
						} else {
							tLeaseAccountLeft.QualityLeft = Convert.ToDecimal(ALeaseAccountLeft[j, 1]);
							tLeaseAccountLeft.LastBillCycle = s_LastMaxBillCycle;
							tLeaseAccountLeft.LastEDate = DateTime.Now.Date;
							session.Update(tLeaseAccountLeft);
						}
					} else {
						break;
					}
				}
				
				tx.Commit();
				session.Close();
			} catch (Exception e) {
				Debug.Assert(false, e.Message);
				tx.Rollback();
				session.Close();
			}
			//4.删除LeaseAccount
			SQLiteHelper.ExecuteNonQuery("DELETE FROM LeaseAccount WHERE BillID=@BillID", i_BillID);
			//5.删除StatementList
			SQLiteHelper.ExecuteNonQuery("DELETE FROM StatementList WHERE SID=@SID", i_SID);
			//6.更新LeaseRecord表对应周期的结算状态为“未结算”
			DateTime dt1 = new DateTime(Convert.ToInt32(s_BillCycle.Substring(0,4)),Convert.ToInt32(s_BillCycle.Substring(4,2)),1);

			DateTime dt2 = dt1.AddMonths(1).AddDays(-1 * (dt1.Day));

			SQLiteHelper.ExecuteNonQuery("UPDATE LeaseRecord SET LeaseStatus = '未结算' WHERE LeaseDate BETWEEN @SDate AND @EDate", dt1,dt2);
			
			return;
		}
		
	}
}
