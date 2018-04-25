/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-15
 * 时间: 15:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of Receipt.
	/// </summary>
	public class Receipt
	{
		public Receipt()
		{
		}
		
		public virtual int ReceiptID	//入库单序号
		{
			get;set;
		}
		
		public virtual DateTime ReceiptDate		//入库日期
		{
			get;set;
		}
		
		public virtual string ReceiptNum		//入库单号
		{
			get;set;
		}
		
		public virtual int ReceiptType			//入库单类别，0：采购入库；1：采购退货；2：调拨入库；3：调拨退货；4：报溢入库；5：报溢退货。
		{
			get;set;
		}
		
		public virtual decimal ReceiptBillAmt	//入库账单金额
		{
			get;set;
		}
		
		public virtual decimal ReceiptDiscAmt	//入库单折扣后金额
		{
			get;set;
		}
		
		public virtual decimal ReceiptDisc		//入库单折扣
		{
			get;set;
		}		
		
		
		public virtual string 	Remark			//备注
		{
			get;set;
		}
		
		public virtual int CompanyID			//对应单位
		{
			get;set;
		}
		
		public virtual int WareHouseID			//入库仓库
		{
			get;set;
		}
		
		public virtual int ProjectID			//对应项目
		{
			get;set;
		}
		
		public virtual string PurchName			//采购员
		{
			get;set;
		}
		
		public virtual string ReceiverName		//收货
		{
			get;set;
		}
		public virtual string BillCycle			//结算周期，如201609
		{
			get;set;
		}
		public virtual string RecordStatus		//状态：“已记账”，“已结算”
		{
			get;set;
		}
	}
}
