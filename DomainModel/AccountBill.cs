/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-03
 * 时间: 16:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of AccountBill.
	/// </summary>
	/// 
	//没用了
	public class AccountBill
	{
		public AccountBill()
		{
		}
		
		public virtual int BillNo			//账单号
		{
			get;set;
		}
		
		public virtual int ProjectID		//项目ID
		{
			get;set;
		}
		public virtual string ProjectName		//项目名称
		{
			get;set;
		}
		
		public virtual int CompanyID		//公司ID
		{
			get;set;
		}
		public virtual string CompanyName		//单位名称
		{
			get;set;
		}
		
		public virtual int MoneyTypeID		//收支类别
		{
			get;set;
		}
		public virtual string MoneyTypeName		//收支名称
		{
			get;set;
		}
		
		public virtual int BillType			//账单类别：0，客户；1，供应商；2，班组
		{
			get;set;
		}
		
		public virtual string BillMemo		//备注
		{
			get;set;
		}
		
		public virtual decimal BillYS		//应收款
		{
			get;set;
		}
		
		public virtual decimal BillSS		//实收款
		{
			get;set;
		}
	
		public virtual decimal BillYF		//应付款
		{
			get;set;
		}
		
		public virtual decimal BillSF		//实付款
		{
			get;set;
		}
		
		public virtual DateTime BillDate	//账单日
		{
			get;set;
		}
		public virtual string BillCycle 	//账单周期
		{
			get;set;
		}
		public virtual string BillStatus	//账单状态：“已记账”，“已结算”
		{
			get;set;
		}
	}
}
