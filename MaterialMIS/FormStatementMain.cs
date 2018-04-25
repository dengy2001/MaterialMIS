/*
 * 由SharpDevelop创建。
 * 用户： Dengyong
 * 日期: 2017-01-02
 * 时间: 10:55
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DomainModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormStatementMain.
	/// </summary>
	public partial class FormStatementMain : Form
	{
		private DataSet ds1 = new DataSet();	//工程项目
		private DataSet ds2 = new DataSet();	//公司
		private DataSet ds3 = new DataSet();	//结算列表
		
		private bool ds1OK = false;
		private bool ds2OK = false;
		
		public FormStatementMain()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormStatementMainLoad(object sender, EventArgs e)
		{
			ds1 = BLL.ProjectsBLL.GetAllProjects();
			DataRow dr = ds1.Tables[0].NewRow();
			dr["ProjectID"] = 0;
			dr["ProjectName"] = "所有项目";
			ds1.Tables[0].Rows.Add(dr);
			
			comboBoxProject.DataSource = ds1.Tables[0];
			comboBoxProject.DisplayMember = "ProjectName";
			comboBoxProject.ValueMember = "ProjectID";
			ds1OK = true;
		}
		void ComboBoxProjectSelectedIndexChanged(object sender, EventArgs e)
		{
			if(ds1OK && comboBoxProject.SelectedIndex >=0 )
			{
				int i_ProjectID;
				i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString());
				if(i_ProjectID == 0)
				{
					ds2 = BLL.CompanyBLL.GetCompanyAll();
				}
				else
				{
					ds2 = BLL.CompanyBLL.GetProjectCompanies(i_ProjectID);
				}
				DataRow dr = ds2.Tables[0].NewRow();
				dr["CompanyName"]="所有单位";
				dr["CompanyID"] = 0;
				ds2.Tables[0].Rows.Add(dr);
				comboBoxCompany.DataSource = ds2.Tables[0];
				comboBoxCompany.DisplayMember = "CompanyName";
				comboBoxCompany.ValueMember = "CompanyID";
				ds2OK = true;
			}
		}
		void ComboBoxCompanySelectedIndexChanged(object sender, EventArgs e)
		{
			if(ds2OK && comboBoxCompany.SelectedIndex >= 0)
			{				
				RefreshStatementList();
			}
		}
		
		void RefreshStatementList()
		{
			int i_ProjectID;
			int i_CompanyID;
			i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString());
			i_CompanyID = Convert.ToInt32(comboBoxCompany.SelectedValue.ToString());
			if(i_ProjectID == 0)
			{
				//所有项目
				if(i_CompanyID == 0)
				{
					//所有项目，所有公司
					ds3 = BLL.StatementListBLL.GetCompanyStatementList();
				}
				else
				{
					//所有项目，单公司
					ds3 = BLL.StatementListBLL.GetCompanyStatementList(i_CompanyID);
				}
			}
			else if(i_CompanyID == 0)
			{
				//指定项目的所有公司
				ds3 = BLL.StatementListBLL.GetCompanyStatementListByProjectID(i_ProjectID);
			}
			else
			{
				//指定了项目及公司
				ds3 = BLL.StatementListBLL.GetCompanyStatementList(i_ProjectID,i_CompanyID);
			}
			dataGridView1.DataSource = ds3.Tables[0];
			SetGridView1Header(dataGridView1);
			if(dataGridView1.Rows.Count > 1)
			{
				dataGridView1.DataSource = null;
				TotalRow(dataGridView1);
				dataGridView1.DataSource = ds3.Tables[0];
			}
			
		}
		
		void SetGridView1Header(DataGridView dv)
		{
			if(dv.Rows.Count == 0)
			{
				return;
			}
			dv.AutoGenerateColumns = false;	
			dv.ReadOnly = true;
			dv.AllowUserToAddRows = false;
			dv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
            dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].HeaderText = "项目名称";
			dv.Columns[0].Name = "ProjectName";
            dv.Columns[0].Width = 120;
            dv.Columns[0].DataPropertyName = "ProjectName";
            
            dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].HeaderText = "单位名称";
            dv.Columns[1].Name = "CompanyName";
            dv.Columns[1].Width = 150;
            dv.Columns[1].DataPropertyName = "CompanyName";
            
            dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].HeaderText = "结算内容";
            dv.Columns[2].Name = "StatementMemo";
            dv.Columns[2].Width = 120;
            dv.Columns[2].DataPropertyName = "StatementMemo";
            
            dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd";
            dv.Columns[3].HeaderText = "结算周期";
            dv.Columns[3].Name = "StatementCycle";
            dv.Columns[3].Width = 80;
            dv.Columns[3].DataPropertyName = "StatementCycle";   

			dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dv.Columns[4].DefaultCellStyle.Format = "0.00";
            dv.Columns[4].HeaderText = "应收";
            dv.Columns[4].Name = "BillYS";
            dv.Columns[4].Width = 80;
            dv.Columns[4].DataPropertyName = "BillYS"; 

			dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dv.Columns[5].DefaultCellStyle.Format = "0.00";
            dv.Columns[5].HeaderText = "实收";
            dv.Columns[5].Name = "BillSS";
            dv.Columns[5].Width = 80;
            dv.Columns[5].DataPropertyName = "BillSS";          

			dv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dv.Columns[6].DefaultCellStyle.Format = "0.00";
            dv.Columns[6].HeaderText = "应付";
            dv.Columns[6].Name = "BillYF";
            dv.Columns[6].Width = 80;
            dv.Columns[6].DataPropertyName = "BillYF";    
       
            dv.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dv.Columns[7].DefaultCellStyle.Format = "0.00";
            dv.Columns[7].HeaderText = "实付";
            dv.Columns[7].Name = "BillSF";
            dv.Columns[7].Width = 80;
            dv.Columns[7].DataPropertyName = "BillSF"; 
            
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dv.Columns)
            {
            	if(c.Index>7)
            	{
            		c.Visible = false;
            	}
            }
           
		}
		
		#region 合计行
        public void TotalRow(DataGridView dg)
        {
            dg.Rows.Add();
            DataGridViewRow dgr = dg.Rows[dg.Rows.Count - 1];
            dgr.ReadOnly = true;
            dgr.DefaultCellStyle.BackColor = System.Drawing.Color.Khaki;
            dgr.Cells[0].Value = "合计";
            for (int i = 0; i < dg.Rows.Count - 1; i++)
            {
                dgr.Cells[4].Value = Convert.ToDecimal(dgr.Cells[4].Value) + Convert.ToDecimal(dg.Rows[i].Cells[4].Value);
                dgr.Cells[5].Value = Convert.ToDecimal(dgr.Cells[5].Value) + Convert.ToDecimal(dg.Rows[i].Cells[5].Value);
                dgr.Cells[6].Value = Convert.ToDecimal(dgr.Cells[6].Value) + Convert.ToDecimal(dg.Rows[i].Cells[6].Value);
                dgr.Cells[7].Value = Convert.ToDecimal(dgr.Cells[7].Value) + Convert.ToDecimal(dg.Rows[i].Cells[7].Value);
            }
        }
        #endregion

        
        
		
		
	}
}
