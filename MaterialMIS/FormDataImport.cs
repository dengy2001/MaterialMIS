/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-20
 * 时间: 11:28
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using DomainModel;
using BLL;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormDataImport.
	/// </summary>
	public partial class FormDataImport : Form
	{
		private DataSet CurDs = new DataSet();
		private DataSet CurPageDs = new DataSet();
		
		private int pageSize = 0;     //每页显示行数
		private int nMax = 0;         //总记录数
		private int pageCount = 0;    //页数＝总记录数/每页显示行数
		private int pageCurrent = 0;   //当前页号，从1开始
//		private int nCurrent = 0;      //当前记录行
//		private int nCurrenPage = 0;	//当前页
		private int nGetMaxPages = 50;	//最多取的页数
		private int nOffsetPageStart = 0;	//偏移起始页码,从0开始
		
		

		
		public FormDataImport()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ButtonImportClick(object sender, EventArgs e)
		{
			
			//开始数据导入
			DataSet tds;
			string fName ="";
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Excel2003文件|*.xls|Excel2007文件|*.xlsx";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				fName = openFileDialog.FileName;
			}
			else
			{
				return;
			}
			string strCon;
			
			FileInfo file = new FileInfo(fName);
			if (!file.Exists) { throw new Exception("文件不存在"); }
			string extension = file.Extension;
			switch (extension)
			{
				case ".xls":
					strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
					break;
				case ".xlsx":
					strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
					strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
					break;
				default:
					strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
					break;
			}
			
			
			OleDbConnection myConn = new OleDbConnection(strCon);
			myConn.Open();
			DataTable dt = myConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
			string[] sheets = new string[dt.Rows.Count];
			tds = new DataSet();
			
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				sheets[i] = dt.Rows[i][2].ToString().Trim();
				OleDbDataAdapter myDa = new OleDbDataAdapter("SELECT * FROM [" + sheets[i] + "]@", myConn);
				try
				{
					// 填充数据
					myDa.Fill(tds);
				}
				catch (Exception ex)
				{
					MessageBox.Show("读取EXCEl出读取文件出错" + ex.Message);
					return;
				}
				finally
				{
					myConn.Close();
				}
				
			}
			
			if(tds.Tables[0].Rows.Count > 0)
			{
				BLL.ComBLL.FillDataTable2Table(tds.Tables[0],"ImportRecord");
				MessageBox.Show("数据导入完成！");
			}
			else
			{
				MessageBox.Show("没有数据导入！");
			}
			
		}
		void FormDataImportLoad(object sender, EventArgs e)
		{
			//
			
            
			GetData();
			
		}
		
		//
		void GetData()
		{
			nMax = BLL.ImportRecordBLL.GetImportRecordCount();
				//
			pageSize = 20;
			OnPageChange();
			toolStripLabel5.Text = "总记录数："+nMax.ToString() + "条";
			CurDs = BLL.ImportRecordBLL.GetImportRecords(nOffsetPageStart * pageSize,pageSize*nGetMaxPages);
			RefreshData();
			
		}
		
		private void RefreshData()
		{
			//如果不分页，全部数据都取出来
			if(pageSize == 0)
			{
				//无分页
				CurDs = BLL.ImportRecordBLL.GetAllImportRecord();
				CurPageDs = CurDs;
			}
			else
			{
				//有分页,
				if((pageCurrent - nOffsetPageStart) > 0)
				{
					if((pageCurrent - nOffsetPageStart) <= nGetMaxPages)
					{
						//在取出的记录中
						CurPageDs = CurDs.Clone();
						for (int i = pageSize*(pageCurrent-nOffsetPageStart-1); i < pageSize * (pageCurrent-nOffsetPageStart) ; i++)
						{
							if(i < CurDs.Tables[0].Rows.Count)
							{
								CurPageDs.Tables[0].ImportRow(CurDs.Tables[0].Rows[i]);
							}
						}
					}
					else
					{
						//超过取的最大记录
						while((pageCurrent-nOffsetPageStart) > nGetMaxPages)
						{
							nOffsetPageStart += nGetMaxPages;
						}
						CurDs = BLL.ImportRecordBLL.GetImportRecords(nOffsetPageStart * pageSize,pageSize*nGetMaxPages);
						CurPageDs = CurDs.Clone();
						for (int i = pageSize*(pageCurrent-nOffsetPageStart-1); i < pageSize * (pageCurrent-nOffsetPageStart) ; i++)
						{
							if(i < CurDs.Tables[0].Rows.Count)
							{
								CurPageDs.Tables[0].ImportRow(CurDs.Tables[0].Rows[i]);
							}
						}
					}
				}
				else
				{
					//在更前面的记录中
					while(pageCurrent <= nOffsetPageStart)
					{
						nOffsetPageStart -= nGetMaxPages;
					}
					CurDs = BLL.ImportRecordBLL.GetImportRecords(nOffsetPageStart * pageSize,pageSize*nGetMaxPages);
					CurPageDs = CurDs.Clone();
					for (int i = pageSize*(pageCurrent-nOffsetPageStart-1); i < pageSize * (pageCurrent-nOffsetPageStart) ; i++)
					{
						if(i < CurDs.Tables[0].Rows.Count)
							{
								CurPageDs.Tables[0].ImportRow(CurDs.Tables[0].Rows[i]);
							}
					}
				}
				
			}
			
			dataGridView1.DataSource = CurPageDs.Tables[0];
		}
		
		private void OnPageChange()
		{
			//根据记录总数，每页数据条数，当前页数确定按钮的允许状态及Lable显示
			if(pageSize == 0)
			{
				pageCount = 1;
				//不限每页数,最多1页
				bindingNavigatorMoveFirstItem.Enabled = true;
				if(pageCurrent == 0)
				{
					pageCurrent = 1;
				}
				bindingNavigatorMovePreviousItem.Enabled = false;
				bindingNavigatorMoveNextItem.Enabled = false;
				bindingNavigatorMoveLastItem.Enabled = true;
				toolStripLabel1.Text = "第" + pageCurrent.ToString() + "页 共" + pageCount.ToString() + "页";
			}
			else
			{
				pageCount = nMax / pageSize;
				if(nMax % pageSize != 0)
				{
					pageCount++;
				}
				if(pageCurrent == 0 && nMax > 0)
				{
					pageCurrent = 1;
				}
				bindingNavigatorMoveFirstItem.Enabled = true;
				if(pageCurrent > 1)
				{
					bindingNavigatorMovePreviousItem.Enabled = true;
				}
				else
				{
					if(pageCurrent == 0)
					{
						pageCurrent = 1;
					}
					bindingNavigatorMovePreviousItem.Enabled = false;
				}
				if(pageCurrent < pageCount)
				{
					bindingNavigatorMoveNextItem.Enabled = true;
				}
				else
				{
					bindingNavigatorMoveNextItem.Enabled = false;
				}
				bindingNavigatorMoveLastItem.Enabled = true;
				toolStripLabel1.Text = "第" + pageCurrent.ToString() + "页 共" + pageCount.ToString() + "页";
			}
		}
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			//跳转到指定页
			if(toolStripTextBox1.Text != "")
			{
				pageCurrent = Convert.ToInt32(toolStripTextBox1.Text);
				if(pageCurrent > pageCount)
				{
					pageCurrent = pageCount;
				}
				if(pageCurrent == 0)
				{
					pageCurrent = 1;
				}
				
				RefreshData();
				OnPageChange();
			}
		}
		void BindingNavigatorMoveFirstItemClick(object sender, EventArgs e)
		{
			//到第一页
			pageCurrent = 1;
			RefreshData();
			OnPageChange();
		}
		void BindingNavigatorMovePreviousItemClick(object sender, EventArgs e)
		{
			//到上一页
			if(pageCurrent > 1)
			{
				pageCurrent--;
			}
			RefreshData();
			OnPageChange();
		}
		void BindingNavigatorMoveNextItemClick(object sender, EventArgs e)
		{
			//到下一页
			if(pageCurrent < pageCount)
			{
				pageCurrent++;
			}
			RefreshData();
			OnPageChange();
		}
		void BindingNavigatorMoveLastItemClick(object sender, EventArgs e)
		{
			//到最后一页
			pageCurrent = pageCount;
			RefreshData();
			OnPageChange();
		}
		void ToolStripTextBox1KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46)) 
            { 
                e.Handled = true; 
            }
		}
		
		
		
	}
}
