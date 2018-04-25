/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-05-16
 * 时间: 12:25
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using DomainModel;
using BLL;
using System.Data;
using System.Text.RegularExpressions;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormTemp.
	/// </summary>
	public partial class FormTemp : Form
	{
		public FormTemp()
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

			pageDataGridView1.PageRecords = 20;
			pageDataGridView1.TotalRecord = 80;
		}
		void Button2Click(object sender, EventArgs e)
		{
			/*
			string tPY = Chinese2PY.GetShortPY2("汽车贴膜工具牛筋刮板");
			MessageBox.Show(tPY);
			*/
			
		}
		void Button3Click(object sender, EventArgs e)
		{
		

		}
		void FormTempLoad(object sender, EventArgs e)
		{
	
		}
		void Button4Click(object sender, EventArgs e)
		{
			Regex reg;
			string tStr;	
			string pattern;
			
			
			tStr = "";
			pattern = @"^\d+$";
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				MessageBox.Show("you wenti 1");
				return;
			}

			
		}
		void PageDataGridView1PageFirstButtonClick(object sender, EventArgs e)
		{
			MessageBox.Show("我激发了自定义的事件");
		}
		
	}
}
