/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-14
 * Time: 15:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of LeaseHT.
	/// </summary>
	public class LeaseHT
	{
		public LeaseHT()
		{
		}
		
		public virtual int HTID			//合同号
		{
			get;set;
		}
		public virtual string HTNumber	//合同编号
		{
			get;set;
		}
		public virtual int CompanyID	//公司ID
		{
			get;set;
		}
		public virtual int ProjectID	//项目ID
		{
			get;set;
		}
		public virtual string HTName	//合同名称
		{
			get;set;
		}
		public virtual int IncludeSDate	//记起租日
		{
			get;set;
		}
		public virtual int IncludeEDate	//记止租日
		{
			get;set;
		}
	}
}
