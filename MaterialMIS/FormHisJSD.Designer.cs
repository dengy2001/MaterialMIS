﻿/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-29
 * 时间: 13:00
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormHisJSD
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ComboBox comboBoxProjectCompany;
		private System.Windows.Forms.ComboBox comboBoxProject;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCX;
		private System.Windows.Forms.Button buttonPrint;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 取消结算ToolStripMenuItem;
		
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.取消结算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comboBoxProjectCompany = new System.Windows.Forms.ComboBox();
			this.comboBoxProject = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonCX = new System.Windows.Forms.Button();
			this.buttonPrint = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridView1.Location = new System.Drawing.Point(7, 38);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(809, 198);
			this.dataGridView1.TabIndex = 11;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.取消结算ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
			// 
			// 取消结算ToolStripMenuItem
			// 
			this.取消结算ToolStripMenuItem.Name = "取消结算ToolStripMenuItem";
			this.取消结算ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.取消结算ToolStripMenuItem.Text = "取消结算";
			this.取消结算ToolStripMenuItem.Click += new System.EventHandler(this.取消结算ToolStripMenuItemClick);
			// 
			// comboBoxProjectCompany
			// 
			this.comboBoxProjectCompany.FormattingEnabled = true;
			this.comboBoxProjectCompany.Location = new System.Drawing.Point(293, 12);
			this.comboBoxProjectCompany.Name = "comboBoxProjectCompany";
			this.comboBoxProjectCompany.Size = new System.Drawing.Size(233, 20);
			this.comboBoxProjectCompany.TabIndex = 9;
			this.comboBoxProjectCompany.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProjectCompanySelectedIndexChanged);
			// 
			// comboBoxProject
			// 
			this.comboBoxProject.FormattingEnabled = true;
			this.comboBoxProject.Location = new System.Drawing.Point(50, 12);
			this.comboBoxProject.Name = "comboBoxProject";
			this.comboBoxProject.Size = new System.Drawing.Size(168, 20);
			this.comboBoxProject.TabIndex = 5;
			this.comboBoxProject.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProjectSelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(245, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "单位：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "项目：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonCX
			// 
			this.buttonCX.Location = new System.Drawing.Point(546, 11);
			this.buttonCX.Name = "buttonCX";
			this.buttonCX.Size = new System.Drawing.Size(106, 23);
			this.buttonCX.TabIndex = 12;
			this.buttonCX.Text = "查询结算单";
			this.buttonCX.UseVisualStyleBackColor = true;
			this.buttonCX.Click += new System.EventHandler(this.ButtonCXClick);
			// 
			// buttonPrint
			// 
			this.buttonPrint.Location = new System.Drawing.Point(658, 12);
			this.buttonPrint.Name = "buttonPrint";
			this.buttonPrint.Size = new System.Drawing.Size(75, 23);
			this.buttonPrint.TabIndex = 13;
			this.buttonPrint.Text = "预览结算单";
			this.buttonPrint.UseVisualStyleBackColor = true;
			this.buttonPrint.Click += new System.EventHandler(this.ButtonPrintClick);
			// 
			// FormHisJSD
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(828, 248);
			this.Controls.Add(this.buttonPrint);
			this.Controls.Add(this.buttonCX);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.comboBoxProjectCompany);
			this.Controls.Add(this.comboBoxProject);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormHisJSD";
			this.Text = "历史结算单";
			this.Load += new System.EventHandler(this.FormHisJSDLoad);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
