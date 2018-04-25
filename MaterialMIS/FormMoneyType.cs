/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-01
 * 时间: 21:10
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
	/// Description of FormMoneyType.
	/// </summary>
	public partial class FormMoneyType : Form
	{
		public int i_MoneyTypeID;
		
		public FormMoneyType()
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
		
		
		void FormMoneyTypeLoad(object sender, EventArgs e)
		{
			//如果是修改，把原来的数据填写进去
			if(this.Text == "收支信息-修改")
			{
				textBoxMoneyTypeID.Text = i_MoneyTypeID.ToString();
				MoneyType tP = BLL.MoneyTypeBLL.GetMoneyType(i_MoneyTypeID);
				textBoxMoneyTypeName.Text = tP.MoneyTypeName;
				if(tP.MoneyTypeClass == 0)
				{
					radioButton1.Select();
				}
				else
				{
					radioButton2.Select();
				}
				
			}
			else
			{
				
				radioButton1.Select();
			}
			this.ActiveControl = textBoxMoneyTypeName;
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			//根据是修改还是新增确定操作
			if(this.Text == "收支信息-新增")
			{
				//确定关闭窗口，将数据保存到数据库中	
				
				MoneyType t1 = new MoneyType();
				t1.MoneyTypeName = textBoxMoneyTypeName.Text.Trim();
				if(radioButton1.Checked)
				{
					t1.MoneyTypeClass = 0;
				}
				else
				{
					t1.MoneyTypeClass = 1;
				}
				BLL.MoneyTypeBLL.AddMoneyType(t1);
				this.Close();
			}
			else
			{
				//确定关闭窗口，将数据修改后保存到数据库中							
				MoneyType t1 = new MoneyType();
				t1.MoneyTypeID = i_MoneyTypeID;
				t1.MoneyTypeName = textBoxMoneyTypeName.Text.Trim();
				if(radioButton1.Checked)
				{
					t1.MoneyTypeClass = 0;
				}
				else
				{
					t1.MoneyTypeClass = 1;
				}
				BLL.MoneyTypeBLL.UpdateMoneyType(t1);
				this.Close();
			}
			BLL.MoneyTypeBLL.FillMoneyType();
		}
	}
}
