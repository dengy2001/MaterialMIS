/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-05-31
 * 时间: 13:54
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
	/// Description of ProjectsBLL.
	/// </summary>
	public class ProjectsBLL
	{
		public ProjectsBLL()
		{
		}
		
		//添加项目
		public static void AddProjects(Projects tp)
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
		
		
		//修改项目
		public static void UpdateProjects(Projects tp)
		{
			ISession session = NHibernateHelper.OpenSession();
			try
			{				
				ITransaction tx = session.BeginTransaction();
				Projects tProject = session.Get<Projects>(tp.ProjectID);
				tProject.ProjectName = tp.ProjectName;
				tProject.ProjectContractor = tp.ProjectContractor;
				tProject.ProjectDeveloper = tp.ProjectDeveloper;
				tProject.ProjectAbstract = tp.ProjectAbstract;
				tx.Commit();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
		}
		
		//指定的Project能删除？
		private static bool CanDelProject(int iProjectID)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			int i_rtn = 0;
			//查询，在AccountBill中是否存在
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM AccountBill WHERE ProjectID = @ProjectID",iProjectID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的项目存在应收或应付款，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			//查询，在Receipt表中是否有
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM Receipt WHERE ProjectID = @ProjectID",iProjectID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的项目在入库单中存在，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			//查询，在OutStock表中是否有？
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM OutStock WHERE ProjectID = @ProjectID",iProjectID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的项目在入库单中存在，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			//查询，在ProjectCompanies表中是否有
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM ProjectCompanies WHERE ProjectID = @ProjectID",iProjectID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的项目在项目供应商表中存在，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			session.Close();
			return true;
		}
		
		//删除指定的项目
		public static void DelProject(int  iProjectID)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			Projects toDelete = session.Get<Projects>(iProjectID);
				
			try
			{
				if(!CanDelProject(iProjectID))
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
		public static void FillProjects()
		{
			LocalData.FillProjects();			
		}
		
		//查询全部Projects,用SQL直接获取
		public static DataSet GetAllProjects()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ProjectID,ProjectName,ProjectAbstract,ProjectContractor,ProjectDeveloper FROM Projects");
			return ds;				
		}
		
		public static DataSet GetAllProject(int i_ProjectID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ProjectID,ProjectName,ProjectAbstract,ProjectContractor,ProjectDeveloper FROM Projects WHERE ProjectID = @ProjectID",i_ProjectID);
			return ds;				
		}
		
		//获取指定ProjectID的Projects
		public static Projects GetProject(int i_ProjectID)
		{
			ISession session = NHibernateHelper.OpenSession();
			Projects tClass = new Projects();
			try
			{
				tClass = session.Get<Projects>(i_ProjectID);
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
