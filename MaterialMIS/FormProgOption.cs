/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-13
 * 时间: 15:35
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
	/// Description of FormProgOpion.
	/// </summary>
	public partial class FormProgOption : Form
	{
		
		public int i_OptionsID;
		
		public FormProgOption()
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
		
		void FormProgOptionLoad(object sender, EventArgs e)
		{
			//如果是修改，把原来的数据填写进去
			if(this.Text == "系统参数-修改")
			{
				textBoxOptionsID.Text = i_OptionsID.ToString();
				ProgOptions tP = BLL.ProgOptionsBLL.GetOptions(i_OptionsID);
				textBoxOptionsKey.Text = tP.OptionsKey;
				textBoxOptionsValue.Text = tP.OptionsValue;
				textBoxOptionsRemark.Text = tP.OptionsRemark;
								
			}
			else
			{
				
				;
			}
			this.ActiveControl = textBoxOptionsKey;
		}
		
		void ButtonSaveClick(object sender, EventArgs e)
		{
			//保存
			//根据是修改还是新增确定操作
			if(this.Text == "系统参数-新增")
			{
				//确定关闭窗口，将数据保存到数据库中	
				
				ProgOptions t1 = new ProgOptions();
				t1.OptionsKey = textBoxOptionsKey.Text.Trim();
				t1.OptionsValue = textBoxOptionsValue.Text.Trim();
				t1.OptionsRemark = textBoxOptionsRemark.Text.Trim();
				
				BLL.ProgOptionsBLL.AddOptions(t1);
				this.Close();
			}
			else
			{
				//确定关闭窗口，将数据修改后保存到数据库中							
				ProgOptions t1 = new ProgOptions();
				t1.OptionsID = i_OptionsID;
				t1.OptionsKey = textBoxOptionsKey.Text.Trim();
				t1.OptionsValue = textBoxOptionsValue.Text.Trim();
				t1.OptionsRemark = textBoxOptionsRemark.Text.Trim();
				
				BLL.ProgOptionsBLL.UpdateOptions(t1);
				this.Close();
			}

		}
	}
}
