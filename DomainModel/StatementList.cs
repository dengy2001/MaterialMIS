/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-10-08
 * 时间: 13:04
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of StatementList.
	/// </summary>
	public class StatementList
	{
		public StatementList()
		{
		}
		
		public virtual int SID					//结算序号
		{
			get;set;
		}
		public virtual string StatementType		//结算类型：供货结算，领用结算，其他结算
		{
			get;set;
		}
		public virtual string StatementCycle		//结算周期
		{
			get;set;
		}
		public virtual int ProjectID
		{
			get;set;
		}
		public virtual string ProjectName
		{
			get;set;
		}
		public virtual int CompanyID
		{
			get;set;
		}
		public virtual string CompanyName
		{
			get;set;
		}
		public virtual int MoneyTypeID 				//收支类别号,10000是特别的。
		{
			get;set;
		}
		public virtual string MoneyTypeName			//收支类别名称
		{
			get;set;
		}
		public virtual string StatementMemo			//备注
		{
			get;set;
		}
		public virtual DateTime StatementDate		//日期
		{
			get;set;
		}
		public virtual decimal BillYS			//应收金额
		{
			get;set;
		}
		public virtual decimal BillSS			//实收金额
		{
			get;set;
		}
		public virtual decimal BillYF			//应付金额
		{
			get;set;
		}
		public virtual decimal BillSF			//实付金额
		{
			get;set;
		}
	}
}
