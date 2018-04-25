/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-03
 * 时间: 14:41
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DomainModel;
using BLL;


namespace MaterialMIS
{
	/// <summary>
	/// Description of FormAccountBill.
	/// </summary>
	public partial class FormAccountBill : Form
	{
		private DataSet ds1 = new DataSet();
		private DataSet ds2 = new DataSet();
		private DataSet ds3 = new DataSet();
		public int i_CompanyID = 0;
		
		public FormAccountBill()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Label1Click(object sender, EventArgs e)
		{
	
		}
		
		void FormAccountBillLoad(object sender, EventArgs e)
		{
			//根据窗口的标题更改一些显示项
			switch(this.Text)
			{
				case "未收款-新增":
					labelCompanyType.Text = "客  户：";
					labelYW.Text = "未收款金额：";
					labelMoneyType.Text = "收入项目";
					//填充Company,project，MoneyType
					FillCompany(0);
					FillProject();
					FillMoneyType(0);
					break;
				case "未收款-收款":
					labelCompanyType.Text = "客  户：";
					labelYW.Text = "收款金额：";
					labelMoneyType.Text = "收入项目";
					//填充Company,project，MoneyType
					FillCompany(0);
					FillProject();
					FillMoneyType(0);
					break;
				case "未付款-新增":
					labelCompanyType.Text = "供应商：";
					labelYW.Text = "未付款金额：";
					labelMoneyType.Text = "支出项目";
					//填充Company,project，MoneyType
					FillCompany(1);
					FillProject();
					FillMoneyType(1);
					break;
				case "未付款-付款":
					labelCompanyType.Text = "供应商：";
					labelYW.Text = "付款金额：";
					labelMoneyType.Text = "支出项目";
					//填充Company,project，MoneyType
					FillCompany(1);
					FillProject();
					FillMoneyType(1);
					break;
				default:
					break;
			}
			
			//选择指定的公司
			if(i_CompanyID != 0)
			{
				comboBoxComPany.SelectedValue = i_CompanyID;
			}
		}
		
		void FillCompany(int i_CompanyType)
		{
			if(i_CompanyType == 0)
			{
				//客户
				ds1 = BLL.CompanyBLL.GetCompany1();
				comboBoxComPany.DataSource = ds1.Tables[0];
				comboBoxComPany.DisplayMember = "CompanyName";
				comboBoxComPany.ValueMember = "CompanyID";
			}
			else
			{
				//供应商
				ds1 = BLL.CompanyBLL.GetCompany2();
				comboBoxComPany.DataSource = ds1.Tables[0];
				comboBoxComPany.DisplayMember = "CompanyName";
				comboBoxComPany.ValueMember = "CompanyID";
			}
		}
		
		void FillProject()
		{
			ds2 = BLL.ProjectsBLL.GetAllProjects();
			comboBoxProject.DataSource = ds2.Tables[0];
			comboBoxProject.DisplayMember = "ProjectName";
			comboBoxProject.ValueMember = "ProjectID";
		}
		
		void FillMoneyType(int i_MoneyTypeClass)
		{
			if(i_MoneyTypeClass == 0)
			{
				//收入
				ds3 = BLL.MoneyTypeBLL.GetAllMoneyTypeIn();
				comboBoxMoneyType.DataSource = ds3.Tables[0];
				comboBoxMoneyType.DisplayMember = "MoneyTypeName";
				comboBoxMoneyType.ValueMember = "MoneyTypeID";
			}
			else
			{
				//支出
				ds3 = BLL.MoneyTypeBLL.GetAllMoneyTypeOut();
				comboBoxMoneyType.DataSource = ds3.Tables[0];
				comboBoxMoneyType.DisplayMember = "MoneyTypeName";
				comboBoxMoneyType.ValueMember = "MoneyTypeID";
			}
		}
		void ButtonCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			
			//按照窗口标题来确定保存数据的操作
			AccountBill t1 = new AccountBill();
			t1.BillDate = dateTimePickerBillDate.Value;
			t1.BillMemo = textBoxBillMemo.Text.Trim();
			t1.CompanyID = Convert.ToInt32(comboBoxComPany.SelectedValue.ToString());
			t1.ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString()); 
			t1.MoneyTypeID = Convert.ToInt32(comboBoxMoneyType.SelectedValue.ToString());
			switch(this.Text)
			{
				case "未收款-新增":					
					t1.BillYS = Convert.ToDecimal(textBoxBillMoney.Text.ToString());
					t1.BillSS = 0;
					t1.BillYF = 0;
					t1.BillSF = 0;
					t1.BillType = 0;
					
					break;
				case "未收款-收款":
					t1.BillYS = 0;
					t1.BillSS = Convert.ToDecimal(textBoxBillMoney.Text.ToString());
					t1.BillYF = 0;
					t1.BillSF = 0;
					t1.BillType = 0;

					break;
				case "未付款-新增":
					t1.BillYS = 0;
					t1.BillSS = 0;
					t1.BillYF = Convert.ToDecimal(textBoxBillMoney.Text.ToString());
					t1.BillSF = 0;
					t1.BillType = 1;

					break;
				case "未付款-付款":
					t1.BillYS = 0;
					t1.BillSS = 0;
					t1.BillYF = 0;
					t1.BillSF = Convert.ToDecimal(textBoxBillMoney.Text.ToString());
					t1.BillType = 1;

					break;
				default:
					break;
			}
			
			BLL.AccountBillBLL.AddAccountBill(t1);
			
			this.Close();
		}
		
		void TextBoxBillMoneyKeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				string ts = ((TextBox)sender).Text;				
				decimal td = Convert.ToDecimal(ts + e.KeyChar.ToString());
			}
			catch
			{
				if(e.KeyChar == '\b')
				{
					e.Handled = false;
				}
				else
				{
					//e.KeyChar = (char)0;
					e.Handled = true;
				}
			}
				
		}

	}
}
