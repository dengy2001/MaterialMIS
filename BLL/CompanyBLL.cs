/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-02
 * 时间: 17:03
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
	/// Description of CompanyBLL.
	/// </summary>
	public class CompanyBLL
	{
		public CompanyBLL()
		{
		}
		
		//新增
		public static void AddCompany(Companies tp)
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
		public static void UpdateCompany(Companies tp)
		{
			ISession session = NHibernateHelper.OpenSession();
			try
			{				
				ITransaction tx = session.BeginTransaction();
				Companies t1 = session.Get<Companies>(tp.CompanyID);
				t1.CompanyName = tp.CompanyName;
				t1.CompanyPY = tp.CompanyPY;
				t1.CompanyType = tp.CompanyType;
				t1.LinkDetail = tp.LinkDetail;			
				t1.Remark = tp.Remark;
				t1.IsSYS = tp.IsSYS;
				t1.IsStop = tp.IsStop;
				t1.CompanySKName = tp.CompanySKName;
				t1.CompanySKBank = tp.CompanySKBank;
				t1.CompanySKAccount = tp.CompanySKAccount;
				tx.Commit();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
		}
		
		//指定的单位或部门能删除？
		private static bool CanDelCompany(int iCompanyID)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			int i_rtn = 0;
			//查询，在AccountBill中是否存在
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM AccountBill WHERE CompanyID = @ID",iCompanyID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的客户或供应商存在应收或应付款，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			//查询，在Receipt表中是否有
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM Receipt WHERE CompanyID = @CompanyID",iCompanyID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的公司在入库单中存在，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			//查询，在OutStock表中是否有？
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM OutStock WHERE CompanyID = @CompanyID",iCompanyID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的公司在入库单中存在，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			session.Close();
			return true;
		}
		
		//删除
		public static void DelCompany(int  iCompanyID)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			Companies toDelete = session.Get<Companies>(iCompanyID);
				
			try
			{
				if(!CanDelCompany(iCompanyID))
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
		
		//查询客户CompanyType=0,用SQL直接获取
		public static DataSet GetCompany1()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT CompanyID,CompanyName,CompanyPY,CompanyType,LinkDetail,Remark,IsSYS,IsStop,CompanySKName,CompanySKBank,CompanySKAccount FROM Companies WHERE CompanyType=0");
			return ds;				
		}
		
		//查询供货商CompanyType=1,用SQL直接获取
		public static DataSet GetCompany2()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT CompanyID,CompanyName,CompanyPY,CompanyType,LinkDetail,Remark,IsSYS,IsStop,CompanySKName,CompanySKBank,CompanySKAccount FROM Companies WHERE CompanyType=1");
			return ds;				
		}
		
		//查询班组CompanyType=5,用SQL直接获取
		public static DataSet GetCompany3()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT CompanyID,CompanyName,CompanyPY,CompanyType,LinkDetail,Remark,IsSYS,IsStop,CompanySKName,CompanySKBank,CompanySKAccount FROM Companies WHERE CompanyType=2");
			return ds;				
		}
		
		//查询全部Company
		public static DataSet GetCompanyAll()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT CompanyID,CompanyName,CompanyPY,CompanyType,LinkDetail,Remark,IsSYS,IsStop,CompanySKName,CompanySKBank,CompanySKAccount FROM Companies");
			return ds;				
		}
		
		public static DataSet GetAllCompany(int i_CompanyID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT CompanyID,CompanyName,CompanyPY,CompanyType,LinkDetail,Remark,IsSYS,IsStop,CompanySKName,CompanySKBank,CompanySKAccount FROM Companies WHERE CompanyID = @CompanyID",i_CompanyID);
			return ds;				
		}
		
		//获取指定Company
		public static Companies GetCompany(int i_CompanyID)
		{
			ISession session = NHibernateHelper.OpenSession();
			Companies tClass = new Companies();
			try
			{
				tClass = session.Get<Companies>(i_CompanyID);
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
			return tClass;
		}
		
		//指定的ProjectCompany需要添加吗？
		private static bool CanAddProjectCompany(ProjectCompanies tNew)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			int i_rtn = 0;
			
			
			//查询，在ProjectCompany表中是否有
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM ProjectCompanies WHERE CompanyID = @CompanyID AND ProjectID=@ProjectID",tNew.Ps.CompanyID,tNew.Ps.ProjectID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要添加的单位在项目单位中存在，不需要添加！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			
			session.Close();
			return true;
		}
		
		//加入项目供应商
		public static void AddProjectCompany(ProjectCompanies tNew)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				if(!CanAddProjectCompany(tNew))
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
		
		//查询全部ProjectCompanies,用SQL直接获取
		public static DataSet GetProjectCompanies(int i_ProjectID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ProjectID,A.CompanyID,B.CompanyName,B.CompanyType FROM ProjectCompanies A,Companies B WHERE A.CompanyID=B.CompanyID AND A.ProjectID=@i_ProjectID",i_ProjectID);
			return ds;				
		}
		
		//查询全部ProjectCompanies,用SQL直接获取，不含租赁公司
		public static DataSet GetProjectCompanies1(int i_ProjectID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ProjectID,A.CompanyID,B.CompanyName,B.CompanyType FROM ProjectCompanies A,Companies B WHERE A.CompanyID=B.CompanyID AND B.CompanyType<>3 AND A.ProjectID=@i_ProjectID",i_ProjectID);
			return ds;				
		}
		
		//查询全部ProjectCompanies,用SQL直接获取，不含租赁公司
		public static DataSet GetProjectCompanies3(int i_ProjectID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ProjectID,A.CompanyID,B.CompanyName,B.CompanyType FROM ProjectCompanies A,Companies B WHERE A.CompanyID=B.CompanyID AND B.CompanyType=3 AND A.ProjectID=@i_ProjectID",i_ProjectID);
			return ds;				
		}
		
		//查询全部ProjectCompanies,用SQL直接获取
		public static DataSet GetProjectCompanies(int i_ProjectID,int i_CompanyType)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ProjectID,A.CompanyID,B.CompanyName,B.CompanyType FROM ProjectCompanies A,Companies B WHERE A.CompanyID=B.CompanyID AND B.CompanyType = @CompanyType AND A.ProjectID=@i_ProjectID",i_CompanyType,i_ProjectID);
			return ds;				
		}
		
		public static DataSet GetProjectCompanies2(int i_ProjectID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ProjectID,A.CompanyID,B.CompanyName,B.CompanyType FROM ProjectCompanies A,Companies B WHERE A.CompanyID=B.CompanyID AND (B.CompanyType IN (0,2)) AND A.ProjectID=@i_ProjectID",i_ProjectID);
			return ds;				
		}
		
		
		//移除项目供应商
		public static void RemoveProjectCompany(ProjectCompanies tNew)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			ProjectCompanies toDelete = session.Get<ProjectCompanies>(tNew.Ps);
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
		
		
		
		
	}
}
