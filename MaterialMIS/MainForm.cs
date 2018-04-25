/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-04-28
 * 时间: 16:27
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLL;

namespace MaterialMIS
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public int tabpages = 0;
		public ToolStripStatusLabel toolStatus = new ToolStripStatusLabel();
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			//显示导航页
            FormGuide tForm = new FormGuide();
            tForm.TopLevel = false;  //设置为非顶级窗体
            tForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;//设置窗体为非边框样式
            tForm.Dock = System.Windows.Forms.DockStyle.Fill;//设置样式是否填充整个panel
            tabControlWithClose1.TabPages[tabpages++].Controls.Add(tForm);//添加窗体
            tForm.Show();//窗体运行
            
            //填充DataSet
            BLL.GoodsTypeBLL.FillGoodType();
            BLL.ProjectsBLL.FillProjects();
            toolStripStatusUserName.Text = UserBLL.CurUserDisplayName;
            toolStatus = toolStripStatusLabel1;
            //toolStatus.Text = "就绪";
            
            BLL.ComBLL.LStatus = toolStripStatusLabel1;

		}
		
		public void Control_Add(Form tform)
        {
            if (TabPageExist(tform))
            {
                return;
            }

            tform.TopLevel = false;  //设置为非顶级窗体
            tform.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;//设置窗体为非边框样式
            tform.Dock = System.Windows.Forms.DockStyle.Fill;//设置样式是否填充整个panel
            tabControlWithClose1.TabPages.Add(tform.Text);
            //tabControlWithClose1.TabPages[tabpages++].Controls.Add(tform);//添加窗体
            tabControlWithClose1.TabPages[tabControlWithClose1.TabPages.Count - 1].Controls.Add(tform);
            tform.Show();//窗体运行
            //int i = tabpages - 1;
            tabControlWithClose1.SelectedTab = tabControlWithClose1.TabPages[tabControlWithClose1.TabPages.Count - 1];
        }

        private bool TabPageExist(Form tform)
        {
            bool tflag = false;
            foreach (TabPage tb in tabControlWithClose1.TabPages)
            {
                if (tb.Text == tform.Text)
                {
                    tflag = true;
                    tabControlWithClose1.SelectedTab = tb;
                    break;
                }
            }
            return tflag;
        }

        //将已经关闭的页面tabpage也关闭
        public void Page_Close(Form tform)
        {
            foreach (TabPage tb in tabControlWithClose1.TabPages)
            {
                if (tb.Text == tform.Text)
                {
                    tb.Parent = null;
                    --tabpages;
                    break;
                }
            }
        }
        
        
		void 项目列表ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//设置系统参数界面
			FormOptions tForm = new FormOptions();
			Control_Add(tForm);
		}
		void 清空数据ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//清空数据
			FormClearData tForm = new FormClearData();
			tForm.ShowDialog();
		}
		
		void 供应商ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//供应商
			FormSupplier tForm = new FormSupplier();
			Control_Add(tForm);
		}
		

		void 批量数据导入ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormDataImport tForm = new FormDataImport();
			Control_Add(tForm);
		}
		void 材料类别ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormStock tForm = new FormStock();
			Control_Add(tForm);
		}
		void 材料入库单ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//入库单列表
			FormReceiptBillList tForm = new FormReceiptBillList();
			Control_Add(tForm);
		}
		void 采购入库ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//新入库
			FormReceiptBill tF = new FormReceiptBill();
			tF.Text="入库单-新增";						
			tF.ShowDialog();
		}
		void 一般材料ToolStripMenuItemClick(object sender, EventArgs e)
		{
	
		}
		void 钢材ToolStripMenuItemClick(object sender, EventArgs e)
		{
	
		}
		void 一般材料结算ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormMaterialConfirm tForm = new FormMaterialConfirm();				
			Control_Add(tForm);
		}
		void 一般材料历史结算查询MenuItemClick(object sender, EventArgs e)
		{
			FormHisJSD tForm = new FormHisJSD();				
			Control_Add(tForm);
		}

		void 材料库存1ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormStock1 tForm = new FormStock1();				
			Control_Add(tForm);
		}
		void 退出ToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void 材料出库单ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormOutBillList tForm = new FormOutBillList();
			Control_Add(tForm);
		}
		void 领用出库ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//新增出库单
			FormOutBill tF = new FormOutBill();
			tF.Text="出库单-新增";						
			tF.ShowDialog();
		}
		void 租赁设定ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormLeaseOption tForm = new FormLeaseOption();
			Control_Add(tForm);
		}
		void 租赁记录ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormLeaseRecord tForm = new FormLeaseRecord();
			Control_Add(tForm);
		}
		void 商混toolStripMenuItem3Click(object sender, EventArgs e)
		{
			//租赁金额算
			FormLeaseAccount tForm = new FormLeaseAccount();
			Control_Add(tForm);
		}
		void 一般材料历史结算查询ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormHisJSD tForm = new FormHisJSD();				
			Control_Add(tForm);
		}
		void 租赁材料历史结算查询ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormHisLeaseJSD tForm = new FormHisLeaseJSD();				
			Control_Add(tForm);
		}
		void 结算项管理ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormStatementMain tForm = new FormStatementMain();				
			Control_Add(tForm);
		}
		void 入库统计ToolStripMenuItemClick(object sender, EventArgs e)
		{
			//打印非零库存
			FastReport.Report report1 = new FastReport.Report();
			report1.Load("Reports\\IncomeSum.frx");

			DataSet FDataSet = new DataSet();
			DataTable table = new DataTable();
			table = BLL.GoodsTypeBLL.GetAllGoodsType().Tables[0].Copy();
			table.TableName = "GoodsType";			
			FDataSet.Tables.Add(table);
			
			table = BLL.ReceiptBLL.GetAllReceiptItems().Tables[0].Copy();
			table.TableName = "ReceiptItems";			
			FDataSet.Tables.Add(table);
			//report1.SetParameterValue("PeriodNo",sPeriodNo);
			DataRelation dsdr = new DataRelation("R1", FDataSet.Tables["GoodsType"].Columns["GoodsTypeID"], FDataSet.Tables["ReceiptItems"].Columns["GoodsTypeID"]);  
			FDataSet.Relations.Add(dsdr);  
			CalculateTotal(ref FDataSet);
			
			report1.RegisterData(FDataSet);
			report1.Show();
			report1.Dispose();
		}
		
		void CalculateTotal(ref DataSet ds)
		{
			DataTable dt1 = ds.Tables["GoodsType"];
			//取直接下级类别
			DataRow[] dRow1 = dt1.Select("GoodsTypePID is null OR GoodsTypePID = 0" );
			foreach(DataRow dr in dRow1)
			{
				//取下级类别金额
				CalTotalAmt(Convert.ToInt32(dr["GoodsTypeID"]),ref ds);
				//取下级类别数量
				CalTotalQty(Convert.ToInt32(dr["GoodsTypeID"]),ref ds);
			}
		}
		
		decimal CalTotalAmt(int i_GoodsTypeID,ref DataSet ds)
		{
			decimal dTotalAmt = 0;
			DataTable dt1 = ds.Tables["GoodsType"];
			DataTable dt2 = ds.Tables["ReceiptItems"];
			DataRow[] dRow2 = dt2.Select("GoodsTypeID = " + i_GoodsTypeID.ToString());
			//先取得本类别的金额
			foreach(DataRow dr in dRow2)
			{
				dTotalAmt += Convert.ToDecimal(dr["GoodsAmt"]);
			}
			//取直接下级类别
			DataRow[] dRow1 = dt1.Select("GoodsTypePID = " + i_GoodsTypeID.ToString());
			foreach(DataRow dr in dRow1)
			{
				//取下级类别金额
				dTotalAmt += CalTotalAmt(Convert.ToInt32(dr["GoodsTypeID"]),ref ds);
			}
			DataRow[] dRow3 = dt1.Select("GoodsTypeID = " + i_GoodsTypeID.ToString());
			//将汇总数据进行更新
			if(dRow3.Length>0)
			{
				DataRow dr = dRow3[0];
				dr["GoodsTypeAmt"] = dTotalAmt;
			}
			return dTotalAmt;
		}
		
		decimal CalTotalQty(int i_GoodsTypeID,ref DataSet ds)
		{
			decimal dTotalQty = 0;
			DataTable dt1 = ds.Tables["GoodsType"];
			DataTable dt2 = ds.Tables["ReceiptItems"];
			DataRow[] dRow2 = dt2.Select("GoodsTypeID = " + i_GoodsTypeID.ToString());
			//先取得本类别的金额
			foreach(DataRow dr in dRow2)
			{
				dTotalQty += Convert.ToDecimal(dr["GoodsQty"]);
			}
			//取直接下级类别
			DataRow[] dRow1 = dt1.Select("GoodsTypePID = " + i_GoodsTypeID.ToString());
			foreach(DataRow dr in dRow1)
			{
				//取下级类别金额
				dTotalQty += CalTotalQty(Convert.ToInt32(dr["GoodsTypeID"]),ref ds);
			}
			DataRow[] dRow3 = dt1.Select("GoodsTypeID = " + i_GoodsTypeID.ToString());
			//将汇总数据进行更新
			if(dRow3.Length>0)
			{
				DataRow dr = dRow3[0];
				dr["GoodsTypeQty"] = dTotalQty;
			}
			return dTotalQty;
		}
		void 购入记录查询ToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormInSearch tForm = new FormInSearch();
			Control_Add(tForm);
		}
		
		
	}
}
