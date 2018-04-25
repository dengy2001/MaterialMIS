/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-01
 * 时间: 12:37
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
	/// Description of FormProject.
	/// </summary>
	public partial class FormProject : Form
	{
		public int i_ProjectID;
		
		public FormProject()
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
		void ButtonSaveClick(object sender, EventArgs e)
		{
			//根据是修改还是新增确定操作
			if(this.Text == "项目信息-新增")
			{
				//确定关闭窗口，将数据保存到数据库中	
				
				Projects tProject = new Projects();
				tProject.ProjectName = textBoxProjectName.Text.Trim();
				tProject.ProjectContractor = textBoxContractor.Text.Trim();
				tProject.ProjectDeveloper = textBoxDevelpoer.Text.Trim();
				tProject.ProjectAbstract = textBoxProjectAbstract.Text.Trim();
				ProjectsBLL.AddProjects(tProject);
				this.Close();
			}
			else
			{
				//确定关闭窗口，将数据修改后保存到数据库中							
				Projects tProject = new Projects();
				tProject.ProjectID = i_ProjectID;
				tProject.ProjectName = textBoxProjectName.Text.Trim();
				tProject.ProjectContractor = textBoxContractor.Text.Trim();
				tProject.ProjectDeveloper = textBoxDevelpoer.Text.Trim();
				tProject.ProjectAbstract = textBoxProjectAbstract.Text.Trim();
				ProjectsBLL.UpdateProjects(tProject);
				this.Close();
			}
			BLL.ProjectsBLL.FillProjects();
		}
		void FormProjectLoad(object sender, EventArgs e)
		{
			//如果是修改，把原来的数据填写进去
			if(this.Text == "项目信息-修改")
			{
				textBoxProjectID.Text = i_ProjectID.ToString();
				Projects tP = BLL.ProjectsBLL.GetProject(i_ProjectID);
				textBoxProjectName.Text = tP.ProjectName;
				textBoxContractor.Text = tP.ProjectContractor;
				textBoxDevelpoer.Text = tP.ProjectDeveloper;
				textBoxProjectAbstract.Text = tP.ProjectAbstract;
				this.ActiveControl = textBoxProjectName;  	//设置焦点
			}
			
		}
	}
}
