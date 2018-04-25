/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-03
 * 时间: 9:08
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
	/// Description of FormAccount.
	/// </summary>
	public partial class FormCompany : Form
	{
		public int i_CompanyID;
		
		public FormCompany()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void FormCompanyLoad(object sender, EventArgs e)
		{
			//如果是修改，把原来的数据填写进去
			if(this.Text == "相关单位-修改")
			{
				textBoxCompanyID.Text = i_CompanyID.ToString();
				Companies tP = BLL.CompanyBLL.GetCompany(i_CompanyID);
				textBoxComanyName.Text = tP.CompanyName;
				//0是客户，1是供应商，2是班组，3是租赁商
				switch(tP.CompanyType)
				{
					case 0:
						radioButton1.Select();
						break;
					case 1:
						radioButton2.Select();
						break;
					case 2:
						radioButton3.Select();
						break;
					case 3:
						radioButton4.Select();
						break;
				}
				textBoxLinkDetail.Text = tP.LinkDetail;
				textBoxSKName.Text = tP.CompanySKName;
				textBoxSKBank.Text = tP.CompanySKBank;
				textBoxSKAccount.Text = tP.CompanySKAccount;			
			}			
			
			this.ActiveControl = textBoxComanyName;
		}
		
		void ButtonCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if(!CheckFillOK())
			{
				return;
			}
			//根据是修改还是新增确定操作
			if(this.Text == "相关单位-新增")
			{
				//确定关闭窗口，将数据保存到数据库中	
				
				Companies t1 = new Companies();
				t1.CompanyName = textBoxComanyName.Text.Trim();
				
				if(radioButton1.Checked)
				{
					t1.CompanyType = 0;		//客户
				}
				else if(radioButton2.Checked)
				{
					t1.CompanyType = 1;		//供应商
				}
				else if(radioButton3.Checked)
				{
					t1.CompanyType = 2;		//班组
				}
				else
				{
					t1.CompanyType = 3;		//租赁单位
				}
				t1.LinkDetail = textBoxLinkDetail.Text.Trim();
				t1.CompanySKName = textBoxSKName.Text.Trim();
				t1.CompanySKBank = textBoxSKBank.Text.Trim();
				t1.CompanySKAccount = textBoxSKAccount.Text.Trim();
				BLL.CompanyBLL.AddCompany(t1);
				this.Close();
			}
			else
			{
				//确定关闭窗口，将数据修改后保存到数据库中							
				Companies t1 = new Companies();
				t1.CompanyID = i_CompanyID;
				t1.CompanyName = textBoxComanyName.Text.Trim();
				
				if(radioButton1.Checked)
				{
					t1.CompanyType = 0;
				}
				else if(radioButton2.Checked)
				{
					t1.CompanyType = 1;
				}
				else if(radioButton3.Checked)
				{
					t1.CompanyType = 2;		//班组
				}
				else
				{
					t1.CompanyType = 3;		//租赁单位
				}
				t1.LinkDetail = textBoxLinkDetail.Text.Trim();
				t1.CompanySKName = textBoxSKName.Text.Trim();
				t1.CompanySKBank = textBoxSKBank.Text.Trim();
				t1.CompanySKAccount = textBoxSKAccount.Text.Trim();
				
				BLL.CompanyBLL.UpdateCompany(t1);
				this.Close();
			}

		}
		
		bool CheckFillOK()
		{
//			Regex reg;
//			string tStr;
//			string pattern;

			if(textBoxComanyName.Text.Trim() == "")
			{
				MessageBox.Show("未填写单位名称！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			

			return true;
		}
		
	}
}
