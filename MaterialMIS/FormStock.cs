/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-04-29
 * 时间: 17:14
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
	/// Description of FormStock.
	/// </summary>
	public partial class FormStock : Form
	{
		
		
		
//		private IList<Goods> list;
		private DataSet ds1 = new DataSet();
//		private bool editflag = false;
		private string s_GoodsID;
		
		private bool b_HideZeroStock = false;		//隐藏0库存
		private List<int> l_GoodsTypeList = new List<int>();	//产品类别过滤
		string s_GoodsTypeID = "";
//		private string s_GoodsNameFilter = "";		//产品名称过滤
		
		public FormStock()
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
			//关闭当前窗口

			((MainForm)(this.ParentForm)).Page_Close(this);
			this.Close();
		}
		void Button2Click(object sender, EventArgs e)
		{
			//新增货品类别
			FormGoodType tF = new FormGoodType();
			tF.Text="货品类别-新增";
			
			//将当前选择的项作为父对象填充到对话框中
			TreeNode rd = treeView1.SelectedNode;
			if(rd != null)
			{
				tF.GoodsTypePID = Int32.Parse(rd.Tag.ToString());
				tF.GoodsTypePName = rd.Text;
			}
			tF.ShowDialog();
			//刷新treeview1显示
			treeView1.Nodes.Clear();
			BLL.GoodsTypeBLL.RefreshView(treeView1);
		}
		void FormStockLoad(object sender, EventArgs e)
		{		
			//填充Treeview
			BLL.GoodsTypeBLL.FillTreeView(treeView1);
			
			//填充DataGridView
			FillDataGridView();
			dataGridView1.Sort(dataGridView1.Columns[0],System.ComponentModel.ListSortDirection.Ascending);

			
		}
		
		//填充表格
		void FillDataGridView()
		{

			ds1 = BLL.GoodsBLL.GetAllGoods3();

			dataGridView1.DataSource = null;
			SetDataGridViewFormat();
			dataGridView1.DataSource = ds1.Tables[0];
			//显示过滤后应显示的行
			ShowGoods1();
			
		}
		
		void RefreshDateSet()
		{
			dataGridView1.DataSource = null;
			ds1 = BLL.GoodsBLL.GetAllGoods3();
			dataGridView1.DataSource = ds1.Tables[0];
		}
		
		void SetDataGridViewFormat()
		{
			dataGridView1.AutoGenerateColumns = false;
			dataGridView1.ColumnCount = 9;
			dataGridView1.ReadOnly = true;
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

			//dataGridView1.Sort(dataGridView1.Columns[0],System.ComponentModel.ListSortDirection.Ascending);


			dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView1.Columns[0].HeaderText = "货品名称";
			dataGridView1.Columns[0].Name = "GoodsName";
			dataGridView1.Columns[0].Width = 200;
			dataGridView1.Columns[0].DataPropertyName = "GoodsName";
			//dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;
			
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
		
		void 删除类别ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//删除当前选择的类别
			TreeNode curSelect = treeView1.SelectedNode;
			if (null != curSelect)
			{
				DialogResult result;
				if(curSelect.Tag.ToString() == "1")
				{
					MessageBox.Show("此根类别不能删除！！！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}

				result = MessageBox.Show("您确认删除当前选中的【" + curSelect.Text + "】货品类别吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == System.Windows.Forms.DialogResult.Yes)
				{
					try
					{
						// 删除指定的类别
						BLL.GoodsTypeBLL.DelGoodType(Int32.Parse(curSelect.Tag.ToString()));
						
						BLL.GoodsTypeBLL.FillGoodType();
						//刷新treeview1显示
						treeView1.Nodes.Clear();
						BLL.GoodsTypeBLL.RefreshView(treeView1);
						return;
					}
					catch(Exception e1)
					{
						string s1 = e1.Message;
						MessageBox.Show("删除错误，可能是有下级类别或该类别有货品信息。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

				}

			}
			else
			{
				return;
			}
		}
		
		
		void 增加类别ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//
			Button2Click(sender,e);
		}
		
		
		void 修改类别ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//修改货品类别
			FormGoodType tF = new FormGoodType();
			tF.Text="货品类别-修改";
			
			//将当前选择的项作为父对象填充到对话框中
			TreeNode rd = treeView1.SelectedNode;
			
			tF.GoodsTypePID = Int32.Parse(rd.Parent.Tag.ToString());
			tF.GoodsTypePName = rd.Parent.Text;
			
			tF.GoodsTypeID = Int32.Parse(rd.Tag.ToString());
			tF.GoodsTypeName = rd.Text;
			tF.ShowDialog();
			//刷新treeview1显示
			treeView1.Nodes.Clear();
			BLL.GoodsTypeBLL.FillGoodType();
			BLL.GoodsTypeBLL.RefreshView(treeView1);
		}
		
		
//		void Button6Click(object sender, EventArgs e)
//		{
//			//切换本按钮显示文本
//			if(button6.Text == "隐藏零库存")
//			{
//				button6.Text = "显示全部";
//				b_HideZeroStock = true;
//				ShowGoods();
//			}
//			else
//			{
//				button6.Text ="隐藏零库存";
//				b_HideZeroStock = false;
//				ShowGoods();
//			}
//		}
		

		
//		//隐藏0库存行
//		void HideZeroRow(bool flag)
//		{
//			if(flag)
//			{
//				//隐藏
//				int row = dataGridView1.Rows.Count;//得到总行数
//				for (int i = 0; i <  row; i++)
//				{
//					//MessageBox.Show(dataGridView1.Rows[i].Cells[3].Value.ToString());
//					string ts = dataGridView1.Rows[i].Cells["LastQty"].Value.ToString();
//					if(ts == "0")
//						{
//							CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
//							cm.SuspendBinding(); //挂起数据绑定
//							dataGridView1.Rows[i].Visible = false;
//							cm.ResumeBinding(); //恢复数据绑定
//						}
//
//				}
//			}
//			else
//			{
//				//显示
//				int row = dataGridView1.Rows.Count;//得到总行数
//				for (int i = 0; i <  row; i++)
//				{
//					dataGridView1.Rows[i].Visible = true;
//				}
//			}
//		}
		
		
		void DataGridView1DoubleClick(object sender, EventArgs e)
		{
			//进入货品编辑状态
			if(dataGridView1.CurrentRow == null)
				return;
			
			
			s_GoodsID = dataGridView1.CurrentRow.Cells["GoodsID"].Value.ToString();
			int i_GoodsID = Convert.ToInt32(s_GoodsID);
			//修改货品
			FormGood tF = new FormGood();
			tF.Text="货品-修改";
			tF.iGoodsID = i_GoodsID;
			tF.ShowDialog();
			//FillDataGridView();
			RefreshDateSet();
		}
		
		void 新增货品ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//新货品
			FormGood tF = new FormGood();
			tF.Text="货品-新增";
			
			//将当前选择的项作为父对象填充到对话框中
			TreeNode rd = treeView1.SelectedNode;
			if(rd != null)
			{
				tF.GoodsTypePID = Int32.Parse(rd.Tag.ToString());
				tF.GoodsTypePName = rd.Text;
			}
			
			tF.ShowDialog();
			//FillDataGridView();
			RefreshDateSet();

		}
		
		void 修改货品ToolStripMenuItemClick(object sender, EventArgs e)
		{
			DataGridView1DoubleClick(sender,e);
		}
		void 删除货品ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//删除货品，可能会出现由于外键不能删的情况
			if(dataGridView1.CurrentRow == null)
				return;
			
			DialogResult result;
			int iGoodsID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["GoodsID"].Value.ToString());
			string sGoodsName = dataGridView1.CurrentRow.Cells["GoodsName"].Value.ToString();

			result = MessageBox.Show("您确认删除当前选中的【" + sGoodsName + "】货品吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == System.Windows.Forms.DialogResult.Yes)
			{
				try
				{
					// 删除指定的类别
					BLL.GoodsBLL.DelGoods(iGoodsID);
					//更新DataGridView中的内容，即
					//FillDataGridView();
					RefreshDateSet();
					
					return;
				}
				catch(Exception e1)
				{
					string s1 = e1.Message;
					MessageBox.Show("删除错误，可能是进货单等有货品信息。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

			}
		}
		
		
		void TextBoxFindGoodsTextChanged(object sender, EventArgs e)
		{
			//根据过滤条件控制显示在DataView中的内容
			ShowGoods1();
			dataGridView1.Sort(dataGridView1.Columns[0],System.ComponentModel.ListSortDirection.Ascending);

		}
		
		void ShowGoods1()
		{
			if(dataGridView1.DataSource == null)
				return;
			DataView dv1 = ds1.Tables[0].DefaultView;
			string s2 = textBoxFindGoods.Text.Trim();
			if(s_GoodsTypeID == "")
			{					
				dv1.RowFilter = "GoodsName Like '%" + s2 +"%'";				
			}
			else
			{
				s_GoodsTypeID = s_GoodsTypeID.Substring(0,s_GoodsTypeID.Length-1);
				if(s_GoodsTypeID != "")
				{
					dv1.RowFilter = "GoodsTypeID in (" + s_GoodsTypeID +") AND GoodsName Like '%" + s2 + "%'";
				}
				else
				{
					dv1.RowFilter = "GoodsName Like '%" + s2 +"%'";
				}
			}
		}
		
		//将适合过滤条件的数据显示在DataGridView中
		void ShowGoods()
		{
			
			BindingManagerBase cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
			cm.SuspendBinding(); //挂起数据绑定
				
			//FillGoodsTypeList();		//将选择的类别列表填充完整			
						
			//MessageBox.Show("Show:"+l_GoodsTypeList.Count.ToString());
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
				
				dataGridView1.Rows[i].Visible = sFlag;
				
			}
			
			cm.ResumeBinding(); //恢复数据绑定
		}
		
		
		void FillGoodsTypeList()
		{
			//将原来可能存在的列表清除
			if(l_GoodsTypeList != null)
			{
				l_GoodsTypeList.Clear();
				s_GoodsTypeID = "";
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
					s_GoodsTypeID += tParent.Tag.ToString() +",";
				}
				else
				{
					return;
				}
			}
			else
			{
				l_GoodsTypeList.Add(Convert.ToInt32(tParent.Tag.ToString()));
				s_GoodsTypeID += tParent.Tag.ToString() +",";
			}
			
			tCurPar = tParent;
			tCur = tCurPar.FirstNode;
			while(tCur != null && tCur.Level > tParent.Level)
			{
				l_GoodsTypeList.Add(Convert.ToInt32(tCur.Tag.ToString()));
				s_GoodsTypeID += tCur.Tag.ToString() +",";
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
			//MessageBox.Show(s_GoodsTypeName);
		}
		void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
		{
			FillGoodsTypeList();
			//MessageBox.Show("AfterSelect:"+ l_GoodsTypeList.Count.ToString());
			//MessageBox.Show(treeView1.SelectedNode.Text);
			ShowGoods1();
			dataGridView1.Sort(dataGridView1.Columns[0],System.ComponentModel.ListSortDirection.Ascending);

		}
		
		
		
		void ButOutPutExcelClick(object sender, EventArgs e)
		{
			OutPutExcel(dataGridView1, "材料信息");
		}
		
		
		//导出到Excel
		void OutPutExcel(DataGridView dgv, string name)
		{
			FastReport.Report report1 = new FastReport.Report();
			report1.Load("Reports\\GoodsList1.frx");

			DataSet FDataSet = new DataSet();
			DataTable table = new DataTable();
			table = ds1.Tables[0].Copy();
			table.TableName = "Goods";
			FDataSet.Tables.Add(table);
			report1.RegisterData(FDataSet);
			report1.Show();
			report1.Dispose();
		}
		void Button3Click(object sender, EventArgs e)
		{
			新增货品ToolStripMenuItemClick(sender, e);
		}
		void 批量改变货品类别ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//判断是否选择了货品
			List<int> iGoodsID = new List<int>();
			foreach(DataGridViewRow dr in dataGridView1.SelectedRows)
			{
				int i1 = Convert.ToInt32(dr.Cells["GoodsID"].Value);
				iGoodsID.Add(i1);
			}
			
			if(iGoodsID.Count == 0)
				return;
			
			FormGoodsTypeChange tForm = new FormGoodsTypeChange();
			tForm.iGoodsID = iGoodsID;
			
			tForm.ShowDialog();
			
			//FillDataGridView();
			RefreshDateSet();
		}
		void 货品合并ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//将当前选择的货品合并到
			if(dataGridView1.CurrentRow == null)
				return;
			int i_GoodsID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["GoodsID"].Value);
			FormSelectGood tForm = new FormSelectGood();
			tForm.i_MergeToGoodsID = i_GoodsID;
			
			tForm.ShowDialog();
			
			//FillDataGridView();
			RefreshDateSet();
			
		}
		void Button5Click(object sender, EventArgs e)
		{
	
		}
		
		
	}
}
