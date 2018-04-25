/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-10-09
 * 时间: 11:12
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
	/// Description of StatementListBLL.
	/// </summary>
	public class StatementListBLL
	{
		public StatementListBLL()
		{
		}
		
		/// <summary>
		/// 按公司类别获取，0：客户；1：供应商；2：班组
		/// </summary>
		/// <param name="i_CompanyType"></param>
		/// <returns></returns>
		public static DataSet GetCompanyTotalByType(int i_CompanyType)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.CompanyID,A.CompanyName,SUM(A.BillYS) AS SUMYS,SUM(A.BillSS) AS SUMSS,SUM(A.BillYS-A.BillSS) AS SUMYE1 ,SUM(A.BillYF) AS SUMYF,SUM(A.BillSF) AS SUMSF,SUM(A.BillYF-A.BillSF) AS SUMYE2  from StatementList A,Companies B WHERE A.CompanyID=B.CompanyID AND B.CompanyType = @CompanyType Group By A.CompanyID ",i_CompanyType);
			return ds;	
		}
		
		/// <summary>
		/// 按公司ID取收付款记录
		/// </summary>
		/// <param name="i_CompanyID"></param>
		/// <returns></returns>
		public static DataSet GetCompanyStatementList(int i_CompanyID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT SID,StatementType,StatementCycle,ProjectID,ProjectName,CompanyID,CompanyName,MoneyTypeID,MoneyTypeName,StatementMemo,StatementDate,BillYS,BillSS,BillYF,BillSF FROM StatementList  WHERE CompanyID=@CompanyID",i_CompanyID);
			return ds;	
		}
		
		public static DataSet GetCompanyStatementList(int i_ProjectID,int i_CompanyID,int i_CompanyType)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.SID,A.StatementType,A.StatementCycle,A.ProjectID,A.ProjectName,A.CompanyID,A.CompanyName,A.MoneyTypeID,A.MoneyTypeName,A.StatementMemo,A.StatementDate,A.BillYS,A.BillSS,A.BillYF,A.BillSF FROM StatementList A,Companies B  WHERE A.CompanyID=B.CompanyID AND A.ProjectID=@ProjectID AND A.CompanyID=@CompanyID AND B.CompanyType=@CompanyType",i_ProjectID,i_CompanyID,i_CompanyType);
			return ds;	
		}
		
		public static DataSet GetCompanyStatementList(int i_ProjectID,int i_CompanyID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.SID,A.StatementType,A.StatementCycle,A.ProjectID,A.ProjectName,A.CompanyID,A.CompanyName,A.MoneyTypeID,A.MoneyTypeName,A.StatementMemo,A.StatementDate,A.BillYS,A.BillSS,A.BillYF,A.BillSF FROM StatementList A,Companies B  WHERE A.CompanyID=B.CompanyID AND A.ProjectID=@ProjectID AND A.CompanyID=@CompanyID",i_ProjectID,i_CompanyID);
			return ds;	
		}
		
		public static DataSet GetCompanyStatementList()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT SID,StatementType,StatementCycle,ProjectID,ProjectName,CompanyID,CompanyName,MoneyTypeID,MoneyTypeName,StatementMemo,StatementDate,BillYS,BillSS,BillYF,BillSF FROM StatementList");
			return ds;	
		}
		
		public static DataSet GetCompanyStatementListByProjectID(int i_ProjectID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT SID,StatementType,StatementCycle,ProjectID,ProjectName,CompanyID,CompanyName,MoneyTypeID,MoneyTypeName,StatementMemo,StatementDate,BillYS,BillSS,BillYF,BillSF FROM StatementList WHERE ProjectID=@ProjectID",i_ProjectID);
			return ds;	
		}
		
		
		
	}
}
