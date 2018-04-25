/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-15
 * Time: 13:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of LeaseAccount.
	/// </summary>
	public class LeaseAccount
	{
		public LeaseAccount()
		{
		}
		public virtual int BillID	//租赁结算单号
		{
			get;set;
		}
		public virtual string CalMethod	//租金算法：累计算法，倒扣算法
		{
			get;set;
		}
		public virtual int ProjectID	//项目ID
		{
			get;set;
		}
		public virtual string ProjectName	//项目名称
		{
			get;set;
		}
		public virtual int CompanyID	//公司ID
		{
			get;set;
		}
		public virtual string CompanyName	//公司名称
		{
			get;set;
		}
		public virtual decimal BillAmt	//结算总额
		{
			get;set;
		}
		public virtual int IncludeSDate	//计算开始日期
		{
			get;set;
		}
		public virtual int IncludeEDate	//计算结束日期
		{
			get;set;
		}
		public virtual Nullable<DateTime> SDate	//开始日期
		{
			get;set;
		}
		public virtual Nullable<DateTime> EDate	//结束日期
		{
			get;set;
		}
		public virtual string BillCycle	//结算周期
		{
			get;set;
		}
		public virtual string Abstract	//摘要
		{
			get;set;
		}
	}
}
