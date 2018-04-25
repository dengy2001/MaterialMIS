/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-22
 * Time: 10:18
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
	/// Description of FormLeaseItem.
	/// </summary>
	public partial class FormLeaseItem : Form
	{
		public int i_ItemsID;
		public int i_HTID;
		
		public FormLeaseItem()
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
			//保存
			if(!CheckFillOK())
			{
				return;
			}
			if(this.Text == "租赁项信息-新增")
			{
				AddNewLeaseItem();
			}
			else
			{
				//修改
				ModifyLeaseItem();
			}
			this.Close();
		}
		
		void AddNewLeaseItem()
		{
			LeaseItems tLeaseItems = new LeaseItems();
			tLeaseItems.HTID = i_HTID;
			tLeaseItems.MName = textBoxMName.Text;
			if(radioButton1.Checked)
			{
				tLeaseItems.LeaseClass = 0;
			}
			else
			{
				tLeaseItems.LeaseClass = 1;
			}
			tLeaseItems.LeaseUnit = textBoxLeaseUnit.Text;
			tLeaseItems.LeasePrice = Convert.ToDecimal(textBoxLeasePrice.Text);
			tLeaseItems.LoadingUnit = textBoxLoadingUnit.Text;
			tLeaseItems.LoadingFactor = Convert.ToDecimal(textBoxLoadingFactor.Text);
			tLeaseItems.LoadingPrice = Convert.ToDecimal(textBoxLoadingPrice.Text);
			tLeaseItems.RepairUnit = textBoxRepairUnit.Text;
			tLeaseItems.RepairFactor = Convert.ToDecimal(textBoxRepairFactor.Text);
			tLeaseItems.RepairPrice = Convert.ToDecimal(textBoxRepairPrice.Text);
						
			BLL.LeaseBLL.AddLeaseItem(tLeaseItems);
		}
		void ModifyLeaseItem()
		{
			LeaseItems tLeaseItems = new LeaseItems();
			tLeaseItems = BLL.LeaseBLL.GetLeaseItem(i_ItemsID);
			tLeaseItems.MName = textBoxMName.Text;
			if(radioButton1.Checked)
			{
				tLeaseItems.LeaseClass = 0;
			}
			else
			{
				tLeaseItems.LeaseClass = 1;
			}
			tLeaseItems.LeaseUnit = textBoxLeaseUnit.Text;
			tLeaseItems.LeasePrice = Convert.ToDecimal(textBoxLeasePrice.Text);
			tLeaseItems.LoadingUnit = textBoxLoadingUnit.Text;
			tLeaseItems.LoadingFactor = Convert.ToDecimal(textBoxLoadingFactor.Text);
			tLeaseItems.LoadingPrice = Convert.ToDecimal(textBoxLoadingPrice.Text);
			tLeaseItems.RepairUnit = textBoxRepairUnit.Text;
			tLeaseItems.RepairFactor = Convert.ToDecimal(textBoxRepairFactor.Text);
			tLeaseItems.RepairPrice = Convert.ToDecimal(textBoxRepairPrice.Text);
			
			BLL.LeaseBLL.ModifyLeaseItem(tLeaseItems);
		}
		bool CheckFillOK()
		{
//			Regex reg;
//			string tStr;	
//			string pattern;
			Decimal dOut = 0.0M;
			
			if(textBoxMName.Text.Length == 0)
			{
				MessageBox.Show("未输入租赁项名称！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			
			//租赁项单价
			if(!Decimal.TryParse(textBoxLeasePrice.Text,out dOut))
			{
				MessageBox.Show("租赁项单价输入错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			if(!Decimal.TryParse(textBoxLoadingFactor.Text,out dOut))
			{
				MessageBox.Show("装卸换算因子输入错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			if(!Decimal.TryParse(textBoxLoadingPrice.Text,out dOut))
			{
				MessageBox.Show("装卸单价输入错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			if(!Decimal.TryParse(textBoxRepairFactor.Text,out dOut))
			{
				MessageBox.Show("维修换算因子输入错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			if(!Decimal.TryParse(textBoxRepairPrice.Text,out dOut))
			{
				MessageBox.Show("维修单价输入错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			/*
			//租赁项单价
			tStr = textBoxLeasePrice.Text.Trim();
			pattern = @"^[0-9]+.([0-9]+)?$|^[0-9]*$";
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				MessageBox.Show("租赁项单价错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			
			//装卸换算因子
			tStr = textBoxLoadingFactor.Text.Trim();
			pattern = @"^[0-9]+.([0-9]+)?$|^[0-9]*$";
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				MessageBox.Show("装卸换算因子错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			
			//装卸单价
			tStr = textBoxLoadingPrice.Text.Trim();
			pattern = @"^[0-9]+.([0-9]+)?$|^[0-9]*$";
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				MessageBox.Show("装卸单价错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			
			//维修换算因子
			tStr = textBoxRepairFactor.Text.Trim();
			pattern = @"^[0-9]+.([0-9]+)?$|^[0-9]*$";
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				MessageBox.Show("维修换算因子错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			
			//维修单价
			tStr = textBoxRepairPrice.Text.Trim();
			pattern = @"^[0-9]+.([0-9]+)?$|^[0-9]*$";
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				MessageBox.Show("维修单价错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			*/
			return true;
		}
		void FormLeaseItemLoad(object sender, EventArgs e)
		{
			textBoxItemsID.Text = i_ItemsID.ToString();
			textBoxHTID.Text = i_HTID.ToString();
			if(this.Text == "租赁项信息-修改")
			{
				LeaseItems tLeaseItem = BLL.LeaseBLL.GetLeaseItem(i_ItemsID);
				textBoxMName.Text = tLeaseItem.MName;
				if(tLeaseItem.LeaseClass == 0)
				{
					radioButton1.Checked = true;
				}
				else
				{
					radioButton2.Checked = true;
				}
				textBoxLeaseUnit.Text = tLeaseItem.LeaseUnit;
				textBoxLeasePrice.Text = tLeaseItem.LeasePrice.ToString();
				textBoxLoadingUnit.Text = tLeaseItem.LoadingUnit;
				textBoxLoadingFactor.Text = tLeaseItem.LoadingFactor.ToString();
				textBoxLoadingPrice.Text = tLeaseItem.LoadingPrice.ToString();
				textBoxRepairUnit.Text = tLeaseItem.RepairUnit;
				textBoxRepairFactor.Text = tLeaseItem.RepairFactor.ToString();
				textBoxRepairPrice.Text = tLeaseItem.RepairPrice.ToString();
			}
		}
		
		
	}
}
