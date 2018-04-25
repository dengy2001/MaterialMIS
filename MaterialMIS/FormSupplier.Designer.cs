/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-08-11
 * 时间: 10:58
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormSupplier
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnAddToProject;
		private System.Windows.Forms.Button btnDelFromProject;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dataGridViewCompanies;
		private System.Windows.Forms.DataGridView dataGridViewProjectCompanies;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.btnAddToProject = new System.Windows.Forms.Button();
			this.btnDelFromProject = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dataGridViewCompanies = new System.Windows.Forms.DataGridView();
			this.dataGridViewProjectCompanies = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompanies)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjectCompanies)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(73, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "项目：";
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(126, 14);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(182, 20);
			this.comboBox1.TabIndex = 2;
			this.comboBox1.SelectedValueChanged += new System.EventHandler(this.ComboBox1SelectedValueChanged);
			// 
			// btnAddToProject
			// 
			this.btnAddToProject.Location = new System.Drawing.Point(4, 12);
			this.btnAddToProject.Name = "btnAddToProject";
			this.btnAddToProject.Size = new System.Drawing.Size(186, 23);
			this.btnAddToProject.TabIndex = 1;
			this.btnAddToProject.Text = "加入到指定项目>>";
			this.btnAddToProject.UseVisualStyleBackColor = true;
			this.btnAddToProject.Click += new System.EventHandler(this.BtnAddToProjectClick);
			// 
			// btnDelFromProject
			// 
			this.btnDelFromProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelFromProject.Location = new System.Drawing.Point(166, 311);
			this.btnDelFromProject.Name = "btnDelFromProject";
			this.btnDelFromProject.Size = new System.Drawing.Size(151, 23);
			this.btnDelFromProject.TabIndex = 1;
			this.btnDelFromProject.Text = "<< 从项目中移除";
			this.btnDelFromProject.UseVisualStyleBackColor = true;
			this.btnDelFromProject.Click += new System.EventHandler(this.BtnDelFromProjectClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(10, 12);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dataGridViewCompanies);
			this.splitContainer1.Panel1.Controls.Add(this.btnAddToProject);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridViewProjectCompanies);
			this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
			this.splitContainer1.Panel2.Controls.Add(this.btnDelFromProject);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Size = new System.Drawing.Size(641, 337);
			this.splitContainer1.SplitterDistance = 317;
			this.splitContainer1.TabIndex = 3;
			// 
			// dataGridViewCompanies
			// 
			this.dataGridViewCompanies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewCompanies.Location = new System.Drawing.Point(4, 41);
			this.dataGridViewCompanies.Name = "dataGridViewCompanies";
			this.dataGridViewCompanies.RowTemplate.Height = 23;
			this.dataGridViewCompanies.Size = new System.Drawing.Size(310, 293);
			this.dataGridViewCompanies.TabIndex = 2;
			this.dataGridViewCompanies.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewCompaniesCellFormatting);
			// 
			// dataGridViewProjectCompanies
			// 
			this.dataGridViewProjectCompanies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewProjectCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewProjectCompanies.Location = new System.Drawing.Point(3, 41);
			this.dataGridViewProjectCompanies.Name = "dataGridViewProjectCompanies";
			this.dataGridViewProjectCompanies.RowTemplate.Height = 23;
			this.dataGridViewProjectCompanies.Size = new System.Drawing.Size(314, 264);
			this.dataGridViewProjectCompanies.TabIndex = 3;
			this.dataGridViewProjectCompanies.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewProjectCompaniesCellFormatting);
			// 
			// FormSupplier
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 359);
			this.Controls.Add(this.splitContainer1);
			this.Name = "FormSupplier";
			this.Text = "项目相关单位";
			this.Load += new System.EventHandler(this.FormSupplierLoad);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompanies)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjectCompanies)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
