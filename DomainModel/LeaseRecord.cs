/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-15
 * Time: 9:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of LeaseRecord.
	/// </summary>
	public class LeaseRecord
	{
		public LeaseRecord()
		{
		}
		public virtual int RID		//租还记录号
		{
			get;set;
		}
		public virtual int HTID		//租赁合同号
		{
			get;set;
		}
		public virtual int ItemsID	//租赁合同项号
		{
			get;set;
		}
		public virtual decimal Quality	//租赁数量，归还用负数
		{
			get;set;
		}
		public virtual Nullable<DateTime> BalanceDate	//结账日期
		{
			get;set;
		}
		public virtual DateTime LeaseDate	//租还日期
		{
			get;set;
		}
		public virtual string LeaseStatus	//租赁记录状态：已结账，未结账
		{
			get;set;
		}
		public virtual string Abstract	//摘要
		{
			get;set;
		}
		public virtual string Handler	//经手人
		{
			get;set;
		}
	}
}
