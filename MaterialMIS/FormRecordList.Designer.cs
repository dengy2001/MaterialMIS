/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-08-19
 * 时间: 16:37
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormRecordList
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxProject;
		private System.Windows.Forms.ComboBox comboBoxYM;
		private System.Windows.Forms.ComboBox comboBoxSupplier;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 新记录ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 修改记录ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 删除记录ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 对账完成ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 反对账ToolStripMenuItem;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem 打印对账单ToolStripMenuItem;
		
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxProject = new System.Windows.Forms.ComboBox();
			this.comboBoxYM = new System.Windows.Forms.ComboBox();
			this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.新记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.修改记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.删除记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.对账完成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.反对账ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.打印对账单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "项目：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(187, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "供应商：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(409, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "对账年月：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxProject
			// 
			this.comboBoxProject.FormattingEnabled = true;
			this.comboBoxProject.Location = new System.Drawing.Point(50, 12);
			this.comboBoxProject.Name = "comboBoxProject";
			this.comboBoxProject.Size = new System.Drawing.Size(131, 20);
			this.comboBoxProject.TabIndex = 2;
			this.comboBoxProject.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProjectSelectedIndexChanged);
			// 
			// comboBoxYM
			// 
			this.comboBoxYM.FormattingEnabled = true;
			this.comboBoxYM.Location = new System.Drawing.Point(470, 11);
			this.comboBoxYM.Name = "comboBoxYM";
			this.comboBoxYM.Size = new System.Drawing.Size(86, 20);
			this.comboBoxYM.TabIndex = 2;
			this.comboBoxYM.SelectedIndexChanged += new System.EventHandler(this.ComboBoxYMSelectedIndexChanged);
			// 
			// comboBoxSupplier
			// 
			this.comboBoxSupplier.FormattingEnabled = true;
			this.comboBoxSupplier.Location = new System.Drawing.Point(239, 11);
			this.comboBoxSupplier.Name = "comboBoxSupplier";
			this.comboBoxSupplier.Size = new System.Drawing.Size(164, 20);
			this.comboBoxSupplier.TabIndex = 2;
			this.comboBoxSupplier.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSupplierSelectedIndexChanged);
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridView1.Location = new System.Drawing.Point(12, 44);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(656, 295);
			this.dataGridView1.TabIndex = 3;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.新记录ToolStripMenuItem,
			this.修改记录ToolStripMenuItem,
			this.删除记录ToolStripMenuItem,
			this.toolStripMenuItem1,
			this.对账完成ToolStripMenuItem,
			this.反对账ToolStripMenuItem,
			this.toolStripMenuItem2,
			this.打印对账单ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(153, 170);
			// 
			// 新记录ToolStripMenuItem
			// 
			this.新记录ToolStripMenuItem.Name = "新记录ToolStripMenuItem";
			this.新记录ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.新记录ToolStripMenuItem.Text = "新增记录";
			this.新记录ToolStripMenuItem.Click += new System.EventHandler(this.新记录ToolStripMenuItemClick);
			// 
			// 修改记录ToolStripMenuItem
			// 
			this.修改记录ToolStripMenuItem.Name = "修改记录ToolStripMenuItem";
			this.修改记录ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.修改记录ToolStripMenuItem.Text = "修改记录";
			this.修改记录ToolStripMenuItem.Click += new System.EventHandler(this.修改记录ToolStripMenuItemClick);
			// 
			// 删除记录ToolStripMenuItem
			// 
			this.删除记录ToolStripMenuItem.Name = "删除记录ToolStripMenuItem";
			this.删除记录ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.删除记录ToolStripMenuItem.Text = "删除记录";
			this.删除记录ToolStripMenuItem.Click += new System.EventHandler(this.删除记录ToolStripMenuItemClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// 对账完成ToolStripMenuItem
			// 
			this.对账完成ToolStripMenuItem.Name = "对账完成ToolStripMenuItem";
			this.对账完成ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.对账完成ToolStripMenuItem.Text = "对账完成";
			// 
			// 反对账ToolStripMenuItem
			// 
			this.反对账ToolStripMenuItem.Name = "反对账ToolStripMenuItem";
			this.反对账ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.反对账ToolStripMenuItem.Text = "反对账";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
			// 
			// 打印对账单ToolStripMenuItem
			// 
			this.打印对账单ToolStripMenuItem.Name = "打印对账单ToolStripMenuItem";
			this.打印对账单ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.打印对账单ToolStripMenuItem.Text = "打印对账单";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(593, 9);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "关闭";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// FormRecordList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(679, 351);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.comboBoxSupplier);
			this.Controls.Add(this.comboBoxYM);
			this.Controls.Add(this.comboBoxProject);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormRecordList";
			this.Text = "一般材料";
			this.Load += new System.EventHandler(this.FormRecordListLoad);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
