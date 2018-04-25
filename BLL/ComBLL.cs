/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-20
 * 时间: 11:34
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using NHibernate;
//using NHibernate.Cfg;
using DomainModel;
//using System.Data.SQLite;
using DAL;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Configuration;

namespace BLL
{
	/// <summary>
	/// Description of ComBLL.
	/// </summary>
	public class ComBLL
	{
		public ComBLL()
		{
		}
		private static ToolStripStatusLabel _lStatus;
		
		public static ToolStripStatusLabel LStatus
		{
			get
			{
				return _lStatus;
			}
			set
			{
				_lStatus = value;
			}
		}
		
		//将DataTable数据填充到指定的数据库表中
		public static void FillDataTable2Table(DataTable tDt,string TableName)
		{
			switch(TableName)
			{
				case "ImportRecord":
					FillDataTableImportRecord(tDt);
					break;
					
				default:
					break;
			}
		}
		
		public static void FillDataTableImportRecord(DataTable tDt)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				DataRow[] drs;
				drs = tDt.Select("1=1");
				for (int i = 0; i < drs.Length; i++)
				{
					ImportRecord tNew = new ImportRecord();
					string ts = drs[i]["采购日期"].ToString();
					if(ts.Length == 6)
					{
						ts = "20" + ts.Substring(0,2) + "-" + ts.Substring(2,2) + "-" + ts.Substring(4,2);
					}
					else
					{
						ts = ts.Substring(0,4) + "-" + ts.Substring(4,2) + "-" + ts.Substring(6,2);
						
					}
					tNew.PurchDateTime = Convert.ToDateTime(ts);
					tNew.MName = drs[i]["材料名称"].ToString();
					tNew.MSpec = drs[i]["规格型号"].ToString();
					tNew.Unit = drs[i]["单位"].ToString();
					if(drs[i]["数量"].ToString() != "")
					{
						tNew.Number = Convert.ToDecimal(drs[i]["数量"]);
					}
					if(drs[i]["单价"].ToString() != "")
					{
						tNew.Price = Convert.ToDecimal(drs[i]["单价"]);
					}
					if(drs[i]["小计"].ToString() != "")
					{
						tNew.SubAmount = Convert.ToDecimal(drs[i]["小计"]);
					}
					if(drs[i]["采运费"].ToString() != "")
					{
						tNew.DCost = Convert.ToDecimal(drs[i]["采运费"]);
					}
					if(drs[i]["合计"].ToString() != "")
					{
						tNew.Amount = Convert.ToDecimal(drs[i]["合计"]);
					}
					tNew.UseSite = drs[i]["使用部位"].ToString();
					tNew.Planner = drs[i]["材料计划人"].ToString();
					if(drs[i]["材料计划编号"].ToString() != "")
					{
						tNew.PlanNo = Convert.ToInt32(drs[i]["材料计划编号"]);
					}
					tNew.PurchMan = drs[i]["采购人"].ToString();
					tNew.Consignee = drs[i]["收货人"].ToString();
					if(drs[i]["收货单号"].ToString() != "")
					{
						tNew.ReceiptNo = Convert.ToInt32(drs[i]["收货单号"]);
					}
					tNew.Abstract = drs[i]["备注"].ToString();
					tNew.SupplierName = drs[i]["供方名称"].ToString();
					tNew.ProjectName = drs[i]["项目名称"].ToString();
					tNew.ImportDateTime = DateTime.Now;

					session.Save(tNew);
					LStatus.Text = "写入数据库：第" + i.ToString() + "条记录。标记行：" + drs[i]["标记"].ToString();
					Application.DoEvents();
				}
				tx.Commit();
				session.Close();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
				tx.Rollback();
				session.Close();
			}
		}
		
		
		
	}
}
