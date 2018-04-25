/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-18
 * Time: 15:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MaterialMIS
{
	partial class FormLeaseOption
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 新租赁合同ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 修改租赁合同ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 删除租赁合同ToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
		private System.Windows.Forms.ToolStripMenuItem 新增租赁项ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 修改租赁项ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 删除租赁项ToolStripMenuItem;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxProject;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.新租赁合同ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.修改租赁合同ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.删除租赁合同ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label2 = new System.Windows.Forms.Label();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.新增租赁项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.修改租赁项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.删除租赁项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxProject = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.contextMenuStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "租赁合同";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridView1.Location = new System.Drawing.Point(12, 76);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(480, 227);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView1CellFormatting);
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1SelectionChanged);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.新租赁合同ToolStripMenuItem,
			this.修改租赁合同ToolStripMenuItem,
			this.删除租赁合同ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
			// 
			// 新租赁合同ToolStripMenuItem
			// 
			this.新租赁合同ToolStripMenuItem.Name = "新租赁合同ToolStripMenuItem";
			this.新租赁合同ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.新租赁合同ToolStripMenuItem.Text = "新租赁合同";
			this.新租赁合同ToolStripMenuItem.Click += new System.EventHandler(this.新租赁合同ToolStripMenuItemClick);
			// 
			// 修改租赁合同ToolStripMenuItem
			// 
			this.修改租赁合同ToolStripMenuItem.Name = "修改租赁合同ToolStripMenuItem";
			this.修改租赁合同ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.修改租赁合同ToolStripMenuItem.Text = "修改租赁合同";
			this.修改租赁合同ToolStripMenuItem.Click += new System.EventHandler(this.修改租赁合同ToolStripMenuItemClick);
			// 
			// 删除租赁合同ToolStripMenuItem
			// 
			this.删除租赁合同ToolStripMenuItem.Name = "删除租赁合同ToolStripMenuItem";
			this.删除租赁合同ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.删除租赁合同ToolStripMenuItem.Text = "删除租赁合同";
			this.删除租赁合同ToolStripMenuItem.Click += new System.EventHandler(this.删除租赁合同ToolStripMenuItemClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(498, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(157, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "租赁合同租赁项信息";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dataGridView2
			// 
			this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.ContextMenuStrip = this.contextMenuStrip2;
			this.dataGridView2.Location = new System.Drawing.Point(498, 76);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.RowTemplate.Height = 23;
			this.dataGridView2.Size = new System.Drawing.Size(198, 227);
			this.dataGridView2.TabIndex = 2;
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.新增租赁项ToolStripMenuItem,
			this.修改租赁项ToolStripMenuItem,
			this.删除租赁项ToolStripMenuItem});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(137, 70);
			// 
			// 新增租赁项ToolStripMenuItem
			// 
			this.新增租赁项ToolStripMenuItem.Name = "新增租赁项ToolStripMenuItem";
			this.新增租赁项ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.新增租赁项ToolStripMenuItem.Text = "新增租赁项";
			this.新增租赁项ToolStripMenuItem.Click += new System.EventHandler(this.新增租赁项ToolStripMenuItemClick);
			// 
			// 修改租赁项ToolStripMenuItem
			// 
			this.修改租赁项ToolStripMenuItem.Name = "修改租赁项ToolStripMenuItem";
			this.修改租赁项ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.修改租赁项ToolStripMenuItem.Text = "修改租赁项";
			this.修改租赁项ToolStripMenuItem.Click += new System.EventHandler(this.修改租赁项ToolStripMenuItemClick);
			// 
			// 删除租赁项ToolStripMenuItem
			// 
			this.删除租赁项ToolStripMenuItem.Name = "删除租赁项ToolStripMenuItem";
			this.删除租赁项ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.删除租赁项ToolStripMenuItem.Text = "删除租赁项";
			this.删除租赁项ToolStripMenuItem.Click += new System.EventHandler(this.删除租赁项ToolStripMenuItemClick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "工程项目：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxProject
			// 
			this.comboBoxProject.FormattingEnabled = true;
			this.comboBoxProject.Location = new System.Drawing.Point(75, 9);
			this.comboBoxProject.Name = "comboBoxProject";
			this.comboBoxProject.Size = new System.Drawing.Size(188, 20);
			this.comboBoxProject.TabIndex = 3;
			// 
			// FormLeaseOption
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(708, 315);
			this.Controls.Add(this.comboBoxProject);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Name = "FormLeaseOption";
			this.Text = "租赁设置";
			this.Load += new System.EventHandler(this.FormLeaseOptionLoad);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.contextMenuStrip2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
