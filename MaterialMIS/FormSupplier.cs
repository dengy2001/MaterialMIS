/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-08-11
 * 时间: 10:58
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DomainModel;
using BLL;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormSupplier.
	/// </summary>
	public partial class FormSupplier : Form
	{
		private DataSet ds1 = new DataSet();		//单位
		private DataSet ds2 = new DataSet();		//项目
		private DataSet ds3 = new DataSet();
		
		public FormSupplier()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		void FormSupplierLoad(object sender, EventArgs e)
		{
			//供应商
			RefreshCompanies();	
			SetCompaniesColumnHeader(dataGridViewCompanies);			
			//添加项目
			RefreshProject();
			RefreshProjectCompnies(0);		//在空数据时要能工作
			SetCompaniesColumnHeader(dataGridViewProjectCompanies);		
			
		}
		
		void RefreshProject()
		{
			//添加到项目下拉框
			ds2 = BLL.ProjectsBLL.GetAllProjects();
			comboBox1.DataSource = ds2.Tables[0];
			comboBox1.DisplayMember = "ProjectName";
			comboBox1.ValueMember = "ProjectID";
		}
		
		void RefreshCompanies()
		{
			ds1 = BLL.CompanyBLL.GetCompanyAll();
			dataGridViewCompanies.DataSource = ds1.Tables[0];			
		}
		
			
		void BtnAddToProjectClick(object sender, EventArgs e)
		{
			//加入到项目相关单位
			ProjectCompanies newPc = new ProjectCompanies();
			ProjectCompany tPc = new ProjectCompany();
			if(comboBox1.SelectedValue != null && comboBox1.SelectedValue.GetType()!=typeof(DataRowView))
			{
				tPc.ProjectID = Convert.ToInt32(comboBox1.SelectedValue);
			}
			else
			{
				return;
			}
			if(dataGridViewCompanies.CurrentRow != null)
			{
				tPc.CompanyID = Convert.ToInt32(dataGridViewCompanies.CurrentRow.Cells["CompanyID"].Value);
				newPc.CompanyType = Convert.ToInt32(dataGridViewCompanies.CurrentRow.Cells["CompanyType"].Value);
			}
			newPc.Ps = tPc;
			
			BLL.CompanyBLL.AddProjectCompany(newPc);
			
			//刷新项目供应商
			RefreshProjectCompnies(newPc.Ps.ProjectID);
		}
		
		void RefreshProjectCompnies(int iProjectID)
		{
			ds3 = BLL.CompanyBLL.GetProjectCompanies(iProjectID);
			dataGridViewProjectCompanies.DataSource = ds3.Tables[0];
		}
		
		void ComboBox1SelectedValueChanged(object sender, EventArgs e)
		{
			//刷新选择项目相关单位
			if( comboBox1.SelectedValue != null && comboBox1.SelectedValue.GetType()!=typeof(DataRowView) )
			{
				RefreshProjectCompnies(Convert.ToInt32(comboBox1.SelectedValue));
			}
		}
		
		void BtnDelFromProjectClick(object sender, EventArgs e)
		{
			//从项目供应商中移除
			ProjectCompanies newPc = new ProjectCompanies();
			ProjectCompany tPc = new ProjectCompany();
			if(comboBox1.SelectedValue != null && comboBox1.SelectedValue.GetType()!=typeof(DataRowView) )
			{
				tPc.ProjectID = Convert.ToInt32(comboBox1.SelectedValue);
			}
			else
			{
				return;
			}
			if(dataGridViewProjectCompanies.CurrentRow != null)
			{
				tPc.CompanyID = Convert.ToInt32(dataGridViewProjectCompanies.CurrentRow.Cells["CompanyID"].Value);
				newPc.CompanyType = Convert.ToInt32(dataGridViewProjectCompanies.CurrentRow.Cells["CompanyType"].Value);
			}
			else
			{
				return;
			}
			newPc.Ps = tPc;
			
			BLL.CompanyBLL.RemoveProjectCompany(newPc);
			
			//刷新项目相关单位
			RefreshProjectCompnies(newPc.Ps.ProjectID);
		}
		void SetCompaniesColumnHeader(DataGridView dv)
		{
			dv.AutoGenerateColumns = false;	
			//dataGridViewProjects.ColumnCount = 3;
			dv.ReadOnly = true;
			dv.AllowUserToAddRows = false;
			dv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
            dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].HeaderText = "单位ID";
			dv.Columns[0].Name = "CompanyID";
            dv.Columns[0].Width = 80;
            dv.Columns[0].DataPropertyName = "CompanyID";
            
            dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].HeaderText = "单位名称";
            dv.Columns[1].Name = "CompanyName";
            dv.Columns[1].Width = 200;
            dv.Columns[1].DataPropertyName = "CompanyName";
            
            dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].HeaderText = "单位类别";
            dv.Columns[2].Name = "CompanyType";
            dv.Columns[2].Width = 100;
            dv.Columns[2].DataPropertyName = "CompanyType";
             //隐藏不需要的
            foreach(DataGridViewColumn c in dv.Columns)
            {
            	if(c.Index>2)
            	{
            		c.Visible = false;
            	}
            }
           
		}
		void DataGridViewCompaniesCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if(2 == e.ColumnIndex)
			{
				switch(Convert.ToInt32(e.Value))
				{
					case 0:
						e.Value = "客户";
						break;
					case 1:
						e.Value = "供应商";
						break;
					case 2:
						e.Value = "班组";
						break;
					case 3:
						e.Value = "租赁";
						break;
				}

			}
		}
		void DataGridViewProjectCompaniesCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if(2 == e.ColumnIndex)
			{
				switch(Convert.ToInt32(e.Value))
				{
					case 0:
						e.Value = "客户";
						break;
					case 1:
						e.Value = "供应商";
						break;
					case 2:
						e.Value = "班组";
						break;
				}

			}
		}
		
		
		
	}
}
