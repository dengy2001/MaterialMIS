/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-20
 * 时间: 10:31
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
	/// Description of FormUser.
	/// </summary>
	public partial class FormUser : Form
	{
		public int iUserID;
		public FormUser()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			//
			if(this.Text == "用户管理-新增")
			{
				//确定关闭窗口，将数据保存到数据库中	
				
				Users t1 = new Users();
				t1.UserName = textBoxUserName.Text.Trim();
				t1.UserDisplayName = textBoxUserDisplayName.Text.Trim();
				if(textBoxUserPassword.Text == textBoxUserPassword1.Text)
				{
					t1.UserPassword = textBoxUserPassword.Text.Trim();
				}
				else
				{
					MessageBox.Show("您输入的两次密码不一致，请重新输入", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					textBoxUserPassword.Text = "";
					textBoxUserPassword1.Text = "";
					return;		
				}
				
				BLL.UserBLL.AddUsers(t1);
				this.Close();
			}
			else
			{
				//确定关闭窗口，将数据修改后保存到数据库中							
				Users t1 = new Users();
				t1.UserID = iUserID;
				t1.UserName = textBoxUserName.Text.Trim();
				t1.UserDisplayName = textBoxUserDisplayName.Text.Trim();
				if(textBoxUserPassword.Text == textBoxUserPassword1.Text)
				{
					t1.UserPassword = textBoxUserPassword.Text.Trim();
				}
				else
				{
					MessageBox.Show("您输入的两次密码不一致，请重新输入", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
					textBoxUserPassword.Text = "";
					textBoxUserPassword1.Text = "";
					return;		
				}
				
				BLL.UserBLL.UpdateUsers(t1);
				this.Close();
			}

		}
		void FormUserLoad(object sender, EventArgs e)
		{
			//如果是修改，把原来的数据填写进去
			if(this.Text == "用户管理-修改")
			{
				textBoxUserID.Text = iUserID.ToString();
				Users tP = BLL.UserBLL.GetUser(iUserID);
				textBoxUserName.Text = tP.UserName;
				textBoxUserDisplayName.Text = tP.UserDisplayName;
				textBoxUserPassword.Text = tP.UserPassword;
				textBoxUserPassword1.Text = tP.UserPassword;							
			}
			else
			{
				
				;
			}
			this.ActiveControl = textBoxUserName;
		}
		
		
		
	}
}
