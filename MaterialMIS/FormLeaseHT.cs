/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-18
 * Time: 16:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DomainModel;
using BLL;
using System.Text.RegularExpressions;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormLeaseHT.
	/// </summary>
	public partial class FormLeaseHT : Form
	{
		public int i_ProjectID;
		public string s_ProjectName;
		public int i_HTID;
		
		private DataSet ds1 = new DataSet();
			
		public FormLeaseHT()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormLeaseHTLoad(object sender, EventArgs e)
		{
			//项目名称
			textBoxProjectName.Text = s_ProjectName;
			
			//得到项目单位
			ds1 = BLL.CompanyBLL.GetProjectCompanies(i_ProjectID,3);
			comboBoxCompany.DataSource = ds1.Tables[0];
			comboBoxCompany.DisplayMember = "CompanyName";
			comboBoxCompany.ValueMember = "CompanyID";
			if(this.Text == "租赁合同-修改")
			{
				textBoxHID.Text = i_HTID.ToString();
				LeaseHT tLeaseHT = BLL.LeaseBLL.GetLeaseHT(i_HTID);
				textBoxHTNumber.Text = tLeaseHT.HTNumber;
				textBoxHTName.Text = tLeaseHT.HTName;
				comboBoxCompany.SelectedValue = tLeaseHT.CompanyID;
				if(tLeaseHT.IncludeSDate == 1)
				{
					checkBoxIncludeSDate.Checked = true;
				}
				else
				{
					checkBoxIncludeSDate.Checked = false;
				}
				if(tLeaseHT.IncludeEDate == 1)
				{
					checkBoxIncludeEDate.Checked = true;
				}
				else
				{
					checkBoxIncludeEDate.Checked = false;
				}
			}
		}
		void ButtonCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			//保存
			if(!CheckFillOK())
			{
				return;
			}
			if(this.Text == "租赁合同-新增")
			{
				if(BLL.LeaseBLL.HasHT( i_ProjectID, Convert.ToInt32(comboBoxCompany.SelectedValue)))
				{
					return;
				}
				AddNewHT();
			}
			else
			{
				//修改
				ModifyHT();
			}
			this.Close();
		}
		void AddNewHT()
		{
			
			LeaseHT tLeaseHT = new LeaseHT();
			tLeaseHT.HTNumber = textBoxHTNumber.Text;
			tLeaseHT.HTName = textBoxHTName.Text;
			tLeaseHT.ProjectID = i_ProjectID;
			tLeaseHT.CompanyID = Convert.ToInt32(comboBoxCompany.SelectedValue);
			
			if(checkBoxIncludeSDate.Checked)
			{
				tLeaseHT.IncludeSDate = 1;
			}
			else
			{
				tLeaseHT.IncludeSDate = 0;
			}
			if(checkBoxIncludeEDate.Checked)
			{
				tLeaseHT.IncludeEDate = 1;
			}
			else
			{
				tLeaseHT.IncludeEDate = 0;
			}
			BLL.LeaseBLL.AddLeaseHT(tLeaseHT);
		}
		void ModifyHT()
		{
			LeaseHT tLeaseHT = new LeaseHT();
			tLeaseHT.HTID = Convert.ToInt32(textBoxHID.Text);
			tLeaseHT.HTNumber = textBoxHTNumber.Text;
			tLeaseHT.HTName = textBoxHTName.Text;
			tLeaseHT.ProjectID = i_ProjectID;
			tLeaseHT.CompanyID = Convert.ToInt32(comboBoxCompany.SelectedValue);
			if(checkBoxIncludeSDate.Checked)
			{
				tLeaseHT.IncludeSDate = 1;
			}
			else
			{
				tLeaseHT.IncludeSDate = 0;
			}
			if(checkBoxIncludeEDate.Checked)
			{
				tLeaseHT.IncludeEDate = 1;
			}
			else
			{
				tLeaseHT.IncludeEDate = 0;
			}
			BLL.LeaseBLL.ModifyLeaseHT(tLeaseHT);
		}
		bool CheckFillOK()
		{
			//Regex reg;
			//string tStr;	
			//string pattern;
			
			//工程项目
			if(comboBoxCompany.SelectedValue == null)
			{
				MessageBox.Show("未指定租赁单位！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			
			if(textBoxHTName.Text.Length == 0)
			{
				MessageBox.Show("未输入合同名！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			
			return true;
		}
		
	}
}
