/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-03
 * 时间: 16:14
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
	/// Description of AccountBillBLL.
	/// </summary>
	public class AccountBillBLL
	{
		public AccountBillBLL()
		{
		}
		
		//新增
		public static void AddAccountBill(AccountBill tp)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				session.Save(tp);
				//将数据级联更新到Companies.CurAmt				
				Companies tC = session.Get<Companies>(tp.CompanyID);
				if(tp.BillType == 0)
				{
					//未收款，客户
					//tC.CurAmt = tC.CurAmt + tp.BillYS - tp.BillSS;
				}
				else
				{
					//未付款，供应商
					//tC.CurAmt = tC.CurAmt + tp.BillYF - tp.BillSF;
				}
				
				session.Save(tC);
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
		public static void UpdateAccountBill(AccountBill tp)
		{
			ISession session = NHibernateHelper.OpenSession();
			try
			{				
				ITransaction tx = session.BeginTransaction();
				AccountBill t1 = session.Get<AccountBill>(tp.BillNo);				
				
				//将数据级联更新到Companies.CurAmt				
				Companies tC = session.Get<Companies>(tp.CompanyID);
				if(tp.BillType == 0)
				{
					//未收款，客户
					//tC.CurAmt = tC.CurAmt + (t1.BillYS - tp.BillYS) - (t1.BillSS - tp.BillSS);
				}
				else
				{
					//未付款，供应商
					//tC.CurAmt = tC.CurAmt + (t1.BillYF - tp.BillYF) - (t1.BillSF - tp.BillSF);
				}
				session.Save(tC);
				
				t1.ProjectID = tp.ProjectID;
				t1.CompanyID = tp.CompanyID;
				t1.CompanyName = tp.CompanyName;
				t1.MoneyTypeID = tp.MoneyTypeID;
				t1.BillType = tp.BillType;
				t1.BillMemo = tp.BillMemo;
				t1.BillYS = tp.BillYS;
				t1.BillSS = tp.BillSS;
				t1.BillYF = tp.BillYF;
				t1.BillSF = tp.BillSF;
				t1.BillDate = tp.BillDate;
				t1.BillCycle = tp.BillCycle;
				t1.BillStatus = tp.BillStatus;
				tx.Commit();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
		}		
		
		//删除
		public static void DelAccountBill(int  iBillNo)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			AccountBill toDelete = session.Get<AccountBill>(iBillNo);
				
			try
			{
				session.Delete(toDelete);
				//将数据级联更新到Companies.CurAmt				
				Companies tC = session.Get<Companies>(toDelete.CompanyID);
				if(toDelete.BillType == 0)
				{
					//未收款，客户
					//tC.CurAmt = tC.CurAmt  - toDelete.BillYS + toDelete.BillSS;
				}
				else
				{
					//未付款，供应商
					//tC.CurAmt = tC.CurAmt - toDelete.BillYF + toDelete.BillSF;
				}
				session.Save(tC);
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
		
		//获得全部的AccountBill
		public static DataSet GetAllAccountBill()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT BillNo,ProjectID,CompanyID,MoneyTypeID,BillType,BillMemo,BillYS,BillSS,BillYF,BillSF,BillDate FROM AccountBill");
			return ds;				
		}
		
		//获得全部的AccountBill
		public static DataSet GetAllAccountBillSK()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.BillNo,A.ProjectID,A.CompanyID,B.CompanyName,B.InitAmt,A.MoneyTypeID,A.BillType,A.BillMemo,A.BillYS,A.BillSS,A.BillYF,A.BillSF,A.BillDate FROM AccountBill A,Companies B WHERE A.CompanyID = B.CompanyID AND A.BillType = 0");
			return ds;				
		}
		
		//获得全部的AccountBill
		public static DataSet GetAllAccountBillFK()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.BillNo,A.ProjectID,A.CompanyID,B.CompanyName,B.InitAmt,A.MoneyTypeID,A.BillType,A.BillMemo,A.BillYS,A.BillSS,A.BillYF,A.BillSF,A.BillDate FROM AccountBill A,Companies B WHERE A.CompanyID = B.CompanyID AND A.BillType = 1");
			return ds;				
		}
		
		//获取指定ProjectID,CompanyID,MoneyTypeID,BillMemo的AccountBill
		public static AccountBill GetAccountBill(int i_ProjectID,int i_CompanyID,int i_MoneyTypeID,string s_BillMemo)
		{
			DataSet ds = new DataSet();
			AccountBill tR = new AccountBill();
			
			object[] myParams={i_ProjectID,i_CompanyID,i_MoneyTypeID,s_BillMemo};
			ds = SQLiteHelper.ExecuteDataSet("SELECT BillNo,ProjectID,CompanyID,CompanyName,MoneyTypeID,BillType,BillMemo,BillYS,BillSS,BillYF,BillSF,BillDate,BillCycle,BillStatus FROM AccountBill WHERE ProjectID = @ProjectID AND CompanyID = @CompanyID AND MoneyTypeID=@MoneyType AND BillMemo = @BillMemo",myParams);

			foreach(DataRow mDr in ds.Tables[0].Rows )
			{
				tR.BillNo = Convert.ToInt32(mDr["BillNo"].ToString());
				tR.ProjectID = Convert.ToInt32(mDr["ProjectID"].ToString());
				tR.CompanyID = Convert.ToInt32(mDr["CompanyID"].ToString());
				tR.CompanyName = mDr["CompanyName"].ToString();
				tR.MoneyTypeID = Convert.ToInt32(mDr["MoneyTypeID"].ToString());
				tR.BillType = Convert.ToInt32(mDr["BillType"].ToString());
				tR.BillMemo = mDr["BillMemo"].ToString();
				tR.BillYS = Convert.ToDecimal(mDr["BillYS"].ToString());
				tR.BillSS = Convert.ToDecimal(mDr["BillSS"].ToString());
				tR.BillYF = Convert.ToDecimal(mDr["BillYF"].ToString());
				tR.BillSF = Convert.ToDecimal(mDr["BillSF"].ToString());
				tR.BillDate = Convert.ToDateTime(mDr["BillDate"].ToString());	
				tR.BillCycle = mDr["BillCycle"].ToString();
				tR.BillStatus = mDr["BillStatus"].ToString();
				
			}
			return tR;
		}
				
		
	}
}
