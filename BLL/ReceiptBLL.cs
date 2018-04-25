/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-28
 * 时间: 16:34
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
	/// Description of ReceiptBLL.
	/// </summary>
	public class ReceiptBLL
	{
		public ReceiptBLL()
		{
		}
		
		//查询指定ProjectID和CompanyID还没有结算的
		public static DataSet GetCommMaterialRecord(int i_ProjectID,int i_CompanyID,string s_RecordStatus)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ReceiptID,ReceiptDate,ReceiptNum,ReceiptType,ReceiptBillAmt,ReceiptDiscAmt,ReceiptDisc,Remark,CompanyID,WareHouseID,ProjectID,PurchName,ReceiverName,BillCycle,RecordStatus FROM Receipt WHERE ProjectID=@ProjectID AND CompanyID=@CompanyID AND RecordStatus=@RecordStatus",i_ProjectID,i_CompanyID,s_RecordStatus);
			return ds;				
		}
		
		public static DataSet GetCommMaterialRecord(string s_ReceiptIDs)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ReceiptID,ReceiptDate,ReceiptNum,ReceiptType,ReceiptBillAmt,ReceiptDiscAmt,ReceiptDisc,Remark,CompanyID,WareHouseID,ProjectID,PurchName,ReceiverName,BillCycle,RecordStatus FROM Receipt WHERE ReceiptID IN (" + s_ReceiptIDs + ") ORDER BY ReceiptDate");
			return ds;				
		}
		
		public static DataSet GetReceiptItems(int i_ProjectID,int i_CompanyID,string s_RecordStatus,string s_BillCycle)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.ItemsID,A.ReceiptID,A.GoodsID,A.GoodsName,A.GoodsSpec,A.MoreSpec,A.GoodsUnit,A.GoodsQty,A.GoodsPrc,A.GoodsYF,A.GoodsAmt,A.UsePosition,A.GoodsPlan,A.GoodsPlanNo,B.PurchName,B.ReceiverName,B.ReceiptDate FROM ReceiptItems A,Receipt B WHERE A.ReceiptID = B.ReceiptID AND B.ProjectID=@ProjectID AND B.CompanyID = @CompanyID AND B.RecordStatus = @RecordStatus AND B.BillCycle=@BillCycle ORDER BY B.ReceiptDate",i_ProjectID,i_CompanyID,s_RecordStatus,s_BillCycle);
			return ds;
		}
		
		public static DataSet GetAllReceiptItems()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.GoodsID,A.GoodsName,A.GoodsSpec,A.MoreSpec,A.GoodsUnit,B.GoodsTypeID,SUM(GoodsQty) AS GoodsQty,SUM(GoodsAmt) AS GoodsAmt FROM ReceiptItems A,Goods B WHERE A.GoodsID=B.GoodsID GROUP BY A.GoodsID ORDER By A.GoodsName");
			return ds;
		}
		
		public static DataSet GetReceiptItems(int i_GoodsID)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT A.GoodsID,A.GoodsName,A.GoodsSpec,A.MoreSpec,A.MoreSpec,A.GoodsUnit,A.GoodsQty,A.GoodsPrc,A.GoodsYF,A.GoodsTaxRate,A.GoodsNoTaxPrice,B.ReceiptDate FROM ReceiptItems A,Receipt B WHERE A.ReceiptID = B.ReceiptID AND A.GoodsID=@GoodsID ORDER BY B.ReceiptDate DESC",i_GoodsID);
			return ds;
		}
		
		public static DataSet GetReceipt(int i_ProjectID,int i_CompanyID,string s_RecordStatus,string s_BillCycle)
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT ReceiptID,ReceiptDate,ReceiptNum,ReceiptType,ReceiptBillAmt,ReceiptDiscAmt,ReceiptDisc,Remark,ProjectID,CompanyID,WareHouseID,BillCycle,RecordStatus,PurchName,ReceiverName FROM Receipt WHERE ProjectID=@ProjectID AND CompanyID = @CompanyID AND RecordStatus = @RecordStatus AND BillCycle=@BillCycle ORDER BY ReceiptDate",i_ProjectID,i_CompanyID,s_RecordStatus,s_BillCycle);
			return ds;				
		}
		
		
	}
}
