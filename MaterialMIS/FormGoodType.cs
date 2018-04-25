/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-04-30
 * 时间: 15:36
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using DomainModel;
using BLL;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormGoodType.
	/// </summary>
	public partial class FormGoodType : Form
	{
		private string s_GoodsTypeName;
		private int i_GoodsTypePID;
		private int i_GoodsTypeID;
		private string s_GoodsTypePName;
		
		public string GoodsTypeName
		{
			get
			{
				return s_GoodsTypeName;
			}
			set
			{
				s_GoodsTypeName = value;
			}
		}
		
		public string GoodsTypePName
		{
			get
			{
				return s_GoodsTypePName;
			}
			set
			{
				s_GoodsTypePName = value;
			}
		}
		
		public int GoodsTypePID
		{
			get
			{
				return i_GoodsTypePID;
			}
			set
			{
				i_GoodsTypePID = value;
			}
		}
		
		public int GoodsTypeID
		{
			get
			{
				return i_GoodsTypeID;
			}
			set
			{
				i_GoodsTypeID = value;
			}
		}
		public FormGoodType()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
		}
		void FormGoodTypeLoad(object sender, EventArgs e)
		{
			//填写treeview
//			ddTree1.tTextBox.Text = GoodsTypePName;
//			ddTree1.tTextBox.Tag = GoodsTypePID;
			comboBoxTreeView1.Text = GoodsTypePName;
			comboBoxTreeView1.Tag = GoodsTypePID;
			BLL.GoodsTypeBLL.FillTreeView(comboBoxTreeView1.TreeView);
			if(this.Text == "货品类别-修改")
			{
				textBox1.Text = GoodsTypeName;
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			//根据是修改还是新增确定操作
			if(this.Text == "货品类别-新增")
			{
				//确定关闭窗口，将数据保存到数据库中			
				//FormGoodTypeBLL tt  = new FormGoodTypeBLL();
				GoodsType gt = new GoodsType();
				gt.GoodsTypeName = textBox1.Text.Trim();
				if(gt.GoodsTypeName == "")
				{
					MessageBox.Show("未输入类别名称！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				int i_Pid = Int32.Parse(comboBoxTreeView1.Tag.ToString());
				if(i_Pid == 0)
				{
					gt.GoodsTypePID = 1;
				}
				else
				{
					gt.GoodsTypePID = i_Pid;
				}
				GoodsTypeBLL.AddGoodType(gt);
				this.Close();
			}
			else
			{
				//确定关闭窗口，将数据修改后保存到数据库中			
				//FormGoodTypeBLL tt  = new FormGoodTypeBLL();
				GoodsType gt = new GoodsType();
				gt.GoodsTypeName = textBox1.Text;
				gt.GoodsTypePID = Int32.Parse(comboBoxTreeView1.Tag.ToString());
				gt.GoodsTypeID = GoodsTypeID;
				GoodsTypeBLL.ModifyGoodType(gt);
				this.Close();
			}
		}
	}
}
