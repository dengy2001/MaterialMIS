/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-29
 * 时间: 13:00
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DomainModel;
using BLL;
using System.Text.RegularExpressions;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormHisJSD.
	/// </summary>
	public partial class FormHisJSD : Form
	{
		private DataSet ds1 = new DataSet();		//工程项目
		private DataSet ds2 = new DataSet();		//项目相关单位
		private DataSet ds3 = new DataSet();		//相关单位未结算数据
		
		public FormHisJSD()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormHisJSDLoad(object sender, EventArgs e)
		{
			//填充工程项目
			ds1 = BLL.ProjectsBLL.GetAllProjects();
			comboBoxProject.DataSource = ds1.Tables[0];
			comboBoxProject.DisplayMember = "ProjectName";
			comboBoxProject.ValueMember = "ProjectID";
			
			//填充项目供货商
			if(comboBoxProject.SelectedValue != null)
			{
				ds2 = BLL.CompanyBLL.GetProjectCompanies1(Convert.ToInt32(comboBoxProject.SelectedValue));
				comboBoxProjectCompany.DataSource = ds2.Tables[0];
				comboBoxProjectCompany.DisplayMember = "CompanyName";
				comboBoxProjectCompany.ValueMember = "CompanyID";
			}
		}
		void ComboBoxProjectSelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(comboBoxProject.ValueMember))
				return;
			if(comboBoxProject.SelectedValue != null)
			{
				
				ds2 = BLL.CompanyBLL.GetProjectCompanies1(Convert.ToInt32(comboBoxProject.SelectedValue));
				comboBoxProjectCompany.DataSource = ds2.Tables[0];
				comboBoxProjectCompany.DisplayMember = "CompanyName";
				comboBoxProjectCompany.ValueMember = "CompanyID";
			}
		}
		void ButtonCXClick(object sender, EventArgs e)
		{
			int	i_CompanyID = Convert.ToInt32(comboBoxProjectCompany.SelectedValue);
			int i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue);
			
			Companies tC = new Companies();
			tC = BLL.CompanyBLL.GetCompany(i_CompanyID);
			switch(tC.CompanyType)
			{
				case 0:		//客户
				case 2:		//班组
					ds3 = BLL.CKBLL.GetOutStockYJ(i_ProjectID,i_CompanyID,"已结算");
					dataGridView1.DataSource = ds3.Tables[0];
					SetHeaderCK(dataGridView1);
					break;
				case 1:		//供货商
					ds3 = BLL.RKBLL.GetReceipt(i_ProjectID,i_CompanyID,"已结算");
					dataGridView1.DataSource = ds3.Tables[0];
					SetHeaderRK(dataGridView1);
					break;
			}
		}
		
		//设置标题行
		void SetHeaderRK(DataGridView dv)
		{
			dv.AutoGenerateColumns = false;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
			dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[0].HeaderText = "项目";
			dv.Columns[0].Name = "ProjectName";
			dv.Columns[0].Width =120;
			dv.Columns[0].DataPropertyName = "ProjectName";
			
			dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[1].HeaderText = "单位名称";
			dv.Columns[1].Name = "CompanyName";
			dv.Columns[1].Width = 120;
			dv.Columns[1].DataPropertyName = "CompanyName";
			
			dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].ReadOnly = true;
			dv.Columns[2].HeaderText = "结算周期";
			dv.Columns[2].Name = "BillCycle";
			dv.Columns[2].Width = 80;
			dv.Columns[2].DataPropertyName = "BillCycle";
			
			dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[3].DefaultCellStyle.Format = "0.00";
			dv.Columns[3].ReadOnly = true;
			dv.Columns[3].HeaderText = "应付合计";
			dv.Columns[3].Name = "SUM_ReceiptDiscAmt";
			dv.Columns[3].Width = 100;
			dv.Columns[3].DataPropertyName = "SUM_ReceiptDiscAmt";
			
			//隐藏不需要的
			foreach(DataGridViewColumn c in dv.Columns)
			{
				if(c.Index>3)
				{
					c.Visible = false;
				}
			}
		}
		
		
		void SetHeaderCK(DataGridView dv)
		{
			dv.AutoGenerateColumns = false;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
			dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[0].HeaderText = "项目";
			dv.Columns[0].Name = "ProjectName";
			dv.Columns[0].Width =120;
			dv.Columns[0].DataPropertyName = "ProjectName";
			
			dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[1].HeaderText = "单位名称";
			dv.Columns[1].Name = "CompanyName";
			dv.Columns[1].Width = 120;
			dv.Columns[1].DataPropertyName = "CompanyName";
			
			dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].ReadOnly = true;
			dv.Columns[2].HeaderText = "结算周期";
			dv.Columns[2].Name = "BillCycle";
			dv.Columns[2].Width = 80;
			dv.Columns[2].DataPropertyName = "BillCycle";
			
			dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[3].ReadOnly = true;
			dv.Columns[3].HeaderText = "领用合计";
			dv.Columns[3].Name = "SUM_OutBillAmt";
			dv.Columns[3].Width = 100;
			dv.Columns[3].DataPropertyName = "SUM_OutBillAmt";
			
			//隐藏不需要的
			foreach(DataGridViewColumn c in dv.Columns)
			{
				if(c.Index>3)
				{
					c.Visible = false;
				}
			}
		}
		void ButtonPrintClick(object sender, EventArgs e)
		{
			//预览结算单
			if(dataGridView1.CurrentRow == null)
				return;
			
			int	i_CompanyID = Convert.ToInt32(comboBoxProjectCompany.SelectedValue);
			int i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue);
			string sBillCycle = dataGridView1.CurrentRow.Cells["BillCycle"].Value.ToString();
			DataSet tmpDs = new DataSet();
			DataSet FDataSet = new DataSet();
			DataTable table = new DataTable();
			//DataRelation dr;
			FastReport.Report report1 = new FastReport.Report();
			
			Companies tC = new Companies();
			tC = BLL.CompanyBLL.GetCompany(i_CompanyID);
			switch(tC.CompanyType)
			{
				case 0:		//客户
				case 2:		//班组
					tmpDs= BLL.CompanyBLL.GetAllCompany(i_CompanyID);
					//					
					report1.Load("Reports\\JSD1.frx");

					
					table = tmpDs.Tables[0].Copy();
					table.TableName = "Companies";
					FDataSet.Tables.Add(table);
					
					tmpDs = BLL.ProjectsBLL.GetAllProject(i_ProjectID);
					table = tmpDs.Tables[0].Copy();
					table.TableName = "Projects";
					FDataSet.Tables.Add(table);
					
					tmpDs = BLL.CKBLL.GetOutStocks(i_ProjectID,i_CompanyID,"已结算",sBillCycle);
					table = tmpDs.Tables[0].Copy();
					table.TableName = "OutStock";
					FDataSet.Tables.Add(table);
					
					tmpDs = BLL.CKBLL.GetOutStockItems(i_ProjectID,i_CompanyID,"已结算",sBillCycle);
					table = tmpDs.Tables[0].Copy();
					table.TableName = "OutStockItems";
					FDataSet.Tables.Add(table);			
					
					report1.RegisterData(FDataSet);
					report1.Show();
					report1.Dispose();
					break;
				case 1:		//供货商
					tmpDs= BLL.CompanyBLL.GetAllCompany(i_CompanyID);
					report1.Load("Reports\\JSD.frx");
					
					table = tmpDs.Tables[0].Copy();
					table.TableName = "Companies";
					FDataSet.Tables.Add(table);
					
					tmpDs = BLL.ProjectsBLL.GetAllProject(i_ProjectID);
					table = tmpDs.Tables[0].Copy();
					table.TableName = "Projects";
					FDataSet.Tables.Add(table);
					
					tmpDs = BLL.ReceiptBLL.GetReceipt(i_ProjectID,i_CompanyID,"已结算",sBillCycle);
					table = tmpDs.Tables[0].Copy();
					table.TableName = "Receipt";
					FDataSet.Tables.Add(table);
					
					tmpDs = BLL.ReceiptBLL.GetReceiptItems(i_ProjectID,i_CompanyID,"已结算",sBillCycle);
					table = tmpDs.Tables[0].Copy();
					table.TableName = "ReceiptItems";
					FDataSet.Tables.Add(table);			

					
					report1.RegisterData(FDataSet);
					report1.Show();
					report1.Dispose();
					break;
			}
		}
		void ComboBoxProjectCompanySelectedIndexChanged(object sender, EventArgs e)
		{
			dataGridView1.DataSource = null;
			//dataGridView1.Rows.Clear();
		}
		void 取消结算ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(dataGridView1.CurrentRow == null)
				return;
			
			int	i_CompanyID = Convert.ToInt32(comboBoxProjectCompany.SelectedValue);
			int i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue);
			string s_BillCycle = dataGridView1.CurrentRow.Cells["BillCycle"].Value.ToString();
			
			Companies tC = new Companies();
			tC = BLL.CompanyBLL.GetCompany(i_CompanyID);
			switch(tC.CompanyType)
			{
				case 0:		//客户
				case 2:		//班组
					BLL.CKBLL.OutStockYJReverse(i_ProjectID,i_CompanyID,s_BillCycle);
					ds3 = BLL.CKBLL.GetOutStockYJ(i_ProjectID,i_CompanyID,"已结算");
					dataGridView1.DataSource = ds3.Tables[0];
					SetHeaderCK(dataGridView1);
					break;
				case 1:		//供货商
					BLL.RKBLL.ReceiptYJReverse(i_ProjectID,i_CompanyID,s_BillCycle);
					ds3 = BLL.RKBLL.GetReceipt(i_ProjectID,i_CompanyID,"已结算");
					dataGridView1.DataSource = ds3.Tables[0];
					SetHeaderRK(dataGridView1);
					break;
			}
		}
		
	}
}
