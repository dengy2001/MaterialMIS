/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-12-07
 * Time: 13:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MaterialMIS
{
	partial class FormLeaseAccount
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox comboBoxCompany;
		private System.Windows.Forms.ComboBox comboBoxProject;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonJSPreview;
		private System.Windows.Forms.Button buttonJS;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.TextBox textBoxBillCycle;
		private System.Windows.Forms.DateTimePicker dateTimePickerSDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerEDate;
		
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
			this.comboBoxCompany = new System.Windows.Forms.ComboBox();
			this.comboBoxProject = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonJSPreview = new System.Windows.Forms.Button();
			this.buttonJS = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label7 = new System.Windows.Forms.Label();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.textBoxBillCycle = new System.Windows.Forms.TextBox();
			this.dateTimePickerSDate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerEDate = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBoxCompany
			// 
			this.comboBoxCompany.FormattingEnabled = true;
			this.comboBoxCompany.Location = new System.Drawing.Point(382, 12);
			this.comboBoxCompany.Name = "comboBoxCompany";
			this.comboBoxCompany.Size = new System.Drawing.Size(195, 20);
			this.comboBoxCompany.TabIndex = 1;
			this.comboBoxCompany.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCompanySelectedIndexChanged);
			// 
			// comboBoxProject
			// 
			this.comboBoxProject.FormattingEnabled = true;
			this.comboBoxProject.Location = new System.Drawing.Point(71, 12);
			this.comboBoxProject.Name = "comboBoxProject";
			this.comboBoxProject.Size = new System.Drawing.Size(195, 20);
			this.comboBoxProject.TabIndex = 0;
			this.comboBoxProject.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProjectSelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(313, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "租赁单位：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "工程项目：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "结算周期：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(175, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "开始日期：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(382, 45);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "结束日期：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonJSPreview
			// 
			this.buttonJSPreview.Location = new System.Drawing.Point(7, 87);
			this.buttonJSPreview.Name = "buttonJSPreview";
			this.buttonJSPreview.Size = new System.Drawing.Size(105, 23);
			this.buttonJSPreview.TabIndex = 5;
			this.buttonJSPreview.Text = "结算预览";
			this.buttonJSPreview.UseVisualStyleBackColor = true;
			this.buttonJSPreview.Click += new System.EventHandler(this.ButtonJSPreviewClick);
			// 
			// buttonJS
			// 
			this.buttonJS.Location = new System.Drawing.Point(133, 87);
			this.buttonJS.Name = "buttonJS";
			this.buttonJS.Size = new System.Drawing.Size(105, 23);
			this.buttonJS.TabIndex = 6;
			this.buttonJS.Text = "结算";
			this.buttonJS.UseVisualStyleBackColor = true;
			this.buttonJS.Click += new System.EventHandler(this.ButtonJSClick);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(7, 123);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 4;
			this.label6.Text = "结算期初余量：";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(7, 149);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(422, 142);
			this.dataGridView1.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(435, 123);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(137, 23);
			this.label7.TabIndex = 4;
			this.label7.Text = "未结算租赁记录：";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dataGridView2
			// 
			this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Location = new System.Drawing.Point(435, 149);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.RowTemplate.Height = 23;
			this.dataGridView2.Size = new System.Drawing.Size(142, 142);
			this.dataGridView2.TabIndex = 8;
			// 
			// textBoxBillCycle
			// 
			this.textBoxBillCycle.Location = new System.Drawing.Point(71, 46);
			this.textBoxBillCycle.Name = "textBoxBillCycle";
			this.textBoxBillCycle.Size = new System.Drawing.Size(85, 21);
			this.textBoxBillCycle.TabIndex = 2;
			// 
			// dateTimePickerSDate
			// 
			this.dateTimePickerSDate.Location = new System.Drawing.Point(242, 46);
			this.dateTimePickerSDate.Name = "dateTimePickerSDate";
			this.dateTimePickerSDate.Size = new System.Drawing.Size(124, 21);
			this.dateTimePickerSDate.TabIndex = 3;
			// 
			// dateTimePickerEDate
			// 
			this.dateTimePickerEDate.Location = new System.Drawing.Point(451, 46);
			this.dateTimePickerEDate.Name = "dateTimePickerEDate";
			this.dateTimePickerEDate.Size = new System.Drawing.Size(124, 21);
			this.dateTimePickerEDate.TabIndex = 4;
			// 
			// FormLeaseAccount
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(590, 303);
			this.Controls.Add(this.dateTimePickerEDate);
			this.Controls.Add(this.dateTimePickerSDate);
			this.Controls.Add(this.textBoxBillCycle);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.buttonJS);
			this.Controls.Add(this.buttonJSPreview);
			this.Controls.Add(this.comboBoxCompany);
			this.Controls.Add(this.comboBoxProject);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Name = "FormLeaseAccount";
			this.Text = "租赁结算";
			this.Load += new System.EventHandler(this.FormLeaseAccountLoad);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
