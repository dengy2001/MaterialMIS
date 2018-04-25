/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-04-29
 * 时间: 16:36
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormGuide.
	/// </summary>
	public partial class FormGuide : Form
	{
		public FormGuide()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
/*
		void PictureBox1MouseEnter(object sender, EventArgs e)
		{
			//换图片
			ResourceManager rm = new ResourceManager ( "MaterialMIS.Resource1" , Assembly.GetExecutingAssembly ( ) ) ;
			pictureBox1.BackgroundImage = ( Image ) rm.GetObject("货品库存-2");
		}
		void PictureBox1MouseLeave(object sender, EventArgs e)
		{
			ResourceManager rm = new ResourceManager ( "MaterialMIS.Resource1" , Assembly.GetExecutingAssembly ( ) ) ;
			pictureBox1.BackgroundImage = ( Image ) rm.GetObject("货品库存-1");
		}
		void PictureBox1Click(object sender, EventArgs e)
		{
			//打开新的tabpage页
            FormStock tForm = new FormStock();
            //this.ParentForm.Controls["tabControl1"].Controls.Add(tbPage);
            ((MainForm)(this.ParentForm)).Control_Add(tForm);
		}
		void Button1Click(object sender, EventArgs e)
		{
//			MessageBox.Show("show dialog windows");
//			FormStock tform = new FormStock();
//			tform.ShowDialog();
			FormTemp tForm = new FormTemp();
            ((MainForm)(this.ParentForm)).Control_Add(tForm);
		}
		void PictureBoxWSMouseEnter(object sender, EventArgs e)
		{
			//换图片
			ResourceManager rm = new ResourceManager ( "MaterialMIS.Resource1" , Assembly.GetExecutingAssembly ( ) ) ;
			pictureBoxWS.BackgroundImage = ( Image ) rm.GetObject("未收款-2");
		}
		
		void PictureBoxWSMouseLeave(object sender, EventArgs e)
		{
			//换图片
			ResourceManager rm = new ResourceManager ( "MaterialMIS.Resource1" , Assembly.GetExecutingAssembly ( ) ) ;
			pictureBoxWS.BackgroundImage = ( Image ) rm.GetObject("未收款-1");
		}
		void PictureBoxWFMouseEnter(object sender, EventArgs e)
		{
			//换图片
			ResourceManager rm = new ResourceManager ( "MaterialMIS.Resource1" , Assembly.GetExecutingAssembly ( ) ) ;
			pictureBoxWF.BackgroundImage = ( Image ) rm.GetObject("未付款-2");
		}
		void PictureBoxWFMouseLeave(object sender, EventArgs e)
		{
			//换图片
			ResourceManager rm = new ResourceManager ( "MaterialMIS.Resource1" , Assembly.GetExecutingAssembly ( ) ) ;
			pictureBoxWF.BackgroundImage = ( Image ) rm.GetObject("未付款-1");
		}
		void PictureBoxJHMouseEnter(object sender, EventArgs e)
		{
			//换图片
			ResourceManager rm = new ResourceManager ( "MaterialMIS.Resource1" , Assembly.GetExecutingAssembly ( ) ) ;
			pictureBoxRK.BackgroundImage = ( Image ) rm.GetObject("入库单-2");
		}
		void PictureBoxJHMouseLeave(object sender, EventArgs e)
		{
			//换图片
			ResourceManager rm = new ResourceManager ( "MaterialMIS.Resource1" , Assembly.GetExecutingAssembly ( ) ) ;
			pictureBoxRK.BackgroundImage = ( Image ) rm.GetObject("入库单-1");
		}
		void PictureBoxXSMouseEnter(object sender, EventArgs e)
		{
			//换图片
			ResourceManager rm = new ResourceManager ( "MaterialMIS.Resource1" , Assembly.GetExecutingAssembly ( ) ) ;
			pictureBoxCK.BackgroundImage = ( Image ) rm.GetObject("出库单-2");
		}
		void PictureBoxXSMouseLeave(object sender, EventArgs e)
		{
			//换图片
			ResourceManager rm = new ResourceManager ( "MaterialMIS.Resource1" , Assembly.GetExecutingAssembly ( ) ) ;
			pictureBoxCK.BackgroundImage = ( Image ) rm.GetObject("出库单-1");
		}
		void PictureBoxWSClick(object sender, EventArgs e)
		{
			//打开未收款
			FormAccountIN tForm = new FormAccountIN();
            ((MainForm)(this.ParentForm)).Control_Add(tForm);
		}
		void PictureBoxWFClick(object sender, EventArgs e)
		{
			//打开未付款
			FormAccountOUT tForm = new FormAccountOUT();
            ((MainForm)(this.ParentForm)).Control_Add(tForm);
		}
		void PictureBoxRKClick(object sender, EventArgs e)
		{
			//入库单列表
			FormReceiptBillList tForm = new FormReceiptBillList();
			((MainForm)(this.ParentForm)).Control_Add(tForm);
		}
		void PictureBoxCKClick(object sender, EventArgs e)
		{
			//出库单列表
			FormOutBillList tForm = new FormOutBillList();
			((MainForm)(this.ParentForm)).Control_Add(tForm);
		}
		*/

	}
}
