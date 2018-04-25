/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-24
 * Time: 11:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MaterialMIS
{
	partial class FormLeaseRecord
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxProject;
		private System.Windows.Forms.ComboBox comboBoxCompany;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 新租赁记录ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 修改租赁记录ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 删除租赁记录ToolStripMenuItem;
		
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
			this.comboBoxProject = new System.Windows.Forms.ComboBox();
			this.comboBoxCompany = new System.Windows.Forms.ComboBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.新租赁记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.修改租赁记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.删除租赁记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "工程项目：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(318, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "租赁单位：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxProject
			// 
			this.comboBoxProject.FormattingEnabled = true;
			this.comboBoxProject.Location = new System.Drawing.Point(76, 19);
			this.comboBoxProject.Name = "comboBoxProject";
			this.comboBoxProject.Size = new System.Drawing.Size(195, 20);
			this.comboBoxProject.TabIndex = 0;
			this.comboBoxProject.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxProjectSelectionChangeCommitted);
			// 
			// comboBoxCompany
			// 
			this.comboBoxCompany.FormattingEnabled = true;
			this.comboBoxCompany.Location = new System.Drawing.Point(387, 19);
			this.comboBoxCompany.Name = "comboBoxCompany";
			this.comboBoxCompany.Size = new System.Drawing.Size(195, 20);
			this.comboBoxCompany.TabIndex = 1;
			this.comboBoxCompany.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxCompanySelectionChangeCommitted);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridView1.Location = new System.Drawing.Point(12, 45);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(627, 204);
			this.dataGridView1.TabIndex = 2;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.新租赁记录ToolStripMenuItem,
			this.修改租赁记录ToolStripMenuItem,
			this.删除租赁记录ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
			// 
			// 新租赁记录ToolStripMenuItem
			// 
			this.新租赁记录ToolStripMenuItem.Name = "新租赁记录ToolStripMenuItem";
			this.新租赁记录ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.新租赁记录ToolStripMenuItem.Text = "新租赁记录";
			this.新租赁记录ToolStripMenuItem.Click += new System.EventHandler(this.新租赁记录ToolStripMenuItemClick);
			// 
			// 修改租赁记录ToolStripMenuItem
			// 
			this.修改租赁记录ToolStripMenuItem.Name = "修改租赁记录ToolStripMenuItem";
			this.修改租赁记录ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.修改租赁记录ToolStripMenuItem.Text = "修改租赁记录";
			this.修改租赁记录ToolStripMenuItem.Click += new System.EventHandler(this.修改租赁记录ToolStripMenuItemClick);
			// 
			// 删除租赁记录ToolStripMenuItem
			// 
			this.删除租赁记录ToolStripMenuItem.Name = "删除租赁记录ToolStripMenuItem";
			this.删除租赁记录ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.删除租赁记录ToolStripMenuItem.Text = "删除租赁记录";
			this.删除租赁记录ToolStripMenuItem.Click += new System.EventHandler(this.删除租赁记录ToolStripMenuItemClick);
			// 
			// FormLeaseRecord
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(651, 261);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.comboBoxCompany);
			this.Controls.Add(this.comboBoxProject);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormLeaseRecord";
			this.Text = "租赁记录";
			this.Load += new System.EventHandler(this.FormLeaseRecordLoad);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
