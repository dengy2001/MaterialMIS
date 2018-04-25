/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-24
 * Time: 11:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
	/// Description of FormLeaseRecord.
	/// </summary>
	public partial class FormLeaseRecord : Form
	{
		private DataSet ds1 = new DataSet();	//工程项目
		private DataSet ds2 = new DataSet();	//公司
		private DataSet ds3 = new DataSet();	//租赁记录
		
		
		public FormLeaseRecord()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormLeaseRecordLoad(object sender, EventArgs e)
		{
			ds1 = BLL.ProjectsBLL.GetAllProjects();
			comboBoxProject.DataSource = ds1.Tables[0];
			comboBoxProject.DisplayMember = "ProjectName";
			comboBoxProject.ValueMember = "ProjectID";
		}

		void ComboBoxProjectSelectionChangeCommitted(object sender, EventArgs e)
		{
			if(comboBoxProject.SelectedIndex >=0 )
			{
				int i_ProjectID;
				i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString());
				ds2 = BLL.LeaseBLL.GetProjectLease(i_ProjectID);
				comboBoxCompany.DataSource = ds2.Tables[0];
				comboBoxCompany.DisplayMember = "CompanyName";
				comboBoxCompany.ValueMember = "CompanyID";
			}
		}
		void ComboBoxCompanySelectionChangeCommitted(object sender, EventArgs e)
		{
			if(comboBoxCompany.SelectedIndex >= 0)
			{
				
				RefreshLeaseRecord();
			}
			else
			{
				SetGridView1Header(dataGridView1);
			}
		}
		//刷新租赁记录
		void RefreshLeaseRecord()
		{
			int i_ProjectID;
			int i_CompanyID;
			i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString());
			i_CompanyID = Convert.ToInt32(comboBoxCompany.SelectedValue.ToString());
			ds3 = BLL.LeaseBLL.GetLeaseRecord1(i_ProjectID,i_CompanyID);
			dataGridView1.DataSource = ds3.Tables[0];
			SetGridView1Header(dataGridView1);
		}
		
		void SetGridView1Header(DataGridView dv)
		{
//			if(dv.Rows.Count == 0)
//			{
//				return;
//			}
			dv.AutoGenerateColumns = false;	
			dv.ReadOnly = true;
			dv.AllowUserToAddRows = false;
			dv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
            dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].HeaderText = "RID";
			dv.Columns[0].Name = "RID";
            dv.Columns[0].Width = 60;
            dv.Columns[0].DataPropertyName = "RID";
            
            dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].HeaderText = "租赁日期";
            dv.Columns[1].Name = "LeaseDate";
            dv.Columns[1].Width = 100;
            dv.Columns[1].DataPropertyName = "LeaseDate";
            
            dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].HeaderText = "租赁项";
            dv.Columns[2].Name = "MName";
            dv.Columns[2].Width = 150;
            dv.Columns[2].DataPropertyName = "MName";
            
            dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].HeaderText = "单位";
            dv.Columns[3].Name = "LeaseUnit";
            dv.Columns[3].Width = 80;
            dv.Columns[3].DataPropertyName = "LeaseUnit";   

			dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].HeaderText = "数量";
            dv.Columns[4].Name = "Quality";
            dv.Columns[4].Width = 80;
            dv.Columns[4].DataPropertyName = "Quality"; 

			dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].HeaderText = "经手人";
            dv.Columns[5].Name = "Handler";
            dv.Columns[5].Width = 80;
            dv.Columns[5].DataPropertyName = "Handler";      

			dv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[6].HeaderText = "备注";
            dv.Columns[6].Name = "Abstract";
            dv.Columns[6].Width = 120;
            dv.Columns[6].DataPropertyName = "Abstract";                  
                        
 			dv.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[7].HeaderText = "状态";
            dv.Columns[7].Name = "LeaseStatus";
            dv.Columns[7].Width = 80;
            dv.Columns[7].DataPropertyName = "LeaseStatus";   
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dv.Columns)
            {
            	if(c.Index>7)
            	{
            		c.Visible = false;
            	}
            }
           
		}
		void 新租赁记录ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormLeaseRecord1 tF = new FormLeaseRecord1();
			tF.Text = "租赁记录-新增";
			
			int i_ProjectID;
			int i_CompanyID;
			if(comboBoxProject.SelectedValue == null || comboBoxCompany.SelectedValue == null)
				return;
			
			i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString());
			i_CompanyID = Convert.ToInt32(comboBoxCompany.SelectedValue.ToString());
			LeaseHT tLeaseHT = BLL.LeaseBLL.GetLeaseHT(i_ProjectID,i_CompanyID);
			tF.i_HTID = tLeaseHT.HTID;
			tF.ShowDialog();
			//刷新
			RefreshLeaseRecord();
		}
		void 修改租赁记录ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(dataGridView1.CurrentRow != null)
			{
				FormLeaseRecord1 tF = new FormLeaseRecord1();
				tF.Text = "租赁记录-修改";
				
				int i_ProjectID;
				int i_CompanyID;
//				int i_RID;
				i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString());
				i_CompanyID = Convert.ToInt32(comboBoxCompany.SelectedValue.ToString());
				LeaseHT tLeaseHT = BLL.LeaseBLL.GetLeaseHT(i_ProjectID,i_CompanyID);
				tF.i_HTID = tLeaseHT.HTID;
				tF.i_RID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["RID"].Value);
				tF.ShowDialog();
				//刷新
				RefreshLeaseRecord();
			}
		}
		void 删除租赁记录ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(dataGridView1.CurrentRow != null)
			{
				DialogResult result;
				int iRID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["RID"].Value.ToString());
				string sHTName = iRID.ToString();

                result = MessageBox.Show("您确认删除当前选中的【" + sHTName + "】租赁记录吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                	try
                	{
	                    // 删除指定的租赁合同
	                    BLL.LeaseBLL.DelLeaseRecord(iRID);
	                   	//刷新租赁记录显示
						RefreshLeaseRecord();
	                   
						return;
                	}                    
                	catch(Exception e1)
                    {
                        MessageBox.Show(e1.Message);
                        return;
                    }

                }
			}
		}
		
		
		
	}
}
