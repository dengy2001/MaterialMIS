/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-12-06
 * Time: 12:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DomainModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormLeaseRecord1.
	/// </summary>
	public partial class FormLeaseRecord1 : Form
	{
		public int i_HTID;	//合同ID
		public int i_RID;	//在修改是可用的租赁记录号
		private DataSet ds1 = new DataSet();	//合同租赁项
		private bool bindingFlag = false;			//数据绑定标记
		
		public FormLeaseRecord1()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormLeaseRecord1Load(object sender, EventArgs e)
		{
			//填充租赁项
			
			ds1 = BLL.LeaseBLL.GetLeaseItemsByHTID(i_HTID);
			comboBoxItemsName.DataSource = ds1.Tables[0];
			comboBoxItemsName.ValueMember = "ItemsID";
			comboBoxItemsName.DisplayMember = "MName";
			if(this.Text == "租赁记录-新增")
			{
				
			}
			else
			{
				LeaseRecord tRI = BLL.LeaseBLL.GetLeaseRecord(i_RID);
				LeaseItems tI = BLL.LeaseBLL.GetLeaseItem(tRI.ItemsID);
				comboBoxItemsName.SelectedValue = tI.ItemsID;
				textBoxLeaseUnit.Text = tI.LeaseUnit;
				dateTimePickerLeaseDate.Value = tRI.LeaseDate;
				textBoxQuality.Text = tRI.Quality.ToString();
				textBoxHandler.Text = tRI.Handler;
				textBoxAbstract.Text = tRI.Abstract;
			}
			
			bindingFlag = true;
		}

		void ComboBoxItemsNameSelectedIndexChanged(object sender, EventArgs e)
		{
			if(bindingFlag && Convert.ToInt32(comboBoxItemsName.SelectedValue) > 0)
			{
				//选择了
				LeaseItems tI = BLL.LeaseBLL.GetLeaseItem(Convert.ToInt32(comboBoxItemsName.SelectedValue));
				textBoxLeaseUnit.Text = tI.LeaseUnit;
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
			if(this.Text == "租赁记录-新增")
			{
				AddNewLeaseRecord();
			}
			else
			{
				//修改
				ModifyLeaseRecord();
			}
			this.Close();
		}
		
		bool CheckFillOK()
		{		
			Decimal dOut = 0.0M;
			
			if(textBoxQuality.Text.Length == 0)
			{
				MessageBox.Show("未输入租赁数量！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			if(textBoxHandler.Text.Length == 0)
			{
				MessageBox.Show("未输入经手人！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}			
			if(!Decimal.TryParse(textBoxQuality.Text,out dOut))
			{
				MessageBox.Show("租赁数量输入错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			if(comboBoxItemsName.SelectedValue == null)
			{
				MessageBox.Show("请指定租赁项！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			return true;
		}
		void AddNewLeaseRecord()
		{
			LeaseRecord tLeaseRecord = new LeaseRecord();
			tLeaseRecord.HTID = i_HTID;
			tLeaseRecord.ItemsID = Convert.ToInt32(comboBoxItemsName.SelectedValue);
			tLeaseRecord.LeaseDate = dateTimePickerLeaseDate.Value.Date;
			tLeaseRecord.Quality = Convert.ToDecimal(textBoxQuality.Text);
			tLeaseRecord.Handler = textBoxHandler.Text;
			tLeaseRecord.Abstract = textBoxAbstract.Text;
			tLeaseRecord.LeaseStatus = "未结算";
			
			BLL.LeaseBLL.AddLeaseRecord(tLeaseRecord);
		}
		void ModifyLeaseRecord()
		{
			LeaseRecord tLeaseRecord = new LeaseRecord();
			tLeaseRecord = BLL.LeaseBLL.GetLeaseRecord(i_RID);
			
			tLeaseRecord.ItemsID = Convert.ToInt32(comboBoxItemsName.SelectedValue);
			tLeaseRecord.LeaseDate = dateTimePickerLeaseDate.Value.Date;
			tLeaseRecord.Quality = Convert.ToDecimal(textBoxQuality.Text);
			tLeaseRecord.Handler = textBoxHandler.Text;
			tLeaseRecord.Abstract = textBoxAbstract.Text;
			
			BLL.LeaseBLL.ModifyLeaseRecord(tLeaseRecord);
		}
		

	}
}
