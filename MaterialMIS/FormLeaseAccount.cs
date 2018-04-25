/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-12-07
 * Time: 13:30
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
	/// Description of FormLeaseAccount.
	/// </summary>
	public partial class FormLeaseAccount : Form
	{
		private DataSet ds1 = new DataSet();	//工程项目
		private DataSet ds2 = new DataSet();	//公司
		private DataSet ds3 = new DataSet();	//租赁余料记录
		private DataSet ds4 = new DataSet();	//还没有结算的租赁记录
		
		private bool ds1OK = false;
		private bool ds2OK = false;
		
		public class ItemsLeftStru
		{
			public int ItemdID;
			public string ItemsName;
			public String ItemsUnit;
			public double ItemsValue;
		}
		
		public FormLeaseAccount()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormLeaseAccountLoad(object sender, EventArgs e)
		{
			ds1 = BLL.ProjectsBLL.GetAllProjects();
			comboBoxProject.DataSource = ds1.Tables[0];
			comboBoxProject.DisplayMember = "ProjectName";
			comboBoxProject.ValueMember = "ProjectID";
			ds1OK = true;
			
			DateTime dt = DateTime.Now;
			DateTime dt_First = dt.AddDays(-(dt.Day) + 1); 
			DateTime dt2 = dt.AddMonths(1);
			DateTime dt_Last = dt2.AddDays(-(dt.Day));

			dateTimePickerSDate.Value = dt_First;
			dateTimePickerEDate.Value = dt_Last;
		}
		void ComboBoxProjectSelectedIndexChanged(object sender, EventArgs e)
		{
			if(ds1OK && comboBoxProject.SelectedIndex >=0 )
			{
				int i_ProjectID;
				i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString());
				ds2 = BLL.LeaseBLL.GetProjectLease(i_ProjectID);
				comboBoxCompany.DataSource = ds2.Tables[0];
				comboBoxCompany.DisplayMember = "CompanyName";
				comboBoxCompany.ValueMember = "CompanyID";
				ds2OK = true;
			}
		}
		void ComboBoxCompanySelectedIndexChanged(object sender, EventArgs e)
		{
			if(ds2OK && comboBoxCompany.SelectedIndex >= 0)
			{				
				RefreshLeaseRemain();
				RefreshLeaseRecord();
			}
		}
		
		//刷新租赁剩余量
		void RefreshLeaseRemain()
		{
			int i_ProjectID;
			int i_CompanyID;
			i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString());
			i_CompanyID = Convert.ToInt32(comboBoxCompany.SelectedValue.ToString());
			ds3 = BLL.LeaseBLL.GetLeaseRemain(i_ProjectID,i_CompanyID);
			dataGridView1.DataSource = ds3.Tables[0];
			SetGridView1Header(dataGridView1);
		}
		
		void SetGridView1Header(DataGridView dv)
		{
			if(dv.Rows.Count == 0)
			{
				return;
			}
			dv.AutoGenerateColumns = false;	
			dv.ReadOnly = true;
			dv.AllowUserToAddRows = false;
			dv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
            dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].HeaderText = "ALeftID";
			dv.Columns[0].Name = "ALeftID";
            dv.Columns[0].Width = 60;
            dv.Columns[0].DataPropertyName = "ALeftID";
            dv.Columns[0].Visible = false;
            
            dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].HeaderText = "租赁项ID";
            dv.Columns[1].Name = "ItemsID";
            dv.Columns[1].Width = 80;
            dv.Columns[1].DataPropertyName = "ItemsID";
            
            dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].HeaderText = "租赁项名称";
            dv.Columns[2].Name = "MName";
            dv.Columns[2].Width = 150;
            dv.Columns[2].DataPropertyName = "MName";
            
            dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].HeaderText = "单位";
            dv.Columns[3].Name = "LeaseUnit";
            dv.Columns[3].Width = 80;
            dv.Columns[3].DataPropertyName = "LeaseUnit";   

			dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].HeaderText = "剩余数量";
            dv.Columns[4].Name = "QualityLeft";
            dv.Columns[4].Width = 80;
            dv.Columns[4].DataPropertyName = "QualityLeft"; 

			dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].HeaderText = "最后结算周期";
            dv.Columns[5].Name = "LastBillCycle";
            dv.Columns[5].Width = 80;
            dv.Columns[5].DataPropertyName = "LastBillCycle";   
			dv.Columns[5].Visible = false;            

			dv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[6].HeaderText = "最后结算日";
            dv.Columns[6].Name = "LasetEDate";
            dv.Columns[6].Width = 120;
            dv.Columns[6].DataPropertyName = "LasetEDate";    
			dv.Columns[6].Visible = false;            
            
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dv.Columns)
            {
            	if(c.Index>6)
            	{
            		c.Visible = false;
            	}
            }
           
		}
		
		//刷新未结算租赁
		void RefreshLeaseRecord()
		{
			int i_ProjectID;
			int i_CompanyID;
			i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString());
			i_CompanyID = Convert.ToInt32(comboBoxCompany.SelectedValue.ToString());
			ds4 = BLL.LeaseBLL.GetLeaseRecord2(i_ProjectID,i_CompanyID);
			dataGridView2.DataSource = ds4.Tables[0];
			SetGridView2Header(dataGridView2);
		}
		
		void SetGridView2Header(DataGridView dv)
		{
			if(dv.Rows.Count == 0)
			{
				return;
			}
			dv.AutoGenerateColumns = false;	
			dv.ReadOnly = true;
			dv.AllowUserToAddRows = false;
			dv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
            dv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dv.Columns[0].HeaderText = "RID";
			dv.Columns[0].Name = "RID";
            dv.Columns[0].Width = 60;
            dv.Columns[0].DataPropertyName = "RID";
            
            dv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[1].HeaderText = "租赁日期";
            dv.Columns[1].Name = "LeaseDate";
            dv.Columns[1].Width = 100;
            dv.Columns[1].DataPropertyName = "LeaseDate";
            
            dv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[2].HeaderText = "租赁项";
            dv.Columns[2].Name = "MName";
            dv.Columns[2].Width = 150;
            dv.Columns[2].DataPropertyName = "MName";
            
            dv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[3].HeaderText = "单位";
            dv.Columns[3].Name = "LeaseUnit";
            dv.Columns[3].Width = 80;
            dv.Columns[3].DataPropertyName = "LeaseUnit";   

			dv.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[4].HeaderText = "数量";
            dv.Columns[4].Name = "Quality";
            dv.Columns[4].Width = 80;
            dv.Columns[4].DataPropertyName = "Quality"; 

			dv.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[5].HeaderText = "经手人";
            dv.Columns[5].Name = "Handler";
            dv.Columns[5].Width = 80;
            dv.Columns[5].DataPropertyName = "Handler";      

			dv.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[6].HeaderText = "备注";
            dv.Columns[6].Name = "Abstract";
            dv.Columns[6].Width = 120;
            dv.Columns[6].DataPropertyName = "Abstract";                  
                        
 			dv.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dv.Columns[7].HeaderText = "状态";
            dv.Columns[7].Name = "LeaseStatus";
            dv.Columns[7].Width = 80;
            dv.Columns[7].DataPropertyName = "LeaseStatus";   
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dv.Columns)
            {
            	if(c.Index>7)
            	{
            		c.Visible = false;
            	}
            }
           
		}
		
		bool CheckFillOK()
		{
			Regex reg;
			string tStr;	
			string pattern;
			//Decimal dOut = 0.0M;
			
			if(comboBoxProject.SelectedIndex == -1)
			{
				MessageBox.Show("未指定工程项目！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			if(comboBoxCompany.SelectedIndex == -1)
			{
				MessageBox.Show("未指定租赁单位！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}		
			
			//检查结算周期对否
			tStr = textBoxBillCycle.Text.Trim();
			pattern = @"(^\d{4}0[1-9]|^\d{4}1[0-2])";
			reg = new Regex(pattern);
			if(tStr.Length !=6 || ! reg.IsMatch(tStr))
			{
				MessageBox.Show("结算周期错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}

			return true;
		}
		
		void AddKeyValue(ref List<ItemsLeftStru> RemainKeyValue,ItemsLeftStru myKV)
		{
			//
			for(int i=0;i<RemainKeyValue.Count;i++)
			{
				if(RemainKeyValue[i].ItemdID == myKV.ItemdID)
				{
					RemainKeyValue[i].ItemsValue += myKV.ItemsValue;
					return;
				}
			}
			RemainKeyValue.Add(myKV);
		}
		
		void ButtonJSPreviewClick(object sender, EventArgs e)
		{
			if(CheckFillOK())
			{
				DataSet tmpDs = new DataSet();
				DataSet FDataSet = new DataSet();
				DataTable table = new DataTable();
				
	
				int i_ProjectID;
				int i_CompanyID;
				i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString());
				i_CompanyID = Convert.ToInt32(comboBoxCompany.SelectedValue.ToString());
				LeaseHT tLeaseHT = BLL.LeaseBLL.GetLeaseHT(i_ProjectID,i_CompanyID);
				
				tmpDs = BLL.LeaseBLL.GetLeaseAccountDs(0);	//随便取数据，用空结构填充
				table = tmpDs.Tables[0].Clone();
				table.TableName = "LeaseAccount";
				FDataSet.Tables.Add(table);
				
				tmpDs = BLL.LeaseBLL.GetLeaseAccountList(0);
				table = tmpDs.Tables[0].Clone();
				table.TableName = "LeaseAccountList";
				FDataSet.Tables.Add(table);
				
				tmpDs = BLL.LeaseBLL.GetLeaseAccountLeft(0);
				table = tmpDs.Tables[0].Clone();
				table.TableName = "LeaseAccountLeft";
				FDataSet.Tables.Add(table);
								
				//将需要结算的数据填写到报表中的表中
				FillReportData(FDataSet);
					
				FastReport.Report report1 = new FastReport.Report();			
				report1.Load("Reports\\LeaseJS.frx");
				report1.RegisterData(FDataSet);
				report1.Show();
				report1.Dispose();
			}
		}
		
		//填数据
		void FillReportData(DataSet FDataSet)
		{
			int i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString());
			int i_CompanyID = Convert.ToInt32(comboBoxCompany.SelectedValue.ToString());
			int i_SNumber = 1;		//租赁结算顺序号
			DateTime dSDate = dateTimePickerSDate.Value.Date;
			DateTime dEDate = dateTimePickerEDate.Value.Date;
			TimeSpan tTS = dEDate.Subtract(dSDate);
			int i_Days = tTS.Days + 1;		//结余时租赁天数
			LeaseHT tLeaseHT = BLL.LeaseBLL.GetLeaseHT(i_ProjectID,i_CompanyID);
			int i_IncludeSDate = tLeaseHT.IncludeSDate;		//租金包含开始日
			int i_IncludeEDate = tLeaseHT.IncludeEDate;		//租金包含结束日
			string s_BillCycle = textBoxBillCycle.Text;		//结算周期
			string s_CalMethod = "" ;		//计算方式
			if(i_IncludeSDate == 0 && i_IncludeEDate == 0)
			{
				s_CalMethod = "倒扣计算法，头尾都不算";
			}
			if(i_IncludeSDate == 1 && i_IncludeEDate == 0)
			{
				s_CalMethod = "倒扣计算法，算头不算尾";
			}
			if(i_IncludeSDate == 1 && i_IncludeEDate == 1)
			{
				s_CalMethod = "倒扣计算法，既算头又算尾";
			}
			if(i_IncludeSDate == 0 && i_IncludeEDate == 1)
			{
				s_CalMethod = "倒扣计算法，算尾不算头";
			}
			List<ItemsLeftStru> RemainKeyValue = new List<ItemsLeftStru>();			
//			myKV.ItemdID = 1;
//			myKV.ItemsName = "asdd";
//			myKV.ItemsValue = 12.80;
//			RemainKeyValue.Add(myKV);

							
			//1.填LeaseAccount表
			DataRow dr = FDataSet.Tables["LeaseAccount"].NewRow();
			dr["BillID"] = 10000;
			dr["ProjectID"] = i_ProjectID;
			dr["ProjectName"] = comboBoxProject.Text;
			dr["CompanyID"] = i_CompanyID;
			dr["CompanyName"] = comboBoxCompany.Text;
			dr["BillCycle"] = s_BillCycle;
			dr["CalMethod"] = s_CalMethod;
			FDataSet.Tables["LeaseAccount"].Rows.Add(dr);
			
			//2.填LeaseAccountList表
			//2.1填结余租赁项						
			DataSet tds = BLL.LeaseBLL.GetLeaseAccountLeft(tLeaseHT.HTID);
			foreach(DataRow drtmp in tds.Tables[0].Rows)
			{
				dr = FDataSet.Tables["LeaseAccountList"].NewRow();
				int i_ItemsID = Convert.ToInt32(drtmp["ItemsID"]);
				LeaseItems tLeaseItem = BLL.LeaseBLL.GetLeaseItem(i_ItemsID);
				dr["ListID"] = i_SNumber;
				dr["SNumber"] = i_SNumber;
				dr["BillID"] = 10000;
				dr["Abstract"] = tLeaseItem.MName + " 上期结余";
				dr["SDate"] = dSDate;
				dr["EDate"] = dEDate;
				dr["LeaseUnit"] = tLeaseItem.LeaseUnit;
				dr["LeaseQuality"] = drtmp["QualityLeft"];
				dr["LeasePrice"] = tLeaseItem.LeasePrice;
				dr["LeaseDays"] = i_Days;
				dr["LeaseAmt"] = Convert.ToDecimal(dr["LeaseQuality"]) * Convert.ToDecimal(dr["LeasePrice"]) * i_Days;
				
				FDataSet.Tables["LeaseAccountList"].Rows.Add(dr);
				
				ItemsLeftStru myKV = new ItemsLeftStru();
				myKV.ItemdID = tLeaseItem.ItemsID;
				myKV.ItemsName = tLeaseItem.MName;
				myKV.ItemsUnit = tLeaseItem.LeaseUnit;
				myKV.ItemsValue = Convert.ToDouble(dr["LeaseQuality"]);
				AddKeyValue(ref RemainKeyValue,myKV);
				
				i_SNumber++;
			}
			//2.2按照时间顺序计算各项租金
			tds = BLL.LeaseBLL.GetLeaseRecord2(i_ProjectID,i_CompanyID);	//未结算的记录
			foreach(DataRow drtmp in tds.Tables[0].Rows)
			{
				//检查租赁日期是否在结算日期范围
				DateTime tLeaseDate = Convert.ToDateTime(drtmp["LeaseDate"]);
				if(tLeaseDate >= dSDate && tLeaseDate <= dEDate)
				{
					dr = FDataSet.Tables["LeaseAccountList"].NewRow();
					int i_ItemsID = Convert.ToInt32(drtmp["ItemsID"]);
					LeaseItems tLeaseItem = BLL.LeaseBLL.GetLeaseItem(i_ItemsID);
					
					
				
					dr["ListID"] = i_SNumber;
					dr["SNumber"] = i_SNumber;
					dr["BillID"] = 10000;
					if(drtmp["Abstract"].ToString().Length != 0)
					{
						dr["Abstract"] = tLeaseItem.MName + "(" + drtmp["Abstract"] + ")";
					}
					else
					{
						dr["Abstract"] = tLeaseItem.MName;
					}
					DateTime dt1 = Convert.ToDateTime(drtmp["LeaseDate"]);
					dr["SDate"] = dt1;
					dr["EDate"] = dEDate;
					TimeSpan tTS1 = dEDate.Subtract(dt1);
					int tDays = tTS1.Days;
					
					if (Convert.ToDecimal(drtmp["Quality"]) > 0)
					{
						if (i_IncludeSDate == 1) 
						{
							tDays++;
						}
					}
					else
					{
						if(i_IncludeEDate != 1)
						{
							tDays++;
						}
					}

					if(tLeaseItem.LeaseClass == 0)
					{
						//租赁项
						dr["LeaseUnit"] = tLeaseItem.LeaseUnit;
						dr["LeaseQuality"] = drtmp["Quality"];
						dr["LeasePrice"] = tLeaseItem.LeasePrice;
						dr["LeaseDays"] = tDays;
						dr["LeaseAmt"] = Convert.ToDecimal(dr["LeaseQuality"]) * Convert.ToDecimal(dr["LeasePrice"]) * tDays;
						
						dr["LoadingUnit"] = tLeaseItem.LoadingUnit;
						dr["LoadingFactor"] = tLeaseItem.LoadingFactor;
						dr["LoadingQuality"] = Math.Abs(Convert.ToDecimal(dr["LeaseQuality"]) / Convert.ToDecimal(dr["LoadingFactor"]));
						dr["LoadingPrice"] = tLeaseItem.LoadingPrice;
						dr["LoadingAmt"] = Math.Abs(Convert.ToDecimal(dr["LoadingPrice"]) * Convert.ToDecimal(dr["LoadingQuality"]));
						
						if(Convert.ToDecimal(drtmp["Quality"]) < 0)
						{
							dr["RepairUnit"] = tLeaseItem.RepairUnit;
							dr["RepairFactor"] = tLeaseItem.RepairFactor;
							dr["RepairQuality"] = Math.Abs(Convert.ToDecimal(dr["LeaseQuality"]) / Convert.ToDecimal(dr["RepairFactor"]));
							dr["RepairPrice"] = tLeaseItem.RepairPrice;
							dr["RepairAmt"] = Math.Abs(Convert.ToDecimal(dr["RepairPrice"]) * Convert.ToDecimal(dr["RepairQuality"]));
						}
						
						ItemsLeftStru myKV = new ItemsLeftStru();
						myKV.ItemdID = tLeaseItem.ItemsID;
						myKV.ItemsName = tLeaseItem.MName;
						myKV.ItemsUnit = tLeaseItem.LeaseUnit;
						myKV.ItemsValue = Convert.ToDouble(dr["LeaseQuality"]);
						AddKeyValue(ref RemainKeyValue, myKV);
						
					}
					else
					{
						//单独结算项
						dr["LeaseUnit"] = tLeaseItem.LeaseUnit;
						dr["OtherUnit"] = tLeaseItem.LeaseUnit;
						dr["OtherQuality"] = drtmp["Quality"];
						dr["OtherPrice"] = tLeaseItem.LeasePrice;
						dr["OtherAmt"] = Convert.ToDecimal(dr["OtherPrice"]) * Convert.ToDecimal(dr["OtherQuality"]);
					}
					FDataSet.Tables["LeaseAccountList"].Rows.Add(dr);
				

					
					i_SNumber++;
				}
				
			}
			//2.3将计算出来的余量数据填写好
			foreach(ItemsLeftStru itemLS in RemainKeyValue)
			{
				dr = FDataSet.Tables["LeaseAccountLeft"].NewRow();
				dr["ItemsID"] = itemLS.ItemdID;
				dr["MName"] = itemLS.ItemsName;
				dr["LeaseUnit"] = itemLS.ItemsUnit;
				dr["QualityLeft"] = itemLS.ItemsValue;
				FDataSet.Tables["LeaseAccountLeft"].Rows.Add(dr);
			}
		}
		void ButtonJSClick(object sender, EventArgs e)
		{
			//结算
			int i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString());
			int i_CompanyID = Convert.ToInt32(comboBoxCompany.SelectedValue.ToString());
			DateTime dSDate = dateTimePickerSDate.Value.Date;
			DateTime dEDate = dateTimePickerEDate.Value.Date;
			string s_BillCycle = textBoxBillCycle.Text;		//结算周期
			//1.结算周期不包含在结算时间段中
			string s1 = dSDate.ToString("yyyyMM");
			string s2 = dEDate.ToString("yyyyMM");
			if(String.Compare(s_BillCycle,s1) == -1 || String.Compare(s_BillCycle,s2) == 1)
			{
				MessageBox.Show("结算周期错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			//2.结算周期已经结算过了
			if(BLL.LeaseBLL.GetLeaseJSLine(i_ProjectID,i_CompanyID,s_BillCycle) > 0)
			{
				MessageBox.Show("输入的结算周期已经结算过了！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			//3.还有日期在结算日期之前的记录未结算
			LeaseHT tLeaseHT = new LeaseHT();
			tLeaseHT = BLL.LeaseBLL.GetLeaseHT(i_ProjectID,i_CompanyID);
			if(BLL.LeaseBLL.GetLeaseRecord(tLeaseHT.HTID,dSDate) > 0)
			{
				MessageBox.Show("存在结算日期段前未结算的租赁数据！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			ButtonJSPreviewClick(sender,e);
			MainForm pF = (MainForm)(this.Parent.Parent.Parent.Parent);
			UpdateToDataBase(pF);
		}
		
		void UpdateToDataBase(MainForm pF)
		{
			ToolStripLabel labelStatus = pF.toolStatus;

			int i_ProjectID = Convert.ToInt32(comboBoxProject.SelectedValue.ToString());
			int i_CompanyID = Convert.ToInt32(comboBoxCompany.SelectedValue.ToString());
			DateTime dSDate = dateTimePickerSDate.Value.Date;
			DateTime dEDate = dateTimePickerEDate.Value.Date;
			string s_BillCycle = textBoxBillCycle.Text;		//结算周期
			DialogResult dr = MessageBox.Show("确定要结算吗？","确认信息",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			if(dr == DialogResult.Yes)
			{
				BLL.LeaseBLL.AddNewLeaseJS(i_ProjectID,i_CompanyID,s_BillCycle,dSDate,dEDate,labelStatus);
			}
		}
	
		
	}
}
