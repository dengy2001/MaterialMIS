/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-02
 * 时间: 16:45
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormAccountOUT
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.CheckBox checkBoxHideZero;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonDel;
		private System.Windows.Forms.Button buttonModify;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 新未付款ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 付款ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 款项记录ToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label labelTotal;
		private System.Windows.Forms.Button buttonPrint;
		private System.Windows.Forms.Label labelCurCompany;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.Label labelCurAmt;
		private System.Windows.Forms.Label labelInitAmt;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
		private System.Windows.Forms.ToolStripMenuItem 删除记录ToolStripMenuItem;
		
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
			this.checkBoxHideZero = new System.Windows.Forms.CheckBox();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonModify = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.新未付款ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.付款ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.款项记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.labelTotal = new System.Windows.Forms.Label();
			this.buttonPrint = new System.Windows.Forms.Button();
			this.labelCurCompany = new System.Windows.Forms.Label();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.删除记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labelCurAmt = new System.Windows.Forms.Label();
			this.labelInitAmt = new System.Windows.Forms.Label();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.contextMenuStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkBoxHideZero
			// 
			this.checkBoxHideZero.Location = new System.Drawing.Point(290, 12);
			this.checkBoxHideZero.Name = "checkBoxHideZero";
			this.checkBoxHideZero.Size = new System.Drawing.Size(104, 24);
			this.checkBoxHideZero.TabIndex = 8;
			this.checkBoxHideZero.Text = "隐藏零欠款";
			this.checkBoxHideZero.UseVisualStyleBackColor = true;
			this.checkBoxHideZero.Click += new System.EventHandler(this.CheckBoxHideZeroClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(675, 11);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 4;
			this.buttonClose.Text = "关闭";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// buttonDel
			// 
			this.buttonDel.Location = new System.Drawing.Point(174, 11);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(75, 23);
			this.buttonDel.TabIndex = 5;
			this.buttonDel.Text = "删除供应商";
			this.buttonDel.UseVisualStyleBackColor = true;
			this.buttonDel.Click += new System.EventHandler(this.ButtonDelClick);
			// 
			// buttonModify
			// 
			this.buttonModify.Location = new System.Drawing.Point(93, 11);
			this.buttonModify.Name = "buttonModify";
			this.buttonModify.Size = new System.Drawing.Size(75, 23);
			this.buttonModify.TabIndex = 6;
			this.buttonModify.Text = "更新供应商";
			this.buttonModify.UseVisualStyleBackColor = true;
			this.buttonModify.Click += new System.EventHandler(this.ButtonModifyClick);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(12, 11);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 7;
			this.buttonAdd.Text = "新增供应商";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.新未付款ToolStripMenuItem,
			this.付款ToolStripMenuItem,
			this.toolStripMenuItem1,
			this.款项记录ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(125, 76);
			// 
			// 新未付款ToolStripMenuItem
			// 
			this.新未付款ToolStripMenuItem.Name = "新未付款ToolStripMenuItem";
			this.新未付款ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.新未付款ToolStripMenuItem.Text = "新未付款";
			this.新未付款ToolStripMenuItem.Click += new System.EventHandler(this.新未付款ToolStripMenuItemClick);
			// 
			// 付款ToolStripMenuItem
			// 
			this.付款ToolStripMenuItem.Name = "付款ToolStripMenuItem";
			this.付款ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.付款ToolStripMenuItem.Text = "付款";
			this.付款ToolStripMenuItem.Click += new System.EventHandler(this.付款ToolStripMenuItemClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
			// 
			// 款项记录ToolStripMenuItem
			// 
			this.款项记录ToolStripMenuItem.Name = "款项记录ToolStripMenuItem";
			this.款项记录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.款项记录ToolStripMenuItem.Text = "款项记录";
			this.款项记录ToolStripMenuItem.Click += new System.EventHandler(this.款项记录ToolStripMenuItemClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(12, 39);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
			this.splitContainer1.Panel1.Controls.Add(this.labelTotal);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
			this.splitContainer1.Panel2.Controls.Add(this.buttonPrint);
			this.splitContainer1.Panel2.Controls.Add(this.labelCurCompany);
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
			this.splitContainer1.Panel2.Controls.Add(this.labelCurAmt);
			this.splitContainer1.Panel2.Controls.Add(this.labelInitAmt);
			this.splitContainer1.Size = new System.Drawing.Size(738, 268);
			this.splitContainer1.SplitterDistance = 311;
			this.splitContainer1.TabIndex = 10;
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridView1.Location = new System.Drawing.Point(3, 15);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 30;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(305, 233);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1SelectionChanged);
			// 
			// labelTotal
			// 
			this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelTotal.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.labelTotal.Location = new System.Drawing.Point(3, 251);
			this.labelTotal.Name = "labelTotal";
			this.labelTotal.Size = new System.Drawing.Size(273, 23);
			this.labelTotal.TabIndex = 5;
			this.labelTotal.Text = "合计应付款：";
			// 
			// buttonPrint
			// 
			this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPrint.Location = new System.Drawing.Point(345, 15);
			this.buttonPrint.Name = "buttonPrint";
			this.buttonPrint.Size = new System.Drawing.Size(75, 23);
			this.buttonPrint.TabIndex = 9;
			this.buttonPrint.Text = "打印";
			this.buttonPrint.UseVisualStyleBackColor = true;
			this.buttonPrint.Click += new System.EventHandler(this.ButtonPrintClick);
			// 
			// labelCurCompany
			// 
			this.labelCurCompany.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.labelCurCompany.Location = new System.Drawing.Point(3, 15);
			this.labelCurCompany.Name = "labelCurCompany";
			this.labelCurCompany.Size = new System.Drawing.Size(233, 23);
			this.labelCurCompany.TabIndex = 8;
			this.labelCurCompany.Text = "当前往来单位：";
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.ContextMenuStrip = this.contextMenuStrip2;
			this.dataGridView2.Location = new System.Drawing.Point(3, 38);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.RowHeadersWidth = 30;
			this.dataGridView2.RowTemplate.Height = 23;
			this.dataGridView2.Size = new System.Drawing.Size(417, 210);
			this.dataGridView2.TabIndex = 6;
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.删除记录ToolStripMenuItem});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(125, 26);
			// 
			// 删除记录ToolStripMenuItem
			// 
			this.删除记录ToolStripMenuItem.Name = "删除记录ToolStripMenuItem";
			this.删除记录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.删除记录ToolStripMenuItem.Text = "删除记录";
			this.删除记录ToolStripMenuItem.Click += new System.EventHandler(this.删除记录ToolStripMenuItemClick);
			// 
			// labelCurAmt
			// 
			this.labelCurAmt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurAmt.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.labelCurAmt.Location = new System.Drawing.Point(242, 251);
			this.labelCurAmt.Name = "labelCurAmt";
			this.labelCurAmt.Size = new System.Drawing.Size(178, 23);
			this.labelCurAmt.TabIndex = 7;
			this.labelCurAmt.Text = "当前应收款：";
			// 
			// labelInitAmt
			// 
			this.labelInitAmt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelInitAmt.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.labelInitAmt.Location = new System.Drawing.Point(3, 251);
			this.labelInitAmt.Name = "labelInitAmt";
			this.labelInitAmt.Size = new System.Drawing.Size(224, 23);
			this.labelInitAmt.TabIndex = 8;
			this.labelInitAmt.Text = "初始应收款：";
			// 
			// FormAccountOUT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(762, 322);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.checkBoxHideZero);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonDel);
			this.Controls.Add(this.buttonModify);
			this.Controls.Add(this.buttonAdd);
			this.Name = "FormAccountOUT";
			this.Text = "未付款信息";
			this.Load += new System.EventHandler(this.FormAccountOUTLoad);
			this.Resize += new System.EventHandler(this.FormAccountOUTResize);
			this.contextMenuStrip1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.contextMenuStrip2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
