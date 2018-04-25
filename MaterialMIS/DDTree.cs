/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-04-30
 * 时间: 13:36
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

namespace MaterialMIS
{
	/// <summary>
	/// Description of DDTree.
	/// </summary>
	public partial class DDTree : UserControl
	{
		private TextBox t_TextBox;
		public TreeView t_TreeView;
		
		
		public TextBox tTextBox
		{
			get
			{
				return t_TextBox;
			}
			set
			{
				t_TextBox = value;
			}
		}		
			
		
		public DDTree()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void PictureBox1MouseEnter(object sender, EventArgs e)
		{
			//换图片
			ResourceManager rm = new ResourceManager ( "MaterialMIS.Resource1" , Assembly.GetExecutingAssembly ( ) ) ;
			pictureBox1.BackgroundImage = ( Image ) rm.GetObject("下箭头-2");
		}
		void PictureBox1MouseLeave(object sender, EventArgs e)
		{
			ResourceManager rm = new ResourceManager ( "MaterialMIS.Resource1" , Assembly.GetExecutingAssembly ( ) ) ;
			pictureBox1.BackgroundImage = ( Image ) rm.GetObject("下箭头-1");

		}
		void TreeView1MouseLeave(object sender, EventArgs e)
		{
			treeView1.Visible = false;
			this.Height = 28;
		}
		void PictureBox1Click(object sender, EventArgs e)
		{
			treeView1.Visible = true;
			this.Height = 193;
		}
		void DDTreeLoad(object sender, EventArgs e)
		{
			tTextBox = textBox1;
			t_TreeView =treeView1;
		}
		void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
		{
			//将当前选择的节点数据暂存
			//MessageBox.Show(e.Node.Text);
			textBox1.Tag = e.Node.Tag;
			textBox1.Text = e.Node.Text;
			treeView1.Visible = false;
		}
	}
}
