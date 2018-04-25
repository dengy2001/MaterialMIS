/*
 * 由SharpDevelop创建。
 * 用户： Dengyong
 * 日期: 2017-05-19
 * 时间: 10:21
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormGoodsTypeChange.
	/// </summary>
	public partial class FormGoodsTypeChange : Form
	{
		public List<int> iGoodsID = new List<int>();
		
		public FormGoodsTypeChange()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormGoodsTypeChangeLoad(object sender, EventArgs e)
		{
			//填充自定义控件
			BLL.GoodsTypeBLL.FillTreeView(comboBoxTreeView1.TreeView);
		}
		void ButtonCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void ButtonChangeClick(object sender, EventArgs e)
		{
			//开始更改
			int i_GoodsTypeID = 0;
			if(comboBoxTreeView1.Text.Trim().Length != 0)
			{
				i_GoodsTypeID = Int32.Parse(comboBoxTreeView1.Tag.ToString());
			}
			BLL.GoodsBLL.UpdateGoodsType(iGoodsID,i_GoodsTypeID);
			
			this.Close();
		}
		
		
	}
}
