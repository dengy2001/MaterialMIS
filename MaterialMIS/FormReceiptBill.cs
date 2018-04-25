/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-13
 * 时间: 14:11
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
	/// Description of FormReceiptBill.
	/// </summary>
	public partial class FormReceiptBill : Form
	{
		
		private DataSet ds1 = new DataSet();
		//供货商
		private DataSet ds2 = new DataSet();
		//工程项目
		private DataSet ds3 = new DataSet();
		//仓库
		private DataSet ds4 = new DataSet();
		
//		private int ii = 0;
		private FormInput tFormInput;
		private Decimal dTotal;
		private Decimal dPay1;
		private Decimal dDisc;
//		private Decimal dPayOK;
		private int iWareHouseID;
		
		public int i_ReceiptID;
		
		public FormReceiptBill()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Label2Click(object sender, EventArgs e)
		{
	
		}
		
		void FormReceiptBillLoad(object sender, EventArgs e)
		{
//			//填充供货商			
//			ds1 = BLL.CompanyBLL.GetCompany2();
//			comboBoxCompanyID.DataSource = ds1.Tables[0];
//			comboBoxCompanyID.DisplayMember = "CompanyName";
//			comboBoxCompanyID.ValueMember = "CompanyID";
			
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
			if (comboBoxProjectID.SelectedValue != null) {
				ds1 = BLL.CompanyBLL.GetProjectCompanies(Convert.ToInt32(comboBoxProjectID.SelectedValue), 1);
				comboBoxCompanyID.DataSource = ds1.Tables[0];
				comboBoxCompanyID.DisplayMember = "CompanyName";
				comboBoxCompanyID.ValueMember = "CompanyID";
			}
			
			//填充DataGridView1
			if (this.Text == "入库单-新增") {
				FillDateGridView1(0);
			} else {
				FillDateGridView1(i_ReceiptID);
				//取得数据填充
				Receipt tR = BLL.RKBLL.GetReceipt(i_ReceiptID);
				comboBoxCompanyID.SelectedValue = tR.CompanyID;
				comboBoxProjectID.SelectedValue = tR.ProjectID;
				comboBoxWareHouseID.SelectedValue = tR.WareHouseID;
				waterTextBoxRemark.Text = tR.Remark;
				int i_ReceiptType = tR.ReceiptType;
				switch(i_ReceiptType)
				{
					case 0:
						comboBoxReceiptType.Text = "采购入库";
						break;
					case 1:
						comboBoxReceiptType.Text = "采购退货";
						break;
					case 2:
						comboBoxReceiptType.Text = "调拨入库";
						break;
					case 3:
						comboBoxReceiptType.Text = "调拨退货";
						break;
					case 4:
						comboBoxReceiptType.Text = "报溢入库";
						break;
					case 5:
						comboBoxReceiptType.Text = "报溢退货";
						break;	
					default:
						break;
				}
				textBoxID.Text = tR.ReceiptID.ToString();
				textBoxNumber.Text = tR.ReceiptNum;
				dateTimePickerRKDate.Value = tR.ReceiptDate;
				dTotal = tR.ReceiptBillAmt;
				textBoxPayDiscAmt.Text = tR.ReceiptDiscAmt.ToString("0.00");
				textBoxDisc.Text = (tR.ReceiptDisc * 100).ToString();
				textBoxPurcher.Text = tR.PurchName;
				textBoxReceriver.Text = tR.ReceiverName;
				
				//入库日期也不准修改
				dateTimePickerRKDate.Enabled = false;
			}
			
			comboBoxWareHouseID.Tag = "1";
			iWareHouseID = Convert.ToInt32(comboBoxWareHouseID.SelectedValue);
			
		}
		
		void FillDateGridView1(int tID)
		{
			//
			ds4 = BLL.RKBLL.GetReceiptItems(tID);
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
			dv.Columns[0].Width = 120;
			dv.Columns[0].DataPropertyName = "GoodsName";
            
			dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[1].ReadOnly = true;
			dv.Columns[1].HeaderText = "货品规格";
			dv.Columns[1].Name = "GoodsSpec";
			dv.Columns[1].Width = 100;
			dv.Columns[1].DataPropertyName = "GoodsSpec";
            
			dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[2].HeaderText = "附加规格";
			dv.Columns[2].Name = "MoreSpec";
			dv.Columns[2].Width = 100;
			dv.Columns[2].DataPropertyName = "MoreSpec";
            
			dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].ReadOnly = true;
			dv.Columns[3].HeaderText = "货品类别";
			dv.Columns[3].Name = "GoodsTypeName";
			dv.Columns[3].Width = 80;
			dv.Columns[3].DataPropertyName = "GoodsTypeName";
            
			dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[4].ReadOnly = true;
			dv.Columns[4].HeaderText = "单位";
			dv.Columns[4].Name = "GoodsUnit";
			dv.Columns[4].Width = 80;
			dv.Columns[4].DataPropertyName = "GoodsUnit";
            
			dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[5].HeaderText = "数量";
			dv.Columns[5].Name = "GoodsQty";
			dv.Columns[5].Width = 80;
			dv.Columns[5].DataPropertyName = "GoodsQty";
            
			dv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[6].HeaderText = "单价";
			dv.Columns[6].Name = "GoodsPrc";
			dv.Columns[6].Width = 80;
			dv.Columns[6].DataPropertyName = "GoodsPrc";
            
			dv.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[7].HeaderText = "运费";
			dv.Columns[7].Name = "GoodsYF";
			dv.Columns[7].Width = 80;
			dv.Columns[7].DataPropertyName = "GoodsYF";
            
			dv.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[8].ReadOnly = true;
			dv.Columns[8].HeaderText = "金额";
			dv.Columns[8].Name = "GoodsAmt";
			dv.Columns[8].Width = 80;
			dv.Columns[8].DataPropertyName = "GoodsAmt";
			
			dv.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[9].HeaderText = "税率";
			dv.Columns[9].Name = "GoodsTaxRate";
			dv.Columns[9].Width = 80;
			dv.Columns[9].DataPropertyName = "GoodsTaxRate";
			
			dv.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[10].ReadOnly = true;
			dv.Columns[10].HeaderText = "不含税价";
			dv.Columns[10].Name = "GoodsNoTaxPrice";
			dv.Columns[10].Width = 80;
			dv.Columns[10].DataPropertyName = "GoodsNoTaxPrice";
            
			dv.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[11].HeaderText = "使用部位";
			dv.Columns[11].Name = "UsePosition";
			dv.Columns[11].Width = 100;
			dv.Columns[11].DataPropertyName = "UsePosition";
            
			dv.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[12].HeaderText = "计划人";
			dv.Columns[12].Name = "GoodsPlan";
			dv.Columns[12].Width = 80;
			dv.Columns[12].DataPropertyName = "GoodsPlan";
            
			dv.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[13].HeaderText = "计划单号";
			dv.Columns[13].Name = "GoodsPlanNo";
			dv.Columns[13].Width = 80;
			dv.Columns[13].DataPropertyName = "GoodsPlanNo";
            
			//不显示出来的列
			dv.Columns[14].Visible = false;
			dv.Columns[14].Name = "GoodsID";
			dv.Columns[14].DataPropertyName = "GoodsID";
            
			dv.Columns[15].Visible = false;
			dv.Columns[15].Name = "GoodsTypeID";
			dv.Columns[15].DataPropertyName = "GoodsTypeID";
            
            
			//隐藏不需要的
			foreach (DataGridViewColumn c in dv.Columns) {
				if (c.Index > 13) {
					c.Visible = false;
				}
			}
           
		}

		void DataGridView1CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			//根据单元格处于的列确定操作
			switch (dataGridView1.CurrentCell.ColumnIndex) {
				case 0:
					int cellX = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex + 1, false).X;
					int cellY = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex + 1, false).Y;
				
					if (tFormInput != null) {	
						tFormInput.iWareHouseID = iWareHouseID;
						tFormInput.Visible = true;
						
						this.Focus();		//将输入焦点保持在原来的输入位置
						Point tP1 = new Point(dataGridView1.CurrentCell.ContentBounds.Left, dataGridView1.CurrentCell.ContentBounds.Bottom);
						Point tP = PointToScreen(dataGridView1.Location);
						
						tP.X = tP.X + cellX;
						tP.Y = tP.Y + cellY;
						tFormInput.Left = tP.X;
						tFormInput.Top = tP.Y;
						
						//传递参数到数据选择输入窗口
						tFormInput.tb1.Text = dataGridView1.CurrentCell.Value.ToString();
						tFormInput.dvParent = dataGridView1;
					} else {						
						tFormInput = new FormInput();
						tFormInput.DispZeroStock = true;
						tFormInput.iWareHouseID = iWareHouseID;
						tFormInput.Show(this);
						
						Point tP1 = new Point(dataGridView1.CurrentCell.ContentBounds.Left, dataGridView1.CurrentCell.ContentBounds.Bottom);
						Point tP = PointToScreen(dataGridView1.Location);
						
						tP.X = tP.X + cellX;
						tP.Y = tP.Y + cellY;
						tFormInput.Left = tP.X;
						tFormInput.Top = tP.Y;
						this.Focus();		//将输入焦点保持在原来的输入位置
					}

					break;
				case 5:		//数量
					CalcTotal();
					break;
				case 6:		//单价
					CalcTotal();
					break;
				case 7:		//运费
					CalcTotal();
					break;
				case 9:		//税率
					CalcTotal();
					break;
				default:					
					break;
			}			
			
			//下面一句必须
			if (dataGridView1.IsCurrentCellDirty) {
				dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}

		}
		
		bool CheckCanCal(int i)
		{
			if (dataGridView1.Rows[i].Cells["GoodsQty"].Value == null
			   || dataGridView1.Rows[i].Cells["GoodsPrc"].Value == null
			   || dataGridView1.Rows[i].Cells["GoodsYF"].Value == null)
				return false;
			Regex reg;
			string tStr;	
			string pattern;			

			tStr = dataGridView1.Rows[i].Cells["GoodsQty"].Value.ToString();
			pattern = @"\d+(\.\d+)|\d+";
			reg = new Regex(pattern);
			if (!reg.IsMatch(tStr)) {
				return false;
			}
			
			tStr = dataGridView1.Rows[i].Cells["GoodsPrc"].Value.ToString();
			pattern = @"\d+(\.\d+)|\d+";
			reg = new Regex(pattern);
			if (!reg.IsMatch(tStr)) {
				return false;
			}
			
			tStr = dataGridView1.Rows[i].Cells["GoodsYF"].Value.ToString();
			pattern = @"\d+(\.\d+)|\d+";
			reg = new Regex(pattern);
			if (!reg.IsMatch(tStr)) {
				return false;
			}
			return true;
		}
		
		
		void CalcTotal()
		{
			//检查能否计算
			
			//重新计算合计
			int row = dataGridView1.Rows.Count;//得到总行数
			dTotal = 0.00M;
			for (int i = 0; i < row; i++) {
				
				decimal dNumber = 0.00M;
				decimal dPrice = 0.00M;
				decimal dYF = 0.00M;
				decimal dAmt = 0.00M;
				decimal dTaxRate = 0.00M;
				decimal dNoTaxPrice = 0.00M;
				try {
					dNumber = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsQty"].Value);
					dPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsPrc"].Value);
					dYF = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsYF"].Value);
					dTaxRate = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsTaxRate"].Value);
					dNoTaxPrice = Math.Round(dPrice / (1 + dTaxRate),2);
					dataGridView1.Rows[i].Cells["GoodsNoTaxPrice"].Value = dNoTaxPrice;
					dAmt = dNumber * dPrice + dYF;
					dataGridView1.Rows[i].Cells["GoodsAmt"].Value = dAmt;
					dTotal += dAmt;
				} 
				catch (Exception e1)
				{
					string s1 = e1.Message;
				}
			}
			textBoxPayDiscAmt.Text = dTotal.ToString();
			
		}
		
		void DataGridView1CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			if (tFormInput != null) {
				tFormInput.Visible = false;
			}
			CalcTotal();
		}
		void TextBoxPayDiscAmtKeyPress(object sender, KeyPressEventArgs e)
		{
			//dDisc
			try {
				string ts = ((TextBox)sender).Text;				
				decimal td = Convert.ToDecimal(ts + e.KeyChar.ToString());
				
			} catch {
				if (e.KeyChar == '\b') {
					e.Handled = false;
				} else {
					//e.KeyChar = (char)0;
					e.Handled = true;
				}
			}
			
				
		}
		
		void TextBoxDiscKeyPress(object sender, KeyPressEventArgs e)
		{
			//折扣率
			try {
				string ts = ((TextBox)sender).Text;				
				decimal td = Convert.ToDecimal(ts + e.KeyChar.ToString());
				if (td > 100) {
					e.Handled = true;
				}
				
			} catch {
				if (e.KeyChar == '\b') {
					e.Handled = false;
				} else {
					//e.KeyChar = (char)0;
					e.Handled = true;
				}
			}
				
				
		}
		
		void TextBoxPayDiscAmtTextChanged(object sender, EventArgs e)
		{
			//更新折扣
			textBoxDisc.TextChanged -= new EventHandler(TextBoxDiscTextChanged);
			try {
				dPay1 = Convert.ToDecimal(textBoxPayDiscAmt.Text);
				if (dTotal != 0) {
					dDisc = dPay1 / dTotal * 100;
				} else {
					dDisc = 100;
				}
				textBoxDisc.Text = dDisc.ToString("0.0000");
			} 
			catch (Exception e1) 
			{
				string s1 = e1.Message;
			}
			textBoxDisc.TextChanged += new EventHandler(TextBoxDiscTextChanged);			
		}
		
		void TextBoxDiscTextChanged(object sender, EventArgs e)
		{
			//更新应付
			textBoxPayDiscAmt.TextChanged -= new EventHandler(TextBoxPayDiscAmtTextChanged);
			try {
				dDisc = Convert.ToDecimal(textBoxDisc.Text);
				dPay1 = dTotal * dDisc / 100;
				textBoxPayDiscAmt.Text = dPay1.ToString("0.00");
			} 
			catch (Exception e1) 
			{
				string s1 = e1.Message;
			}
			textBoxPayDiscAmt.TextChanged += new EventHandler(TextBoxPayDiscAmtTextChanged);
		}
		
		void ButtonCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if (!CheckFillOK()) {
				return;
			}
			if (this.Text == "入库单-新增") {
				AddNewReceipt();
			} else {
				//修改
				ModifyReceipt();
			}
			
						
		}
		
		bool CheckFillOK()
		{
			Regex reg;
			string tStr;	
			string pattern;
			
			//工程项目
			if (comboBoxProjectID.SelectedValue == null) {
				MessageBox.Show("未指定工程项目！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			tStr = comboBoxProjectID.SelectedValue.ToString();
			pattern = @"^\d+$";
			reg = new Regex(pattern);
			if (!reg.IsMatch(tStr)) {
				MessageBox.Show("指定工程项目错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			
			//供货商
			if (comboBoxCompanyID.SelectedValue == null) {
				MessageBox.Show("未指定供货商！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			tStr = comboBoxCompanyID.SelectedValue.ToString();
			pattern = @"^\d+$";
			reg = new Regex(pattern);
			if (!reg.IsMatch(tStr)) {
				MessageBox.Show("指定供货商错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			
			//入库仓库
			if (comboBoxWareHouseID.SelectedValue == null) {
				MessageBox.Show("未指定入库仓库！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			tStr = comboBoxWareHouseID.SelectedValue.ToString();
			pattern = @"^\d+$";
			reg = new Regex(pattern);
			if (!reg.IsMatch(tStr)) {
				MessageBox.Show("指定入库仓库错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			
			return true;
		}
		
		void ModifyReceipt()
		{
			//修改数据，用事务处理
			Receipt tR = new Receipt();
			tR.ReceiptID = Convert.ToInt32(textBoxID.Text);
			tR.ReceiptNum = textBoxNumber.Text;
			
			tR.ReceiptDate = dateTimePickerRKDate.Value;
			tR.ProjectID = Convert.ToInt32(comboBoxProjectID.SelectedValue.ToString());
			tR.CompanyID = Convert.ToInt32(comboBoxCompanyID.SelectedValue.ToString());
			tR.WareHouseID = Convert.ToInt32(comboBoxWareHouseID.SelectedValue.ToString());
			string tS1 = comboBoxReceiptType.Text;
			int i_ReceiptType = 0;
			switch(tS1)
			{
				case "采购入库":
					i_ReceiptType = 0;
					break;
				case "采购退货":
					i_ReceiptType = 1;
					break;
				case "调拨入库":
					i_ReceiptType = 2;
					break;
				case "调拨退货":
					i_ReceiptType = 3;
					break;
				case "报溢入库":
					i_ReceiptType = 4;
					break;
				case "报溢退货":
					i_ReceiptType = 5;
					break;
				default:
					break;
			}
			tR.ReceiptType = i_ReceiptType;
			
			tR.ReceiptBillAmt = dTotal;
			tR.ReceiptDiscAmt = Convert.ToDecimal(textBoxPayDiscAmt.Text == "" ? "0" : textBoxPayDiscAmt.Text);
			tR.ReceiptDisc = Convert.ToDecimal(textBoxDisc.Text == "" ? "100" : textBoxDisc.Text) / 100;
			tR.PurchName = textBoxPurcher.Text;
			tR.ReceiverName = textBoxReceriver.Text;
			tR.RecordStatus = "已记账";
			tR.Remark = waterTextBoxRemark.Text;
			List<ReceiptItems> tItems = new List<ReceiptItems>();
			
			int row = dataGridView1.Rows.Count;//得到总行数
			for (int i = 0; i < row - 1; i++) {
				//最后一行是新行，不算
				ReceiptItems tItem;
				tItem = new ReceiptItems();
				tItem.GoodsID = Convert.ToInt32(dataGridView1.Rows[i].Cells["GoodsID"].Value);
				tItem.GoodsQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsQty"].Value);
				tItem.GoodsPrc = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsPrc"].Value);
				tItem.GoodsYF = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsYF"].Value);
				tItem.GoodsAmt = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsAmt"].Value);
				tItem.GoodsTaxRate = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsTaxRate"].Value);
				tItem.GoodsNoTaxPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsNoTaxPrice"].Value);				
				tItem.GoodsName = dataGridView1.Rows[i].Cells["GoodsName"].Value.ToString();
				tItem.GoodsSpec = dataGridView1.Rows[i].Cells["GoodsSpec"].Value.ToString();
				tItem.MoreSpec = dataGridView1.Rows[i].Cells["MoreSpec"].Value.ToString();
				tItem.GoodsUnit = dataGridView1.Rows[i].Cells["GoodsUnit"].Value.ToString();
				tItem.UsePosition = dataGridView1.Rows[i].Cells["UsePosition"].Value.ToString();
				tItem.GoodsPlan = dataGridView1.Rows[i].Cells["GoodsPlan"].Value.ToString();
				tItem.GoodsPlanNo = dataGridView1.Rows[i].Cells["GoodsPlanNo"].Value.ToString();
				
				tItems.Add(tItem);
			}
			
			BLL.RKBLL.ModifyRKD(tR, tItems);
			this.Close();
		}
		
		void AddNewReceipt()
		{
			//保存数据，注意使用事务进行处理
			//1、入库单号的生成与修改；2、入库单的增加；3入库单项目的增加
			Receipt tR = new Receipt();
			tR.ReceiptDate = dateTimePickerRKDate.Value;
			tR.ProjectID = Convert.ToInt32(comboBoxProjectID.SelectedValue.ToString());
			tR.CompanyID = Convert.ToInt32(comboBoxCompanyID.SelectedValue.ToString());
			tR.WareHouseID = Convert.ToInt32(comboBoxWareHouseID.SelectedValue.ToString());
			string tS1 = comboBoxReceiptType.Text;
			int i_ReceiptType = 0;
			switch(tS1)
			{
				case "采购入库":
					i_ReceiptType = 0;
					break;
				case "采购退货":
					i_ReceiptType = 1;
					break;
				case "调拨入库":
					i_ReceiptType = 2;
					break;
				case "调拨退货":
					i_ReceiptType = 3;
					break;
				case "报溢入库":
					i_ReceiptType = 4;
					break;
				case "报溢退货":
					i_ReceiptType = 5;
					break;
				default:
					break;
			}
			tR.ReceiptType = i_ReceiptType;
			tR.ReceiptBillAmt = dTotal;
			tR.ReceiptDiscAmt = Convert.ToDecimal(textBoxPayDiscAmt.Text == "" ? "0" : textBoxPayDiscAmt.Text);
			tR.ReceiptDisc = Convert.ToDecimal(textBoxDisc.Text == "" ? "100" : textBoxDisc.Text) / 100;
			tR.Remark = waterTextBoxRemark.Text;
			tR.PurchName = textBoxPurcher.Text;
			tR.ReceiverName = textBoxReceriver.Text;
			tR.RecordStatus = "已记账";
			List<ReceiptItems> tItems = new List<ReceiptItems>();
			
			int row = dataGridView1.Rows.Count;//得到总行数
			for (int i = 0; i < row - 1; i++) {
				//最后一行是新行，不算
				ReceiptItems tItem;
				tItem = new ReceiptItems();
				tItem.GoodsID = Convert.ToInt32(dataGridView1.Rows[i].Cells["GoodsID"].Value);
				tItem.GoodsQty = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsQty"].Value);
				tItem.GoodsPrc = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsPrc"].Value);
				tItem.GoodsYF = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsYF"].Value);
				tItem.GoodsAmt = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsAmt"].Value);
				tItem.GoodsTaxRate = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsTaxRate"].Value);
				tItem.GoodsNoTaxPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["GoodsNoTaxPrice"].Value);
				tItem.GoodsName = dataGridView1.Rows[i].Cells["GoodsName"].Value.ToString();
				tItem.GoodsSpec = dataGridView1.Rows[i].Cells["GoodsSpec"].Value.ToString();
				tItem.MoreSpec = dataGridView1.Rows[i].Cells["MoreSpec"].Value.ToString();
				tItem.GoodsUnit = dataGridView1.Rows[i].Cells["GoodsUnit"].Value.ToString();
				tItem.UsePosition = dataGridView1.Rows[i].Cells["UsePosition"].Value.ToString();
				tItem.GoodsPlan = dataGridView1.Rows[i].Cells["GoodsPlan"].Value.ToString();
				tItem.GoodsPlanNo = dataGridView1.Rows[i].Cells["GoodsPlanNo"].Value.ToString();
				
				tItems.Add(tItem);
			}
			
			BLL.RKBLL.AddRKD(tR, tItems);
			this.Close();
		}
		
		void 删除ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//删除当前选择的行
			if (dataGridView1.CurrentRow == null)
				return;
			if (!dataGridView1.CurrentRow.IsNewRow) {
				dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
				CalcTotal();
			}
		}
		
		void TextBoxPayAmtKeyPress(object sender, KeyPressEventArgs e)
		{
			try {
				string ts = ((TextBox)sender).Text;				
				decimal td = Convert.ToDecimal(ts + e.KeyChar.ToString());
				
			} catch {
				if (e.KeyChar == '\b') {
					e.Handled = false;
				} else {
					//e.KeyChar = (char)0;
					e.Handled = true;
				}
			}
			
		}
		void ComboBoxProjectIDSelectedIndexChanged(object sender, EventArgs e)
		{
			//
			if  (string.IsNullOrEmpty(comboBoxProjectID.ValueMember))
				return;
			if (comboBoxProjectID.SelectedValue != null) {
				
				ds1 = BLL.CompanyBLL.GetProjectCompanies(Convert.ToInt32(comboBoxProjectID.SelectedValue), 1);
				comboBoxCompanyID.DataSource = ds1.Tables[0];
			}
		}
		void DataGridView1DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			return;
		}
		void 查询历史单价ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(dataGridView1.CurrentRow == null)
				return;
			string s_GoodsID = dataGridView1.CurrentRow.Cells["GoodsID"].Value.ToString();
			if(s_GoodsID == "")
				return;
			int i_GoodsID;
			i_GoodsID = Convert.ToInt32(s_GoodsID);
			//显示历史单价
			switch (dataGridView1.CurrentCell.ColumnIndex) {
				case 6:		//单价列
					FormPriceList tFormPriceList = new FormPriceList();			
					tFormPriceList.i_GoodsID = i_GoodsID;
					tFormPriceList.ShowDialog();

					break;
				default:
					break;
			}
			
			
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
	
		}
		void ComboBoxWareHouseIDSelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBoxWareHouseID.Tag == null)
				return;
			iWareHouseID = Convert.ToInt32(comboBoxWareHouseID.SelectedValue);
		}
		
		

		
		
		
	
		
		
		
	}
}
