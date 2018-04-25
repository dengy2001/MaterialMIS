/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-01
 * 时间: 20:53
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
	/// Description of MoneyTypeBLL.
	/// </summary>
	public class MoneyTypeBLL
	{
		public MoneyTypeBLL()
		{
		}
		
		//添加新收支项
		public static void AddMoneyType(MoneyType tp)
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
		public static void UpdateMoneyType(MoneyType tp)
		{
			ISession session = NHibernateHelper.OpenSession();
			try
			{				
				ITransaction tx = session.BeginTransaction();
				MoneyType t1 = session.Get<MoneyType>(tp.MoneyTypeID);
				t1.MoneyTypeName = tp.MoneyTypeName;
				t1.MoneyTypeClass = tp.MoneyTypeClass;
				tx.Commit();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
		}
		
		//指定的收支项目能删除？
		private static bool CanDelMoneyType(int iMoneyTypeID)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			int i_rtn = 0;
			//查询，在AccountBill中是否存在
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM AccountBill WHERE MoneyTypeID = @ID",iMoneyTypeID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的收支项目存在应收或应付款，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			session.Close();
			return true;
		}
		
		//删除
		public static void DelMoneyType(int  iMoneyTypeID)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			MoneyType toDelete = session.Get<MoneyType>(iMoneyTypeID);
				
			try
			{
				if(!CanDelMoneyType(iMoneyTypeID))
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
		public static void FillMoneyType()
		{
			LocalData.FillMoneyType();
		}
		
		//查询全部MoneyType,用SQL直接获取
		public static DataSet GetAllMoneyType()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT MoneyTypeID,MoneyTypeName,MoneyTypeClass FROM MoneyType");
			return ds;				
		}
		
		//查询全部MoneyType,收入
		public static DataSet GetAllMoneyTypeIn()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT MoneyTypeID,MoneyTypeName,MoneyTypeClass FROM MoneyType WHERE MoneyTypeClass=0");
			return ds;				
		}
		
		//查询全部MoneyType,支出
		public static DataSet GetAllMoneyTypeOut()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT MoneyTypeID,MoneyTypeName,MoneyTypeClass FROM MoneyType WHERE MoneyTypeClass=1");
			return ds;				
		}
		
		//获取指定MoneyTypeID的MoneyType
		public static MoneyType GetMoneyType(int i_MoneyTypeID)
		{
			ISession session = NHibernateHelper.OpenSession();
			MoneyType tClass = new MoneyType();
			try
			{
				tClass = session.Get<MoneyType>(i_MoneyTypeID);
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
