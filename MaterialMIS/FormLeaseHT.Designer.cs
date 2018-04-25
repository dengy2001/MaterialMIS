/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-18
 * Time: 16:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MaterialMIS
{
	partial class FormLeaseHT
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox checkBoxIncludeSDate;
		private System.Windows.Forms.CheckBox checkBoxIncludeEDate;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox textBoxHID;
		private System.Windows.Forms.TextBox textBoxHTNumber;
		private System.Windows.Forms.TextBox textBoxHTName;
		private System.Windows.Forms.ComboBox comboBoxCompany;
		private System.Windows.Forms.TextBox textBoxProjectName;
		
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
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBoxIncludeSDate = new System.Windows.Forms.CheckBox();
			this.checkBoxIncludeEDate = new System.Windows.Forms.CheckBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.textBoxHID = new System.Windows.Forms.TextBox();
			this.textBoxHTNumber = new System.Windows.Forms.TextBox();
			this.textBoxHTName = new System.Windows.Forms.TextBox();
			this.comboBoxCompany = new System.Windows.Forms.ComboBox();
			this.textBoxProjectName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "合同ID：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(236, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "合同号：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(236, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "租赁单位：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 42);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "工程项目：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 77);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "合同名称：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkBoxIncludeSDate
			// 
			this.checkBoxIncludeSDate.Location = new System.Drawing.Point(12, 120);
			this.checkBoxIncludeSDate.Name = "checkBoxIncludeSDate";
			this.checkBoxIncludeSDate.Size = new System.Drawing.Size(145, 24);
			this.checkBoxIncludeSDate.TabIndex = 4;
			this.checkBoxIncludeSDate.Text = "算头（租赁日计租）";
			this.checkBoxIncludeSDate.UseVisualStyleBackColor = true;
			// 
			// checkBoxIncludeEDate
			// 
			this.checkBoxIncludeEDate.Location = new System.Drawing.Point(163, 120);
			this.checkBoxIncludeEDate.Name = "checkBoxIncludeEDate";
			this.checkBoxIncludeEDate.Size = new System.Drawing.Size(139, 24);
			this.checkBoxIncludeEDate.TabIndex = 5;
			this.checkBoxIncludeEDate.Text = "算尾（归还日计租）";
			this.checkBoxIncludeEDate.UseVisualStyleBackColor = true;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(244, 158);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 6;
			this.buttonSave.Text = "保存";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(356, 158);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// textBoxHID
			// 
			this.textBoxHID.Location = new System.Drawing.Point(69, 9);
			this.textBoxHID.Name = "textBoxHID";
			this.textBoxHID.ReadOnly = true;
			this.textBoxHID.Size = new System.Drawing.Size(121, 21);
			this.textBoxHID.TabIndex = 0;
			// 
			// textBoxHTNumber
			// 
			this.textBoxHTNumber.Location = new System.Drawing.Point(310, 9);
			this.textBoxHTNumber.Name = "textBoxHTNumber";
			this.textBoxHTNumber.Size = new System.Drawing.Size(121, 21);
			this.textBoxHTNumber.TabIndex = 0;
			// 
			// textBoxHTName
			// 
			this.textBoxHTName.Location = new System.Drawing.Point(69, 77);
			this.textBoxHTName.Name = "textBoxHTName";
			this.textBoxHTName.Size = new System.Drawing.Size(362, 21);
			this.textBoxHTName.TabIndex = 3;
			// 
			// comboBoxCompany
			// 
			this.comboBoxCompany.FormattingEnabled = true;
			this.comboBoxCompany.Location = new System.Drawing.Point(310, 42);
			this.comboBoxCompany.Name = "comboBoxCompany";
			this.comboBoxCompany.Size = new System.Drawing.Size(121, 20);
			this.comboBoxCompany.TabIndex = 1;
			// 
			// textBoxProjectName
			// 
			this.textBoxProjectName.Location = new System.Drawing.Point(69, 41);
			this.textBoxProjectName.Name = "textBoxProjectName";
			this.textBoxProjectName.ReadOnly = true;
			this.textBoxProjectName.Size = new System.Drawing.Size(121, 21);
			this.textBoxProjectName.TabIndex = 0;
			// 
			// FormLeaseHT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(448, 197);
			this.Controls.Add(this.comboBoxCompany);
			this.Controls.Add(this.textBoxHTNumber);
			this.Controls.Add(this.textBoxHTName);
			this.Controls.Add(this.textBoxProjectName);
			this.Controls.Add(this.textBoxHID);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.checkBoxIncludeEDate);
			this.Controls.Add(this.checkBoxIncludeSDate);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormLeaseHT";
			this.Text = "租赁合同-新增";
			this.Load += new System.EventHandler(this.FormLeaseHTLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
