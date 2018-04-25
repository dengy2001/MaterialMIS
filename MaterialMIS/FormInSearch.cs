/*
 * 由SharpDevelop创建。
 * 用户： Dengyong
 * 日期: 2017-10-4
 * 时间: 12:50
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
	/// Description of FormInSearch.
	/// </summary>
	public partial class FormInSearch : Form
	{
		
		private DataSet ds1 = new DataSet();		//工程项目
		private DataSet ds2 = new DataSet();		//查询出来的入库项
		private int i_ProjectID = 0;
		private string sProjectName;
		
		public FormInSearch()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		void FormInSearchLoad(object sender, EventArgs e)
		{
			//填充工程项目
			ds1 = BLL.ProjectsBLL.GetAllProjects();
			comboBoxProject.DataSource = ds1.Tables[0];
			comboBoxProject.DisplayMember = "ProjectName";
			comboBoxProject.ValueMember = "ProjectID";
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			//关闭当前窗口
			((MainForm)(this.ParentForm)).Page_Close(this);
			this.Close();
		}
		void ButtonCXClick(object sender, EventArgs e)
		{
			//将查询结果填充到DataGridView1
			if (string.IsNullOrEmpty(comboBoxProject.ValueMember))
				return;
			if(comboBoxProject.SelectedValue != null)
			{				
				ds2 = BLL.RKBLL.GetInStockItemsAll(Convert.ToInt32(comboBoxProject.SelectedValue));
			}
			dataGridView1.DataSource = ds2.Tables[0];
			SetHeader(dataGridView1);
		}
		
		void SetHeader(DataGridView dv)
		{
			dv.AutoGenerateColumns = false;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
			dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[0].HeaderText = "货品ID";
			dv.Columns[0].Name = "GoodsID";
			dv.Columns[0].Width =80;
			dv.Columns[0].DataPropertyName = "GoodsID";
			
			dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[1].HeaderText = "货品名称";
			dv.Columns[1].Name = "GoodsName";
			dv.Columns[1].Width = 120;
			dv.Columns[1].DataPropertyName = "GoodsName";
			
			dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].ReadOnly = true;
			dv.Columns[2].HeaderText = "规格";
			dv.Columns[2].Name = "GoodsSpec";
			dv.Columns[2].Width = 100;
			dv.Columns[2].DataPropertyName = "GoodsSpec";
			
			dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[3].ReadOnly = true;
			dv.Columns[3].HeaderText = "补充规格";
			dv.Columns[3].Name = "MoreSpec";
			dv.Columns[3].Width = 100;
			dv.Columns[3].DataPropertyName = "MoreSpec";
			
			dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[4].ReadOnly = true;
			dv.Columns[4].HeaderText = "单位";
			dv.Columns[4].Name = "GoodsUnit";
			dv.Columns[4].Width = 60;
			dv.Columns[4].DataPropertyName = "GoodsUnit";
			
			dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[5].DefaultCellStyle.Format = "0.00";
			dv.Columns[5].ReadOnly = true;
			dv.Columns[5].HeaderText = "单价";
			dv.Columns[5].Name = "GoodsPrc";
			dv.Columns[5].Width = 80;
			dv.Columns[5].DataPropertyName = "GoodsPrc";
			
			dv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[6].DefaultCellStyle.Format = "0.00";
			dv.Columns[6].ReadOnly = true;
			dv.Columns[6].HeaderText = "税率";
			dv.Columns[6].Name = "GoodsTaxRate";
			dv.Columns[6].Width = 80;
			dv.Columns[6].DataPropertyName = "GoodsTaxRate";
			
			dv.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[7].DefaultCellStyle.Format = "0.00";
			dv.Columns[7].ReadOnly = true;
			dv.Columns[7].HeaderText = "除税价";
			dv.Columns[7].Name = "GoodsNoTaxPrice";
			dv.Columns[7].Width = 80;
			dv.Columns[7].DataPropertyName = "GoodsNoTaxPrice";
			
			dv.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[8].ReadOnly = true;
			dv.Columns[8].HeaderText = "购入日期";
			dv.Columns[8].Name = "ReceiptDate";
			dv.Columns[8].Width = 100;
			dv.Columns[8].DataPropertyName = "ReceiptDate";
			
			//隐藏不需要的
			foreach(DataGridViewColumn c in dv.Columns)
			{
				if(c.Index>8)
				{
					c.Visible = false;
				}
			}
		}
		void ButtonSCClick(object sender, EventArgs e)
		{
			FastReport.Report report1 = new FastReport.Report();
			report1.Load("Reports\\PriceLimit.frx");

			DataSet FDataSet = new DataSet();
			DataTable table = new DataTable();
			
			table = BLL.GoodsTypeBLL.GetAllGoodsType().Tables[0].Copy();
			table.TableName = "GoodsType";			
			FDataSet.Tables.Add(table);
			
			table = BLL.RKBLL.GetInStockItems(Convert.ToInt32(comboBoxProject.SelectedValue)).Tables[0].Copy();
			table.TableName = "ReceiptItems";			
			FDataSet.Tables.Add(table);
			
			sProjectName = comboBoxProject.Text;
			report1.SetParameterValue("ProjectName",sProjectName);
			
			DataRelation dsdr = new DataRelation("R1", FDataSet.Tables["GoodsType"].Columns["GoodsTypeID"], FDataSet.Tables["ReceiptItems"].Columns["GoodsTypeID"]);  
			FDataSet.Relations.Add(dsdr);  

			
			report1.RegisterData(FDataSet);
			report1.Show();
			report1.Dispose();
		}
		
	}
}
