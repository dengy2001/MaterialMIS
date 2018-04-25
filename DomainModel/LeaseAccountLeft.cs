/*
 * 由SharpDevelop创建。
 * 用户： Dengyong
 * 日期: 2016-12-07
 * 时间: 15:33
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of LeaseAccountLeft.
	/// </summary>
	public class LeaseAccountLeft
	{
		public LeaseAccountLeft()
		{
		}
		
		public virtual int ALeftID		//剩余量编号
		{
			get;set;
		}
		public virtual int HTID		//租赁合同号
		{
			get;set;
		}
		public virtual int ItemsID		//剩余项目号
		{
			get;set;
		}
		public virtual decimal QualityLeft	//剩余量
		{
			get;set;
		}
		public virtual string LastBillCycle	//最后结算周期
		{
			get;set;
		}
		public virtual DateTime LastEDate	//最后结算日期
		{
			get;set;
		}
	}
}
