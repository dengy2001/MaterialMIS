/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-17
 * 时间: 17:00
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialMIS
{
	/// <summary>
	/// Description of PageDataGridView.
	/// </summary>
	public partial class PageDataGridView : UserControl
	{
		private int _CurPage = 0;			//当前页
		private int _TotalRecord = 0;		//总记录数
		private int _PageRecords = 0;		//每页行数
		private int MaxPage = 0;			//最大行数
		
		public DataGridView Dv;				//当前的dataGridView控件
		

		[Browsable(true), Category("自定义"),Description("当前页")]
		public int CurPage
		{
			set{_CurPage = value;OnPageOptionsChange();}
			get{return _CurPage;}
		}
		
		[Browsable(true), Category("自定义"),Description("总记录数")]
		public int TotalRecord
		{
			set{_TotalRecord = value;OnPageOptionsChange();}
			get{return _TotalRecord;}
		}
		
		[Browsable(true), Category("自定义"),Description("总页数")]
		public int PageRecords
		{
			set{_PageRecords = value;OnPageOptionsChange();}
			get{return _PageRecords;}
		}
		public event EventHandler PageFirstButtonClick,PagePrevButtonClick,PageNextButtonClick,PageLastButtonClick,PageGoButtonClick;

		private void OnPageOptionsChange()
		{
			//根据记录总数，每页数据条数，当前页数确定按钮的允许状态及Lable显示			
				
			if(PageRecords == 0)
			{
				int MaxPage = 1;
				//不限每页数,最多1页
				this.buttonFirst.Enabled = true;
				if(CurPage == 0)
				{
					CurPage = 1;
				}				
				this.buttonPrev.Enabled = false;

				this.buttonNext.Enabled = false;
				this.buttonLast.Enabled = true;
				this.labelPage.Text = "共 " + TotalRecord.ToString() + " 条记录，第 " + CurPage.ToString() + " 页/共 " + MaxPage.ToString() + " 页";
			}
			else
			{
				MaxPage = TotalRecord / PageRecords;
				if(TotalRecord % PageRecords != 0)
				{
					MaxPage++;
				}
				this.buttonFirst.Enabled = true;
				if(CurPage > 1)
				{
					this.buttonPrev.Enabled = true;
				}
				else
				{
					if(CurPage == 0)
					{
						CurPage = 1;
					}
					this.buttonPrev.Enabled = false;
				}
				if(CurPage < MaxPage)
				{
					this.buttonNext.Enabled = true;
				}
				else
				{
					this.buttonNext.Enabled = false;
				}
				this.buttonLast.Enabled = true;
				this.labelPage.Text = "共 " + TotalRecord.ToString() + " 条记录，第 " + CurPage.ToString() + " 页/共 " + MaxPage.ToString() + " 页";
			}
		}
		
		public PageDataGridView()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ButtonFirstClick(object sender, EventArgs e)
		{
			//到首页
			CurPage = 1;
			if(PageFirstButtonClick != null)
			{				
				PageFirstButtonClick(this,e);
			}
		}
		void ButtonPrevClick(object sender, EventArgs e)
		{
			CurPage--;
			if(PagePrevButtonClick != null)
			{				
				PagePrevButtonClick(this,e);
			}
		}
		void ButtonNextClick(object sender, EventArgs e)
		{
			CurPage++;
			if(PageNextButtonClick != null)
			{				
				PageNextButtonClick(this,e);
			}
		}
		void ButtonLastClick(object sender, EventArgs e)
		{
			CurPage = MaxPage;
			if(PageLastButtonClick != null)
			{				
				PageLastButtonClick(this,e);
			}
		}
		void ButtonJumpClick(object sender, EventArgs e)
		{
			if(PageGoButtonClick != null)
			{				
				PageGoButtonClick(this,e);
			}
		}
		
		
	}
}
