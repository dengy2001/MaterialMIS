/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-05-31
 * 时间: 10:43
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormOptions.
	/// </summary>
	public partial class FormOptions : Form
	{
		private DataSet ds1 = new DataSet();
		private DataSet ds2 = new DataSet();
		private DataSet ds3 = new DataSet();
		private DataSet ds4 = new DataSet();
		private DataSet ds5 = new DataSet();
		private DataSet ds6 = new DataSet();
		
		public FormOptions()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		//调整Panel的显示
		void ShowPanel(int iPanel)
		{
			switch(iPanel)
			{
				case 1:
					//显示panel1
					panel1.Visible = true;
					panel2.Visible = false;
					panel3.Visible = false;
					panel4.Visible = false;
					panel5.Visible = false;
					panel6.Visible = false;
					MovePanel(panel1);
					break;
				case 2:
					//显示panel2
					panel1.Visible = false;
					panel2.Visible = true;
					panel3.Visible = false;
					panel4.Visible = false;
					panel5.Visible = false;
					panel6.Visible = false;
					MovePanel(panel2);
					break;
				case 3:
					//显示panel3
					panel1.Visible = false;
					panel2.Visible = false;
					panel3.Visible = true;
					panel4.Visible = false;
					panel5.Visible = false;
					panel6.Visible = false;
					MovePanel(panel3);
					break;
				case 4:
					//显示panel4
					panel1.Visible = false;
					panel2.Visible = false;
					panel3.Visible = false;
					panel4.Visible = true;
					panel5.Visible = false;
					panel6.Visible = false;
					MovePanel(panel4);
					break;
				case 5:
					//显示panel5
					panel1.Visible = false;
					panel2.Visible = false;
					panel3.Visible = false;
					panel4.Visible = false;
					panel5.Visible = true;
					panel6.Visible = false;
					MovePanel(panel5);
					break;
				case 6:
					//显示panel6
					panel1.Visible = false;
					panel2.Visible = false;
					panel3.Visible = false;
					panel4.Visible = false;
					panel5.Visible = false;
					panel6.Visible = true;
					MovePanel(panel6);
					break;
				default:
					break;
						
			}
		}
		
		void MovePanel(Panel iPanel)
		{
			iPanel.Location = new Point(148,13);
			iPanel.Anchor = AnchorStyles.Bottom|AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right;
			iPanel.Height = this.Height - 30;
		}
		
		void ButtonProjectClick(object sender, EventArgs e)
		{
			ShowPanel(1);
		}
		void ButtonSZClick(object sender, EventArgs e)
		{
			ShowPanel(2);
		}
		void ButtonWareHouseClick(object sender, EventArgs e)
		{
			ShowPanel(3);
		}
		void FormOptionsLoad(object sender, EventArgs e)
		{
			ShowPanel(1);
			//项目信息列表
			ds1 = BLL.ProjectsBLL.GetAllProjects();
			dataGridViewProjects.DataSource = ds1.Tables[0];
			SetProjectsColumnHeader();
			//收支信息
			ds2 = BLL.MoneyTypeBLL.GetAllMoneyType();
			dataGridViewMoneyType.DataSource = ds2.Tables[0];
			SetMoneyTypeColumnHeader();
			
			//仓库信息
			ds3 = BLL.WareHouseBLL.GetAllWareHouse();
			dataGridViewWareHouse.DataSource = ds3.Tables[0];
			SetWareHouseColumnHeader();
			
			//Options
			ds4 = BLL.ProgOptionsBLL.GetAllOptions();
			dataGridViewOptions.DataSource = ds4.Tables[0];
			SetOptionsColumnHeader();
			
			//Users
			ds5 = BLL.UserBLL.GetAllUsers();
			dataGridViewUsers.DataSource = ds5.Tables[0];
			SetUsersColumnHeader();
			
			//Companies
			ds6 = BLL.CompanyBLL.GetCompanyAll();
			dataGridViewCompanies.DataSource = ds6.Tables[0];
			SetCompaniesColumnHeader();
		}
		
		void SetProjectsColumnHeader()
		{
			dataGridViewProjects.AutoGenerateColumns = false;	
			//dataGridViewProjects.ColumnCount = 3;
			dataGridViewProjects.ReadOnly = true;
			dataGridViewProjects.AllowUserToAddRows = false;
			dataGridViewProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			
            dataGridViewProjects.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewProjects.Columns[0].HeaderText = "项目ID";
			dataGridViewProjects.Columns[0].Name = "ProjectID";
            dataGridViewProjects.Columns[0].Width = 100;
            dataGridViewProjects.Columns[0].DataPropertyName = "ProjectID";
            
            dataGridViewProjects.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewProjects.Columns[1].HeaderText = "项目名称";
            dataGridViewProjects.Columns[1].Name = "ProjectName";
            dataGridViewProjects.Columns[1].Width = 120;
            dataGridViewProjects.Columns[1].DataPropertyName = "ProjectName";
            
            dataGridViewProjects.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewProjects.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewProjects.Columns[2].HeaderText = "项目详情";
            dataGridViewProjects.Columns[2].Name = "ProjectAbstract";
            dataGridViewProjects.Columns[2].Width = panel1.Width - 240;
            dataGridViewProjects.Columns[2].DataPropertyName = "ProjectAbstract";
           
		}
		
		
		void SetMoneyTypeColumnHeader()
		{
			dataGridViewMoneyType.AutoGenerateColumns = false;	
			//dataGridViewProjects.ColumnCount = 3;
			dataGridViewMoneyType.ReadOnly = true;
			dataGridViewMoneyType.AllowUserToAddRows = false;
			dataGridViewMoneyType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewMoneyType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			
            dataGridViewMoneyType.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewMoneyType.Columns[0].HeaderText = "收支项目ID";
			dataGridViewMoneyType.Columns[0].Name = "MoneyTypeID";
            dataGridViewMoneyType.Columns[0].Width = 150;
            dataGridViewMoneyType.Columns[0].DataPropertyName = "MoneyTypeID";
            
            dataGridViewMoneyType.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewMoneyType.Columns[1].HeaderText = "收支项目名称";
            dataGridViewMoneyType.Columns[1].Name = "MoneyTypeName";
            dataGridViewMoneyType.Columns[1].Width = 120;
            dataGridViewMoneyType.Columns[1].DataPropertyName = "MoneyTypeName";
            
            dataGridViewMoneyType.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewMoneyType.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewMoneyType.Columns[2].HeaderText = "收支项目性质";
            dataGridViewMoneyType.Columns[2].Name = "MoneyTypeClass";
            dataGridViewMoneyType.Columns[2].Width = panel1.Width - 300;
            dataGridViewMoneyType.Columns[2].DataPropertyName = "MoneyTypeClass";
           
		}
		
		void SetWareHouseColumnHeader()
		{
			dataGridViewWareHouse.AutoGenerateColumns = false;	
			//dataGridViewProjects.ColumnCount = 3;
			dataGridViewWareHouse.ReadOnly = true;
			dataGridViewWareHouse.AllowUserToAddRows = false;
			dataGridViewWareHouse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewWareHouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			
            dataGridViewWareHouse.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewWareHouse.Columns[0].HeaderText = "仓库ID";
			dataGridViewWareHouse.Columns[0].Name = "WareHouseID";
            dataGridViewWareHouse.Columns[0].Width = 150;
            dataGridViewWareHouse.Columns[0].DataPropertyName = "WareHouseID";
            
            dataGridViewWareHouse.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewWareHouse.Columns[1].HeaderText = "仓库名称";
            dataGridViewWareHouse.Columns[1].Name = "WareHouseName";
            dataGridViewWareHouse.Columns[1].Width = panel1.Width - 200;
            dataGridViewWareHouse.Columns[1].DataPropertyName = "WareHouseName";
                       
		}
		
		void SetUsersColumnHeader()
		{
			dataGridViewUsers.AutoGenerateColumns = false;
			dataGridViewUsers.ReadOnly = true;
			dataGridViewUsers.AllowUserToAddRows = false;
			dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
            dataGridViewUsers.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewUsers.Columns[0].HeaderText = "UserID";
			dataGridViewUsers.Columns[0].Name = "UserID";
            dataGridViewUsers.Columns[0].Width = 80;
            dataGridViewUsers.Columns[0].DataPropertyName = "UserID";
            
            dataGridViewUsers.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewUsers.Columns[1].HeaderText = "登录名";
            dataGridViewUsers.Columns[1].Name = "UserName";
            dataGridViewUsers.Columns[1].Width = 120;
            dataGridViewUsers.Columns[1].DataPropertyName = "UserName";
            
            dataGridViewUsers.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewUsers.Columns[2].HeaderText = "显示名";
            dataGridViewUsers.Columns[2].Name = "UserDisplayName";
            dataGridViewUsers.Columns[2].Width = 200;
            dataGridViewUsers.Columns[2].DataPropertyName = "UserDisplayName";
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dataGridViewUsers.Columns)
            {
            	if(c.Index>2)
            	{
            		c.Visible = false;
            	}
            }
                       
		}
		
		void SetCompaniesColumnHeader()
		{
			dataGridViewCompanies.AutoGenerateColumns = false;
			dataGridViewCompanies.ReadOnly = true;
			dataGridViewCompanies.AllowUserToAddRows = false;
			dataGridViewCompanies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewCompanies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			
            dataGridViewCompanies.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCompanies.Columns[0].HeaderText = "单位ID";
			dataGridViewCompanies.Columns[0].Name = "CompanyID";
            dataGridViewCompanies.Columns[0].Width = 80;
            dataGridViewCompanies.Columns[0].DataPropertyName = "CompanyID";
            
            dataGridViewCompanies.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCompanies.Columns[1].HeaderText = "单位名";
            dataGridViewCompanies.Columns[1].Name = "CompanyName";
            dataGridViewCompanies.Columns[1].Width = 300;
            dataGridViewCompanies.Columns[1].DataPropertyName = "CompanyName";
            
            dataGridViewCompanies.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCompanies.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCompanies.Columns[2].HeaderText = "单位类别";
            dataGridViewCompanies.Columns[2].Name = "CompanyType";
            dataGridViewCompanies.Columns[2].Width = 100;
            dataGridViewCompanies.Columns[2].DataPropertyName = "CompanyType";
            
            //隐藏不需要的
            foreach(DataGridViewColumn c in dataGridViewCompanies.Columns)
            {
            	if(c.Index>2)
            	{
            		c.Visible = false;
            	}
            }
                       
		}
		
		
		void SetOptionsColumnHeader()
		{
			dataGridViewOptions.AutoGenerateColumns = false;	
			dataGridViewOptions.ReadOnly = true;
			dataGridViewOptions.AllowUserToAddRows = false;
			dataGridViewOptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewOptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			
            dataGridViewOptions.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewOptions.Columns[0].HeaderText = "OptionsID";
			dataGridViewOptions.Columns[0].Name = "OptionsID";
            dataGridViewOptions.Columns[0].Width = 100;
            dataGridViewOptions.Columns[0].DataPropertyName = "OptionsID";
            
            dataGridViewOptions.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOptions.Columns[1].HeaderText = "选项Key";
            dataGridViewOptions.Columns[1].Name = "OptionsKey";
            dataGridViewOptions.Columns[1].Width = 120;
            dataGridViewOptions.Columns[1].DataPropertyName = "OptionsKey";
            
            dataGridViewOptions.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewOptions.Columns[2].HeaderText = "选项Value";
            dataGridViewOptions.Columns[2].Name = "OptionsValue";
            dataGridViewOptions.Columns[2].Width = panel4.Width - 250;
            dataGridViewOptions.Columns[2].DataPropertyName = "OptionsValue";
                       
		}
		
		
		void ButtonAddProjectClick(object sender, EventArgs e)
		{
			//新增项目
			FormProject tF = new FormProject();
			tF.Text="项目信息-新增";						
			tF.ShowDialog();
			RefreshProjects();
		}

		void ButtonModifyProjectClick(object sender, EventArgs e)
		{
			//修改项目信息
			if(dataGridViewProjects.CurrentRow != null)
			{
				FormProject tF = new FormProject();
				tF.i_ProjectID = Convert.ToInt32(dataGridViewProjects.CurrentRow.Cells[0].Value.ToString());
				tF.Text="项目信息-修改";						
				tF.ShowDialog();
			}
			else
			{
				MessageBox.Show("请选择要修改的项目！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			RefreshProjects();
		}
		
		void RefreshProjects()
		{
			ds1 = BLL.ProjectsBLL.GetAllProjects();
			dataGridViewProjects.DataSource = null;
			dataGridViewProjects.DataSource = ds1.Tables[0];
			//dataGridViewProjects.Refresh();
		}
		
		
		void ButtonDelProjectClick(object sender, EventArgs e)
		{
			if(dataGridViewProjects.CurrentRow != null)
			{
				DialogResult result;
				int iProjectID = Convert.ToInt32(dataGridViewProjects.CurrentRow.Cells[0].Value.ToString());
				string sProjectName = dataGridViewProjects.CurrentRow.Cells[1].Value.ToString();

                result = MessageBox.Show("您确认删除当前选中的【" + sProjectName + "】项目吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                	try
                	{
	                    // 删除指定的项目
	                    BLL.ProjectsBLL.DelProject(iProjectID);
	                    //更新DataGridView中的内容，即
	                    BLL.ProjectsBLL.FillProjects();
	                    RefreshProjects();
	                   
						return;
                	}                    
                	catch(Exception e1)
                    {
                		string s1 = e1.Message;
                        MessageBox.Show("删除错误，可能是其他单据使用了此项目。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                
			}
		}
		
		
		void ButtonAddMoneyTypeClick(object sender, EventArgs e)
		{
			//新收支项
			FormMoneyType tF = new FormMoneyType();
			tF.Text="收支信息-新增";						
			tF.ShowDialog();
			RefreshMoneyType();
		}
		
		
		void RefreshMoneyType()
		{
			ds1 = BLL.MoneyTypeBLL.GetAllMoneyType();
			dataGridViewMoneyType.DataSource = null;
			dataGridViewMoneyType.DataSource = ds1.Tables[0];
			//dataGridViewProjects.Refresh();
		}
		void DataGridViewMoneyTypeCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0)) 
			{
				if (dataGridViewMoneyType.Columns[e.ColumnIndex].Name.Equals("MoneyTypeClass"))
				{
					//这里是将列Column2的显示内容改成*号
					if(Convert.ToInt32(e.Value.ToString()) == 0)
					{
						e.Value = "收入项";
					}
					else
					{
						e.Value = "支出项";
					}
				}
			}
		}
		void ButtonModifyMonetTypeClick(object sender, EventArgs e)
		{
			//修改
			if(dataGridViewMoneyType.CurrentRow != null)
			{
				FormMoneyType tF = new FormMoneyType();
				tF.i_MoneyTypeID = Convert.ToInt32(dataGridViewMoneyType.CurrentRow.Cells[0].Value.ToString());
				tF.Text="收支信息-修改";						
				tF.ShowDialog();
			}
			else
			{
				MessageBox.Show("请选择要修改的收支项目！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			RefreshMoneyType();
		}
		void ButtonDelMoneyTypeClick(object sender, EventArgs e)
		{
			if(dataGridViewMoneyType.CurrentRow != null)
			{
				DialogResult result;
				int iMoneyTypeID = Convert.ToInt32(dataGridViewMoneyType.CurrentRow.Cells[0].Value.ToString());
				string sMoneyTypeName = dataGridViewMoneyType.CurrentRow.Cells[1].Value.ToString();

                result = MessageBox.Show("您确认删除当前选中的【" + sMoneyTypeName + "】收支项目吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                	try
                	{
	                    // 删除指定的项目
	                    BLL.MoneyTypeBLL.DelMoneyType(iMoneyTypeID);
	                    //更新DataGridView中的内容，即
	                    BLL.MoneyTypeBLL.FillMoneyType();
	                    RefreshMoneyType();
	                   
						return;
                	}                    
                	catch(Exception e1)
                    {
                		string s1 = e1.Message;
                        MessageBox.Show("删除错误，可能是其他单据使用了此收支项目。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                
			}
			
		}
		
		
		void ButtonAddWareHouseClick(object sender, EventArgs e)
		{
			//新仓库
			FormWareHouse tF = new FormWareHouse();
			tF.Text="仓库信息-新增";						
			tF.ShowDialog();
			RefreshWareHouse();
		}
		
		void RefreshWareHouse()
		{
			ds3 = BLL.WareHouseBLL.GetAllWareHouse();
			dataGridViewWareHouse.DataSource = null;
			dataGridViewWareHouse.DataSource = ds3.Tables[0];
			//dataGridViewProjects.Refresh();
		}
		
		
		void ButtonModifyWareHouseClick(object sender, EventArgs e)
		{
			//修改
			if(dataGridViewWareHouse.CurrentRow != null)
			{
				FormWareHouse tF = new FormWareHouse();
				tF.i_WareHouseID = Convert.ToInt32(dataGridViewWareHouse.CurrentRow.Cells[0].Value.ToString());
				tF.Text="仓库信息-修改";						
				tF.ShowDialog();
			}
			else
			{
				MessageBox.Show("请选择要修改的收支项目！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			RefreshWareHouse();
		}
		
		
		void ButtonDelWareHouseClick(object sender, EventArgs e)
		{
			if(dataGridViewWareHouse.CurrentRow != null)
			{
				DialogResult result;
				int iWareHouseID = Convert.ToInt32(dataGridViewWareHouse.CurrentRow.Cells[0].Value.ToString());
				string sWareHouseName = dataGridViewWareHouse.CurrentRow.Cells[1].Value.ToString();

                result = MessageBox.Show("您确认删除当前选中的【" + sWareHouseName + "】仓库吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                	try
                	{
	                    // 删除指定的项目
	                    BLL.WareHouseBLL.DelWareHouse(iWareHouseID);
	                    //更新DataGridView中的内容，即
	                    BLL.WareHouseBLL.FillWareHouse();
	                    RefreshWareHouse();
	                   
						return;
                	}                    
                	catch(Exception e1)
                    {
                		string s1 = e1.Message;
                        MessageBox.Show("删除错误，可能是其他单据使用了此仓库。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
			}
			
			
			
		}
		void ButtonOPtionsClick(object sender, EventArgs e)
		{
			ShowPanel(4);
		}
		
		
		void ButtonDelOptionsClick(object sender, EventArgs e)
		{
			//删除
			if(dataGridViewOptions.CurrentRow != null)
			{
				DialogResult result;
				int iOptionsID = Convert.ToInt32(dataGridViewOptions.CurrentRow.Cells[0].Value.ToString());
				string sOptionsKey = dataGridViewOptions.CurrentRow.Cells[1].Value.ToString();

                result = MessageBox.Show("您确认删除当前选中的【" + sOptionsKey + "】选项Key吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                	try
                	{
	                    // 删除指定的项目
	                    BLL.ProgOptionsBLL.DelOptions(iOptionsID);
	                    //更新DataGridView中的内容，即	                    
	                    RefreshOptions();
	                   
						return;
                	}                    
                	catch(Exception e1)
                    {
                		string s1 = e1.Message;
                        MessageBox.Show("删除错误，可能是其他单据使用了此选项Key。", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
			}
		}
		
		
		void RefreshOptions()
		{
			ds4.Clear();
			ds4 = BLL.ProgOptionsBLL.GetAllOptions();
			dataGridViewOptions.DataSource = null;
			dataGridViewOptions.DataSource = ds4.Tables[0];
		}
		
		void RefreshUsers()
		{
			ds5.Clear();
			ds5 = BLL.UserBLL.GetAllUsers();
			dataGridViewUsers.DataSource = null;
			dataGridViewUsers.DataSource = ds5.Tables[0];
		}
		
		void RefreshCompanies()
		{
			ds6.Clear();
			ds6 = BLL.CompanyBLL.GetCompanyAll();
			dataGridViewCompanies.DataSource = null;
			dataGridViewCompanies.DataSource = ds6.Tables[0];
		}
		
		void ButtonAddOptionsClick(object sender, EventArgs e)
		{
			//新参数
			FormProgOption tF = new FormProgOption();
			tF.Text="系统参数-新增";						
			tF.ShowDialog();
			RefreshOptions();
		}
		
		void ButtonModifyOptionsClick(object sender, EventArgs e)
		{
			//修改
			if(dataGridViewWareHouse.CurrentRow != null)
			{
				FormProgOption tF = new FormProgOption();
				tF.i_OptionsID = Convert.ToInt32(dataGridViewOptions.CurrentRow.Cells[0].Value.ToString());
				tF.Text="系统参数-修改";						
				tF.ShowDialog();
			}
			else
			{
				MessageBox.Show("请选择要修改的系统参数！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			RefreshOptions();
		}
		void ButtonUserClick(object sender, EventArgs e)
		{
			ShowPanel(5);
		}
		void ButtonDelUserClick(object sender, EventArgs e)
		{
			//删除
			if(dataGridViewUsers.CurrentRow != null)
			{
				DialogResult result;
				int iUserID = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells[0].Value.ToString());
				string sUserName = dataGridViewUsers.CurrentRow.Cells[1].Value.ToString();

                result = MessageBox.Show("您确认删除当前选中的【" + sUserName + "】用户吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                	try
                	{
	                    // 删除指定的用户
	                    BLL.UserBLL.DelUsers(iUserID);
	                    //更新DataGridView中的内容，即	                    
	                    RefreshUsers();
	                   
						return;
                	}                    
                	catch(Exception e1)
                    {
                        MessageBox.Show(e1.Message);
                        return;
                    }

                }
			}
		}
		
		void ButtonAddUserClick(object sender, EventArgs e)
		{
			//新用户
			FormUser tF = new FormUser();
			tF.Text="用户管理-新增";						
			tF.ShowDialog();
			RefreshUsers();
		}
		void ButtonModifyUserClick(object sender, EventArgs e)
		{
			//修改
			if(dataGridViewUsers.CurrentRow != null)
			{
				FormUser tF = new FormUser();
				tF.iUserID = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells[0].Value.ToString());
				tF.Text="用户管理-修改";						
				tF.ShowDialog();
			}
			else
			{
				MessageBox.Show("请选择要修改的用户！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			RefreshUsers();
		}
		void ButtonCompanyClick(object sender, EventArgs e)
		{
			ShowPanel(6);
		}

		void ButtonNewCompanyClick(object sender, EventArgs e)
		{
			//新单位
			FormCompany tF = new FormCompany();
			tF.Text="相关单位-新增";						
			tF.ShowDialog();
			RefreshCompanies();
		}
		void DataGridViewCompaniesCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if(2 == e.ColumnIndex)
			{
				switch(Convert.ToInt32(e.Value))
				{
					case 0:
						e.Value = "客户";
						break;
					case 1:
						e.Value = "供应商";
						break;
					case 2:
						e.Value = "班组";
						break;
					case 3:
						e.Value = "租赁商";
						break;
				}

			}
		}
		void ButtonModifyCompanyClick(object sender, EventArgs e)
		{
			//修改
			if(dataGridViewCompanies.CurrentRow != null)
			{
				FormCompany tF = new FormCompany();
				tF.i_CompanyID = Convert.ToInt32(dataGridViewCompanies.CurrentRow.Cells[0].Value.ToString());
				tF.Text="相关单位-修改";						
				tF.ShowDialog();
			}
			else
			{
				MessageBox.Show("请选择要修改的单位！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			RefreshCompanies();
		}
		void ButtonDelCompanyClick(object sender, EventArgs e)
		{
			//删除
			if(dataGridViewCompanies.CurrentRow != null)
			{
				DialogResult result;
				int iCompanyID = Convert.ToInt32(dataGridViewCompanies.CurrentRow.Cells[0].Value.ToString());
				string sCompanyName = dataGridViewCompanies.CurrentRow.Cells[1].Value.ToString();

                result = MessageBox.Show("您确认删除当前选中的【" + sCompanyName + "】单位吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                	try
                	{
	                    // 删除指定的用户
	                    BLL.CompanyBLL.DelCompany(iCompanyID);
	                    //更新DataGridView中的内容，即	                    
	                    RefreshCompanies();	                   
						return;
                	}                    
                	catch(Exception e1)
                    {
                        MessageBox.Show(e1.Message);
                        return;
                    }

                }
			}
		}
		
		
	}
}
