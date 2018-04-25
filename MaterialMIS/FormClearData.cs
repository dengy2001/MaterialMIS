/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-08-02
 * 时间: 10:51
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormClearData.
	/// </summary>
	public partial class FormClearData : Form
	{
		public FormClearData()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			//清空数据
			if(textBox1.Text == "我确认要清空数据")
			{
				DialogResult result;
				result = MessageBox.Show("您确认清空数据吗，数据将不可恢复！！！？", "清空再确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               	if (result == System.Windows.Forms.DialogResult.Yes)
                {
               		if(checkBoxGoods.Checked)
               		{
               			BLL.ProgOptionsBLL.ClearData();
               		}
               		else
               		{
               			BLL.ProgOptionsBLL.ClearData1();
               		}
               	}
			}
			this.Close();
		}

	}
}
