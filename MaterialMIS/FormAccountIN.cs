/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-02
 * 时间: 16:38
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
	/// Description of FormAccountIN.
	/// </summary>
	public partial class FormAccountIN : Form
	{
		private DataSet ds1 = new DataSet();
		public int i_CompanyID;
		private DataSet ds2 = new DataSet();
		private int i_CompanyType = 3;
		private decimal d_InitAmt = 0;
		
		public FormAccountIN()
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
		void FormAccountINLoad(object sender, EventArgs e)
		{
			//
			ds1 = BLL.StatementListBLL.GetCompanyTotalByType(0);
			
			dataGridView1.DataSource = ds1.Tables[0];
			SetColumnHeader(dataGridView1);
			RefreshAccount();
		}
		
		void SetColumnHeader(DataGridView dv)
		{
			if(dv.ColumnCount == 0)
				return;
			dv.AutoGenerateColumns = false;
			//dv.ColumnCount = 3;
			dv.ReadOnly = true;
			dv.AllowUserToAddRows = false;
			dv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
            dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].HeaderText = "ID";
			dv.Columns[0].Name = "CompanyID";
            dv.Columns[0].Width = 60;
            dv.Columns[0].DataPropertyName = "CompanyID";
            
            dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].HeaderText = "名称";
            dv.Columns[1].Name = "CompanyName";
            dv.Columns[1].Width = 200;
            dv.Columns[1].DataPropertyName = "CompanyName";
            
            dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].HeaderText = "应收款";
            dv.Columns[2].Name = "SUMYS";
            dv.Columns[2].Width = 100;
            dv.Columns[2].DataPropertyName = "SUMYS";
            
            dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].HeaderText = "实收款";
            dv.Columns[3].Name = "SUMSS";
            dv.Columns[3].Width = 100;
            dv.Columns[3].DataPropertyName = "SUMSS";
            
            dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].HeaderText = "未收款";
            dv.Columns[4].Name = "SUMYE1";
            dv.Columns[4].Width = 100;
            dv.Columns[4].DataPropertyName = "SUMYE1";
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dataGridView1.Columns)
            {
            	if(c.Index>4)
            	{
            		c.Visible = false;
            	}
            }
                     
		}
		
		void ButtonAddClick(object sender, EventArgs e)
		{
			//增加
			FormCompany tF = new FormCompany();
			tF.Text="未收款信息-新增";						
			tF.ShowDialog();
			RefreshAccount();
		}
		
		
		void RefreshAccount()
		{
			ds1 = BLL.StatementListBLL.GetCompanyTotalByType(0);
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = ds1.Tables[0];
			decimal d_Total = 0.00M;
			int row = dataGridView1.Rows.Count;//得到总行数				
			for (int i = 0; i <  row; i++)
			{
				d_Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["SUMYE1"].Value.ToString());
				//MessageBox.Show(dataGridView1.Rows[i].Cells[3].Value.ToString());
				bool sFlag = true;
				if(checkBoxHideZero.Checked)
				{
					string ts = dataGridView1.Rows[i].Cells["SUMYE1"].Value.ToString();
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
			
			labelTotal.Text = "合计未收款：" + d_Total.ToString() + "元";
		}
			
		void ButtonModifyClick(object sender, EventArgs e)
		{
			//修改
			if(dataGridView1.CurrentRow != null)
			{
				FormCompany tF = new FormCompany();
				tF.i_CompanyID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
				tF.Text="未收款信息-修改";						
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
		void 新未收款ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormAccountBill tF = new FormAccountBill();
			tF.Text="未收款-新增";
			if(dataGridView1.CurrentRow != null)
			{
				tF.i_CompanyID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
			}
					
			tF.ShowDialog();
			RefreshAccount();
		}
		
		void 未收款列表ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormAccountBill tF = new FormAccountBill();
			tF.Text="未收款-收款";
			if(dataGridView1.CurrentRow != null)
			{
				tF.i_CompanyID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
			}
					
			tF.ShowDialog();
			RefreshAccount();
		}
		void 收款ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//款项记录
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
			//
			收款ToolStripMenuItemClick(sender, e);
		}
		
		
		void SetColumnHeader2(DataGridView dv)
		{
			if(dv.ColumnCount == 0)
				return;
			dv.AutoGenerateColumns = false;
			//dataGridView1.ColumnCount = 3;
			dv.ReadOnly = true;
			dv.AllowUserToAddRows = false;
			dv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
            dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].HeaderText = "SID";
			dv.Columns[0].Name = "SID";
            dv.Columns[0].Width = 60;
            dv.Columns[0].DataPropertyName = "SID";
            
            dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].HeaderText = "业务日期";
            dv.Columns[1].Name = "StatementDate";
            dv.Columns[1].Width = 100;
            dv.Columns[1].DataPropertyName = "StatementDate";
            dv.Columns[1].DefaultCellStyle.Format = "D";
            
            dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].HeaderText = "说明";
            dv.Columns[2].Name = "StatementMemo";
            dv.Columns[2].Width = 200;
            dv.Columns[2].DataPropertyName = "StatementMemo";
            
            dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].HeaderText = "应收款";
            dv.Columns[3].Name = "BillYS";
            dv.Columns[3].Width = 80;
            dv.Columns[3].DataPropertyName = "BillYS";
            
            dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].HeaderText = "实收款";
            dv.Columns[4].Name = "BillSS";
            dv.Columns[4].Width = 80;
            dv.Columns[4].DataPropertyName = "BillSS";
            
            dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].HeaderText = "应付款";
            dv.Columns[5].Name = "BillYF";
            dv.Columns[5].Width = 80;
            dv.Columns[5].DataPropertyName = "BillYF";
            
            dv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[6].HeaderText = "实付款";
            dv.Columns[6].Name = "BillSF";
            dv.Columns[6].Width = 80;
            dv.Columns[6].DataPropertyName = "BillSF";

            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dataGridView2.Columns)
            {
            	if(c.Index>6)
            	{
            		c.Visible = false;
            	}
            }
                     
		}
		
		void GetAllAccountBill()
		{
			ds2 = BLL.StatementListBLL.GetCompanyStatementList(i_CompanyID);
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
		void DataGridView1MouseClick(object sender, MouseEventArgs e)
		{
			
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
				SetColumnHeader2(dataGridView2);
				
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
		
		void FormAccountINResize(object sender, EventArgs e)
		{
			SetColumnHeader(dataGridView1);
			SetColumnHeader2(dataGridView2);
		}
		void 删除记录ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//
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
	
				DataSet FDataSet = BLL.AccountBillBLL.GetAllAccountBillSK();
				DataTable table = new DataTable();
				table = FDataSet.Tables[0];
				table.TableName = "AccountBill";
				report1.SetParameterValue("ListType",0);
				report1.RegisterData(FDataSet);
				report1.Show();
				report1.Dispose();

			}
		}
		
	}
}
