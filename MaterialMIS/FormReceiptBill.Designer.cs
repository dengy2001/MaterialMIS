/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-13
 * 时间: 14:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormReceiptBill
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DateTimePicker dateTimePickerRKDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxID;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxNumber;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxPayDiscAmt;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxDisc;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonSave;
		private MaterialMIS.WaterTextBox waterTextBoxRemark;
		private System.Windows.Forms.ComboBox comboBoxWareHouseID;
		private System.Windows.Forms.ComboBox comboBoxProjectID;
		private System.Windows.Forms.ComboBox comboBoxCompanyID;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBoxPurcher;
		private System.Windows.Forms.TextBox textBoxReceriver;
		private System.Windows.Forms.ToolStripMenuItem 查询历史单价ToolStripMenuItem;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox comboBoxReceiptType;
		private System.Windows.Forms.Label label14;
		
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
			this.dateTimePickerRKDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxID = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxNumber = new System.Windows.Forms.TextBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.查询历史单价ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxDisc = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.comboBoxReceiptType = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.comboBoxWareHouseID = new System.Windows.Forms.ComboBox();
			this.comboBoxProjectID = new System.Windows.Forms.ComboBox();
			this.comboBoxCompanyID = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxPayDiscAmt = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.waterTextBoxRemark = new MaterialMIS.WaterTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.textBoxPurcher = new System.Windows.Forms.TextBox();
			this.textBoxReceriver = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dateTimePickerRKDate
			// 
			this.dateTimePickerRKDate.Location = new System.Drawing.Point(98, 68);
			this.dateTimePickerRKDate.Name = "dateTimePickerRKDate";
			this.dateTimePickerRKDate.Size = new System.Drawing.Size(124, 21);
			this.dateTimePickerRKDate.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "入库日期：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "供货商：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Click += new System.EventHandler(this.Label2Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(14, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "入库单ID：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxID
			// 
			this.textBoxID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxID.Location = new System.Drawing.Point(98, 10);
			this.textBoxID.Name = "textBoxID";
			this.textBoxID.ReadOnly = true;
			this.textBoxID.Size = new System.Drawing.Size(302, 21);
			this.textBoxID.TabIndex = 0;
			this.textBoxID.TabStop = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 38);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "入库单号：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNumber.Location = new System.Drawing.Point(98, 39);
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.ReadOnly = true;
			this.textBoxNumber.Size = new System.Drawing.Size(302, 21);
			this.textBoxNumber.TabIndex = 0;
			this.textBoxNumber.TabStop = false;
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridView1.Location = new System.Drawing.Point(12, 118);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(1001, 191);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellLeave);
			this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridView1CurrentCellDirtyStateChanged);
			this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView1DataError);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.查询历史单价ToolStripMenuItem,
			this.删除ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
			// 
			// 查询历史单价ToolStripMenuItem
			// 
			this.查询历史单价ToolStripMenuItem.Name = "查询历史单价ToolStripMenuItem";
			this.查询历史单价ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.查询历史单价ToolStripMenuItem.Text = "查询历史单价";
			this.查询历史单价ToolStripMenuItem.Click += new System.EventHandler(this.查询历史单价ToolStripMenuItemClick);
			// 
			// 删除ToolStripMenuItem
			// 
			this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
			this.删除ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.删除ToolStripMenuItem.Text = "删除";
			this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItemClick);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(367, 311);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "说 明：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label7.Location = new System.Drawing.Point(226, 10);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 23);
			this.label7.TabIndex = 0;
			this.label7.Text = "折扣率：";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDisc
			// 
			this.textBoxDisc.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxDisc.Location = new System.Drawing.Point(311, 11);
			this.textBoxDisc.Name = "textBoxDisc";
			this.textBoxDisc.Size = new System.Drawing.Size(153, 21);
			this.textBoxDisc.TabIndex = 1;
			this.textBoxDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxDisc.TextChanged += new System.EventHandler(this.TextBoxDiscTextChanged);
			this.textBoxDisc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDiscKeyPress);
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label9.Location = new System.Drawing.Point(472, 10);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(107, 23);
			this.label9.TabIndex = 0;
			this.label9.Text = "% ";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(10, 9);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(69, 23);
			this.label11.TabIndex = 0;
			this.label11.Text = "入库仓库：";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(12, 12);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.comboBoxReceiptType);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxNumber);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxID);
			this.splitContainer1.Panel1.Controls.Add(this.label13);
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
			this.splitContainer1.Size = new System.Drawing.Size(1001, 100);
			this.splitContainer1.SplitterDistance = 501;
			this.splitContainer1.TabIndex = 0;
			// 
			// comboBoxReceiptType
			// 
			this.comboBoxReceiptType.FormattingEnabled = true;
			this.comboBoxReceiptType.Items.AddRange(new object[] {
			"采购入库",
			"采购退货",
			"调拨入库",
			"调拨退货",
			"报溢入库",
			"报溢退货"});
			this.comboBoxReceiptType.Location = new System.Drawing.Point(291, 68);
			this.comboBoxReceiptType.Name = "comboBoxReceiptType";
			this.comboBoxReceiptType.Size = new System.Drawing.Size(121, 20);
			this.comboBoxReceiptType.TabIndex = 1;
			this.comboBoxReceiptType.Text = "采购入库";
			this.comboBoxReceiptType.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(228, 67);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(69, 23);
			this.label13.TabIndex = 0;
			this.label13.Text = "入库类别：";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxWareHouseID
			// 
			this.comboBoxWareHouseID.FormattingEnabled = true;
			this.comboBoxWareHouseID.Location = new System.Drawing.Point(95, 10);
			this.comboBoxWareHouseID.Name = "comboBoxWareHouseID";
			this.comboBoxWareHouseID.Size = new System.Drawing.Size(204, 20);
			this.comboBoxWareHouseID.TabIndex = 0;
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
			this.comboBoxCompanyID.TabIndex = 2;
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
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 420F));
			this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label9, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBoxDisc, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBoxPayDiscAmt, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 337);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1002, 44);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// textBoxPayDiscAmt
			// 
			this.textBoxPayDiscAmt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxPayDiscAmt.Location = new System.Drawing.Point(78, 11);
			this.textBoxPayDiscAmt.Name = "textBoxPayDiscAmt";
			this.textBoxPayDiscAmt.Size = new System.Drawing.Size(142, 21);
			this.textBoxPayDiscAmt.TabIndex = 0;
			this.textBoxPayDiscAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxPayDiscAmt.TextChanged += new System.EventHandler(this.TextBoxPayDiscAmtTextChanged);
			this.textBoxPayDiscAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPayDiscAmtKeyPress);
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label6.Location = new System.Drawing.Point(3, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "折后应付：";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(938, 396);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 7;
			this.buttonClose.Text = "关闭";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(857, 396);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 6;
			this.buttonSave.Text = "保存";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// waterTextBoxRemark
			// 
			this.waterTextBoxRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.waterTextBoxRemark.Location = new System.Drawing.Point(427, 313);
			this.waterTextBoxRemark.Name = "waterTextBoxRemark";
			this.waterTextBoxRemark.Size = new System.Drawing.Size(586, 21);
			this.waterTextBoxRemark.TabIndex = 4;
			this.waterTextBoxRemark.WaterText = "在此输入相关信息可辅助查询";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(11, 311);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(69, 23);
			this.label8.TabIndex = 0;
			this.label8.Text = "采购人：";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(189, 311);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(69, 23);
			this.label12.TabIndex = 0;
			this.label12.Text = "收货人：";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPurcher
			// 
			this.textBoxPurcher.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxPurcher.Location = new System.Drawing.Point(65, 312);
			this.textBoxPurcher.Name = "textBoxPurcher";
			this.textBoxPurcher.Size = new System.Drawing.Size(100, 21);
			this.textBoxPurcher.TabIndex = 2;
			// 
			// textBoxReceriver
			// 
			this.textBoxReceriver.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxReceriver.Location = new System.Drawing.Point(237, 312);
			this.textBoxReceriver.Name = "textBoxReceriver";
			this.textBoxReceriver.Size = new System.Drawing.Size(100, 21);
			this.textBoxReceriver.TabIndex = 3;
			// 
			// label14
			// 
			this.label14.ForeColor = System.Drawing.Color.Red;
			this.label14.Location = new System.Drawing.Point(11, 396);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(375, 23);
			this.label14.TabIndex = 8;
			this.label14.Text = "以正数表示入库，负数表示退库。注意保证供应商正确。";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormReceiptBill
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1026, 431);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.waterTextBoxRemark);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxReceriver);
			this.Controls.Add(this.textBoxPurcher);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label5);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormReceiptBill";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormReceiptBill";
			this.Load += new System.EventHandler(this.FormReceiptBillLoad);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
