/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-08-19
 * 时间: 23:53
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
	/// Description of CommMatreialRecordBLL.
	/// </summary>
	public class CommMatreialRecordBLL
	{
		public CommMatreialRecordBLL()
		{
		}
		
		//添加新材料记录
		public static void AddRecord(CommMaterialRecord tNew)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
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
		
		//查询指定ProjectID和SupplierID和BillCycle的CommMaterialRecord,用SQL直接获取
		public static DataSet GetCommMaterialRecord(int i_ProjectID,int i_SupplierID,string s_BillCycle)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT CommRecordID,ProjectID,SupplierID,PurchaseDate,MaterialName,MaterialSpec,MaterialUnit,MaterialNumber,Materialprice,MaterialShipment,MaterialAmt,ForUsePosition,MaterialPlan,MaterialPlanNo,PurchName,ReceiverName,ReceiveNo,Brief,BillCycle,RecordState FROM CommMaterialRecord WHERE ProjectID=@i_ProjectID AND SupplierID=@i_SupplierID AND BillCycle=@s_BillCycle",i_ProjectID,i_SupplierID,s_BillCycle);
			return ds;				
		}
		
		//查询到指定的BillCycle
		public static DataSet GetBillCycles(int i_ProjectID,int i_SupplierID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT DISTINCT(BillCycle) AS BillCycles FROM CommMaterialRecord WHERE ProjectID=@i_ProjectID AND SupplierID=@i_SupplierID",i_ProjectID,i_SupplierID);
			return ds;	
		}
		
		//删除
		public static void DelCommRecordID(int  iCommRecordID)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			CommMaterialRecord toDelete = session.Get<CommMaterialRecord>(iCommRecordID);
				
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
		
		//修改
		public static void UpdateCommRecord(CommMaterialRecord tNew)
		{
			ISession session = NHibernateHelper.OpenSession();
			try
			{				
				ITransaction tx = session.BeginTransaction();
				CommMaterialRecord tModify = session.Get<CommMaterialRecord>(tNew.CommRecordID);
				tModify.BillCycle = tNew.BillCycle;
				tModify.Brief = tNew.Brief;
				tModify.ForUsePosition = tNew.ForUsePosition;
				tModify.MaterialAmt = tNew.MaterialAmt;
				tModify.MaterialName = tNew.MaterialName;
				tModify.MaterialNumber = tNew.MaterialNumber;
				tModify.MaterialPlan = tNew.MaterialPlan;
				tModify.MaterialPlanNo = tNew.MaterialPlanNo;
				tModify.MaterialPrice = tNew.MaterialPrice;
				tModify.MaterialShipment = tNew.MaterialShipment;
				tModify.MaterialSpec = tNew.MaterialSpec;
				tModify.MaterialUnit = tNew.MaterialUnit;
				tModify.ProjectID = tNew.ProjectID;
				tModify.PurchaseDate = tNew.PurchaseDate;
				tModify.PurchName = tNew.PurchName;
				tModify.CompanyID = tNew.CompanyID;
				tModify.ReceiveNo = tNew.ReceiveNo;
				tModify.ReceiverName = tNew.ReceiverName;
				tModify.RecordState = tNew.RecordState;
				tx.Commit();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
		}
		
		//获取指定CommRecordID
		public static CommMaterialRecord GetCommMaterialRecordID(int i_CommRecordID)
		{
			ISession session = NHibernateHelper.OpenSession();
			CommMaterialRecord tClass = new CommMaterialRecord();
			try
			{
				tClass = session.Get<CommMaterialRecord>(i_CommRecordID);
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
			return tClass;
		}
	}
}
