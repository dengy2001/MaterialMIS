/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-16
 * 时间: 12:47
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DomainModel;


namespace MaterialMIS
{
	/// <summary>
	/// Description of FormInput.
	/// </summary>
	public partial class FormInput : Form
	{
		public TextBox tb1;
		public int iWareHouseID;	//仓库
		
		private int ii;
		DataSet ds1 = new DataSet();
		public DataGridView dvParent;
		public bool DispZeroStock;
		
		public FormInput()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormInputLoad(object sender, EventArgs e)
		{
			tb1 = textBox1;
			//填充DataGridView
			FillDataGridView();
			if(DispZeroStock)
			{
				checkBox1.Checked = true;
			}
		}
		
		void SetDataGridViewFormat(DataGridView dv)
		{
			dv.AutoGenerateColumns = false;	
			dv.ColumnCount = 8;
			dv.ReadOnly = true;
			dv.AllowUserToAddRows = false;
			dv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
						
            dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].HeaderText = "货品名称";
			dv.Columns[0].Name = "GoodsName";
            dv.Columns[0].Width = 150;
            dv.Columns[0].DataPropertyName = "GoodsName";
            
            dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].HeaderText = "规格型号";
            dv.Columns[1].Name = "GoodsSpec";
            dv.Columns[1].Width = 80;
            dv.Columns[1].DataPropertyName = "GoodsSpec";
            
            dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].HeaderText = "货品类别";
            dv.Columns[2].Name = "GoodsTypeName";
            dv.Columns[2].Width = 100;
            dv.Columns[2].DataPropertyName = "GoodsTypeName";
            
            dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].HeaderText = "单位";
            dv.Columns[3].Name = "GoodsUnit";
            dv.Columns[3].Width = 80;
            dv.Columns[3].DataPropertyName = "GoodsUnit";  
            
            dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].HeaderText = "库存";
            dv.Columns[4].Name = "Number";
            dv.Columns[4].Width = 80;
            dv.Columns[4].DataPropertyName = "Number";  
            
            //不显示出来的列
            dv.Columns[5].Visible = false;
            dv.Columns[5].Name = "GoodsID";
            dv.Columns[5].DataPropertyName = "GoodsID";
            
            dv.Columns[6].Visible = false;
            dv.Columns[6].Name = "GoodsTypeID";
            dv.Columns[6].DataPropertyName = "GoodsTypeID";            
           
            dv.Columns[7].Visible = false;
            dv.Columns[7].Name = "LastPrice";
            dv.Columns[7].DataPropertyName = "LastPrice";

		}
		
		//将适合过滤条件的数据显示在DataGridView中
		void ShowGoods()
		{		
			int row = dataGridView1.Rows.Count;//得到总行数	
					
			for (int i = 0; i <  row; i++)
			{
				bool sFlag = true;	
				//检测品名过滤
				string s1 = dataGridView1.Rows[i].Cells["GoodsName"].Value.ToString();
				string s2 = textBox1.Text.Trim();
				if(s1.IndexOf(s2) == -1)
				{
					sFlag = false;
					goto DoShow;
				}
				if(!checkBox1.Checked)
				{
					if(dataGridView1.Rows[i].Cells["Number"].Value.ToString() == "")
					{
						sFlag = false;
						goto DoShow;
					}
					string s3 = dataGridView1.Rows[i].Cells["Number"].Value.ToString();
					if(Convert.ToDecimal(s3) <= 0)
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
		}
		
		void FillDataGridView()
		{
			ds1 = BLL.GoodsBLL.GetAllGoods2(iWareHouseID);
			
			//dataGridView格式调整
			dataGridView1.DataSource = null;
			SetDataGridViewFormat(dataGridView1);
			dataGridView1.DataSource = ds1.Tables[0];
			//显示过滤后应显示的行
			ShowGoods();
			
		}
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			ii++;
			label1.Text = ii.ToString();
			ShowGoods();
		}
		void Button1Click(object sender, EventArgs e)
		{
			//添加选择的货品到货品列表中
			if(dataGridView1.CurrentRow == null)
			{
				this.Visible = false;
				return;
			}			
			string sGoodsName = dataGridView1.CurrentRow.Cells["GoodsName"].Value.ToString();
			string sGoodsTypeName = dataGridView1.CurrentRow.Cells["GoodsTypeName"].Value.ToString();
			string sGoodsUnit = dataGridView1.CurrentRow.Cells["GoodsUnit"].Value.ToString();
			string sLastPrc = dataGridView1.CurrentRow.Cells["LastPrice"].Value.ToString();
			//排除没有单价时的错误
			if(sLastPrc == "")
			{
				sLastPrc = "0";
			}
			
			string sGoodsID = dataGridView1.CurrentRow.Cells["GoodsID"].Value.ToString();
			string sGoodsTypeID = dataGridView1.CurrentRow.Cells["GoodsTypeID"].Value.ToString();
			string sGoodsSpec = dataGridView1.CurrentRow.Cells["GoodsSpec"].Value.ToString();
			
			dvParent.CurrentRow.Cells["GoodsName"].Value = sGoodsName;
			dvParent.CurrentRow.Cells["GoodsTypeName"].Value = sGoodsTypeName;
			dvParent.CurrentRow.Cells["GoodsSpec"].Value = sGoodsSpec;
			dvParent.CurrentRow.Cells["GoodsUnit"].Value = sGoodsUnit;
			dvParent.CurrentRow.Cells["GoodsPrc"].Value = Convert.ToDecimal(sLastPrc);
			dvParent.CurrentRow.Cells["GoodsQty"].Value = 0;
			dvParent.CurrentRow.Cells["GoodsTaxRate"].Value = 0;
			if(dvParent.Columns.Contains("GoodsYF"))
			{
				dvParent.CurrentRow.Cells["GoodsYF"].Value = 0;
			}
			dvParent.CurrentRow.Cells["GoodsID"].Value = Convert.ToInt32(sGoodsID);
			dvParent.CurrentRow.Cells["GoodsTypeID"].Value = Convert.ToInt32(sGoodsTypeID);
			
			dvParent.EndEdit();
			this.Visible = false;
			
		}
		void DataGridView1DoubleClick(object sender, EventArgs e)
		{
			Button1Click(sender,e);
		}
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			DispZeroStock = !DispZeroStock;
			ShowGoods();
		}

		void DataGridView1KeyDown(object sender, KeyEventArgs e)
		{
			//检查是否回车
			switch(e.KeyCode)
			{
				case Keys.Enter:
					Button1Click(sender,e);
					break;
				case Keys.Escape:
					this.Visible = false;
					break;
				default:
					break;
			}
			
		}
		void FormInputVisibleChanged(object sender, EventArgs e)
		{
			//重新填充
			FillDataGridView();
		}
		
	}
}
