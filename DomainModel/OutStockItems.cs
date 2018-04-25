/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-07-14
 * 时间: 15:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of OutStockItems.
	/// </summary>
	public class OutStockItems
	{
		public OutStockItems()
		{
		}
		
		public virtual int ItemsID				//出库号
		{
			get;set;
		}
		
		public virtual int OutStockID			//出库单号
		{
			get;set;
		}
		
		public virtual int GoodsID				//货品ID
		{
			get;set;
		}
		
		public virtual string GoodsName			//货品名称
		{
			get;set;
		}
		
		public virtual string GoodsSpec			//规格型号
		{
			get;set;
		}
		
		public virtual string GoodsUnit			//单位
		{
			get;set;
		}
		
		public virtual decimal GoodsQty			//出库数量
		{
			get;set;
		}
		
		public virtual decimal GoodsPrc			//出库单价
		{
			get;set;
		}
		
		public virtual decimal GoodsAmt			//出库金额
		{
			get;set;
		}
		public virtual string UsePosition		//使用部位
		{get;set;}
	}
}
