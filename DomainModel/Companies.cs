/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-02
 * 时间: 16:52
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of Companies.
	/// </summary>
	public class Companies
	{
		public Companies()
		{
		}
		
		public virtual int CompanyID		//相关单位ID
		{
			get;set;
		}
		
		public virtual string CompanyName	//相关单位名称
		{
			get;set;
		}
		
		public virtual string CompanyPY		//单位名称拼音
		{
			get;set;
		}
		
		public virtual int CompanyType		//单位类别：0，客户；1，供货商；2，班组；3，租赁商
		{
			get;set;
		}
		
		public virtual string LinkDetail	//联系详细信息
		{
			get;set;
		}		
		
		public virtual string Remark		//备注
		{
			get;set;
		}
		
		public virtual int IsSYS			//未用
		{
			get;set;
		}
		
		public virtual int IsStop			//未用
		{
			get;set;
		}
		public virtual string CompanySKName		//收款名
		{
			get;set;
		}
		public virtual string CompanySKBank		//收款开户行
		{
			get;set;
		}
		public virtual string CompanySKAccount	//收款账户
		{
			get;set;
		}
		
	}
}
