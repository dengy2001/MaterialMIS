/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-13
 * 时间: 14:57
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
	/// Description of ProgOptionsBLL.
	/// </summary>
	public class ProgOptionsBLL
	{
		public ProgOptionsBLL()
		{
		}
		
		//添加
		public static void AddOptions(ProgOptions tp)
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
		public static void UpdateOptions(ProgOptions tp)
		{
			ISession session = NHibernateHelper.OpenSession();
			try
			{				
				ITransaction tx = session.BeginTransaction();
				ProgOptions t1 = session.Get<ProgOptions>(tp.OptionsID);
				t1.OptionsKey = tp.OptionsKey;
				t1.OptionsValue = tp.OptionsValue;
				t1.OptionsRemark = tp.OptionsRemark;
				tx.Commit();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
		}
		
		
		//删除
		public static void DelOptions(int  iOptionsID)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.OpenSession();
			ITransaction tx = session.BeginTransaction();
			ProgOptions toDelete = session.Get<ProgOptions>(iOptionsID);
			//判断是否程序中已经使用的参数，如果是，不允许删除！！！
			List<string> usedKey=new List<string>(){"RKLX","CKLX","RKD_LastNumber","CKD_LastNumber"};
			if(usedKey.Contains(toDelete.OptionsKey))
			{
				//不能删除，返回
				MessageBox.Show("此参数程序有使用，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				tx.Rollback();
				session.Close();
				return;
			}
				
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
		
		//查询全部Options,用SQL直接获取
		public static DataSet GetAllOptions()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT OptionsID,OptionsKey,OptionsValue,OptionsRemark FROM ProgOptions");
			return ds;				
		}
		
		//获取指定OptionsID的ProgOptions
		public static ProgOptions GetOptions(int i_OptionsID)
		{
			ISession session = NHibernateHelper.OpenSession();
			ProgOptions tClass = new ProgOptions();
			try
			{
				tClass = session.Get<ProgOptions>(i_OptionsID);
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
			}
			session.Close();
			return tClass;
		}
		
		//获取指定OptionsKey的ProgOptions
		public static IList<ProgOptions> GetOptions(string s_OptionsKey)
		{
			ISession session = NHibernateHelper.OpenSession();
			return session.CreateQuery("FROM ProgOptions WHERE OptionsKey = :p1")
				.SetString("p1",s_OptionsKey)
				.List<ProgOptions>();
		}
		
		//清空数据
		public static void ClearData()
		{
			//把数据库先备份下
			backupDatabase();
			//删除AccountBill表			
			SQLiteHelper.ExecuteNonQuery("DELETE FROM AccountBill");
			//删除StatementList表			
			SQLiteHelper.ExecuteNonQuery("DELETE FROM StatementList");
			//删除入库单项
			SQLiteHelper.ExecuteNonQuery("DELETE FROM ReceiptItems");
			//删除出库单项
			SQLiteHelper.ExecuteNonQuery("DELETE FROM OutStockItems");
			//删除入库单
			SQLiteHelper.ExecuteNonQuery("DELETE FROM Receipt");
			//删除出库单
			SQLiteHelper.ExecuteNonQuery("DELETE FROM OutStock");
			//删除仓库库存
			SQLiteHelper.ExecuteNonQuery("DELETE FROM WareHouseStock");
			//删除仓库
			SQLiteHelper.ExecuteNonQuery("DELETE FROM WareHouses");
			//删除供货商或领用
			SQLiteHelper.ExecuteNonQuery("DELETE FROM Companies");
			//删除MoneyType
			SQLiteHelper.ExecuteNonQuery("DELETE FROM MoneyType");
			//删除ProjectCompanies
			SQLiteHelper.ExecuteNonQuery("DELETE FROM ProjectCompanies");
			//删除Projects
			SQLiteHelper.ExecuteNonQuery("DELETE FROM Projects");
			//删除货品
			SQLiteHelper.ExecuteNonQuery("DELETE FROM Goods");
			//删除货品类别
			SQLiteHelper.ExecuteNonQuery("DELETE FROM GoodsType");
			//删除Users
			SQLiteHelper.ExecuteNonQuery("DELETE FROM Users");
			//删除LeaseAccountList
			SQLiteHelper.ExecuteNonQuery("DELETE FROM LeaseAccountList");
			//删除LeaseAccountLeft
			SQLiteHelper.ExecuteNonQuery("DELETE FROM LeaseAccountLeft");
			//删除LeaseAccount
			SQLiteHelper.ExecuteNonQuery("DELETE FROM LeaseAccount");
			//删除LeaseItems
			SQLiteHelper.ExecuteNonQuery("DELETE FROM LeaseItems");
			//删除LeaseHT
			SQLiteHelper.ExecuteNonQuery("DELETE FROM LeaseHT");
			//删除LeaseRecord
			SQLiteHelper.ExecuteNonQuery("DELETE FROM LeaseRecord","VACUUM");	
			
			//更新RKD_LastNumber
			SQLiteHelper.ExecuteNonQuery("UPDATE ProgOptions SET OptionsValue ='' WHERE OptionsKey='RKD_LastNumber'");
			//更新CKD_LastNumber
			SQLiteHelper.ExecuteNonQuery("UPDATE ProgOptions SET OptionsValue ='' WHERE OptionsKey='CKD_LastNumber'");
			//加全部类别
			SQLiteHelper.ExecuteNonQuery("INSERT INTO GoodsType(GoodsTypeName) VALUES('全部类别')");
			//加User
			Users tUser = new Users();
			tUser.UserName = "admin";
			tUser.UserDisplayName = "系统管理员";
			tUser.UserPassword = "admin";
			BLL.UserBLL.AddUsers(tUser);
		}
		//清空数据
		
		public static void ClearData1()
		{
			//把数据库先备份下
			backupDatabase();
			//删除AccountBill表			
			SQLiteHelper.ExecuteNonQuery("DELETE FROM AccountBill");
			//删除StatementList表			
			SQLiteHelper.ExecuteNonQuery("DELETE FROM StatementList");
			//删除入库单项
			SQLiteHelper.ExecuteNonQuery("DELETE FROM ReceiptItems");
			//删除出库单项
			SQLiteHelper.ExecuteNonQuery("DELETE FROM OutStockItems");
			//删除入库单
			SQLiteHelper.ExecuteNonQuery("DELETE FROM Receipt");
			//删除出库单
			SQLiteHelper.ExecuteNonQuery("DELETE FROM OutStock");
			//删除仓库库存
			SQLiteHelper.ExecuteNonQuery("DELETE FROM WareHouseStock");
			//删除仓库
			SQLiteHelper.ExecuteNonQuery("DELETE FROM WareHouses");
			//删除供货商或领用
			SQLiteHelper.ExecuteNonQuery("DELETE FROM Companies");
			//删除MoneyType
			SQLiteHelper.ExecuteNonQuery("DELETE FROM MoneyType");
			//删除ProjectCompanies
			SQLiteHelper.ExecuteNonQuery("DELETE FROM ProjectCompanies");
			//删除Projects
			SQLiteHelper.ExecuteNonQuery("DELETE FROM Projects");
			//删除Users
			SQLiteHelper.ExecuteNonQuery("DELETE FROM Users");
			//删除LeaseAccountList
			SQLiteHelper.ExecuteNonQuery("DELETE FROM LeaseAccountList");
			//删除LeaseAccountLeft
			SQLiteHelper.ExecuteNonQuery("DELETE FROM LeaseAccountLeft");
			//删除LeaseAccount
			SQLiteHelper.ExecuteNonQuery("DELETE FROM LeaseAccount");
			//删除LeaseItems
			SQLiteHelper.ExecuteNonQuery("DELETE FROM LeaseItems");
			//删除LeaseHT
			SQLiteHelper.ExecuteNonQuery("DELETE FROM LeaseHT");	
			//删除LeaseRecord
			SQLiteHelper.ExecuteNonQuery("DELETE FROM LeaseRecord");			
			
			//更新RKD_LastNumber
			SQLiteHelper.ExecuteNonQuery("UPDATE ProgOptions SET OptionsValue ='' WHERE OptionsKey='RKD_LastNumber'");
			//更新CKD_LastNumber
			SQLiteHelper.ExecuteNonQuery("UPDATE ProgOptions SET OptionsValue ='' WHERE OptionsKey='CKD_LastNumber'");
			//加User
			Users tUser = new Users();
			tUser.UserName = "admin";
			tUser.UserDisplayName = "系统管理员";
			tUser.UserPassword = "admin";
			BLL.UserBLL.AddUsers(tUser);
		}
		
		public static void backupDatabase()
		{
			//
			string sourcefile = ConfigurationManager.AppSettings["SQLiteConnectionString"];
			int startpos = sourcefile.IndexOf('=');
			sourcefile = sourcefile.Substring(startpos+1);
			DateTime dt = new DateTime();
			dt = System.DateTime.Now;
			string newfile = dt.ToString("yyyyMMddHHmmss");
			newfile = newfile + "BAK.db";
			System.IO.File.Copy(sourcefile,newfile);
		}
		
	}
}
