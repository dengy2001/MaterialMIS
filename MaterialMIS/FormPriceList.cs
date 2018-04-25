/*
 * 由SharpDevelop创建。
 * 用户： Dengyong
 * 日期: 2017-03-16
 * 时间: 9:45
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
	/// Description of FormPriceList.
	/// </summary>
	public partial class FormPriceList : Form
	{
		DataSet ds1 = new DataSet();
		public DataGridView dvParent;
		public int i_GoodsID;
		
		public FormPriceList()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormPriceListLoad(object sender, EventArgs e)
		{
			FillDataGridView();
			
		}
		
		void FillDataGridView()
		{
			ds1 = BLL.ReceiptBLL.GetReceiptItems(i_GoodsID);
			//dataGridView格式调整
			dataGridView1.DataSource = null;
			SetDataGridViewFormat(dataGridView1);
			dataGridView1.DataSource = ds1.Tables[0];
		}
		
		void SetDataGridViewFormat(DataGridView dv)
		{
			dv.AutoGenerateColumns = false;	
			dv.ColumnCount = 10;
			dv.ReadOnly = true;
			dv.AllowUserToAddRows = false;
			dv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
						
            dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[0].DefaultCellStyle.Format = "yyyy-MM-dd";
			dv.Columns[0].HeaderText = "购货日期";
			dv.Columns[0].Name = "ReceiptDate";
            dv.Columns[0].Width = 80;
            dv.Columns[0].DataPropertyName = "ReceiptDate";
            
            dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].HeaderText = "货品名称";
            dv.Columns[1].Name = "GoodsName";
            dv.Columns[1].Width = 120;
            dv.Columns[1].DataPropertyName = "GoodsName";
            
            dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].HeaderText = "规格型号";
            dv.Columns[2].Name = "GoodsSpec";
            dv.Columns[2].Width = 100;
            dv.Columns[2].DataPropertyName = "GoodsSpec";
            
            dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].HeaderText = "附加规格";
            dv.Columns[3].Name = "MoreSpec";
            dv.Columns[3].Width = 100;
            dv.Columns[3].DataPropertyName = "MoreSpec";
            
            dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].HeaderText = "单位";
            dv.Columns[4].Name = "GoodsUnit";
            dv.Columns[4].Width = 80;
            dv.Columns[4].DataPropertyName = "GoodsUnit";  
            
            dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].HeaderText = "单价";
            dv.Columns[5].Name = "GoodsPrc";
            dv.Columns[5].Width = 80;
            dv.Columns[5].DataPropertyName = "GoodsPrc";   
            
            dv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[6].HeaderText = "数量";
            dv.Columns[6].Name = "GoodsQty";
            dv.Columns[6].Width = 80;
            dv.Columns[6].DataPropertyName = "GoodsQty"; 
            
            dv.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[7].HeaderText = "税率";
            dv.Columns[7].Name = "GoodsTaxRate";
            dv.Columns[7].Width = 60;
            dv.Columns[7].DataPropertyName = "GoodsTaxRate"; 
            
            dv.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[8].HeaderText = "除税价";
            dv.Columns[8].Name = "GoodsNoTaxPrice";
            dv.Columns[8].Width = 80;
            dv.Columns[8].DataPropertyName = "GoodsNoTaxPrice"; 
            //隐藏不需要的
            foreach(DataGridViewColumn c in dv.Columns)
            {
            	if(c.Index>8)
            	{
            		c.Visible = false;
            	}
            }
		}
		
		
	}
}
