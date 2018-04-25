/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-10-27
 * 时间: 16:18
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
	/// Description of FormStock1.
	/// </summary>
	public partial class FormStock1 : Form
	{
		private DataSet ds1 = new DataSet();	//库存
		private List<int> l_GoodsTypeList = new List<int>();	//产品类别过滤
		private string s_GoodsNameFilter = "";		//产品名称过滤
		private bool b_DispPositive = true;			//显示正库存
		private bool b_DispZeroStock = false;		//显示0库存
		private bool b_DispNegative = false;			//显示负库存
		private string sPeriodNo;					//当前的周期
		private DataSet ds2 = new DataSet();	//库房
		
		public FormStock1()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormStock1Load(object sender, EventArgs e)
		{
			//填充Treeview
			BLL.GoodsTypeBLL.FillTreeView(treeView1);
			//缺省选择树
			treeView1.SelectedNode = treeView1.Nodes[0];
			treeView1.Nodes[0].Checked = true;

			DataSet dsTmp = new DataSet();
			dsTmp = BLL.WareHouseBLL.GetAllBillCycle();
			foreach(DataRow dr in dsTmp.Tables[0].Rows)
			{
				comboBoxPeriod.Items.Add(dr["BillCycle"].ToString());
			}
			checkBox1.Checked = b_DispPositive;
			checkBox2.Checked = b_DispZeroStock;
			checkBox3.Checked = b_DispNegative;
			if(radioButtonCurStock.Checked)
			{
				string s1 = BLL.WareHouseBLL.GetMaxJSCycle();
				sPeriodNo = s1;
				FillCurStock(s1);
			}
			//填充仓库
			ds2 = BLL.WareHouseBLL.GetAllWareHouse();
			ds2.Tables[0].Rows.Add(0,"所有库房");
			comboBoxWareHouseID.DataSource = ds2.Tables[0];
			comboBoxWareHouseID.DisplayMember = "WareHouseName";
			comboBoxWareHouseID.ValueMember = "WareHouseID";
			comboBoxWareHouseID.SelectedValue = 0;
			comboBoxWareHouseID.Tag = "1";
		}
		
		//设置标题行
		void SetHeader(DataGridView dv)
		{			
			dv.AutoGenerateColumns = false;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
			dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dv.Columns[0].HeaderText = "货品号";
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
			dv.Columns[2].HeaderText = "规格型号";
			dv.Columns[2].Name = "GoodsSpec";
			dv.Columns[2].Width = 100;
			dv.Columns[2].DataPropertyName = "GoodsSpec";
			
			dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[3].ReadOnly = true;
			dv.Columns[3].HeaderText = "单位";
			dv.Columns[3].Name = "GoodsUnit";
			dv.Columns[3].Width = 80;
			dv.Columns[3].DataPropertyName = "GoodsUnit";
			
			dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[4].ReadOnly = true;
			dv.Columns[4].HeaderText = "期初数";
			dv.Columns[4].Name = "LastQty";
			dv.Columns[4].Width = 80;
			dv.Columns[4].DataPropertyName = "LastQty";
			
			dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[5].ReadOnly = true;
			dv.Columns[5].HeaderText = "期初额";
			dv.Columns[5].Name = "LastAmt";
			dv.Columns[5].Width = 80;
			dv.Columns[5].DataPropertyName = "LastAmt";
			
			dv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[6].ReadOnly = true;
			dv.Columns[6].HeaderText = "本期入库";
			dv.Columns[6].Name = "ThisQtyIn";
			dv.Columns[6].Width = 80;
			dv.Columns[6].DataPropertyName = "ThisQtyIn";
			
			dv.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[7].ReadOnly = true;
			dv.Columns[7].HeaderText = "本期出库";
			dv.Columns[7].Name = "ThisQtyOut";
			dv.Columns[7].Width = 80;
			dv.Columns[7].DataPropertyName = "ThisQtyOut";
			
			dv.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[8].ReadOnly = true;
			dv.Columns[8].HeaderText = "期末库存";
			dv.Columns[8].Name = "EndQty";
			dv.Columns[8].Width = 80;
			dv.Columns[8].DataPropertyName = "EndQty";
			
			dv.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[9].ReadOnly = true;
			dv.Columns[9].HeaderText = "期末额";
			dv.Columns[9].Name = "EndAmt";
			dv.Columns[9].Width = 80;
			dv.Columns[9].DataPropertyName = "EndAmt";
			
			dv.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dv.Columns[10].Visible = false;
			dv.Columns[10].HeaderText = "GoodsTypeID";
			dv.Columns[10].Name = "GoodsTypeID";
			dv.Columns[10].Width = 60;
			dv.Columns[10].DataPropertyName = "GoodsTypeID";
			
			
			//隐藏不需要的
			foreach(DataGridViewColumn c in dv.Columns)
			{
				if(c.Index>9)
				{
					c.Visible = false;
				}
			}
		}
		
		void ButtonCXClick(object sender, EventArgs e)
		{
			//查询库存
			int iWareHouseID = Convert.ToInt32(comboBoxWareHouseID.SelectedValue);
			if(iWareHouseID == 0)
			{
				ds1 = BLL.WareHouseBLL.GetStock(comboBoxPeriod.Text);
			}
			else
			{
				ds1 = BLL.WareHouseBLL.GetStock(comboBoxPeriod.Text,iWareHouseID);
			}
			
			sPeriodNo = comboBoxPeriod.Text;
			dataGridView1.DataSource = ds1.Tables[0];
			SetHeader(dataGridView1);
			ShowStock();
		}
		
		void FillCurStock(string sCycle)
		{
			ds1 = BLL.WareHouseBLL.GetStockCurrent(sCycle);
			dataGridView1.DataSource = ds1.Tables[0];
			SetHeader(dataGridView1);
			ShowStock();
		}
		
		void FillCurStock(string sCycle,int iWareHouseID)
		{
			ds1 = BLL.WareHouseBLL.GetStockCurrent(sCycle,iWareHouseID);
			dataGridView1.DataSource = ds1.Tables[0];
			SetHeader(dataGridView1);
			ShowStock();
		}
		
		void RadioButtonCurStockClick(object sender, EventArgs e)
		{
			string s1 = BLL.WareHouseBLL.GetMaxJSCycle();
			
			int iWareHouseID = Convert.ToInt32(comboBoxWareHouseID.SelectedValue);
			if(iWareHouseID == 0)
			{
				FillCurStock(s1);
			}
			else
			{
				FillCurStock(s1,iWareHouseID);
			}
			
			buttonCX.Enabled = false;
		}
		void RadioButtonHisStockClick(object sender, EventArgs e)
		{
			buttonCX.Enabled = true;
		}
		
		//将适合过滤条件的库存数据显示在DataGridView中
		void ShowStock()
		{
			//FillGoodsTypeList();		//将选择的类别列表填充完整
			//MessageBox.Show(l_GoodsTypeList.Count.ToString());
			int row = dataGridView1.Rows.Count;//得到总行数
			for (int i = 0; i <  row; i++)
			{
				//MessageBox.Show(dataGridView1.Rows[i].Cells[3].Value.ToString());
				bool sFlag = true;
				string ts = dataGridView1.Rows[i].Cells["EndQty"].Value.ToString();
				if(ts == "")
				{
					ts = "0";
				}
				decimal dt1 = 0.0M;
				if (ts.Contains("E"))
				{
                	dt1 = Convert.ToDecimal(Decimal.Parse(ts.ToString(), System.Globalization.NumberStyles.Float));
            	}
				else
				{
					dt1 = Convert.ToDecimal(ts);
				}
				if(dt1 > 0 && !b_DispPositive)
				{
					sFlag = false;
					goto DoShow;
				}
				if(dt1 == 0 && !b_DispZeroStock)
				{
					sFlag = false;
					goto DoShow;
				}
				if(dt1 < 0 && !b_DispNegative)
				{
					sFlag = false;
					goto DoShow;
				}
				int tGID =  Convert.ToInt32(dataGridView1.Rows[i].Cells["GoodsID"].Value.ToString());
				//检测货品类别
				int tiTypeID = Convert.ToInt32(dataGridView1.Rows[i].Cells["GoodsTypeID"].Value.ToString());
				if(!l_GoodsTypeList.Contains(tiTypeID))
				{
					sFlag = false;
					goto DoShow;
				}
				//检测品名过滤
				string s1 = dataGridView1.Rows[i].Cells["GoodsName"].Value.ToString();
				string s2 = textBoxFindGoods.Text.Trim();
				if(s1.IndexOf(s2) == -1)
				{
					sFlag = false;
					goto DoShow;
				}
				
			DoShow:
				CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
				cm.SuspendBinding(); //挂起数据绑定
				dataGridView1.Rows[i].Visible = sFlag;
				cm.ResumeBinding(); //恢复数据绑定
			}
			
			
		}
		
		
		void FillGoodsTypeList()
		{
			//将原来可能存在的列表清除
			if(l_GoodsTypeList != null)
			{
				l_GoodsTypeList.Clear();
			}
			//根据当前选择的节点，将当前节点及下级节点添加到list中
			TreeNode tParent = treeView1.SelectedNode;
			
			TreeNode tCur,tCurPar;
			if(tParent == null)
			{
				if(treeView1.Nodes.Count>0)
				{
					tParent = treeView1.Nodes[0];
					l_GoodsTypeList.Add(Convert.ToInt32(tParent.Tag.ToString()));
				}
				else
				{
					return;
				}
			}
			else
			{
				l_GoodsTypeList.Add(Convert.ToInt32(tParent.Tag.ToString()));
			}
			
			tCurPar = tParent;
			tCur = tCurPar.FirstNode;
			while(tCur != null && tCur.Level > tParent.Level)
			{
				l_GoodsTypeList.Add(Convert.ToInt32(tCur.Tag.ToString()));
				if(tCur.Nodes.Count > 0)
				{
					tCurPar = tCur;
					tCur = tCurPar.FirstNode;
				}
				else
				{
					//tCurPar = tCur.Parent;
					if(tCur.NextNode == null)
					{
						tCurPar = tCur.Parent;
						tCur = tCurPar.NextNode;
					}
					else
					{
						tCur = tCur.NextNode;
					}
				}
				
			}
			
		}
		
		void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
		{
			FillGoodsTypeList();
			ShowStock();
		}
		
		void TextBoxFindGoodsTextChanged(object sender, EventArgs e)
		{
			s_GoodsNameFilter = textBoxFindGoods.Text;
			ShowStock();
		}
		
		void ButtonPrintClick(object sender, EventArgs e)
		{
			FastReport.Report report1 = new FastReport.Report();
			report1.Load("Reports\\Stock.frx");

			DataSet FDataSet = new DataSet();
			DataTable table = new DataTable();
			table = ds1.Tables[0].Copy();
			table.TableName = "Stock";
			FDataSet.Tables.Add(table);
			report1.SetParameterValue("PeriodNo",sPeriodNo);
			report1.RegisterData(FDataSet);
			report1.Show();
			report1.Dispose();
		}
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			b_DispPositive = checkBox1.Checked;
			ShowStock();
		}
		void CheckBox2CheckedChanged(object sender, EventArgs e)
		{
			b_DispZeroStock = checkBox2.Checked;
			ShowStock();
		}
		void CheckBox3CheckedChanged(object sender, EventArgs e)
		{
			b_DispNegative = checkBox3.Checked;
			ShowStock();
		}
		void ButtonPrint1Click(object sender, EventArgs e)
		{
			//打印非零库存
			FastReport.Report report1 = new FastReport.Report();
			report1.Load("Reports\\Stock.frx");

			DataSet FDataSet = new DataSet();
			DataTable table = new DataTable();
			table = ds1.Tables[0].Clone();
			DataRow[] drArr = ds1.Tables[0].Select("EndQty <> 0");//查询			
			table.TableName = "Stock";
			for (int i = 0; i < drArr.Length; i++) 
			{ 
			    table.ImportRow(drArr[i]);
			}
			FDataSet.Tables.Add(table);
			report1.SetParameterValue("PeriodNo",sPeriodNo);
			report1.RegisterData(FDataSet);
			report1.Show();
			report1.Dispose();
		}
		void Button1Click(object sender, EventArgs e)
		{
			//打印当前显示的库存内容
			FastReport.Report report1 = new FastReport.Report();
			report1.Load("Reports\\Stock.frx");

			DataSet FDataSet = new DataSet();
			DataTable table = new DataTable();
			table = ds1.Tables[0].Clone();
				
			table.TableName = "Stock";
			//dataGridView1.SelectAll();
			foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
			{ 
				string tsGoodsID = dr.Cells["GoodsID"].Value.ToString();
				DataRow[] dr1 = ds1.Tables[0].Select("GoodsID = " + tsGoodsID);//查询
				table.ImportRow(dr1[0]);
			}
			FDataSet.Tables.Add(table);
			report1.SetParameterValue("PeriodNo",sPeriodNo);
			report1.RegisterData(FDataSet);
			report1.Show();
			report1.Dispose();
		}
		void 历史入库价ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(dataGridView1.CurrentRow == null)
				return;
			string s_GoodsID = dataGridView1.CurrentRow.Cells["GoodsID"].Value.ToString();
			if(s_GoodsID == "")
				return;
			int i_GoodsID;
			i_GoodsID = Convert.ToInt32(s_GoodsID);
			//显示历史单价
			FormPriceList tFormPriceList = new FormPriceList();			
			tFormPriceList.i_GoodsID = i_GoodsID;
			tFormPriceList.ShowDialog();

		}
		void ComboBoxWareHouseIDSelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBoxWareHouseID.Tag == null)
				return;
			int iWareHouseID = Convert.ToInt32(comboBoxWareHouseID.SelectedValue);
			string s1 = BLL.WareHouseBLL.GetMaxJSCycle();
			if(radioButtonCurStock.Checked)
			{
				if(iWareHouseID == 0)
				{
					FillCurStock(s1);
				}
				else
				{
					FillCurStock(s1,iWareHouseID);
				}
			}
			else
			{
				//历史库存
				if(iWareHouseID == 0)
				{
					ds1 = BLL.WareHouseBLL.GetStock(comboBoxPeriod.Text);
				}
				else
				{
					ds1 = BLL.WareHouseBLL.GetStock(comboBoxPeriod.Text,iWareHouseID);
				}
				
				sPeriodNo = comboBoxPeriod.Text;
				dataGridView1.DataSource = ds1.Tables[0];
				SetHeader(dataGridView1);
				ShowStock();
			}
		}
		
		
	}
}
