/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-20
 * 时间: 14:40
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of ImportRecord.
	/// </summary>
	public class ImportRecord
	{
		public ImportRecord()
		{
		}
		
		public virtual int ID		//编号
		{
			get;set;
		}
		public virtual Nullable<DateTime> PurchDateTime		//采购日期
		{
			get;set;
		}
		public virtual string MName			//材料名称
		{
			get;set;
		}
		public virtual string MSpec			//规格型号
		{
			get;set;
		}
		public virtual string Unit			//单位
		{
			get;set;
		}
		public virtual Nullable<decimal> Number		//数量
		{
			get;set;
		}
		public virtual Nullable<decimal> Price		//单价
		{
			get;set;
		}
		public virtual Nullable<decimal> SubAmount		//小计
		{
			get;set;
		}
		public virtual Nullable<decimal> DCost			//运费
		{
			get;set;
		}
		public virtual Nullable<decimal> Amount			//合计
		{
			get;set;
		}
		public virtual string UseSite				//使用部位
		{
			get;set;
		}
		public virtual string Planner			//计划人
		{
			get;set;
		}
		public virtual Nullable<int> PlanNo		//计划号
		{
			get;set;
		}
		public virtual string PurchMan			//采购人
		{
			get;set;
		}
		public virtual string Consignee			//收货人
		{
			get;set;
		}
		public virtual Nullable<int> ReceiptNo		//收货单号
		{
			get;set;
		}
		public virtual string Abstract			//备注
		{
			get;set;
		}
		public virtual string SupplierName		//供方名称
		{
			get;set;
		}
		public virtual string ProjectName		//项目名称
		{
			get;set;
		}
		public virtual Nullable<DateTime> ImportDateTime	//导入时间
		{
			get;set;
		}		
  
		
	}
}
