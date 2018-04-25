/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-07-14
 * 时间: 14:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormOutBill
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private MaterialMIS.WaterTextBox waterTextBoxRemark;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBoxOutAmt;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TextBox textBoxNumber;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePickerRKDate;
		private System.Windows.Forms.ComboBox comboBoxWareHouseID;
		private System.Windows.Forms.ComboBox comboBoxProjectID;
		private System.Windows.Forms.ComboBox comboBoxCompanyID;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxUseMan;
		private System.Windows.Forms.TextBox textBoxOutMan;
		private System.Windows.Forms.ComboBox comboBoxOutStockType;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label12;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.waterTextBoxRemark = new MaterialMIS.WaterTextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxOutAmt = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.comboBoxOutStockType = new System.Windows.Forms.ComboBox();
			this.textBoxNumber = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxID = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePickerRKDate = new System.Windows.Forms.DateTimePicker();
			this.comboBoxWareHouseID = new System.Windows.Forms.ComboBox();
			this.comboBoxProjectID = new System.Windows.Forms.ComboBox();
			this.comboBoxCompanyID = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxUseMan = new System.Windows.Forms.TextBox();
			this.textBoxOutMan = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// waterTextBoxRemark
			// 
			this.waterTextBoxRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.waterTextBoxRemark.Location = new System.Drawing.Point(437, 313);
			this.waterTextBoxRemark.Name = "waterTextBoxRemark";
			this.waterTextBoxRemark.Size = new System.Drawing.Size(370, 21);
			this.waterTextBoxRemark.TabIndex = 4;
			this.waterTextBoxRemark.WaterText = "在此输入相关信息可辅助查询";
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(615, 396);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 6;
			this.buttonSave.Text = "保存";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(696, 396);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 7;
			this.buttonClose.Text = "关闭";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 6;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
			this.tableLayoutPanel1.Controls.Add(this.label9, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBoxOutAmt, 5, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 337);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(795, 44);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label9.Location = new System.Drawing.Point(472, 10);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(107, 23);
			this.label9.TabIndex = 0;
			this.label9.Text = "本次出库金额：";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label9.Click += new System.EventHandler(this.Label9Click);
			// 
			// textBoxOutAmt
			// 
			this.textBoxOutAmt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxOutAmt.Location = new System.Drawing.Point(585, 11);
			this.textBoxOutAmt.Name = "textBoxOutAmt";
			this.textBoxOutAmt.ReadOnly = true;
			this.textBoxOutAmt.Size = new System.Drawing.Size(163, 21);
			this.textBoxOutAmt.TabIndex = 2;
			this.textBoxOutAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(13, 12);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.comboBoxOutStockType);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxNumber);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxID);
			this.splitContainer1.Panel1.Controls.Add(this.label8);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.dateTimePickerRKDate);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxWareHouseID);
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxProjectID);
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxCompanyID);
			this.splitContainer1.Panel2.Controls.Add(this.label10);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.label11);
			this.splitContainer1.Size = new System.Drawing.Size(794, 100);
			this.splitContainer1.SplitterDistance = 398;
			this.splitContainer1.TabIndex = 0;
			// 
			// comboBoxOutStockType
			// 
			this.comboBoxOutStockType.FormattingEnabled = true;
			this.comboBoxOutStockType.Items.AddRange(new object[] {
			"领料出库",
			"领料退货",
			"物资借出",
			"物资归还",
			"报损出库",
			"报损退货"});
			this.comboBoxOutStockType.Location = new System.Drawing.Point(289, 69);
			this.comboBoxOutStockType.Name = "comboBoxOutStockType";
			this.comboBoxOutStockType.Size = new System.Drawing.Size(106, 20);
			this.comboBoxOutStockType.TabIndex = 3;
			this.comboBoxOutStockType.Text = "领料出库";
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNumber.Location = new System.Drawing.Point(98, 39);
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.ReadOnly = true;
			this.textBoxNumber.Size = new System.Drawing.Size(199, 21);
			this.textBoxNumber.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 38);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "出库单号：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(14, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "出库单ID：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxID
			// 
			this.textBoxID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxID.Location = new System.Drawing.Point(98, 10);
			this.textBoxID.Name = "textBoxID";
			this.textBoxID.ReadOnly = true;
			this.textBoxID.Size = new System.Drawing.Size(199, 21);
			this.textBoxID.TabIndex = 0;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(228, 68);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(69, 23);
			this.label8.TabIndex = 0;
			this.label8.Text = "出库日期：";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "出库日期：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerRKDate
			// 
			this.dateTimePickerRKDate.Location = new System.Drawing.Point(98, 68);
			this.dateTimePickerRKDate.Name = "dateTimePickerRKDate";
			this.dateTimePickerRKDate.Size = new System.Drawing.Size(124, 21);
			this.dateTimePickerRKDate.TabIndex = 2;
			// 
			// comboBoxWareHouseID
			// 
			this.comboBoxWareHouseID.FormattingEnabled = true;
			this.comboBoxWareHouseID.Location = new System.Drawing.Point(95, 10);
			this.comboBoxWareHouseID.Name = "comboBoxWareHouseID";
			this.comboBoxWareHouseID.Size = new System.Drawing.Size(204, 20);
			this.comboBoxWareHouseID.TabIndex = 1;
			this.comboBoxWareHouseID.SelectedIndexChanged += new System.EventHandler(this.ComboBoxWareHouseIDSelectedIndexChanged);
			// 
			// comboBoxProjectID
			// 
			this.comboBoxProjectID.FormattingEnabled = true;
			this.comboBoxProjectID.Location = new System.Drawing.Point(95, 39);
			this.comboBoxProjectID.Name = "comboBoxProjectID";
			this.comboBoxProjectID.Size = new System.Drawing.Size(204, 20);
			this.comboBoxProjectID.TabIndex = 1;
			this.comboBoxProjectID.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProjectIDSelectedIndexChanged);
			// 
			// comboBoxCompanyID
			// 
			this.comboBoxCompanyID.FormattingEnabled = true;
			this.comboBoxCompanyID.Location = new System.Drawing.Point(95, 68);
			this.comboBoxCompanyID.Name = "comboBoxCompanyID";
			this.comboBoxCompanyID.Size = new System.Drawing.Size(204, 20);
			this.comboBoxCompanyID.TabIndex = 1;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(10, 38);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(69, 23);
			this.label10.TabIndex = 0;
			this.label10.Text = "工程项目：";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "客户/班组：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(10, 9);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(69, 23);
			this.label11.TabIndex = 0;
			this.label11.Text = "出库仓库：";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridView1.Location = new System.Drawing.Point(13, 118);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(794, 191);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellLeave);
			this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridView1CurrentCellDirtyStateChanged);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.删除ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
			// 
			// 删除ToolStripMenuItem
			// 
			this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
			this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.删除ToolStripMenuItem.Text = "删除";
			this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItemClick);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(380, 312);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "说 明：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 312);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 23);
			this.label6.TabIndex = 9;
			this.label6.Text = "领用人：";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(197, 312);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(69, 23);
			this.label7.TabIndex = 9;
			this.label7.Text = "出库人：";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxUseMan
			// 
			this.textBoxUseMan.Location = new System.Drawing.Point(64, 313);
			this.textBoxUseMan.Name = "textBoxUseMan";
			this.textBoxUseMan.Size = new System.Drawing.Size(100, 21);
			this.textBoxUseMan.TabIndex = 2;
			// 
			// textBoxOutMan
			// 
			this.textBoxOutMan.Location = new System.Drawing.Point(250, 313);
			this.textBoxOutMan.Name = "textBoxOutMan";
			this.textBoxOutMan.Size = new System.Drawing.Size(100, 21);
			this.textBoxOutMan.TabIndex = 3;
			// 
			// label12
			// 
			this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label12.ForeColor = System.Drawing.Color.Red;
			this.label12.Location = new System.Drawing.Point(12, 396);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(579, 23);
			this.label12.TabIndex = 0;
			this.label12.Text = "在出库需要归还的物资时请务必选择物资借出，归还时选择物资归还，数量为负。领用人必须填对!";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label12.Click += new System.EventHandler(this.Label9Click);
			// 
			// FormOutBill
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(819, 431);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.textBoxOutMan);
			this.Controls.Add(this.textBoxUseMan);
			this.Controls.Add(this.waterTextBoxRemark);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Name = "FormOutBill";
			this.Text = "FormOutBill";
			this.Load += new System.EventHandler(this.FormOutBillLoad);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
