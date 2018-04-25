/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-02
 * 时间: 12:32
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
	/// Description of FormWareHouse.
	/// </summary>
	public partial class FormWareHouse : Form
	{
		
		public int i_WareHouseID;
		
		public FormWareHouse()
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
		
		void FormWareHouseLoad(object sender, EventArgs e)
		{
			//如果是修改，把原来的数据填写进去
			if(this.Text == "仓库信息-修改")
			{
				textBoxWareHouseID.Text = i_WareHouseID.ToString();
				WareHouse tP = BLL.WareHouseBLL.GetWareHouse(i_WareHouseID);
				textBoxWareHouseName.Text = tP.WareHouseName;
				
				this.ActiveControl = textBoxWareHouseName;
			}
			else
			{
				this.ActiveControl = textBoxWareHouseName;
			}	
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			//根据是修改还是新增确定操作
			if(this.Text == "仓库信息-新增")
			{
				//确定关闭窗口，将数据保存到数据库中	
				
				WareHouse t1 = new WareHouse();
				t1.WareHouseName = textBoxWareHouseName.Text.Trim();				
				BLL.WareHouseBLL.AddWareHouse(t1);
				this.Close();
			}
			else
			{
				//确定关闭窗口，将数据修改后保存到数据库中							
				WareHouse t1 = new WareHouse();
				t1.WareHouseID = i_WareHouseID;
				t1.WareHouseName = textBoxWareHouseName.Text.Trim();
				
				BLL.WareHouseBLL.UpdateWareHouse(t1);
				this.Close();
			}
			BLL.WareHouseBLL.FillWareHouse();
		}
		
		
	}
}
