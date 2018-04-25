/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-02
 * 时间: 16:45
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
	/// Description of FormAccountOUT.
	/// </summary>
	public partial class FormAccountOUT : Form
	{
		private DataSet ds1 = new DataSet();
		public int i_CompanyID;
		private DataSet ds2 = new DataSet();
		private int i_CompanyType = 3;
		private decimal d_InitAmt = 0;
		
		public FormAccountOUT()
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
		
		void ButtonAddClick(object sender, EventArgs e)
		{
			//增加
			FormCompany tF = new FormCompany();
			tF.Text="未付款信息-新增";						
			tF.ShowDialog();
			RefreshAccount();
		}
		
		
		void SetColumnHeader()
		{
			if(dataGridView1.ColumnCount == 0)
				return;
			dataGridView1.AutoGenerateColumns = false;
			//dataGridView1.ColumnCount = 3;
			dataGridView1.ReadOnly = true;
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView1.Columns[0].HeaderText = "ID";
			dataGridView1.Columns[0].Name = "CompanyID";
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[0].DataPropertyName = "CompanyID";
            
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderText = "名称";
            dataGridView1.Columns[1].Name = "CompanyName";
            dataGridView1.Columns[1].Width = dataGridView1.Width - 160 - 30;
            dataGridView1.Columns[1].DataPropertyName = "CompanyName";
            
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderText = "未收款";
            dataGridView1.Columns[2].Name = "CurAmt";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[2].DataPropertyName = "CurAmt";
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dataGridView1.Columns)
            {
            	if(c.Index>2)
            	{
            		c.Visible = false;
            	}
            }
                     
		}
		
		void RefreshAccount()
		{
			ds1 = BLL.CompanyBLL.GetCompany2();
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = ds1.Tables[0];
			decimal d_Total = 0.00M;
			int row = dataGridView1.Rows.Count;//得到总行数				
			for (int i = 0; i <  row; i++)
			{
				d_Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["CurAmt"].Value.ToString());
				//MessageBox.Show(dataGridView1.Rows[i].Cells[3].Value.ToString());
				bool sFlag = true;
				if(checkBoxHideZero.Checked)
				{
					string ts = dataGridView1.Rows[i].Cells["CurAmt"].Value.ToString();
					//检测0
					if(ts == "0")
					{
						sFlag = false;
						goto DoShow;
					}
				}				
				
			DoShow:
				CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
				cm.SuspendBinding(); //挂起数据绑定
				dataGridView1.Rows[i].Visible = sFlag;
				cm.ResumeBinding(); //恢复数据绑定
			}
			labelTotal.Text = "合计应付款：" + d_Total.ToString() + "元";
			
		}
		void FormAccountOUTLoad(object sender, EventArgs e)
		{
			//
			ds1 = BLL.CompanyBLL.GetCompany2();
			
			dataGridView1.DataSource = ds1.Tables[0];
			SetColumnHeader();
			RefreshAccount();
		}
		
		void ButtonModifyClick(object sender, EventArgs e)
		{
			//修改
			if(dataGridView1.CurrentRow != null)
			{
				FormCompany tF = new FormCompany();
				tF.i_CompanyID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
				tF.Text="未付款信息-修改";						
				tF.ShowDialog();
			}
			else
			{
				MessageBox.Show("请选择要修改的客户或供应商！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			RefreshAccount();
		}
		
		
		void ButtonDelClick(object sender, EventArgs e)
		{
			if(dataGridView1.CurrentRow != null)
			{
				DialogResult result;
				int iCompanyID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
				string sCompanyName = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                result = MessageBox.Show("您确认删除当前选中的【" + sCompanyName + "】客户或供应商吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                	try
                	{
	                    // 删除
	                    BLL.CompanyBLL.DelCompany(iCompanyID);
	                    //更新DataGridView中的内容
	                    RefreshAccount();	                   
						return;
                	}                    
                	catch(Exception e1)
                    {
                		string s1 = e1.Message;
                        MessageBox.Show("删除错误，可能是其他单据使用了此客户或供应商。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
			}			
		}
		
		
		void CheckBoxHideZeroClick(object sender, EventArgs e)
		{
			RefreshAccount();
		}
		void 新未付款ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormAccountBill tF = new FormAccountBill();
			tF.Text="未付款-新增";
			if(dataGridView1.CurrentRow != null)
			{
				tF.i_CompanyID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
			}
					
			tF.ShowDialog();
			RefreshAccount();
		}
		void 付款ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormAccountBill tF = new FormAccountBill();
			tF.Text="未付款-付款";
			if(dataGridView1.CurrentRow != null)
			{
				tF.i_CompanyID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
			}
					
			tF.ShowDialog();
			RefreshAccount();
		}
		
		void 款项记录ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//款项记录、
			/*
			FormAccountBillList tForm = new FormAccountBillList();
			tForm.Text = "款项记录";
			if(dataGridView1.CurrentRow != null)
			{
				tForm.i_CompanyID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
			}
            ((MainForm)(this.ParentForm)).Control_Add(tForm);
            */
		}
		void DataGridView1DoubleClick(object sender, EventArgs e)
		{
			款项记录ToolStripMenuItemClick(sender, e);
		}
		
		void SetColumnHeader2()
		{
			if(dataGridView2.ColumnCount == 0)
				return;
			dataGridView2.AutoGenerateColumns = false;
			//dataGridView1.ColumnCount = 3;
			dataGridView2.ReadOnly = true;
			dataGridView2.AllowUserToAddRows = false;
			dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			
            dataGridView2.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView2.Columns[0].HeaderText = "BillNo";
			dataGridView2.Columns[0].Name = "BillNo";
            dataGridView2.Columns[0].Width = 60;
            dataGridView2.Columns[0].DataPropertyName = "BillNo";
            
            dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[1].HeaderText = "业务日期";
            dataGridView2.Columns[1].Name = "BillDate";
            dataGridView2.Columns[1].Width = 100;
            dataGridView2.Columns[1].DataPropertyName = "BillDate";
            dataGridView2.Columns[1].DefaultCellStyle.Format = "D";
            
            dataGridView2.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[2].HeaderText = "说明";
            dataGridView2.Columns[2].Name = "BillMemo";
            dataGridView2.Columns[2].Width = dataGridView2.Width - 320 - 30;
            dataGridView2.Columns[2].DataPropertyName = "BillMemo";
            
            if(i_CompanyType == 0)
            {
	            dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView2.Columns[3].HeaderText = "应收款";
	            dataGridView2.Columns[3].Name = "BillYS";
	            dataGridView2.Columns[3].Width = 80;
	            dataGridView2.Columns[3].DataPropertyName = "BillYS";
	            
	            dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView2.Columns[4].HeaderText = "实收款";
	            dataGridView2.Columns[4].Name = "BillSS";
	            dataGridView2.Columns[4].Width = 80;
	            dataGridView2.Columns[4].DataPropertyName = "BillSS";
            }
            else
            {
            	dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView2.Columns[3].HeaderText = "应付款";
	            dataGridView2.Columns[3].Name = "BillYF";
	            dataGridView2.Columns[3].Width = 80;
	            dataGridView2.Columns[3].DataPropertyName = "BillYF";
	            
	            dataGridView2.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView2.Columns[4].HeaderText = "实付款";
	            dataGridView2.Columns[4].Name = "BillSF";
	            dataGridView2.Columns[4].Width = 80;
	            dataGridView2.Columns[4].DataPropertyName = "BillSF";
            }
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dataGridView2.Columns)
            {
            	if(c.Index>4)
            	{
            		c.Visible = false;
            	}
            }
                     
		}
		
		void GetAllAccountBill()
		{
			ds2 = BLL.AccountBillBLL.GetAllAccountBill();
		}
		
		void RefreshAccountBill()
		{
			//过滤DataSet
			ds2.Tables[0].DefaultView.RowFilter = string.Format("ComPanyID = {0}" , i_CompanyID);
			dataGridView2.DataSource = ds2.Tables[0].DefaultView;
			
			decimal d_Total = 0.00M;
			int row = dataGridView2.RowCount ;//得到总行数
			if(i_CompanyType == 0)
			{
				for (int i = 0; i <  row; i++)
				{
					d_Total += Convert.ToDecimal(dataGridView2.Rows[i].Cells["BillYS"].Value.ToString());
					d_Total -= Convert.ToDecimal(dataGridView2.Rows[i].Cells["BillSS"].Value.ToString());
				}
				labelCurAmt.Text = "当前应收款：" + (d_Total+d_InitAmt).ToString() + "元";
			}
			else
			{
				for (int i = 0; i <  row; i++)
				{
					d_Total += Convert.ToDecimal(dataGridView2.Rows[i].Cells["BillYF"].Value.ToString());
					d_Total -= Convert.ToDecimal(dataGridView2.Rows[i].Cells["BillSF"].Value.ToString());
				}
				labelCurAmt.Text = "当前应付款：" + (d_Total+d_InitAmt).ToString() + "元";
			}
			
		}
		
		void DataGridView1SelectionChanged(object sender, EventArgs e)
		{
			//检查DataGridView1中选择的相关单位
			if(dataGridView1.CurrentRow != null)
			{
				labelCurCompany.Tag =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
				labelCurCompany.Text = "当前往来单位：" + dataGridView1.CurrentRow.Cells[1].Value.ToString();
				//更新其他显示信息
				i_CompanyID =Convert.ToInt32(labelCurCompany.Tag.ToString());
				Companies tP = BLL.CompanyBLL.GetCompany(i_CompanyID);
				if(tP == null)
					return;
				i_CompanyType = tP.CompanyType;
				//d_InitAmt = tP.InitAmt;
				
				GetAllAccountBill();
				RefreshAccountBill();
				SetColumnHeader2();
				
				if(tP.CompanyType == 0)
				{
					//未收款
					labelInitAmt.Text = "初始应收款：" + d_InitAmt.ToString() + "元";
				}
				else
				{
					labelInitAmt.Text = "初始应付款：" + d_InitAmt.ToString() + "元";
				}
			}
		}
		void FormAccountOUTResize(object sender, EventArgs e)
		{
			SetColumnHeader();
			SetColumnHeader2();
		}
		void 删除记录ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//删除收付款记录
			if(dataGridView2.CurrentRow != null)
			{
				DialogResult result;
				int iBillNo	= Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
				string sDate = dataGridView2.CurrentRow.Cells[1].Value.ToString();
				string sBillMemo = dataGridView2.CurrentRow.Cells[2].Value.ToString();

                result = MessageBox.Show("您确认删除当前选中的【" + sDate + "的" + sBillMemo + "】收付款吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                	try
                	{
	                    // 删除
	                    BLL.AccountBillBLL.DelAccountBill(iBillNo);
	                    //更新DataGridView中的内容
	                    GetAllAccountBill();
	                    RefreshAccountBill();	
						//刷新DataGridView1
	                    RefreshAccount();	                    
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
		void ButtonPrintClick(object sender, EventArgs e)
		{
			//打印
			using(FastReport.Report report1 = new FastReport.Report())
			{
				report1.Load("Reports\\AccountList.frx");
	
				DataSet FDataSet = BLL.AccountBillBLL.GetAllAccountBillFK();
				DataTable table = new DataTable();
				table = FDataSet.Tables[0];
				table.TableName = "AccountBill";
				report1.SetParameterValue("ListType",1);
				report1.RegisterData(FDataSet);
				report1.Show();
				report1.Dispose();
			}
		}
		
		
	}
}
