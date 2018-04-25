/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-07-14
 * 时间: 14:16
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
	/// Description of FormOutBill.
	/// </summary>
	public partial class FormOutBill : Form
	{
		
		private DataSet ds1 = new DataSet();
		private DataSet ds2 = new DataSet();
		private DataSet ds3 = new DataSet();
		private DataSet ds4 = new DataSet();
		
//		private int ii = 0;
		private FormInput tFormInput;
		private Decimal dTotal;
//		private Decimal dPay1;
//		private Decimal dDisc;
//		private Decimal dPayOK;
		
		public int i_OutStockID;
		private int iWareHouseID;
		
		public FormOutBill()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void FormOutBillLoad(object sender, EventArgs e)
		{
			
			
			//填充工程项目
			ds2 = BLL.ProjectsBLL.GetAllProjects();
			comboBoxProjectID.DataSource = ds2.Tables[0];
			comboBoxProjectID.DisplayMember = "ProjectName";
			comboBoxProjectID.ValueMember = "ProjectID";
			
			//填充仓库
			ds3 = BLL.WareHouseBLL.GetAllWareHouse();
			comboBoxWareHouseID.DataSource = ds3.Tables[0];
			comboBoxWareHouseID.DisplayMember = "WareHouseName";
			comboBoxWareHouseID.ValueMember = "WareHouseID";
			
			//填充项目供货商
			if(comboBoxProjectID.SelectedValue != null)
			{
				ds1 = BLL.CompanyBLL.GetProjectCompanies2(Convert.ToInt32(comboBoxProjectID.SelectedValue));
				comboBoxCompanyID.DataSource = ds1.Tables[0];
				comboBoxCompanyID.DisplayMember = "CompanyName";
				comboBoxCompanyID.ValueMember = "CompanyID";
			}
			
			//填充DataGridView1
			if(this.Text == "出库单-新增")
			{
				FillDateGridView1(0);
			}
			else
			{
				FillDateGridView1(i_OutStockID);
				//取得数据填充
				OutStock tR = BLL.CKBLL.GetOutStock(i_OutStockID);
				comboBoxCompanyID.SelectedValue = tR.CompanyID;
				comboBoxProjectID.SelectedValue = tR.ProjectID;
				comboBoxWareHouseID.SelectedValue = tR.WareHouseID;
				int i_OutStockType = tR.OutStockType;
				switch(i_OutStockType)
				{
					case 0:
						comboBoxOutStockType.Text = "领料出库";
						break;
					case 1:
						comboBoxOutStockType.Text = "领料退货";
						break;
					case 2:
						comboBoxOutStockType.Text = "物资借出";
						break;
					case 3:
						comboBoxOutStockType.Text = "物资归还";
						break;
					case 4:
						comboBoxOutStockType.Text = "报损出库";
						break;
					case 5:
						comboBoxOutStockType.Text = "报损退货";
						break;	
					default:
						break;
				}
				
				waterTextBoxRemark.Text = tR.OutBillRemark;
				textBoxID.Text = tR.OutStockID.ToString();
				textBoxNumber.Text = tR.OutStockNum;
				dateTimePickerRKDate.Value = tR.OutStockDate;
				dTotal = tR.OutBillAmt;
				textBoxOutAmt.Text = tR.OutBillAmt.ToString();
				textBoxUseMan.Text = tR.UseMan;
				textBoxOutMan.Text = tR.OutMan;
				
				
				//入库日期也不准修改
				dateTimePickerRKDate.Enabled = false;
			}
			comboBoxWareHouseID.Tag = "1";
			iWareHouseID = Convert.ToInt32(comboBoxWareHouseID.SelectedValue);
		}
		
		void FillDateGridView1(int tID)
		{
			//
			ds4 = BLL.CKBLL.GetOutStockItems(tID);
			dataGridView1.DataSource = ds4.Tables[0];
			SetGridView1Header(dataGridView1);
		}
		
		void SetGridView1Header(DataGridView dv)
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
			dv.Columns[1].HeaderText = "货品规格";
			dv.Columns[1].Name = "GoodsSpec";
			dv.Columns[1].Width = 100;
			dv.Columns[1].DataPropertyName = "GoodsSpec";
			
			dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].ReadOnly = true;
			dv.Columns[2].HeaderText = "货品类别";
			dv.Columns[2].Name = "GoodsTypeName";
			dv.Columns[2].Width = 80;
			dv.Columns[2].DataPropertyName = "GoodsTypeName";
			
			dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].ReadOnly = true;
			dv.Columns[3].HeaderText = "单位";
			dv.Columns[3].Name = "GoodsUnit";
			dv.Columns[3].Width = 80;
			dv.Columns[3].DataPropertyName = "GoodsUnit";
			
			dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[4].HeaderText = "数量";
			dv.Columns[4].Name = "GoodsQty";
			dv.Columns[4].Width = 80;
			dv.Columns[4].DataPropertyName = "GoodsQty";
			
			dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[5].HeaderText = "单价";
			dv.Columns[5].Name = "GoodsPrc";
			dv.Columns[5].Width = 80;
			dv.Columns[5].DataPropertyName = "GoodsPrc";
			
			dv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[6].ReadOnly = true;
			dv.Columns[6].HeaderText = "金额";
			dv.Columns[6].Name = "GoodsAmt";
			dv.Columns[6].Width = 80;
			dv.Columns[6].DataPropertyName = "GoodsAmt";
			
			dv.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[7].HeaderText = "使用部位";
			dv.Columns[7].Name = "UsePosition";
			dv.Columns[7].Width = 100;
			dv.Columns[7].DataPropertyName = "UsePosition";
			
			
			
			//不显示出来的列
			dv.Columns[8].Visible = false;
			dv.Columns[8].Name = "GoodsID";
			dv.Columns[8].DataPropertyName = "GoodsID";
			
			dv.Columns[9].Visible = false;
			dv.Columns[9].Name = "GoodsTypeID";
			dv.Columns[9].DataPropertyName = "GoodsTypeID";
			
			dv.Columns[10].Visible = false;
			dv.Columns[10].Name = "GoodsTaxRate";
			dv.Columns[10].DataPropertyName = "GoodsTaxRate";
			
			dv.Columns[11].Visible = false;
			dv.Columns[11].Name = "GoodsNoTaxPrice";
			dv.Columns[11].DataPropertyName = "GoodsNoTaxPrice";
			
			
			
			//隐藏不需要的
			foreach(DataGridViewColumn c in dataGridView1.Columns)
			{
				if(c.Index>7)
				{
					c.Visible = false;
				}
			}
			
		}
		void Label9Click(object sender, EventArgs e)
		{
			
		}
		
		
		void DataGridView1CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			//根据单元格出于的列确定操作
			switch(dataGridView1.CurrentCell.ColumnIndex)
			{
				case 0:
					int cellX = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex,dataGridView1.CurrentCell.RowIndex+1,false).X;
					int cellY = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex,dataGridView1.CurrentCell.RowIndex+1,false).Y;
					
					if(tFormInput != null)
					{
						tFormInput.iWareHouseID = iWareHouseID;
						tFormInput.Visible = true;
						
						this.Focus();		//将输入焦点保持在原来的输入位置
						Point tP1 = new Point(dataGridView1.CurrentCell.ContentBounds.Left,dataGridView1.CurrentCell.ContentBounds.Bottom);
						Point tP = PointToScreen(dataGridView1.Location);
						
						tP.X = tP.X + cellX;
						tP.Y = tP.Y + cellY;
						tFormInput.Left = tP.X;
						tFormInput.Top = tP.Y;
						
						//传递参数到数据选择输入窗口
						tFormInput.tb1.Text = dataGridView1.CurrentCell.Value.ToString();
						tFormInput.dvParent = dataGridView1;
					}
					else
					{
						tFormInput = new FormInput();
						tFormInput.DispZeroStock = false;
						tFormInput.iWareHouseID = iWareHouseID;
						tFormInput.Show(this);
						Point tP1 = new Point(dataGridView1.CurrentCell.ContentBounds.Left,dataGridView1.CurrentCell.ContentBounds.Bottom);
						Point tP = PointToScreen(dataGridView1.Location);
						
						tP.X = tP.X + cellX;
						tP.Y = tP.Y + cellY;
						tFormInput.Left = tP.X;
						tFormInput.Top = tP.Y;
						this.Focus();		//将输入焦点保持在原来的输入位置
					}

					break;
				case 4:		//数量
					CalcTotal();
					break;
				case 5:		//单价
					CalcTotal();
					break;
				default:
					
					break;
			}
			
			
			//下面一句必须
			if (dataGridView1.IsCurrentCellDirty)
			{
				dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}
		
		void DataGridView1CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			if(tFormInput != null)
			{
				tFormInput.Visible = false;
			}
			CalcTotal();
		}
		
		
		void CalcTotal()
		{
			//重新计算合计
			int row = dataGridView1.Rows.Count;//得到总行数
			dTotal = 0.00M;
			for (int i = 0; i <  row; i++)
			{
				decimal dNumber = 0.00M;
				decimal dPrice = 0.00M;
				decimal dAmt = 0.00M;
				try
				{
					dNumber = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsQty"].Value);
					dPrice =  Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsPrc"].Value);
					dAmt = dNumber * dPrice;
					dataGridView1.Rows[i].Cells["GoodsAmt"].Value = dAmt;
					dTotal += dAmt;
				}
				catch(Exception e1)
				{
					string s1 = e1.Message;
				}
			}
			textBoxOutAmt.Text = dTotal.ToString();
			
		}
		
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if(!CheckFillOK())
			{
				return;
			}
			
			if(this.Text == "出库单-新增")
			{
				AddNewOutStock();
			}
			else
			{
				//修改
				ModifyOutStock();
			}
		}
		
		void AddNewOutStock()
		{
			//保存数据，注意使用事务进行处理
			//1、入库单号的生成与修改；2、入库单的增加；3入库单项目的增加
			OutStock tR = new OutStock();
			tR.OutStockDate = dateTimePickerRKDate.Value;
			tR.ProjectID = Convert.ToInt32(comboBoxProjectID.SelectedValue.ToString());
			tR.CompanyID = Convert.ToInt32(comboBoxCompanyID.SelectedValue.ToString());
			tR.WareHouseID = Convert.ToInt32(comboBoxWareHouseID.SelectedValue.ToString());
			int i_OutStockType = 0;
			string tS1 = comboBoxOutStockType.Text;
			switch(tS1)
			{
				case "领料出库":
					i_OutStockType = 0;
					break;
				case "领料退货":
					i_OutStockType = 1;
					break;
				case "物资借出":
					i_OutStockType = 2;
					break;
				case "物资归还":
					i_OutStockType = 3;
					break;
				case "报损出库":
					i_OutStockType = 4;
					break;
				case "报损归还":
					i_OutStockType = 5;
					break;
				default:
					break;
			}
			tR.OutStockType = i_OutStockType;
			tR.OutBillAmt = dTotal;
			tR.OutBillRemark = waterTextBoxRemark.Text;
			tR.UseMan = textBoxUseMan.Text;
			tR.OutMan = textBoxOutMan.Text;
			tR.RecordStatus = "已记账";
			List<OutStockItems> tItems = new List<OutStockItems>();
			
			int row = dataGridView1.Rows.Count;//得到总行数
			for (int i = 0; i <  row - 1; i++)
			{
				//最后一行是新行，不算
				if(dataGridView1.Rows[i].Cells["GoodsID"].Value ==DBNull.Value)
				{
					continue;
				}
				OutStockItems tItem;
				tItem = new OutStockItems();
				tItem.GoodsID = Convert.ToInt32(dataGridView1.Rows[i].Cells["GoodsID"].Value);
				tItem.GoodsQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsQty"].Value);
				tItem.GoodsPrc =  Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsPrc"].Value);
				tItem.GoodsAmt =  Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsAmt"].Value);
				tItem.GoodsName = dataGridView1.Rows[i].Cells["GoodsName"].Value.ToString();
				tItem.GoodsSpec = dataGridView1.Rows[i].Cells["GoodsSpec"].Value.ToString();
				tItem.GoodsUnit = dataGridView1.Rows[i].Cells["GoodsUnit"].Value.ToString();
				tItem.UsePosition = dataGridView1.Rows[i].Cells["UsePosition"].Value.ToString();
				if(dataGridView1.Rows[i].Cells["UsePosition"].Value != null)
				{
					tItem.UsePosition = dataGridView1.Rows[i].Cells["UsePosition"].Value.ToString();
				}
				tItems.Add(tItem);
			}
			
			BLL.CKBLL.AddCKD(tR,tItems);
			this.Close();
		}
		
		void ModifyOutStock()
		{
			//修改数据，用事务处理
			OutStock tR = new OutStock();
			tR.OutStockID = Convert.ToInt32(textBoxID.Text);
			tR.OutStockNum = textBoxNumber.Text;
			
			tR.OutStockDate = dateTimePickerRKDate.Value;
			tR.ProjectID = Convert.ToInt32(comboBoxProjectID.SelectedValue.ToString());
			tR.CompanyID = Convert.ToInt32(comboBoxCompanyID.SelectedValue.ToString());
			tR.WareHouseID = Convert.ToInt32(comboBoxWareHouseID.SelectedValue.ToString());
			int i_OutStockType = 0;
			string tS1 = comboBoxOutStockType.Text;
			switch(tS1)
			{
				case "领料出库":
					i_OutStockType = 0;
					break;
				case "领料退货":
					i_OutStockType = 1;
					break;
				case "物资借出":
					i_OutStockType = 2;
					break;
				case "物资归还":
					i_OutStockType = 3;
					break;
				case "报损出库":
					i_OutStockType = 4;
					break;
				case "报损归还":
					i_OutStockType = 5;
					break;
				default:
					break;
			}
			tR.OutStockType = i_OutStockType;
			
			tR.OutBillAmt = dTotal;
			tR.OutBillRemark = waterTextBoxRemark.Text;
			List<OutStockItems> tItems = new List<OutStockItems>();
			
			int row = dataGridView1.Rows.Count;//得到总行数
			for (int i = 0; i <  row - 1; i++)
			{
				//最后一行是新行，不算
				OutStockItems tItem;
				tItem = new OutStockItems();
				tItem.GoodsID = Convert.ToInt32(dataGridView1.Rows[i].Cells["GoodsID"].Value);
				tItem.GoodsQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsQty"].Value);
				tItem.GoodsPrc =  Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsPrc"].Value);
				tItem.GoodsAmt =  Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsAmt"].Value);
				tItem.GoodsName = dataGridView1.Rows[i].Cells["GoodsName"].Value.ToString();
				tItem.GoodsSpec = dataGridView1.Rows[i].Cells["GoodsSpec"].Value.ToString();
				tItem.GoodsUnit = dataGridView1.Rows[i].Cells["GoodsUnit"].Value.ToString();
				tItem.UsePosition = dataGridView1.Rows[i].Cells["UsePosition"].Value.ToString();
				
				tItems.Add(tItem);
			}
			
			BLL.CKBLL.ModifyCKD(tR,tItems);
			this.Close();
		}
		
		void ButtonCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void 删除ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//删除当前选择的行
			if(dataGridView1.CurrentRow == null)
				return;
			if(!dataGridView1.CurrentRow.IsNewRow)
			{
				dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
				CalcTotal();
			}
			
		}
		
		bool CheckFillOK()
		{
			Regex reg;
			string tStr;
			string pattern;
			
			//工程项目
			if(comboBoxProjectID.SelectedValue == null)
			{
				MessageBox.Show("未指定工程项目！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			tStr = comboBoxProjectID.SelectedValue.ToString();
			pattern = @"^\d+$";
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				MessageBox.Show("指定工程项目错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			
			//供货商
			if(comboBoxCompanyID.SelectedValue == null)
			{
				MessageBox.Show("未指定供货商或班组！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			tStr = comboBoxCompanyID.SelectedValue.ToString();
			pattern = @"^\d+$";
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				MessageBox.Show("指定供货商错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			
			//入库仓库
			if(comboBoxWareHouseID.SelectedValue == null)
			{
				MessageBox.Show("未指定入库仓库！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			tStr = comboBoxWareHouseID.SelectedValue.ToString();
			pattern = @"^\d+$";
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				MessageBox.Show("指定入库仓库错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			
			//如果是物资借出或物资归还，必修填领用人
			if(comboBoxOutStockType.Text == "物资借出" || comboBoxOutStockType.Text == "物资归还")
			{
				if(textBoxUseMan.Text == "")
				{
					MessageBox.Show("必须填写物资领用人！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return false;
				}
			}
			
			return true;
		}
		void ComboBoxProjectIDSelectedIndexChanged(object sender, EventArgs e)
		{
			//
			if (string.IsNullOrEmpty(comboBoxProjectID.ValueMember))
				return;
			if(comboBoxProjectID.SelectedValue != null)
			{
				
				ds1 = BLL.CompanyBLL.GetProjectCompanies2(Convert.ToInt32(comboBoxProjectID.SelectedValue));
				comboBoxCompanyID.DataSource = ds1.Tables[0];
			}
		}
		void ComboBoxWareHouseIDSelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBoxWareHouseID.Tag == null)
				return;
			iWareHouseID = Convert.ToInt32(comboBoxWareHouseID.SelectedValue);
		}
		
	}
}
