/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-14
 * Time: 15:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of LeaseItems.
	/// </summary>
	public class LeaseItems
	{
		public LeaseItems()
		{
		}
		public virtual int ItemsID		//合同项号
		{
			get;set;
		}
		public virtual int HTID			//合同号
		{
			get;set;
		}
		public virtual string MName		//租赁材料名称
		{
			get;set;
		}
		public virtual int LeaseClass	//租赁项类别：租赁项，0；单独计费项，1
		{
			get;set;
		}
		public virtual string LeaseUnit	//租赁单位
		{
			get;set;
		}
		public virtual decimal LeasePrice	//租赁单价
		{
			get;set;
		}
		public virtual string LoadingUnit	//装卸单位
		{
			get;set;
		}
		public virtual Nullable<decimal> LoadingFactor	//装卸因子
		{
			get;set;
		}
		public virtual Nullable<decimal> LoadingPrice	//装卸单价
		{
			get;set;
		}
		public virtual string RepairUnit	//维修单位
		{
			get;set;
		}
		public virtual Nullable<decimal> RepairFactor	//维修因子
		{
			get;set;
		}
		public virtual Nullable<decimal> RepairPrice	//维修单价
		{
			get;set;
		}
		public virtual Nullable<DateTime> BalanceDate	//最后记账日期
		{
			get;set;
		}
		public virtual decimal CurLeaseQuality	//当前余量
		{
			get;set;
		}
	}
}
