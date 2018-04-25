/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-04-29
 * 时间: 17:14
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormStock
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 增加类别ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 修改类别ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 删除类别ToolStripMenuItem;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button butOutPutExcel;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
		private System.Windows.Forms.ToolStripMenuItem 新增货品ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 修改货品ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 删除货品ToolStripMenuItem;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox textBoxFindGoods;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 批量改变货品类别ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 货品合并ToolStripMenuItem;
		
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
			this.button1 = new System.Windows.Forms.Button();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.增加类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.修改类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.删除类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.新增货品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.修改货品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.删除货品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.批量改变货品类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.货品合并ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.butOutPutExcel = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.textBoxFindGoods = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(582, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "关闭";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
			this.treeView1.Location = new System.Drawing.Point(13, 3);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(153, 100);
			this.treeView1.TabIndex = 1;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1AfterSelect);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.增加类别ToolStripMenuItem,
			this.修改类别ToolStripMenuItem,
			this.删除类别ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
			// 
			// 增加类别ToolStripMenuItem
			// 
			this.增加类别ToolStripMenuItem.Name = "增加类别ToolStripMenuItem";
			this.增加类别ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.增加类别ToolStripMenuItem.Text = "增加类别";
			this.增加类别ToolStripMenuItem.Click += new System.EventHandler(this.增加类别ToolStripMenuItemClick);
			// 
			// 修改类别ToolStripMenuItem
			// 
			this.修改类别ToolStripMenuItem.Name = "修改类别ToolStripMenuItem";
			this.修改类别ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.修改类别ToolStripMenuItem.Text = "修改类别";
			this.修改类别ToolStripMenuItem.Click += new System.EventHandler(this.修改类别ToolStripMenuItemClick);
			// 
			// 删除类别ToolStripMenuItem
			// 
			this.删除类别ToolStripMenuItem.Name = "删除类别ToolStripMenuItem";
			this.删除类别ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.删除类别ToolStripMenuItem.Text = "删除类别";
			this.删除类别ToolStripMenuItem.Click += new System.EventHandler(this.删除类别ToolStripMenuItemClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Column1});
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip2;
			this.dataGridView1.Location = new System.Drawing.Point(172, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(461, 100);
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.DoubleClick += new System.EventHandler(this.DataGridView1DoubleClick);
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Column1";
			this.Column1.Name = "Column1";
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.新增货品ToolStripMenuItem,
			this.修改货品ToolStripMenuItem,
			this.删除货品ToolStripMenuItem,
			this.toolStripMenuItem1,
			this.批量改变货品类别ToolStripMenuItem,
			this.货品合并ToolStripMenuItem});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(173, 120);
			// 
			// 新增货品ToolStripMenuItem
			// 
			this.新增货品ToolStripMenuItem.Name = "新增货品ToolStripMenuItem";
			this.新增货品ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.新增货品ToolStripMenuItem.Text = "新增货品";
			this.新增货品ToolStripMenuItem.Click += new System.EventHandler(this.新增货品ToolStripMenuItemClick);
			// 
			// 修改货品ToolStripMenuItem
			// 
			this.修改货品ToolStripMenuItem.Name = "修改货品ToolStripMenuItem";
			this.修改货品ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.修改货品ToolStripMenuItem.Text = "修改货品";
			this.修改货品ToolStripMenuItem.Click += new System.EventHandler(this.修改货品ToolStripMenuItemClick);
			// 
			// 删除货品ToolStripMenuItem
			// 
			this.删除货品ToolStripMenuItem.Name = "删除货品ToolStripMenuItem";
			this.删除货品ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.删除货品ToolStripMenuItem.Text = "删除货品";
			this.删除货品ToolStripMenuItem.Click += new System.EventHandler(this.删除货品ToolStripMenuItemClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(169, 6);
			// 
			// 批量改变货品类别ToolStripMenuItem
			// 
			this.批量改变货品类别ToolStripMenuItem.Name = "批量改变货品类别ToolStripMenuItem";
			this.批量改变货品类别ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.批量改变货品类别ToolStripMenuItem.Text = "批量改变货品类别";
			this.批量改变货品类别ToolStripMenuItem.Click += new System.EventHandler(this.批量改变货品类别ToolStripMenuItemClick);
			// 
			// 货品合并ToolStripMenuItem
			// 
			this.货品合并ToolStripMenuItem.Name = "货品合并ToolStripMenuItem";
			this.货品合并ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.货品合并ToolStripMenuItem.Text = "货品合并到";
			this.货品合并ToolStripMenuItem.Click += new System.EventHandler(this.货品合并ToolStripMenuItemClick);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(14, 121);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(152, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "新增类别";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 12);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 0;
			this.button3.Text = "新增货品";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// butOutPutExcel
			// 
			this.butOutPutExcel.Location = new System.Drawing.Point(93, 12);
			this.butOutPutExcel.Name = "butOutPutExcel";
			this.butOutPutExcel.Size = new System.Drawing.Size(75, 23);
			this.butOutPutExcel.TabIndex = 1;
			this.butOutPutExcel.Text = "货品导出";
			this.butOutPutExcel.UseVisualStyleBackColor = true;
			this.butOutPutExcel.Click += new System.EventHandler(this.ButOutPutExcelClick);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(174, 12);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 2;
			this.button5.Text = "打印";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.treeView1);
			this.panel2.Controls.Add(this.dataGridView1);
			this.panel2.Controls.Add(this.button2);
			this.panel2.Location = new System.Drawing.Point(12, 44);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(645, 161);
			this.panel2.TabIndex = 6;
			// 
			// textBoxFindGoods
			// 
			this.textBoxFindGoods.Location = new System.Drawing.Point(326, 13);
			this.textBoxFindGoods.Name = "textBoxFindGoods";
			this.textBoxFindGoods.Size = new System.Drawing.Size(157, 21);
			this.textBoxFindGoods.TabIndex = 7;
			this.textBoxFindGoods.TextChanged += new System.EventHandler(this.TextBoxFindGoodsTextChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(255, 12);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(67, 23);
			this.label10.TabIndex = 8;
			this.label10.Text = "限定货品：";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormStock
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(669, 217);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBoxFindGoods);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.butOutPutExcel);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button1);
			this.Name = "FormStock";
			this.Text = "材料信息";
			this.Load += new System.EventHandler(this.FormStockLoad);
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
