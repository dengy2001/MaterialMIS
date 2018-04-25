/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-08-11
 * 时间: 14:39
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
	/// Description of FormSupplierDetail.
	/// </summary>
	public partial class FormSupplierDetail : Form
	{
		public int i_SupplierID;
		
		public FormSupplierDetail()
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
			//保存
			//根据是修改还是新增确定操作
			if(this.Text == "供货商信息-新增")
			{
				//确定关闭窗口，将数据保存到数据库中	
				
				Supplier tNew = new Supplier();
				tNew.SupplierName = textBoxSupplierName.Text.Trim();
				tNew.SupplierSKName = textBoxSupplierSKName.Text.Trim();
				tNew.SupplierSKAccount = textBoxSupplierSKAccount.Text.Trim();
				tNew.SupplierSKBank = textBoxSupplierSKBank.Text.Trim();
				tNew.SupplierLeader = textBoxSupplierLeader.Text.Trim();
					
				BLL.SupplierBLL.AddSupplier(tNew);
				this.Close();
			}
			else
			{
				//确定关闭窗口，将数据修改后保存到数据库中							
				Supplier tModify = new Supplier();
				tModify.SupplierID = i_SupplierID;
				tModify.SupplierName = textBoxSupplierName.Text.Trim();
				tModify.SupplierSKName = textBoxSupplierSKName.Text.Trim();
				tModify.SupplierSKAccount = textBoxSupplierSKAccount.Text.Trim();
				tModify.SupplierSKBank = textBoxSupplierSKBank.Text.Trim();
				tModify.SupplierLeader = textBoxSupplierLeader.Text.Trim();
					
				BLL.SupplierBLL.UpdateSupplier(tModify);
				this.Close();
			}
		}
		void FormSupplierDetailLoad(object sender, EventArgs e)
		{
			//如果是修改，把原来的数据填写进去
			if(this.Text == "供货商信息-修改")
			{
				textBoxSupplierID.Text = i_SupplierID.ToString();
				Supplier tModify = BLL.SupplierBLL.GetSupplier(i_SupplierID);
				textBoxSupplierName.Text = tModify.SupplierName;
				textBoxSupplierSKName.Text = tModify.SupplierSKName;
				textBoxSupplierSKAccount.Text = tModify.SupplierSKAccount;
				textBoxSupplierSKBank.Text = tModify.SupplierSKBank;
				textBoxSupplierLeader.Text = tModify.SupplierLeader;				
			}
			
		}
	}
}
