/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-08-11
 * 时间: 10:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of Supplier.
	/// </summary>
	public class Supplier
	{
		public Supplier()
		{
		}
		
		public virtual int SupplierID
		{
			get;set;
		}
		
		public virtual string SupplierName
		{
			get;set;
		}
		
		public virtual string SupplierSKName
		{
			get;set;
		}
		
		public virtual string SupplierSKAccount
		{
			get;set;
		}
		
		public virtual string SupplierSKBank
		{
			get;set;
		}
		
		public virtual string SupplierLeader
		{
			get;set;
		}
		
	}
}
