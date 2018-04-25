/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-28
 * 时间: 10:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormMaterialConfirm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxProject;
		private System.Windows.Forms.ComboBox comboBoxProjectCompany;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxPeriod;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button buttonConfirm;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.Button buttonPrint;
		
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
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxProject = new System.Windows.Forms.ComboBox();
			this.comboBoxProjectCompany = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxPeriod = new System.Windows.Forms.TextBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.buttonConfirm = new System.Windows.Forms.Button();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.buttonPrint = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "项目：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(250, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "单位：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxProject
			// 
			this.comboBoxProject.FormattingEnabled = true;
			this.comboBoxProject.Location = new System.Drawing.Point(55, 22);
			this.comboBoxProject.Name = "comboBoxProject";
			this.comboBoxProject.Size = new System.Drawing.Size(168, 20);
			this.comboBoxProject.TabIndex = 0;
			this.comboBoxProject.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProjectSelectedIndexChanged);
			// 
			// comboBoxProjectCompany
			// 
			this.comboBoxProjectCompany.FormattingEnabled = true;
			this.comboBoxProjectCompany.Location = new System.Drawing.Point(298, 22);
			this.comboBoxProjectCompany.Name = "comboBoxProjectCompany";
			this.comboBoxProjectCompany.Size = new System.Drawing.Size(233, 20);
			this.comboBoxProjectCompany.TabIndex = 1;
			this.comboBoxProjectCompany.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProjectCompanySelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(161, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "结算周期（形如 201609）：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPeriod
			// 
			this.textBoxPeriod.Location = new System.Drawing.Point(167, 67);
			this.textBoxPeriod.Name = "textBoxPeriod";
			this.textBoxPeriod.Size = new System.Drawing.Size(100, 21);
			this.textBoxPeriod.TabIndex = 2;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 93);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(467, 192);
			this.dataGridView1.TabIndex = 3;
			// 
			// buttonConfirm
			// 
			this.buttonConfirm.Location = new System.Drawing.Point(273, 66);
			this.buttonConfirm.Name = "buttonConfirm";
			this.buttonConfirm.Size = new System.Drawing.Size(133, 23);
			this.buttonConfirm.TabIndex = 4;
			this.buttonConfirm.Text = "结算选中的单据";
			this.buttonConfirm.UseVisualStyleBackColor = true;
			this.buttonConfirm.Click += new System.EventHandler(this.ButtonConfirmClick);
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Location = new System.Drawing.Point(485, 93);
			this.dataGridView2.MultiSelect = false;
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowTemplate.Height = 23;
			this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView2.Size = new System.Drawing.Size(155, 192);
			this.dataGridView2.TabIndex = 5;
			// 
			// buttonPrint
			// 
			this.buttonPrint.Location = new System.Drawing.Point(412, 66);
			this.buttonPrint.Name = "buttonPrint";
			this.buttonPrint.Size = new System.Drawing.Size(75, 23);
			this.buttonPrint.TabIndex = 6;
			this.buttonPrint.Text = "结算预览";
			this.buttonPrint.UseVisualStyleBackColor = true;
			this.buttonPrint.Click += new System.EventHandler(this.ButtonPrintClick);
			// 
			// FormMaterialConfirm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(652, 297);
			this.Controls.Add(this.buttonPrint);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.buttonConfirm);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.textBoxPeriod);
			this.Controls.Add(this.comboBoxProjectCompany);
			this.Controls.Add(this.comboBoxProject);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Name = "FormMaterialConfirm";
			this.Text = "材料月结";
			this.Load += new System.EventHandler(this.FormMaterialConfirmLoad);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
