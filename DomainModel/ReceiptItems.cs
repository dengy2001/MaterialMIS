/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-15
 * 时间: 15:33
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of ReceiptItems.
	/// </summary>
	public class ReceiptItems
	{
		public ReceiptItems()
		{
		}
		public virtual int ItemsID		//入库材料项ID
		{
			get;set;
		}
		
		public virtual int ReceiptID	//入库单号
		{
			get;set;
		}
		
		public virtual int GoodsID		//货品号
		{
			get;set;
		}
		public virtual string GoodsName	//货品名称
		{
			get;set;
		}
		public virtual string GoodsSpec	//货品规格
		{
			get;set;
		}
		public virtual string MoreSpec	//补充规格
		{
			get;set;
		}
		public virtual string GoodsUnit	//货品单位
		{
			get;set;
		}
		public virtual decimal GoodsQty	//数量
		{
			get;set;
		}
		
		public virtual decimal GoodsPrc	//单价
		{
			get;set;
		}
		
		public virtual decimal GoodsYF	//运费
		{
			get;set;
		}
		
		public virtual decimal GoodsAmt	//金额
		{
			get;set;
		}
		public virtual string UsePosition	//使用部位
		{
			get;set;
		}
		public virtual string GoodsPlan		//材料计划
		{
			get;set;
		}
		public virtual string GoodsPlanNo	//材料计划号
		{
			get;set;
		}
		public virtual decimal GoodsTaxRate	//税率
		{
			get;set;
		}
		public virtual decimal GoodsNoTaxPrice	//不含税价
		{
			get;set;
		}
	}
}
