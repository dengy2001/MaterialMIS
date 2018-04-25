/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-08-19
 * 时间: 23:35
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of CommMaterialRecord.
	/// </summary>
	public class CommMaterialRecord
	{
		public CommMaterialRecord()
		{
		}
		
		public virtual int CommRecordID		//记录号
		{get;set;}
		
		public virtual int ProjectID		//项目
		{get;set;}
		
		public virtual int CompanyID		//相关单位
		{get;set;}
		
		public virtual DateTime PurchaseDate	//采购日期
		{get;set;}
		
		public virtual string MaterialName		//材料名
		{get;set;}
		
		public virtual string MaterialSpec		//材料规格
		{get;set;}
		
		public virtual string MaterialUnit		//材料单位
		{get;set;}
		
		public virtual decimal MaterialNumber	//材料数量
		{get;set;}
		
		public virtual decimal MaterialPrice	//材料单价
		{get;set;}
		
		public virtual decimal MaterialShipment	//材料运费
		{get;set;}
		
		public virtual decimal MaterialAmt		//材料小记
		{get;set;}
		
		public virtual string ForUsePosition	//使用部位
		{get;set;}
		
		public virtual string MaterialPlan		//材料计划
		{get;set;}
		
		public virtual string MaterialPlanNo	//计划单号
		{get;set;}
		
		public virtual string PurchName			//采购人
		{get;set;}
		
		public virtual string ReceiverName		//收货人
		{get;set;}
		
		public virtual string ReceiveNo			//收货单号
		{get;set;}
		
		public virtual string Brief				//摘要
		{get;set;}
		
		public virtual string BillCycle			//记账周期：如201609
		{get;set;}
		
		public virtual string RecordState		//记录状态。“登帐”、“已对账”
		{get;set;}
		
	}
}
