/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-04-28
 * 时间: 16:22
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Collections.Generic;

namespace DAL
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class LocalData
	{
		public static DataSet dsLocal;
				
		private LocalData()
		{
			
		}
		
		
		/// <summary>
		/// 将指定表名的表数据填充到dsLocal数据集中
		/// </summary>
		/// <param></param>
		/// <returns>void</returns>
		public static void FillGoodsType()
		{
			try
			{
				if(dsLocal == null)
				{
					dsLocal = new DataSet();
				}
				//如果原来此表已经存在，删除
				if(dsLocal.Tables["GoodsType"] != null)
				{
					dsLocal.Tables.Remove("GoodsType");
				}
				DataSet ds = new DataSet();
				ds = SQLiteHelper.ExecuteDataSet("SELECT GoodsTypeID,GoodsTypeName,GoodsTypePID FROM GoodsType ");
				DataTable dt = new DataTable();
				dt = ds.Tables[0];
				dt.TableName = "GoodsType";
				dsLocal.Tables.Add(dt.Copy());
			}
			catch(Exception e1)
			{
				string s1 = e1.Message;
				return ;
			}
			
		}
		
		public static void FillProjects()
		{
			try
			{
				if(dsLocal == null)
				{
					dsLocal = new DataSet();
				}
				//如果原来此表已经存在，删除
				if(dsLocal.Tables["Projects"] != null)
				{
					dsLocal.Tables.Remove("Projects");
				}
				DataSet ds = new DataSet();
				ds = SQLiteHelper.ExecuteDataSet("SELECT ProjectID,ProjectName FROM Projects");
				DataTable dt = new DataTable();
				dt = ds.Tables[0];
				dt.TableName = "Projects";
				dsLocal.Tables.Add(dt.Copy());
			}
			catch(Exception e1)
			{
				string s1 = e1.Message;
				return ;
			}
			
		}
		
		public static void FillMoneyType()
		{
			try
			{
				if(dsLocal == null)
				{
					dsLocal = new DataSet();
				}
				//如果原来此表已经存在，删除
				if(dsLocal.Tables["MoneyType"] != null)
				{
					dsLocal.Tables.Remove("MoneyType");
				}
				DataSet ds = new DataSet();
				ds = SQLiteHelper.ExecuteDataSet("SELECT MoneyTypeID,MoneyTypeName,MoneyTypeClass FROM MoneyType");
				DataTable dt = new DataTable();
				dt = ds.Tables[0];
				dt.TableName = "MoneyType";
				dsLocal.Tables.Add(dt.Copy());
			}
			catch(Exception e1)
			{
				string s1 = e1.Message;
				return ;
			}
			
		}
		
		public static void FillWareHouses()
		{
			try
			{
				if(dsLocal == null)
				{
					dsLocal = new DataSet();
				}
				//如果原来此表已经存在，删除
				if(dsLocal.Tables["WareHouses"] != null)
				{
					dsLocal.Tables.Remove("WareHouses");
				}
				DataSet ds = new DataSet();
				ds = SQLiteHelper.ExecuteDataSet("SELECT WareHouseID,WareHouseName FROM WareHouses");
				DataTable dt = new DataTable();
				dt = ds.Tables[0];
				dt.TableName = "WareHouses";
				dsLocal.Tables.Add(dt.Copy());
			}
			catch(Exception e1)
			{
				string s1 = e1.Message;
				return ;
			}
			
		}
		
	}
}