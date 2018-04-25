/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-07-14
 * 时间: 14:58
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of OutStock.
	/// </summary>
	public class OutStock
	{
		public OutStock()
		{
		}
		
		public virtual int OutStockID				//出库序号
		{
			get;set;
		}
		
		public virtual DateTime OutStockDate		//出库日期
		{
			get;set;
		}
		
		public virtual string OutStockNum			//出库单号
		{
			get;set;
		}
		
		public virtual int OutStockType				//出库类别.0:领料出库；1：领料退货；2：物资借出；3：物资归还；4：报损出库；5：报损退货；
		{
			get;set;
		}
		
		public virtual decimal OutBillAmt			//出库金额
		{
			get;set;
		}
		
		public virtual string OutBillRemark			//备注
		{
			get;set;
		}
		
		public virtual int ProjectID				//项目ID
		{
			get;set;
		}

		
		public virtual int CompanyID				//单位ID
		{
			get;set;
		}

		
		public virtual int WareHouseID				//仓库ID
		{
			get;set;
		}

		public virtual string BillCycle				//账单周期
		{
			get;set;
		}
		public virtual string RecordStatus			//出库单状态：“已记账”，“已结算”
		{
			get;set;
		}
		public virtual string OutMan				//出库人
		{
			get;set;
		}
		public virtual string UseMan				//领用人
		{
			get;set;
		}
	}
}
