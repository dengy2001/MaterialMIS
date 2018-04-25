/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-08-19
 * 时间: 16:37
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
	/// Description of FormRecordList.
	/// </summary>
	public partial class FormRecordList : Form
	{
		private DataSet ds1 = new DataSet();
		private DataSet ds2 = new DataSet();
		private DataSet ds3 = new DataSet();
		private DataSet ds4 = new DataSet();
		
		public FormRecordList()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			((MainForm)(this.ParentForm)).Page_Close(this);
			this.Close();
		}
		
		void RefreshProject()
		{
			//添加到项目下拉框
			ds1 = BLL.ProjectsBLL.GetAllProjects();
			comboBoxProject.DataSource = ds1.Tables[0];
			comboBoxProject.DisplayMember = "ProjectName";
			comboBoxProject.ValueMember = "ProjectID";
		}
		
		void RefreshProjectSupplier(int i_ProjectID)
		{
			ds2 = BLL.SupplierBLL.GetProjectSupplier(i_ProjectID);
			
			comboBoxSupplier.DisplayMember = "SupplierName";
			comboBoxSupplier.ValueMember = "SupplierID";
			comboBoxSupplier.DataSource = ds2.Tables[0];
		}
		
		void FormRecordListLoad(object sender, EventArgs e)
		{
			//添加项目
			RefreshProject();
		}
		void ComboBoxProjectSelectedIndexChanged(object sender, EventArgs e)
		{
			//将对帐年月清除
			comboBoxYM.Text = "";
			//清空DataView1
			ds3.Clear();
			//刷新选择项目的供货商
			if(comboBoxProject.SelectedValue.GetType()!=typeof(DataRowView) && comboBoxProject.SelectedValue != null)
			{
				RefreshProjectSupplier(Convert.ToInt32(comboBoxProject.SelectedValue));
			}
		}
		
		void 新记录ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//
			FormRecord tF = new FormRecord();
			tF.Text="材料记录-新增";	
			int i_ProjectID,i_SupplierID;
			i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue);
			i_SupplierID = Convert.ToInt32(comboBoxSupplier.SelectedValue);
			
			if(i_ProjectID != 0 && i_SupplierID != 0)
			{
				tF.i_ProjectID = i_ProjectID;
				tF.i_SupplierID = i_SupplierID;
				tF.ShowDialog();
				RefreshDataGridView1();
			}
		}
		
		
		void RefreshDataGridView1()
		{
			int i_ProjectID,i_SupplierID;
			i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue);
			if(i_ProjectID == 0)
			{
				MessageBox.Show("请指定项目！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			i_SupplierID = Convert.ToInt32(comboBoxSupplier.SelectedValue);
			if(i_SupplierID == 0)
			{
				MessageBox.Show("请指定供应商！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			string s_BillCycle = comboBoxYM.Text;
			//检查选BillCycle没
			if(s_BillCycle == "")
			{
				MessageBox.Show("请指定对账年月！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			
			ds3 = BLL.CommMatreialRecordBLL.GetCommMaterialRecord(i_ProjectID,i_SupplierID,s_BillCycle);
			dataGridView1.DataSource = ds3.Tables[0];
			SetGridView1Header();			
			//CalcTotal();
			//FormOutBillListResize(null,null);
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
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Format = "yyyy-MM-dd";
			dataGridView1.Columns[0].HeaderText = "日期";
			dataGridView1.Columns[0].Name = "PurchaseDate";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[0].DataPropertyName = "PurchaseDate";
            
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].HeaderText = "材料名称";
            dataGridView1.Columns[1].Name = "MaterialName";
            dataGridView1.Columns[1].Width = dataGridView1.Width - 41 - 660;
            dataGridView1.Columns[1].DataPropertyName = "MaterialName";
            
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].HeaderText = "规格型号";
            dataGridView1.Columns[2].Name = "MaterialSpec";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[2].DataPropertyName = "MaterialSpec";
            
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].HeaderText = "单位";
            dataGridView1.Columns[3].Name = "MaterialUnit";
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[3].DataPropertyName = "MaterialUnit";            
                        
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "0.000";
            dataGridView1.Columns[4].HeaderText = "数量";
            dataGridView1.Columns[4].Name = "MaterialNumber";
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[4].DataPropertyName = "MaterialNumber";
            
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Format = "0.00";
            dataGridView1.Columns[5].HeaderText = "单价";
            dataGridView1.Columns[5].Name = "Materialprice";
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[5].DataPropertyName = "Materialprice";
            
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].DefaultCellStyle.Format = "0.00";
            dataGridView1.Columns[6].HeaderText = "运费";
            dataGridView1.Columns[6].Name = "MaterialShipment";
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[6].DataPropertyName = "MaterialShipment";
            
            dataGridView1.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].DefaultCellStyle.Format = "0.00";
            dataGridView1.Columns[7].HeaderText = "金额";
            dataGridView1.Columns[7].Name = "MaterialAmt";
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[7].DataPropertyName = "MaterialAmt";
            
            //不显示出来的列
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[8].Name = "CommRecordID";
            dataGridView1.Columns[8].DataPropertyName = "CommRecordID"; 
            
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dataGridView1.Columns)
            {
            	if(c.Index>7)
            	{
            		c.Visible = false;
            	}
            }
           
		}
		
		void ComboBoxSupplierSelectedIndexChanged(object sender, EventArgs e)
		{
			//将对帐年月清除
			comboBoxYM.Text = "";
			//清空DataView1
			ds3.Clear();
			RefreshBillCycle();
		}
		
		void RefreshBillCycle()
		{
			//添加到对账年月
			int i_ProjectID,i_SupplierID;
			i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue);
			if(i_ProjectID == 0)
			{
				MessageBox.Show("请指定项目！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			i_SupplierID = Convert.ToInt32(comboBoxSupplier.SelectedValue);
			if(i_SupplierID == 0)
			{
				MessageBox.Show("请指定供应商！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			ds4 = BLL.CommMatreialRecordBLL.GetBillCycles(i_ProjectID,i_SupplierID);
			//检测当前年月是否在其中，没有的话加上
			DateTime tD = DateTime.Now;
			string sNowYM = tD.ToString("yyyyMM");
			DataTable table = ds4.Tables[0];
		    string expression;
		    expression = "BillCycles ='"+sNowYM+"'";
		    DataRow[] foundRows;
		   	//使用选择方法来找到匹配的所有行。
		   	foundRows = table.Select(expression);
		   	if(foundRows.GetLength(0) == 0)
		   	{
		   		//没有，要加
		   		DataRow newRow; 
		   		newRow = table.NewRow();
				newRow["BillCycles"] = sNowYM; 
				table.Rows.Add(newRow); 

		   	}
			comboBoxYM.DataSource = ds4.Tables[0];
			comboBoxYM.DisplayMember = "BillCycles";
			comboBoxYM.ValueMember = "BillCycles";
		}
		void ComboBoxYMSelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshDataGridView1();
		}
		
		void 修改记录ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(dataGridView1.CurrentRow != null)
			{
				int i_CommRecordID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CommRecordID"].Value.ToString());
				FormRecord tF = new FormRecord();
				tF.Text="材料记录-修改";					
				tF.i_CommRecordID = i_CommRecordID;
				tF.ShowDialog();
				RefreshDataGridView1();
			}
			
		}
		void 删除记录ToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(dataGridView1.CurrentRow != null)
			{
				DialogResult result;
				int i_CommRecordID= Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value.ToString());
				string sCommRecordNo = dataGridView1.CurrentRow.Cells[8].Value.ToString();
				result = MessageBox.Show("您确认删除当前选中的【" + sCommRecordNo + "】记录吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                	try
                	{
	                    // 删除
	                    BLL.CommMatreialRecordBLL.DelCommRecordID(i_CommRecordID);
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
	}
}
