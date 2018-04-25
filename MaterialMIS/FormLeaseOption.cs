/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-18
 * Time: 15:25
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
	/// Description of FormLeaseOption.
	/// </summary>
	public partial class FormLeaseOption : Form
	{
		private DataSet ds1 = new DataSet();	//工程项目
		private DataSet ds2 = new DataSet();	//租赁合同
		private DataSet ds3 = new DataSet();	//租赁合同租赁项
		
		public FormLeaseOption()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void 新租赁合同ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormLeaseHT tF = new FormLeaseHT();
			tF.Text = "租赁合同-新增";
			if(comboBoxProject.SelectedIndex >=0)
			{
				tF.i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue);
				tF.s_ProjectName = comboBoxProject.SelectedText.ToString();
				tF.ShowDialog();
				//刷新租赁合同显示
				RefreshLeaseHT();
			}
			
		}
		
		//刷新租赁合同
		void RefreshLeaseHT()
		{
			//表头
			ds2 = BLL.LeaseBLL.GetProjectLease(Convert.ToInt32(comboBoxProject.SelectedValue));
			dataGridView1.DataSource = ds2.Tables[0];
			SetGridView1Header(dataGridView1);
		}
		void FormLeaseOptionLoad(object sender, EventArgs e)
		{
			//填充工程项目
			ds1 = BLL.ProjectsBLL.GetAllProjects();
			comboBoxProject.DataSource = ds1.Tables[0];
			comboBoxProject.DisplayMember = "ProjectName";
			comboBoxProject.ValueMember = "ProjectID";
			
			//刷新租赁合同显示
			RefreshLeaseHT();
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
			dv.Columns[0].HeaderText = "HTID";
			dv.Columns[0].Name = "HTID";
            dv.Columns[0].Width = 0;
            dv.Columns[0].DataPropertyName = "HTID";
            dv.Columns[0].Visible = false;
            
            dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].HeaderText = "合同编号";
            dv.Columns[1].Name = "HTNumber";
            dv.Columns[1].Width = 100;
            dv.Columns[1].DataPropertyName = "HTNumber";
            
            dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].HeaderText = "单位名称";
            dv.Columns[2].Name = "CompanyName";
            dv.Columns[2].Width = 150;
            dv.Columns[2].DataPropertyName = "CompanyName";
            
            dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].HeaderText = "合同名称";
            dv.Columns[3].Name = "HTName";
            dv.Columns[3].Width = 120;
            dv.Columns[3].DataPropertyName = "HTName";   

			dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].HeaderText = "算头";
            dv.Columns[4].Name = "IncludeSDate";
            dv.Columns[4].Width = 60;
            dv.Columns[4].DataPropertyName = "IncludeSDate"; 

			dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].HeaderText = "算尾";
            dv.Columns[5].Name = "IncludeEDate";
            dv.Columns[5].Width = 60;
            dv.Columns[5].DataPropertyName = "IncludeEDate";             
                        
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dv.Columns)
            {
            	if(c.Index>5)
            	{
            		c.Visible = false;
            	}
            }
           
		}
		void DataGridView1CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			//格式化显示算头和算尾
			if(e.ColumnIndex == 4 || e.ColumnIndex == 5)
			{
				if(e.Value == null)
				{
					return;
				}
				if(e.Value.ToString() == "0")
				{
					e.Value = "否";
				}
				else
				{
					e.Value = "是";
				}
			}
		}
		void 修改租赁合同ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormLeaseHT tF = new FormLeaseHT();
			tF.Text = "租赁合同-修改";
			if(comboBoxProject.SelectedIndex >=0)
			{
				tF.i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue);
				tF.s_ProjectName = comboBoxProject.SelectedText.ToString();
				tF.i_HTID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["HTID"].Value);
				tF.ShowDialog();
				//刷新租赁合同显示
				RefreshLeaseHT();
			}
		}
		void 新增租赁项ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormLeaseItem tF = new FormLeaseItem();
			tF.Text = "租赁项信息-新增";
			tF.i_HTID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["HTID"].Value);
			if(dataGridView1.CurrentRow != null)
			{
				tF.ShowDialog();
			}
			//刷新租赁合同项
			RefreshLeaseItems();

		}
		void DataGridView1SelectionChanged(object sender, EventArgs e)
		{	
			//刷新租赁合同项
			RefreshLeaseItems();
		}
		//刷新租赁合同项
		void RefreshLeaseItems()
		{
			//表头
			int i = 0;
			i = Convert.ToInt32(dataGridView1.CurrentRow.Cells["HTID"].Value);
			ds3 = BLL.LeaseBLL.GetLeaseItemsByHTID(i);
			dataGridView2.DataSource = ds3.Tables[0];
			SetGridView2Header(dataGridView2);
		}
		
		void SetGridView2Header(DataGridView dv)
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
			dv.Columns[0].HeaderText = "ItemsID";
			dv.Columns[0].Name = "ItemsID";
            dv.Columns[0].Width = 0;
            dv.Columns[0].DataPropertyName = "ItemsID";
            dv.Columns[0].Visible = false;
            
            dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].HeaderText = "租赁项名称";
            dv.Columns[1].Name = "MName";
            dv.Columns[1].Width = 100;
            dv.Columns[1].DataPropertyName = "MName";
            
            dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].HeaderText = "租赁单位";
            dv.Columns[2].Name = "LeaseUnit";
            dv.Columns[2].Width = 80;
            dv.Columns[2].DataPropertyName = "LeaseUnit";
            
            dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].HeaderText = "租赁单价";
            dv.Columns[3].Name = "LeasePrice";
            dv.Columns[3].Width = 80;
            dv.Columns[3].DataPropertyName = "LeasePrice";   

			dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].HeaderText = "装卸单位";
            dv.Columns[4].Name = "LoadingUnit";
            dv.Columns[4].Width = 80;
            dv.Columns[4].DataPropertyName = "LoadingUnit"; 

			dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].HeaderText = "装卸因子";
            dv.Columns[5].Name = "LoadingFactor";
            dv.Columns[5].Width = 80;
            dv.Columns[5].DataPropertyName = "LoadingFactor";     

			dv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[6].HeaderText = "装卸单价";
            dv.Columns[6].Name = "LoadingPrice";
            dv.Columns[6].Width = 80;
            dv.Columns[6].DataPropertyName = "LoadingPrice";  

			dv.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[7].HeaderText = "维修单位";
            dv.Columns[7].Name = "RepairUnit";
            dv.Columns[7].Width = 80;
            dv.Columns[7].DataPropertyName = "RepairUnit";        

			dv.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[8].HeaderText = "维修因子";
            dv.Columns[8].Name = "RepairFactor";
            dv.Columns[8].Width = 80;
            dv.Columns[8].DataPropertyName = "RepairFactor";     

			dv.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[9].HeaderText = "维修单价";
            dv.Columns[9].Name = "RepairPrice";
            dv.Columns[9].Width = 80;
            dv.Columns[9].DataPropertyName = "RepairPrice";         
            
            //隐藏
            dv.Columns[10].Name = "HTID";
            dv.Columns[10].Width = 0;
            dv.Columns[10].DataPropertyName = "HTID";         
                        
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dv.Columns)
            {
            	if(c.Index>9)
            	{
            		c.Visible = false;
            	}
            }
           
		}
		void 修改租赁项ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormLeaseItem tF = new FormLeaseItem();
			tF.Text = "租赁项信息-修改";
			
			if(dataGridView1.CurrentRow != null)
			{
				tF.i_HTID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["HTID"].Value);
				tF.i_ItemsID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ItemsID"].Value);
				tF.ShowDialog();
				//刷新租赁合同显示
				RefreshLeaseItems();
			}			
		
		}
		void 删除租赁项ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//删除租赁项
			if(dataGridView2.CurrentRow != null)
			{
				DialogResult result;
				int iItemsID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ItemsID"].Value.ToString());
				string sMName = dataGridView2.CurrentRow.Cells["MName"].Value.ToString();

                result = MessageBox.Show("您确认删除当前选中的【" + sMName + "】租赁项吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                	try
                	{
	                    // 删除指定的用户
	                    BLL.LeaseBLL.DelLeaseItem(iItemsID);
	                   	//刷新租赁合同显示
						RefreshLeaseItems();
	                   
						return;
                	}                    
                	catch(Exception e1)
                    {
                        MessageBox.Show(e1.Message);
                        return;
                    }
					
                }
                //刷新租赁合同项
				RefreshLeaseItems();
			}
		}
		void 删除租赁合同ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(dataGridView1.CurrentRow != null)
			{
				DialogResult result;
				int iHTID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["HTID"].Value.ToString());
				string sHTName = dataGridView1.CurrentRow.Cells["HTName"].Value.ToString();

                result = MessageBox.Show("您确认删除当前选中的【" + sHTName + "】租赁合同吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                	try
                	{
	                    // 删除指定的租赁合同
	                    BLL.LeaseBLL.DelLeaseHT(iHTID);
	                   	//刷新租赁合同显示
						RefreshLeaseHT();
	                   
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
