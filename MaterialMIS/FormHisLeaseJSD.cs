/*
 * 由SharpDevelop创建。
 * 用户： Dengyong
 * 日期: 2016-12-22
 * 时间: 9:23
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
	/// Description of FormHisLeaseJSD.
	/// </summary>
	public partial class FormHisLeaseJSD : Form
	{
		private DataSet ds1 = new DataSet();		//工程项目
		private DataSet ds2 = new DataSet();		//项目相关单位
		private DataSet ds3 = new DataSet();		//相关单位未结算数据
		
		public FormHisLeaseJSD()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormHisLeaseJSDLoad(object sender, EventArgs e)
		{
			//填充工程项目
			ds1 = BLL.ProjectsBLL.GetAllProjects();
			comboBoxProject.DataSource = ds1.Tables[0];
			comboBoxProject.DisplayMember = "ProjectName";
			comboBoxProject.ValueMember = "ProjectID";
			
			//填充项目供货商
			if(comboBoxProject.SelectedValue != null)
			{
				ds2 = BLL.CompanyBLL.GetProjectCompanies3(Convert.ToInt32(comboBoxProject.SelectedValue));
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
				
				ds2 = BLL.CompanyBLL.GetProjectCompanies3(Convert.ToInt32(comboBoxProject.SelectedValue));
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
				case 3:		//租赁
					ds3 = BLL.StatementListBLL.GetCompanyStatementList(i_ProjectID,i_CompanyID,3);
					dataGridView1.DataSource = ds3.Tables[0];
					SetHeaderLease(dataGridView1);
					break;
			}
		}
		
		//设置标题行
		void SetHeaderLease(DataGridView dv)
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
			dv.Columns[2].Name = "StatementCycle";
			dv.Columns[2].Width = 80;
			dv.Columns[2].DataPropertyName = "StatementCycle";
			
			dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[3].ReadOnly = true;
			dv.Columns[3].HeaderText = "应付合计";
			dv.Columns[3].Name = "BillYF";
			dv.Columns[3].Width = 100;
			dv.Columns[3].DataPropertyName = "BillYF";
			
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
			if(dataGridView1.CurrentRow == null)
				return;
			

			
			DataSet tmpDs = new DataSet();
			DataSet FDataSet = new DataSet();
			DataTable table = new DataTable();
			

			int	i_CompanyID = Convert.ToInt32(comboBoxProjectCompany.SelectedValue);
			int i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue);
			string s_StatementCycle = dataGridView1.CurrentRow.Cells["StatementCycle"].Value.ToString();;
			LeaseHT tLeaseHT = BLL.LeaseBLL.GetLeaseHT(i_ProjectID,i_CompanyID);
			
			tmpDs = BLL.LeaseBLL.GetLeaseAccountDs(i_ProjectID,i_CompanyID,s_StatementCycle);
			table = tmpDs.Tables[0].Copy();
			table.TableName = "LeaseAccount";
			FDataSet.Tables.Add(table);
			
			int i_BillID = 0;
			foreach(DataRow drtmp in table.Rows)
			{
				i_BillID = Convert.ToInt32(drtmp["BillID"]);
			}
			
			tmpDs = BLL.LeaseBLL.GetLeaseAccountList(i_BillID);
			table = tmpDs.Tables[0].Copy();
			table.TableName = "LeaseAccountList";
			FDataSet.Tables.Add(table);
			
			tmpDs = BLL.LeaseBLL.GetLeaseAccountList(0,i_BillID);
			table = tmpDs.Tables[0].Copy();
			table.TableName = "LeaseAccountLeft";
			FDataSet.Tables.Add(table);				
			//将需要结算的数据填写到报表中的表中
				
			FastReport.Report report1 = new FastReport.Report();			
			report1.Load("Reports\\LeaseHisJS.frx");
			report1.RegisterData(FDataSet);
			report1.Show();
			report1.Dispose();
		}
		void 取消结算ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//将选择的结算单进行取消，只能取消最后一期结算
			if(dataGridView1.CurrentRow == null)
				return;		
			
			int	i_CompanyID = Convert.ToInt32(comboBoxProjectCompany.SelectedValue);
			int i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue);
			string s_StatementCycle = dataGridView1.CurrentRow.Cells["StatementCycle"].Value.ToString();;
			//
			BLL.LeaseBLL.DelLeaseAccount(i_ProjectID,i_CompanyID,s_StatementCycle);
			
		}
		
		
			
		
		
	}
}
