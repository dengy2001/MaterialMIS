/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-08-11
 * 时间: 10:34
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
	/// Description of SupplierBLL.
	/// </summary>
	public class SupplierBLL
	{
		public SupplierBLL()
		{
		}
		
		//添加新供应商
		public static void AddSupplier(Supplier tNew)
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
		
		
		//修改
		public static void UpdateSupplier(Supplier tNew)
		{
			ISession session = NHibernateHelper.OpenSession();
			try
			{				
				ITransaction tx = session.BeginTransaction();
				Supplier tModify = session.Get<Supplier>(tNew.SupplierID);
				tModify.SupplierName = tNew.SupplierName;
				tModify.SupplierSKName = tNew.SupplierSKName;
				tModify.SupplierSKAccount = tNew.SupplierSKAccount;
				tModify.SupplierSKBank = tNew.SupplierSKBank;
				tModify.SupplierLeader = tNew.SupplierLeader;
				tx.Commit();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
		}
		
		//指定的供应商能删除？
		private static bool CanDelSupplier(int iSupplierID)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			int i_rtn = 0;
			
			
			//查询，在ProjectSupplier表中是否有
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM ProjectSupplier WHERE SupplierID = @SuppierID",iSupplierID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的供货商在项目供应商表中存在，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			
			session.Close();
			return true;
		}
		
		
		//删除
		public static void DelSupplier(int  iSupplierID)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			Supplier toDelete = session.Get<Supplier>(iSupplierID);
				
			try
			{
				if(!CanDelSupplier(iSupplierID))
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
		
		
		//查询全部Supplier,用SQL直接获取
		public static DataSet GetAllSupplier()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT SupplierID,SupplierName,SupplierSKName,SupplierSKAccount,SupplierSKBank,SupplierLeader FROM Supplier");
			return ds;				
		}
		
		//查询全部ProjectSupplier,用SQL直接获取
		public static DataSet GetProjectSupplier(int i_ProjectID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ProjectID,A.SupplierID,B.SupplierName FROM ProjectSupplier A,Supplier B WHERE A.SupplierID=B.SupplierID AND A.ProjectID=@i_ProjectID",i_ProjectID);
			return ds;				
		}
		
		//获取指定SupplierID的Supplier
		public static Supplier GetSupplier(int i_SupplierID)
		{
			ISession session = NHibernateHelper.OpenSession();
			Supplier tClass = new Supplier();
			try
			{
				tClass = session.Get<Supplier>(i_SupplierID);
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
			return tClass;
		}
		
		//加入项目供应商
		public static void AddProjectSupplier(ProjectSupplier tNew)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				if(!CanAddProjectSupplier(tNew))
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
		
		//移除项目供应商
		public static void RemoveProjectSupplier(ProjectSupplier tNew)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			ProjectSupplier toDelete = session.Get<ProjectSupplier>(tNew.Ps);
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
		
		//指定的ProjectSupplier需要添加吗？
		private static bool CanAddProjectSupplier(ProjectSupplier tNew)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			int i_rtn = 0;
			
			
			//查询，在ProjectSupplier表中是否有
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM ProjectSupplier WHERE SupplierID = @SuppierID AND ProjectID=@ProjectID",tNew.Ps.SupplierID,tNew.Ps.ProjectID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要添加的供货商在项目供应商表中存在，不需要添加！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			
			session.Close();
			return true;
		}
	}
}
