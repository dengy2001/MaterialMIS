/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-08-19
 * 时间: 17:43
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
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
	/// Description of FormRecord.
	/// </summary>
	public partial class FormRecord : Form
	{
		public int i_ProjectID;
		public int i_SupplierID;
		public int i_CommRecordID;
		
		public FormRecord()
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
			if(this.Text =="材料记录-新增")
			{
				CommMaterialRecord tNew = new CommMaterialRecord();
				
				tNew.ProjectID = i_ProjectID;
				tNew.CompanyID = i_SupplierID;
				tNew.RecordState = textBoxRecordState.Text;
				tNew.PurchaseDate = dateTimePicker1.Value;
				tNew.BillCycle = textBoxBillCycle.Text;
				tNew.MaterialName = comboBox1.Text;
				if(tNew.MaterialName == "")
				{
					MessageBox.Show("材料名称必须输入！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				tNew.MaterialUnit = textBoxUnit.Text;
				tNew.MaterialSpec = textBoxSpec.Text;
				Decimal dNumber = 0.0M;
				Decimal dPrice = 0.0M;
				Decimal dShipment = 0.0M;
				Decimal dAmount = 0.0M;
				if(!Decimal.TryParse(textBoxNumber.Text,out dNumber))
				{
					MessageBox.Show("数量输入错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				if(!Decimal.TryParse(textBoxPrice.Text,out dPrice))
				{
					MessageBox.Show("单价输入错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				if(!Decimal.TryParse(textBoxShipment.Text,out dShipment))
				{
					MessageBox.Show("运费输入错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				dAmount = dNumber*dPrice + dShipment;
				tNew.MaterialNumber = dNumber;
				tNew.MaterialPrice = dPrice;
				tNew.MaterialShipment = dShipment;
				tNew.MaterialAmt = dAmount;
				tNew.ForUsePosition = textBoxPosition.Text;
				tNew.MaterialPlan = textBoxPlaner.Text;
				tNew.MaterialPlanNo = textBoxPlanNo.Text;
				tNew.PurchName = textBoxPucher.Text;
				tNew.ReceiverName = textBoxReceiver.Text;
				tNew.ReceiveNo = textBoxReceiveNo.Text;
				tNew.Brief = textBoxBrief.Text;
				
				BLL.CommMatreialRecordBLL.AddRecord(tNew);
				this.Close();
			}
			else
			{
				//修改保存
				CommMaterialRecord tNew = new CommMaterialRecord();
				
				tNew.CommRecordID = i_CommRecordID;
				tNew.ProjectID = i_ProjectID;
				tNew.CompanyID = i_SupplierID;
				tNew.RecordState = textBoxRecordState.Text;
				tNew.PurchaseDate = dateTimePicker1.Value;
				tNew.BillCycle = textBoxBillCycle.Text;
				tNew.MaterialName = comboBox1.Text;
				if(tNew.MaterialName == "")
				{
					MessageBox.Show("材料名称必须输入！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				tNew.MaterialUnit = textBoxUnit.Text;
				tNew.MaterialSpec = textBoxSpec.Text;
				Decimal dNumber = 0.0M;
				Decimal dPrice = 0.0M;
				Decimal dShipment = 0.0M;
				Decimal dAmount = 0.0M;
				if(!Decimal.TryParse(textBoxNumber.Text,out dNumber))
				{
					MessageBox.Show("数量输入错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				if(!Decimal.TryParse(textBoxPrice.Text,out dPrice))
				{
					MessageBox.Show("单价输入错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				if(!Decimal.TryParse(textBoxShipment.Text,out dShipment))
				{
					MessageBox.Show("运费输入错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				dAmount = dNumber*dPrice + dShipment;
				tNew.MaterialNumber = dNumber;
				tNew.MaterialPrice = dPrice;
				tNew.MaterialShipment = dShipment;
				tNew.MaterialAmt = dAmount;
				tNew.ForUsePosition = textBoxPosition.Text;
				tNew.MaterialPlan = textBoxPlaner.Text;
				tNew.MaterialPlanNo = textBoxPlanNo.Text;
				tNew.PurchName = textBoxPucher.Text;
				tNew.ReceiverName = textBoxReceiver.Text;
				tNew.ReceiveNo = textBoxReceiveNo.Text;
				tNew.Brief = textBoxBrief.Text;
				
				BLL.CommMatreialRecordBLL.UpdateCommRecord(tNew);
				this.Close();
			}
		}
		void FormRecordLoad(object sender, EventArgs e)
		{
			//填充缺省值
			FillDefault();
			
			
		}
		
		void FillDefault()
		{
			if(this.Text == "材料记录-新增")
			{
				textBoxProjectID.Text = i_ProjectID.ToString();
				textBoxSupplierID.Text = i_SupplierID.ToString();
				textBoxRecordState.Text = "未对账";
				//采购日期就用当前显示的
				DateTime tD = DateTime.Now;
				string sBillCycle =  tD.ToString("yyyyMM");
				textBoxBillCycle.Text = sBillCycle;
				//填充其他的数据
			}
			else
			{
				CommMaterialRecord tModify = new CommMaterialRecord();
				tModify = BLL.CommMatreialRecordBLL.GetCommMaterialRecordID(i_CommRecordID);
				i_ProjectID = tModify.ProjectID;
				i_SupplierID = tModify.CompanyID;
				textBoxProjectID.Text = i_ProjectID.ToString();
				textBoxSupplierID.Text = i_SupplierID.ToString();
				textBoxCommRecordID.Text = i_CommRecordID.ToString();
				textBoxRecordState.Text = tModify.RecordState;
				dateTimePicker1.Value = tModify.PurchaseDate;
				textBoxBillCycle.Text = tModify.BillCycle;
				comboBox1.Text = tModify.MaterialName;
				textBoxUnit.Text = tModify.MaterialUnit;
				textBoxSpec.Text = tModify.MaterialSpec;
				textBoxNumber.Text = tModify.MaterialNumber.ToString();
				textBoxPrice.Text = tModify.MaterialPrice.ToString();
				textBoxShipment.Text = tModify.MaterialShipment.ToString();
				textBoxAmount.Text = tModify.MaterialAmt.ToString();
				textBoxPosition.Text = tModify.ForUsePosition;
				textBoxPlaner.Text = tModify.MaterialPlan;
				textBoxPlanNo.Text = tModify.MaterialPlanNo;
				textBoxPucher.Text = tModify.PurchName;
				textBoxReceiver.Text = tModify.ReceiverName;
				textBoxReceiveNo.Text = tModify.ReceiveNo;
				textBoxBrief.Text = tModify.Brief;
			}
			if(textBoxNumber.Text =="")
			{
				textBoxNumber.Text = "0";
			}
			if(textBoxPrice.Text =="")
			{
				textBoxPrice.Text = "0";
			}
			if(textBoxShipment.Text =="")
			{
				textBoxShipment.Text = "0";
			}
		
		}
		void TextBoxNumberTextChanged(object sender, EventArgs e)
		{
			Cal1();
		}
		
		void Cal1()
		{
			//计算金额
			Decimal dNumber = 0.0M;
			Decimal dPrice = 0.0M;
			Decimal dShipment = 0.0M;
			Decimal dAmount = 0.0M;
			if(!Decimal.TryParse(textBoxNumber.Text,out dNumber))
			{
				return;
			}
			if(!Decimal.TryParse(textBoxPrice.Text,out dPrice))
			{
				return;
			}
			if(!Decimal.TryParse(textBoxShipment.Text,out dShipment))
			{
				return;
			}
			dAmount = dNumber*dPrice + dShipment;
			textBoxAmount.Text = dAmount.ToString();
		}
		void TextBoxPriceTextChanged(object sender, EventArgs e)
		{
			Cal1();
		}
		void TextBoxShipmentTextChanged(object sender, EventArgs e)
		{
			Cal1();
		}
		void TextBoxSpecTextChanged(object sender, EventArgs e)
		{
			Cal2();
		}
		
		void Cal2()
		{
			//计算材料规格辅助
			try
			{
				Object dO = new DataTable().Compute(textBoxSpec.Text, null);			
				textBoxCal.Text = dO.ToString();
			}
			catch(Exception e1)
			{
				string s1 = e1.Message;
			}
		}
	}
}
