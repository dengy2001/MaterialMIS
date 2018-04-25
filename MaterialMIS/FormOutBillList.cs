/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-07-14
 * 时间: 14:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormOutBillList.
	/// </summary>
	public partial class FormOutBillList : Form
	{
		
		private DataSet ds1 = new DataSet();		//出库项
		private DataSet ds2 = new DataSet();		//出库明细
		
		public FormOutBillList()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ButtonCloseClick(object sender, EventArgs e)
		{
			((MainForm)(this.ParentForm)).Page_Close(this);
            this.Close();
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			//根据下拉框选择的改变，修改日期选择
			string ts1 = comboBox1.Text;
			switch(ts1)
			{
				case "今日":
					dateTimePicker1.Value = DateTime.Today;
					dateTimePicker2.Value = DateTime.Today;
					break;
				case "本月":
					DateTime dt = DateTime.Now;
					DateTime dt_First = dt.AddDays(-(dt.Day) + 1); 
					DateTime dt2 = dt.AddMonths(1);
					DateTime dt_Last = dt2.AddDays(-(dt.Day));
 
					dateTimePicker1.Value = dt_First;
					dateTimePicker2.Value = dt_Last;
					break;
				case "本年":
					dt = DateTime.Now;
					dt_First = dt.AddDays(-(dt.Day) + 1); 
					dt_First = dt_First.AddMonths(-(dt_First.Month)+1);
					dt2 = dt.AddYears(1);
					dt_Last = dt2.AddMonths(-(dt.Month)+1);
					dt_Last = dt_Last.AddDays(-(dt_Last.Day));
					
					dateTimePicker1.Value = dt_First;
					dateTimePicker2.Value = dt_Last;
					break;
				default:
					break;
			}
		}
		
		void RefreshDataGridView1()
		{
			ds1 = BLL.CKBLL.GetAllOutStock("已记账");
			dataGridView1.DataSource = ds1.Tables[0];
			SetGridView1Header();			
			CalcTotal();
			FormOutBillListResize(null,null);
		}
		
		void SetGridView1Header()
		{
			if(dataGridView1.Rows.Count == 0)
			{
				return;
			}
			dataGridView1.AutoGenerateColumns = false;	
			//dataGridViewProjects.ColumnCount = 3;
			dataGridView1.ReadOnly = true;
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Format = "yyyy-MM-dd";
			dataGridView1.Columns[0].HeaderText = "单据日期";
			dataGridView1.Columns[0].Name = "OutStockDate";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[0].DataPropertyName = "OutStockDate";
            
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderText = "单据编号";
            dataGridView1.Columns[1].Name = "OutStockNum";
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[1].DataPropertyName = "OutStockNum";
            
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderText = "领用部门名称";
            dataGridView1.Columns[2].Name = "CompanyName";
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[2].DataPropertyName = "CompanyName";
            
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Format = "0.00";
            dataGridView1.Columns[3].HeaderText = "出库金额";
            dataGridView1.Columns[3].Name = "OutBillAmt";
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[3].DataPropertyName = "OutBillAmt";   

			dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].HeaderText = "领用人";
            dataGridView1.Columns[4].Name = "UseMan";
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[4].DataPropertyName = "UseMan"; 

			dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].HeaderText = "出库人";
            dataGridView1.Columns[5].Name = "OutMan";
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[5].DataPropertyName = "OutMan";             
                        
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[6].HeaderText = "说明";
            dataGridView1.Columns[6].Name = "OutBillRemark";
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[6].DataPropertyName = "OutBillRemark";
            
            //不显示出来的列
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[7].Name = "OutStockID";
            dataGridView1.Columns[7].DataPropertyName = "OutStockID"; 
            
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dataGridView1.Columns)
            {
            	if(c.Index>6)
            	{
            		c.Visible = false;
            	}
            }
           
		}

		void MoveLable()
		{
			//调整显示合计位置
			try
			{
				Rectangle r1 = dataGridView1.GetCellDisplayRectangle(3,0,false);
				labelBillAmtTotal.Left = r1.Left;
				labelBillAmtTotal.Width = r1.Width;
			}
			catch(Exception e1)
			{
				string s1 = e1.Message;
			}
		}
		
		void CalcTotal()
		{
			//重新计算合计
			int row = dataGridView1.Rows.Count;//得到总行数
			Decimal dTotalBillAmt = 0.00M;

			for (int i = 0; i <  row; i++)
			{
				if(!dataGridView1.Rows[i].Visible)
				{
					continue;
				}
				
				decimal dBillAmt = 0.00M;

				try
				{
					dBillAmt = Convert.ToDecimal(dataGridView1.Rows[i].Cells["OutBillAmt"].Value);
					dTotalBillAmt += dBillAmt;
				}
				catch(Exception e1)
				{
					string s1 = e1.Message;
				}
			}
			labelBillAmtTotal.Text = dTotalBillAmt.ToString("0.00");
			
		}
		void FormOutBillListLoad(object sender, EventArgs e)
		{
			//填充ds1
			RefreshDataGridView1();
			FormOutBillListResize(sender,e);
			CalcTotal();
		}
		void FormOutBillListResize(object sender, EventArgs e)
		{
			SetGridView1Header();
			MoveLable();
		}
		void ButtonDelClick(object sender, EventArgs e)
		{
			//删除出库单
			if(dataGridView1.CurrentRow != null)
			{
				DialogResult result;
				int i_OutStockID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OutStockID"].Value.ToString());
				string sReceiptNo = dataGridView1.CurrentRow.Cells["OutStockNum"].Value.ToString();
				result = MessageBox.Show("您确认删除当前选中的【" + sReceiptNo + "】出库单吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                	try
                	{
	                    // 删除
	                    BLL.CKBLL.DelCKD(i_OutStockID);
	                    RefreshDataGridView1();
						return;
                	}                    
                	catch(Exception e1)
                    {
                        MessageBox.Show("删除错误:" + e1.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
			}
		}
		
		
		void ButtonAddClick(object sender, EventArgs e)
		{
			//新增出库单
			FormOutBill tF = new FormOutBill();
			tF.Text="出库单-新增";						
			tF.ShowDialog();
			RefreshDataGridView1();
		}
		
		void ButtonModifyClick(object sender, EventArgs e)
		{
			//修改出库单
			if(dataGridView1.CurrentRow != null)
			{
				FormOutBill tF = new FormOutBill();
				tF.Text="出库单-修改";	
				tF.i_OutStockID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OutStockID"].Value.ToString());				
				tF.ShowDialog();
				RefreshDataGridView1();
			}
		}
		void DataGridView1CurrentCellChanged(object sender, EventArgs e)
		{
			//选择的出库单变化了
			if(dataGridView1.CurrentRow != null)
			{
				int i_OutStockID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OutStockID"].Value.ToString());
				ds2 = BLL.CKBLL.GetOutStockItems(i_OutStockID);
				RefreshDataGridView2();
			}
		}
		
		void RefreshDataGridView2()
		{
			dataGridView2.DataSource = ds2.Tables[0];
			SetGridView2Header();			
		}
		
		void SetGridView2Header()
		{
			if(dataGridView2.Rows.Count == 0)
			{
				return;
			}
			dataGridView2.AutoGenerateColumns = false;	
			//dataGridViewProjects.ColumnCount = 3;
			dataGridView2.ReadOnly = true;
			dataGridView2.AllowUserToAddRows = false;
			dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
            dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridView2.Columns[0].HeaderText = "品名";
			dataGridView2.Columns[0].Name = "GoodsName";
            dataGridView2.Columns[0].Width = 150;
            dataGridView2.Columns[0].DataPropertyName = "GoodsName";
            
            dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[1].HeaderText = "单位";
            dataGridView2.Columns[1].Name = "GoodsUnit";
            dataGridView2.Columns[1].Width = 80;
            dataGridView2.Columns[1].DataPropertyName = "GoodsUnit";
            
            dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[2].HeaderText = "数量";
            dataGridView2.Columns[2].Name = "GoodsQty";
            dataGridView2.Columns[2].Width = 120;
            dataGridView2.Columns[2].DataPropertyName = "GoodsQty";
            
 
            //隐藏不需要的
            foreach(DataGridViewColumn c in dataGridView2.Columns)
            {
            	if(c.Index>2)
            	{
            		c.Visible = false;
            	}
            }
           
		}
		void ButtonSearchClick(object sender, EventArgs e)
		{
			//限定条件，确定显示的入库单
			int row = dataGridView1.Rows.Count;//得到总行数
			string s_str = waterTextBox1.Text.Trim();
			DateTime d_Start = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-M-d"));
			
			DateTime d_End = Convert.ToDateTime(dateTimePicker2.Value.ToString("yyyy-M-d"));
			
			for (int i = 0; i <  row; i++)
			{
				//检测过滤条件确定是否显示
				bool sFlag = true;
				string s_OutStockNum = dataGridView1.Rows[i].Cells["OutStockNum"].Value.ToString();
				string s_OutBillRemark = dataGridView1.Rows[i].Cells["OutBillRemark"].Value.ToString();
				string s_CompanyName = dataGridView1.Rows[i].Cells["CompanyName"].Value.ToString();
				DateTime d_t = Convert.ToDateTime(Convert.ToDateTime(dataGridView1.Rows[i].Cells["OutStockDate"].Value).ToString("yyyy-M-d"));
				if(!s_OutStockNum.Contains(s_str) && !s_OutBillRemark.Contains(s_str) && !s_CompanyName.Contains(s_str))
				{
					sFlag = false;
					goto DoShow;
				}
				
				if(d_t<d_Start || d_t>d_End)
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
			CalcTotal();
		}

		void ButtonPrtCKDClick(object sender, EventArgs e)
		{
			//打印出库单
			FastReport.Report report1 = new FastReport.Report();
			report1.Load("Reports\\CKD.frx");
			int i_OutStockID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OutStockID"].Value.ToString());	

			DataSet FDataSet = new DataSet();
			DataTable table = new DataTable();
			DataSet ds1 = BLL.CKBLL.GetOutStock1(i_OutStockID);
			table = ds1.Tables[0].Copy();
			table.TableName = "OutStock";
			FDataSet.Tables.Add(table);
			
			ds1 = BLL.CKBLL.GetOutStockItems(i_OutStockID);
			table = ds1.Tables[0].Copy();
			table.TableName = "OutStockItems";
			FDataSet.Tables.Add(table);
			
			report1.RegisterData(FDataSet);
			report1.Show();
			report1.Dispose();
		}
		
		
	}
}
