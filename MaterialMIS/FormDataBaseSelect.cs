/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-18
 * 时间: 12:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Configuration;
using DomainModel;


namespace MaterialMIS
{
	
	
	/// <summary>
	/// Description of FormDataBaseSelect.
	/// </summary>
	public partial class FormDataBaseSelect : Form
	{
		public FormDataBaseSelect()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ButtonEnterClick(object sender, EventArgs e)
		{
			if(comboBox1.SelectedIndex >= 0)
			{
				ComboboxItem tItem = new ComboboxItem();
				tItem.Key = ((ComboboxItem)(comboBox1.Items[comboBox1.SelectedIndex])).Key;
				tItem.Value = ((ComboboxItem)(comboBox1.Items[comboBox1.SelectedIndex])).Value;
				//更新当前连接串
				UpdateConn(tItem);
				
				//检查是否没有用户，没有则创建一个admin
				//MessageBox.Show("检查用户前");
				if(BLL.UserBLL.GetUserCount() == 0)
				{
					Users tUser = new Users();
					tUser.UserName = "admin";
					tUser.UserDisplayName = "系统管理员";
					tUser.UserPassword = "admin";
					BLL.UserBLL.AddUsers(tUser);
				}
				//MessageBox.Show("登录验证前");
				//登录验证
				if(!BLL.UserBLL.UserLoginOK(baseTextBox1.Text,baseTextBox2.Text))
				{
					return;
				}
				else
				{
					this.DialogResult = DialogResult.OK;
				}
				

			}
		}
		void UpdateConn(ComboboxItem tItem)
		{
			Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			config.AppSettings.Settings["SQLiteConnectionString"].Value = tItem.Value.ToString();
			//一定要记得保存，写不带参数的config.Save()也可以
			config.Save(ConfigurationSaveMode.Modified);
			
			XmlDocument doc=new XmlDocument();
			//获得配置文件的全路径
			string strFileName = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
			doc.Load(strFileName);
			//找出名称为“add”的所有元素
			XmlNodeList nodes=doc.GetElementsByTagName("property");
			for(int i=0;i<nodes.Count;i++)　　  
			{
				//获得将当前元素的key属性
				XmlAttribute att=nodes[i].Attributes["name"];
				//根据元素的第一个属性来判断当前的元素是不是目标元素
				if (att.Value=="connection.connection_string")
				{
					//对目标元素中的第二个属性赋值
					nodes[i].InnerText = tItem.Value.ToString();
					break;
				}
			}
			//保存上面的修改
			doc.Save(strFileName);	
			//刷新，否则程序读取的还是之前的值（可能已装入内存）
			System.Configuration.ConfigurationManager.RefreshSection("appSettings");			

		}
		
		void ButtonAddClick(object sender, EventArgs e)
		{
			string sFileName="";
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "数据库文件|*.db";
			if (dialog .ShowDialog() == DialogResult.OK)
			{
				sFileName = dialog.FileName;
			}
			else
			{
				return;
			}


			//Key用DataBase##样式
			Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			int iMaxDatabase = 0;
			foreach (string key in ConfigurationManager.AppSettings)
			{
				if(key.Contains("DataBase"))
				{
					int iTemp = Convert.ToInt32(key.Substring(8,2));
					if(iTemp > iMaxDatabase)
					{
						iMaxDatabase = iTemp;
					}
				}
			}
			iMaxDatabase++;
			string sNewKey = "DataBase" + iMaxDatabase.ToString("00");
			config.AppSettings.Settings.Add(sNewKey,"Data Source = " + sFileName);
			//一定要记得保存，写不带参数的config.Save()也可以
			config.Save(ConfigurationSaveMode.Modified);
			//刷新，否则程序读取的还是之前的值（可能已装入内存）
			System.Configuration.ConfigurationManager.RefreshSection("appSettings");
			//填充下拉框
			FillComboDataBase(comboBox1);
		}
		void FormDataBaseSelectLoad(object sender, EventArgs e)
		{
			//填充下拉框
			FillComboDataBase(comboBox1);
		}
		
		void FillComboDataBase(ComboBox tComboBox)
		{
			tComboBox.Items.Clear();
			tComboBox.Text = "";
			Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			foreach (string key in ConfigurationManager.AppSettings)
			{
				if(key.Contains("DataBase"))
				{
					ComboboxItem tItem = new ComboboxItem();
					tItem.Key = key;
					tItem.Value = ConfigurationManager.AppSettings[key];
					tComboBox.Items.Add(tItem);
				}
			}
		}
		void ButtonRemoveClick(object sender, EventArgs e)
		{
			if(comboBox1.SelectedIndex >= 0)
			{
				ComboboxItem tItem = new ComboboxItem();
				tItem.Key = ((ComboboxItem)(comboBox1.Items[comboBox1.SelectedIndex])).Key;
				tItem.Value = ((ComboboxItem)(comboBox1.Items[comboBox1.SelectedIndex])).Value;
				//删除
				Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				config.AppSettings.Settings.Remove(tItem.Key);
				//一定要记得保存，写不带参数的config.Save()也可以
				config.Save(ConfigurationSaveMode.Modified);
				//刷新，否则程序读取的还是之前的值（可能已装入内存）
				System.Configuration.ConfigurationManager.RefreshSection("appSettings");
				//填充下拉框
				FillComboDataBase(comboBox1);


			}
		}
		void Button1Click(object sender, EventArgs e)
		{
		Random random = new Random();

			for (int i = 0; i < 100; i++)
			{
				Class1.Beep(random.Next(10000), 100);
				Application.DoEvents();
			}
		}
		
	}
	
	public class ComboboxItem
	{
		public string Key { get; set; }
		public object Value { get; set; }
		public override string ToString()
		{
			return Key + " ["+ Value.ToString()+"]";
		}

	}
	
	

}
