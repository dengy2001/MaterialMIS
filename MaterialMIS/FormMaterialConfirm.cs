/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-28
 * 时间: 10:13
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
	/// Description of FormMaterialComfirm.
	/// </summary>
	public partial class FormMaterialConfirm : Form
	{
		private DataSet ds1 = new DataSet();		//工程项目
		private DataSet ds2 = new DataSet();		//项目相关单位
		private DataSet ds3 = new DataSet();		//相关单位未结算数据
		private DataSet ds4 = new DataSet();		//放出库或入库记录项
		
		public FormMaterialConfirm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormMaterialConfirmLoad(object sender, EventArgs e)
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
			
			//填充datagridview
			if (string.IsNullOrEmpty(comboBoxProjectCompany.ValueMember))
				return;
			if(comboBoxProjectCompany.SelectedValue != null)
			{
				int i_CompanyID = Convert.ToInt32(comboBoxProjectCompany.SelectedValue);
				FillDataGridView(i_CompanyID);
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
		
		//填充datagridview
		void FillDataGridView(int i_CompanyID)
		{
			int i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue);
			
			Companies tC = new Companies();
			tC = BLL.CompanyBLL.GetCompany(i_CompanyID);
			switch(tC.CompanyType)
			{
				case 0:		//客户
				case 2:		//班组
					ds3 = BLL.CKBLL.GetOutStocks(i_ProjectID,i_CompanyID,"已记账");
					dataGridView1.DataSource = ds3.Tables[0];
					FillConfirmCK(dataGridView1);
					ds4 = BLL.CKBLL.GetOutStockItems(i_ProjectID,i_CompanyID,"已记账");
					dataGridView2.DataSource = ds4.Tables[0];
					FillOutStockItems(dataGridView2);
					break;
				case 1:		//供货商
					ds3 = BLL.ReceiptBLL.GetCommMaterialRecord(i_ProjectID,i_CompanyID,"已记账");
					dataGridView1.DataSource = ds3.Tables[0];
					FillConfirmRK(dataGridView1);
					ds4 = BLL.RKBLL.GetReceiptItems(i_ProjectID,i_CompanyID,"已记账");
					dataGridView2.DataSource = ds4.Tables[0];
					FillReceiptItems(dataGridView2);
					break;
			}
			
		}
		
		//填充出库项
		void FillOutStockItems(DataGridView dv)
		{
			dv.AutoGenerateColumns = false;
			//dataGridViewProjects.ColumnCount = 3;
			//dataGridView1.ReadOnly = true;
			//dataGridView1.AllowUserToAddRows = false;
			//dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
			dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[0].HeaderText = "货品名称";
			dv.Columns[0].Name = "GoodsName";
			dv.Columns[0].Width =120;
			dv.Columns[0].DataPropertyName = "GoodsName";
			
			dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[1].HeaderText = "规格型号";
			dv.Columns[1].Name = "GoodsSpec";
			dv.Columns[1].Width = 100;
			dv.Columns[1].DataPropertyName = "GoodsSpec";
			
			dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].ReadOnly = true;
			dv.Columns[2].HeaderText = "单位";
			dv.Columns[2].Name = "GoodsUnit";
			dv.Columns[2].Width = 80;
			dv.Columns[2].DataPropertyName = "GoodsUnit";
			
			dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[3].ReadOnly = true;
			dv.Columns[3].HeaderText = "数量";
			dv.Columns[3].Name = "GoodsQty";
			dv.Columns[3].Width = 80;
			dv.Columns[3].DataPropertyName = "GoodsQty";
			
			dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[4].ReadOnly = true;
			dv.Columns[4].HeaderText = "单价";
			dv.Columns[4].Name = "GoodsPrc";
			dv.Columns[4].Width = 80;
			dv.Columns[4].DataPropertyName = "GoodsPrc";
			
			dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[5].ReadOnly = true;
			dv.Columns[5].HeaderText = "金额";
			dv.Columns[5].Name = "GoodsAmt";
			dv.Columns[5].Width = 80;
			dv.Columns[5].DataPropertyName = "GoodsAmt";
			
			
			//隐藏不需要的
			foreach(DataGridViewColumn c in dv.Columns)
			{
				if(c.Index>5)
				{
					c.Visible = false;
				}
			}
		}
		
		
		//填充入库项
		void FillReceiptItems(DataGridView dv)
		{
			dv.AutoGenerateColumns = false;
			//dataGridViewProjects.ColumnCount = 3;
			//dataGridView1.ReadOnly = true;
			//dataGridView1.AllowUserToAddRows = false;
			//dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
			dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[0].HeaderText = "货品名称";
			dv.Columns[0].Name = "GoodsName";
			dv.Columns[0].Width =120;
			dv.Columns[0].DataPropertyName = "GoodsName";
			
			dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[1].HeaderText = "规格型号";
			dv.Columns[1].Name = "GoodsSpec";
			dv.Columns[1].Width = 100;
			dv.Columns[1].DataPropertyName = "GoodsSpec";
			
			dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].ReadOnly = true;
			dv.Columns[2].HeaderText = "单位";
			dv.Columns[2].Name = "GoodsUnit";
			dv.Columns[2].Width = 80;
			dv.Columns[2].DataPropertyName = "GoodsUnit";
			
			dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[3].ReadOnly = true;
			dv.Columns[3].HeaderText = "数量";
			dv.Columns[3].Name = "GoodsQty";
			dv.Columns[3].Width = 80;
			dv.Columns[3].DataPropertyName = "GoodsQty";
			
			dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[4].ReadOnly = true;
			dv.Columns[4].HeaderText = "单价";
			dv.Columns[4].Name = "GoodsPrc";
			dv.Columns[4].Width = 80;
			dv.Columns[4].DataPropertyName = "GoodsPrc";
			
			dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[5].ReadOnly = true;
			dv.Columns[5].HeaderText = "运费";
			dv.Columns[5].Name = "GoodsYF";
			dv.Columns[5].Width = 80;
			dv.Columns[5].DataPropertyName = "GoodsYF";
			
			dv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[6].ReadOnly = true;
			dv.Columns[6].Visible = true;
			dv.Columns[6].HeaderText = "金额";
			dv.Columns[6].Name = "GoodsAmt";
			dv.Columns[6].Width = 80;
			dv.Columns[6].DataPropertyName = "GoodsAmt";
			
			
			//隐藏不需要的
			foreach(DataGridViewColumn c in dv.Columns)
			{
				if(c.Index>6)
				{
					c.Visible = false;
				}
			}
		}
		
		//填充入库结算
		void FillConfirmRK(DataGridView dv)
		{
			dv.AutoGenerateColumns = false;
			//dataGridViewProjects.ColumnCount = 3;
			//dataGridView1.ReadOnly = true;
			//dataGridView1.AllowUserToAddRows = false;
			//dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
			dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[0].HeaderText = "入库ID";
			dv.Columns[0].Name = "ReceiptID";
			dv.Columns[0].Width =80;
			dv.Columns[0].DataPropertyName = "ReceiptID";
			
			dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[1].HeaderText = "入库单号";
			dv.Columns[1].Name = "ReceiptNum";
			dv.Columns[1].Width = 100;
			dv.Columns[1].DataPropertyName = "ReceiptNum";
			
			dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].ReadOnly = true;
			dv.Columns[2].HeaderText = "入库日期";
			dv.Columns[2].Name = "ReceiptDate";
			dv.Columns[2].Width = 120;
			dv.Columns[2].DataPropertyName = "ReceiptDate";
			
			dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[3].ReadOnly = true;
			dv.Columns[3].HeaderText = "入库金额";
			dv.Columns[3].Name = "ReceiptDiscAmt";
			dv.Columns[3].Width = 80;
			dv.Columns[3].DataPropertyName = "ReceiptDiscAmt";
			
			
			
			//不显示出来的列
			//            dv.Columns[4].Visible = false;
			//            dv.Columns[4].Name = "GoodsID";
			//            dv.Columns[4].DataPropertyName = "GoodsID";
			
			//            dv.Columns[12].Visible = false;
			//            dv.Columns[12].Name = "GoodsTypeID";
			//            dv.Columns[12].DataPropertyName = "GoodsTypeID";
			
			
			//隐藏不需要的
			foreach(DataGridViewColumn c in dv.Columns)
			{
				if(c.Index>3)
				{
					c.Visible = false;
				}
			}
		}
		
		//填充出库结算
		void FillConfirmCK(DataGridView dv)
		{
			dv.AutoGenerateColumns = false;
			//dataGridViewProjects.ColumnCount = 3;
			//dataGridView1.ReadOnly = true;
			//dataGridView1.AllowUserToAddRows = false;
			//dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
			dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[0].HeaderText = "出库ID";
			dv.Columns[0].Name = "OutStockID";
			dv.Columns[0].Width =80;
			dv.Columns[0].DataPropertyName = "OutStockID";
			
			dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[1].HeaderText = "出库单号";
			dv.Columns[1].Name = "OutStockNum";
			dv.Columns[1].Width = 100;
			dv.Columns[1].DataPropertyName = "OutStockNum";
			
			dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].ReadOnly = true;
			dv.Columns[2].HeaderText = "出库日期";
			dv.Columns[2].Name = "OutStockDate";
			dv.Columns[2].Width = 120;
			dv.Columns[2].DataPropertyName = "OutStockDate";
			
			dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[3].ReadOnly = true;
			dv.Columns[3].HeaderText = "出库金额";
			dv.Columns[3].Name = "OutBillAmt";
			dv.Columns[3].Width = 80;
			dv.Columns[3].DataPropertyName = "OutBillAmt";
			
			
			
			//不显示出来的列
			//            dv.Columns[11].Visible = false;
			//            dv.Columns[11].Name = "GoodsID";
			//            dv.Columns[11].DataPropertyName = "GoodsID";
//
			//            dv.Columns[12].Visible = false;
			//            dv.Columns[12].Name = "GoodsTypeID";
			//            dv.Columns[12].DataPropertyName = "GoodsTypeID";
			
			
			//隐藏不需要的
			foreach(DataGridViewColumn c in dv.Columns)
			{
				if(c.Index>3)
				{
					c.Visible = false;
				}
			}
		}
		
		void ComboBoxProjectCompanySelectedIndexChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(comboBoxProjectCompany.ValueMember))
				return;
			if(comboBoxProjectCompany.SelectedValue != null)
			{
				int i_CompanyID = Convert.ToInt32(comboBoxProjectCompany.SelectedValue);
				FillDataGridView(i_CompanyID);
			}
		}
		
		bool CheckPeriod()
		{
			string pattern = @"(^\d{4}0[1-9]|^\d{4}1[0-2])";

			if(textBoxPeriod.Text.Length == 6 && DyMatch(textBoxPeriod.Text,pattern))
			{
				return true;
			}
			return false;
		}
		
		bool DyMatch(string tStr,string pattern)
		{
			Regex reg;
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		
		void ButtonConfirmClick(object sender, EventArgs e)
		{
			//结算
			int i_CompanyID = 0;
			if(comboBoxProjectCompany.SelectedValue != null)
			{
				i_CompanyID = Convert.ToInt32(comboBoxProjectCompany.SelectedValue);
			}
			
			//1.检查周期格式是否正确
			if(!CheckPeriod())
			{
				MessageBox.Show("结算周期输入错误，请纠正后再试！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			//2.根据选择的单位类别作相应的更新
			int i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue);
			
			Companies tC = new Companies();
			tC = BLL.CompanyBLL.GetCompany(i_CompanyID);
			switch(tC.CompanyType)
			{
				case 0:		//客户
				case 2:		//班组
					BLL.CKBLL.UpdateCKD(i_ProjectID,i_CompanyID,"已结算",textBoxPeriod.Text,dataGridView1.SelectedRows);
					break;
				case 1:		//供货商
					BLL.RKBLL.UpdateRKD(i_ProjectID,i_CompanyID,"已结算",textBoxPeriod.Text,dataGridView1.SelectedRows);
					break;
			}
			
			//刷新显示
			ComboBoxProjectCompanySelectedIndexChanged(null,null);
		}
		
		void ButtonPrintClick(object sender, EventArgs e)
		{
			int i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue);
			int i_CompanyID = Convert.ToInt32(comboBoxProjectCompany.SelectedValue);
			
			DataSet tmpDs = new DataSet();
			DataSet FDataSet = new DataSet();
			DataTable table = new DataTable();
//			DataRelation dr;
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
					
					string s_OutStockIDs="";
					foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
					{
						s_OutStockIDs += item.Cells["OutStockID"].Value.ToString();
						s_OutStockIDs += ",";
					}
					if(s_OutStockIDs.Length > 0)
						s_OutStockIDs = s_OutStockIDs.Substring(0,s_OutStockIDs.Length - 1);
					
					tmpDs = BLL.CKBLL.GetOutStock(s_OutStockIDs);
					table = tmpDs.Tables[0].Copy();
					table.TableName = "OutStock";
					FDataSet.Tables.Add(table);
					
					tmpDs = BLL.CKBLL.GetOutStockItems(s_OutStockIDs);
					table = tmpDs.Tables[0].Copy();
					table.TableName = "OutStockItems";
					FDataSet.Tables.Add(table);
					
//					dr  = new DataRelation("FK_1",FDataSet.Tables["OutStock"].Columns["OutStockID"],FDataSet.Tables["OutStockItems"].Columns["OutStockID"]);
//					FDataSet.Relations.Add(dr);					
					
					report1.RegisterData(FDataSet);
					report1.Show();
					report1.Dispose();
					break;
				case 1:		//供货商
					tmpDs= BLL.CompanyBLL.GetAllCompany(i_CompanyID);
					//
					
					report1.Load("Reports\\JSD.frx");

					
					table = tmpDs.Tables[0].Copy();
					table.TableName = "Companies";
					FDataSet.Tables.Add(table);
					
					tmpDs = BLL.ProjectsBLL.GetAllProject(i_ProjectID);
					table = tmpDs.Tables[0].Copy();
					table.TableName = "Projects";
					FDataSet.Tables.Add(table);
					
					
					
					string s_ReceiptIDs="";
					foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
					{
						s_ReceiptIDs += item.Cells["ReceiptID"].Value.ToString();
						s_ReceiptIDs += ",";
					}
					if(s_ReceiptIDs.Length > 0)
						s_ReceiptIDs = s_ReceiptIDs.Substring(0,s_ReceiptIDs.Length - 1);
					
					tmpDs = BLL.ReceiptBLL.GetCommMaterialRecord(s_ReceiptIDs);
					table = tmpDs.Tables[0].Copy();
					table.TableName = "Receipt";
					FDataSet.Tables.Add(table);
					
					tmpDs = BLL.RKBLL.GetReceiptItems(s_ReceiptIDs);
					table = tmpDs.Tables[0].Copy();
					table.TableName = "ReceiptItems";
					FDataSet.Tables.Add(table);
					
//					dr  = new DataRelation("FK_1",FDataSet.Tables["Receipt"].Columns["ReceiptID"],FDataSet.Tables["ReceiptItems"].Columns["ReceiptID"]);
//					FDataSet.Relations.Add(dr);
					
					report1.RegisterData(FDataSet);
					report1.Show();
					report1.Dispose();
					break;
			}

			
		}
		
		

		
	}
}
