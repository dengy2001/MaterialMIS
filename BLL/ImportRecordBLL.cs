/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-20
 * 时间: 15:16
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
	/// Description of ImportRecordBLL.
	/// </summary>
	public partial class ImportRecordBLL : UserControl
	{
		public ImportRecordBLL()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		//添加
		public static void AddImportRecord(ImportRecord tp)
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
		public static void UpdateImportRecord(ImportRecord tp)
		{
			ISession session = NHibernateHelper.OpenSession();
			try
			{				
				ITransaction tx = session.BeginTransaction();
				ImportRecord t1 = session.Get<ImportRecord>(tp.ID);
				t1.PurchDateTime = tp.PurchDateTime;
				t1.MName = tp.MName;
				t1.MSpec = tp.MSpec;
				t1.Unit = tp.Unit;
				t1.Number = tp.Number;
				t1.Price = tp.Price;
				t1.SubAmount = tp.SubAmount;
				t1.DCost = tp.DCost;
				t1.Amount = tp.Amount;
				t1.UseSite = tp.UseSite;
				t1.Planner = tp.Planner;
				t1.PlanNo = tp.PlanNo;
				t1.PurchMan = tp.PurchMan;
				t1.Consignee = tp.Consignee;
				t1.ReceiptNo = tp.ReceiptNo;
				t1.Abstract = tp.Abstract;
				t1.SupplierName = tp.SupplierName;
				t1.ProjectName = tp.ProjectName;
				t1.ImportDateTime = tp.ImportDateTime;
				
				tx.Commit();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
		}
		
		//删除
		public static void DelImportRecord(int  iID)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			ImportRecord toDelete = session.Get<ImportRecord>(iID);	
				
			try
			{
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
		
		//查询全部,用SQL直接获取
		public static DataSet GetAllImportRecord()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ID,PurchDateTime,MName,MSpec,Unit,Number,Price,SubAmount,DCost,Amount,UseSite,Planner,PlanNo,PurchMan,Consignee,ReceiptNo,Abstract,SupplierName,ProjectName,ImportDateTime FROM ImportRecord ORDER BY ID");
			return ds;
		}
		
		//查询指定部分记录,用SQL直接获取
		public static DataSet GetImportRecords(int s,int number)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ID,PurchDateTime,MName,MSpec,Unit,Number,Price,SubAmount,DCost,Amount,UseSite,Planner,PlanNo,PurchMan,Consignee,ReceiptNo,Abstract,SupplierName,ProjectName,ImportDateTime FROM ImportRecord ORDER BY ID" + " LIMIT " + s.ToString() + "," + number.ToString());
			return ds;
		}
		
		//查询记录数
		public static int GetImportRecordCount()
		{
			int i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM ImportRecord"));
			return i_rtn;
		}
		
				
		
	}
}
