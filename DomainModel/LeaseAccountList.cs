/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-15
 * Time: 13:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of LeaseAccountList.
	/// </summary>
	public class LeaseAccountList
	{
		public LeaseAccountList()
		{
		}
		public virtual int ListID	//结算项号
		{
			get;set;
		}
		public virtual int BillID	//结算单号
		{
			get;set;
		}
		public virtual int SNumber	//结算项序号
		{
			get;set;
		}
		public virtual int ItemsID	//租赁项ID
		{
			get;set;
		}
		public virtual string ItemsName	//租赁项名
		{
			get;set;
		}
		public virtual int LeaseClass	//租赁类别号，0：租赁；1：非租赁；3：结余
		{
			get;set;
		}
		public virtual string Abstract	//摘要
		{
			get;set;
		}
		public virtual DateTime SDate	//开始日期
		{
			get;set;
		}
		public virtual DateTime EDate	//结束日期
		{
			get;set;
		}
		public virtual string LeaseUnit	//租赁单位
		{
			get;set;
		}
		public virtual decimal LeaseQuality	//租赁数量
		{
			get;set;
		}
		public virtual decimal LeasePrice	//租赁单价
		{
			get;set;
		}
		public virtual int LeaseDays	//租赁天数
		{
			get;set;
		}
		public virtual decimal LeaseAmt	//租金
		{
			get;set;
		}
		public virtual string LoadingUnit	//装卸计量单位
		{
			get;set;
		}
		public virtual decimal LoadingFactor	//装卸变换因子
		{
			get;set;
		}
		public virtual decimal LoadingQuality	//装卸量
		{
			get;set;
		}
		public virtual decimal LoadingPrice	//装卸单价
		{
			get;set;
		}
		public virtual decimal LoadingAmt	//装卸金额
		{
			get;set;
		}
		public virtual string RepairUnit	//维修计量单位
		{
			get;set;
		}
		public virtual decimal RepairFactor	//维修变换因子
		{
			get;set;
		}
		public virtual decimal RepairQuality	//维修量
		{
			get;set;
		}
		public virtual decimal RepairPrice	//维修单价
		{
			get;set;
		}
		public virtual decimal RepairAmt	//维修金额
		{
			get;set;
		}
		public virtual string OtherUnit	//其他计量单位
		{
			get;set;
		}
		public virtual decimal OtherQuality	//其他量
		{
			get;set;
		}
		public virtual decimal OtherPrice	//其他单价
		{
			get;set;
		}
		public virtual decimal OtherAmt		//其他金额
		{
			get;set;
		}
	}
}
