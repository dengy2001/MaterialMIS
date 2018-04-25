/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-03
 * 时间: 20:56
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
	/// Description of FormAccountBillList.
	/// </summary>
	public partial class FormAccountBillList : Form
	{
		
		public int i_CompanyID;
		private DataSet ds1 = new DataSet();
		private DataSet ds2 = new DataSet();
		private int i_CompanyType = 3;
		private decimal d_InitAmt = 0;
		
		public FormAccountBillList()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ButtonCancelClick(object sender, EventArgs e)
		{
			((MainForm)(this.ParentForm)).Page_Close(this);
			this.Close();
		}
		
		void FillCompany()
		{
			ds1 = BLL.CompanyBLL.GetCompanyAll();
			comboBoxCompany.DataSource = ds1.Tables[0];
			comboBoxCompany.DisplayMember = "CompanyName";
			comboBoxCompany.ValueMember = "CompanyID";
		}
		
		void GetAllAccountBill()
		{
			ds2 = BLL.AccountBillBLL.GetAllAccountBill();
		}
		
		void RefreshAccountBill()
		{
			//过滤DataSet
			ds2.Tables[0].DefaultView.RowFilter = string.Format("ComPanyID = {0}" , i_CompanyID);
			dataGridView1.DataSource = ds2.Tables[0].DefaultView;
			
			decimal d_Total = 0.00M;
			int row = dataGridView1.RowCount ;//得到总行数
			if(i_CompanyType == 0)
			{
				for (int i = 0; i <  row; i++)
				{
					d_Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["BillYS"].Value.ToString());
					d_Total -= Convert.ToDecimal(dataGridView1.Rows[i].Cells["BillSS"].Value.ToString());
				}
				labelCurAmt.Text = "当前应收款：" + (d_Total+d_InitAmt).ToString() + "元";
			}
			else
			{
				for (int i = 0; i <  row; i++)
				{
					d_Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["BillYF"].Value.ToString());
					d_Total -= Convert.ToDecimal(dataGridView1.Rows[i].Cells["BillSF"].Value.ToString());
				}
				labelCurAmt.Text = "当前应付款：" + (d_Total+d_InitAmt).ToString() + "元";
			}
			
		}
		
		void FormAccountBillListLoad(object sender, EventArgs e)
		{	
			dataGridView1.AllowUserToAddRows = false;
			
			FillCompany();			
			comboBoxCompany.SelectedValue = i_CompanyID;
			Companies tP = BLL.CompanyBLL.GetCompany(i_CompanyID);
			i_CompanyType = tP.CompanyType;	
			//d_InitAmt = tP.InitAmt;
			
			GetAllAccountBill();
			RefreshAccountBill();
			SetColumnHeader();
			
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
		
		void SetColumnHeader()
		{
			dataGridView1.AutoGenerateColumns = false;
			//dataGridView1.ColumnCount = 3;
			dataGridView1.ReadOnly = true;
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView1.Columns[0].HeaderText = "BillNo";
			dataGridView1.Columns[0].Name = "BillNo";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[0].DataPropertyName = "BillNo";
            
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderText = "业务日期";
            dataGridView1.Columns[1].Name = "BillDate";
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[1].DataPropertyName = "BillDate";
            dataGridView1.Columns[1].DefaultCellStyle.Format = "D";
            
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderText = "说明";
            dataGridView1.Columns[2].Name = "BillMemo";
            dataGridView1.Columns[2].Width = dataGridView1.Width - 500;
            dataGridView1.Columns[2].DataPropertyName = "BillMemo";
            
            if(i_CompanyType == 0)
            {
	            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView1.Columns[3].HeaderText = "应收款";
	            dataGridView1.Columns[3].Name = "BillYS";
	            dataGridView1.Columns[3].Width = 100;
	            dataGridView1.Columns[3].DataPropertyName = "BillYS";
	            
	            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView1.Columns[4].HeaderText = "实收款";
	            dataGridView1.Columns[4].Name = "BillSS";
	            dataGridView1.Columns[4].Width = 100;
	            dataGridView1.Columns[4].DataPropertyName = "BillSS";
            }
            else
            {
            	dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView1.Columns[3].HeaderText = "应付款";
	            dataGridView1.Columns[3].Name = "BillYF";
	            dataGridView1.Columns[3].Width = 100;
	            dataGridView1.Columns[3].DataPropertyName = "BillYF";
	            
	            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	            dataGridView1.Columns[4].HeaderText = "实付款";
	            dataGridView1.Columns[4].Name = "BillSF";
	            dataGridView1.Columns[4].Width = 100;
	            dataGridView1.Columns[4].DataPropertyName = "BillSF";
            }
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dataGridView1.Columns)
            {
            	if(c.Index>4)
            	{
            		c.Visible = false;
            	}
            }
                     
		}
		void ComboBoxCompanySelectedIndexChanged(object sender, EventArgs e)
		{
			//改变了公司
			if(comboBoxCompany.SelectedValue.ToString() == "System.Data.DataRowView")
				return;
			i_CompanyID =Convert.ToInt32(comboBoxCompany.SelectedValue.ToString());
			Companies tP = BLL.CompanyBLL.GetCompany(i_CompanyID);
			i_CompanyType = tP.CompanyType;
			//d_InitAmt = tP.InitAmt;
			
			GetAllAccountBill();
			RefreshAccountBill();
			SetColumnHeader();
			
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
		void ButtonPrintClick(object sender, EventArgs e)
		{
			//MessageBox.Show(this.comboBoxCompany.SelectedValue.ToString());
		}
		void 删除记录ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//删除收付款记录
			if(dataGridView1.CurrentRow != null)
			{
				DialogResult result;
				int iBillNo	= Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
				string sDate = dataGridView1.CurrentRow.Cells[1].Value.ToString();
				string sBillMemo = dataGridView1.CurrentRow.Cells[2].Value.ToString();

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
		
	}
}
