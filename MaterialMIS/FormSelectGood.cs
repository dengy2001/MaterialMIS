/*
 * 由SharpDevelop创建。
 * 用户： Dengyong
 * 日期: 2017-05-19
 * 时间: 14:21
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
	/// Description of FormSelectGood.
	/// </summary>
	public partial class FormSelectGood : Form
	{
		
		public int i_MergeToGoodsID;
		private DataSet ds1 = new DataSet();
		private bool b_HideZeroStock = false;		//隐藏0库存
		private List<int> l_GoodsTypeList = new List<int>();	//产品类别过滤
//		private string s_GoodsNameFilter = "";		//产品名称过滤
		private Goods Goods1,Goods2;
		
		public FormSelectGood()
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
			this.Close();
		}
		void FormSelectGoodLoad(object sender, EventArgs e)
		{
			//填充Treeview
			BLL.GoodsTypeBLL.FillTreeView(treeView1);
			treeView1.CollapseAll();
			//填充DataGridView
			FillDataGridView();
			Goods1 = BLL.GoodsBLL.GetGoods(i_MergeToGoodsID);
			
			label1.Text = "货品【" + Goods1.GoodsName + "(" + Goods1.GoodsID.ToString() + ")】 将合并到【】";
		}
		//填充表格
		void FillDataGridView()
		{
			ds1 = BLL.GoodsBLL.GetAllGoods3();

			dataGridView1.DataSource = null;
			SetDataGridViewFormat();
			dataGridView1.DataSource = ds1.Tables[0];
			//显示过滤后应显示的行
			ShowGoods();
			
		}
		void SetDataGridViewFormat()
		{
			dataGridView1.AutoGenerateColumns = false;
			dataGridView1.ColumnCount = 9;
			dataGridView1.ReadOnly = true;
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
			dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView1.Columns[0].HeaderText = "货品名称";
			dataGridView1.Columns[0].Name = "GoodsName";
			dataGridView1.Columns[0].Width = 200;
			dataGridView1.Columns[0].DataPropertyName = "GoodsName";
			
			dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView1.Columns[1].HeaderText = "规格型号";
			dataGridView1.Columns[1].Name = "GoodsSpec";
			dataGridView1.Columns[1].Width = 100;
			dataGridView1.Columns[1].DataPropertyName = "GoodsSpec";
			
			dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView1.Columns[2].HeaderText = "货品类别";
			dataGridView1.Columns[2].Name = "GoodsTypeName";
			dataGridView1.Columns[2].Width = 80;
			dataGridView1.Columns[2].DataPropertyName = "GoodsTypeName";
			
			dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView1.Columns[3].HeaderText = "单位";
			dataGridView1.Columns[3].Name = "GoodsUnit";
			dataGridView1.Columns[3].Width = 60;
			dataGridView1.Columns[3].DataPropertyName = "GoodsUnit";
			
			
			dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns[4].HeaderText = "单价";
			dataGridView1.Columns[4].Name = "GoodsPrice";
			dataGridView1.Columns[4].Width = 80;
			dataGridView1.Columns[4].DataPropertyName = "GoodsPrice";
			
			dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns[5].HeaderText = "库存低限";
			dataGridView1.Columns[5].Name = "LimitLow";
			dataGridView1.Columns[5].Width = 80;
			dataGridView1.Columns[5].DataPropertyName = "LimitLow";
			
			dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridView1.Columns[6].HeaderText = "库存高限";
			dataGridView1.Columns[6].Name = "LimitUP";
			dataGridView1.Columns[6].Width = 80;
			dataGridView1.Columns[6].DataPropertyName = "LimitUP";
			
			//不显示出来的列
			dataGridView1.Columns[7].Visible = false;
			dataGridView1.Columns[7].Name = "GoodsID";
			dataGridView1.Columns[7].DataPropertyName = "GoodsID";
			
			dataGridView1.Columns[8].Visible = false;
			dataGridView1.Columns[8].Name = "GoodsTypeID";
			dataGridView1.Columns[8].DataPropertyName = "GoodsTypeID";

		}
		
		//将适合过滤条件的数据显示在DataGridView中
		void ShowGoods()
		{
			FillGoodsTypeList();		//将选择的类别列表填充完整
			//MessageBox.Show(l_GoodsTypeList.Count.ToString());
			int row = dataGridView1.Rows.Count;//得到总行数
			for (int i = 0; i <  row; i++)
			{
				//MessageBox.Show(dataGridView1.Rows[i].Cells[3].Value.ToString());
				bool sFlag = true;
				if(b_HideZeroStock)
				{
					string ts = dataGridView1.Rows[i].Cells["LastQty"].Value.ToString();
					//检测0库存
					if(ts == "0")
					{
						sFlag = false;
						goto DoShow;
					}
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
			//MessageBox.Show(l_GoodsTypeList.Count.ToString());
			ShowGoods();
		}
		void TextBoxFindGoodsTextChanged(object sender, EventArgs e)
		{
			//根据过滤条件控制显示在DataView中的内容
			ShowGoods();
		}
		void DataGridView1SelectionChanged(object sender, EventArgs e)
		{
			//
			if(Goods1 == null)
				return;
			if(dataGridView1 == null)
				return;
			if(dataGridView1.CurrentRow == null)
				return;
			int i1 = Convert.ToInt32(dataGridView1.CurrentRow.Cells["GoodsID"].Value);
			Goods2 = BLL.GoodsBLL.GetGoods(i1);
			label1.Text = "货品【" + Goods1.GoodsName + "(" + Goods1.GoodsID.ToString() + ")】 将合并到【" + Goods2.GoodsName + "(" + Goods2.GoodsID.ToString()+ ")】";

		}
		void ButtonMergeClick(object sender, EventArgs e)
		{
			//确认合并
			if(dataGridView1.CurrentRow == null)
				return;
			
			DialogResult result;

			result = MessageBox.Show("您确认合并货品吗？", "合并确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == System.Windows.Forms.DialogResult.Yes)
			{
				BLL.GoodsBLL.MergeGoods(Goods1,Goods2);
				this.Close();
			}
		}
		
		
	}
}
