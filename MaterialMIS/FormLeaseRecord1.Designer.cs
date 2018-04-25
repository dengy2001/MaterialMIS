/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-12-06
 * Time: 12:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MaterialMIS
{
	partial class FormLeaseRecord1
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox comboBoxItemsName;
		private System.Windows.Forms.TextBox textBoxLeaseUnit;
		private System.Windows.Forms.DateTimePicker dateTimePickerLeaseDate;
		private System.Windows.Forms.TextBox textBoxQuality;
		private System.Windows.Forms.TextBox textBoxHandler;
		private System.Windows.Forms.TextBox textBoxAbstract;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		
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
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBoxItemsName = new System.Windows.Forms.ComboBox();
			this.textBoxLeaseUnit = new System.Windows.Forms.TextBox();
			this.dateTimePickerLeaseDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxQuality = new System.Windows.Forms.TextBox();
			this.textBoxHandler = new System.Windows.Forms.TextBox();
			this.textBoxAbstract = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "租赁数量：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "租赁日期：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(214, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "租赁单位：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "租 赁 项：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(214, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 3;
			this.label5.Text = "经 手 人：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 133);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 3;
			this.label6.Text = "备    注：";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxItemsName
			// 
			this.comboBoxItemsName.FormattingEnabled = true;
			this.comboBoxItemsName.Location = new System.Drawing.Point(84, 10);
			this.comboBoxItemsName.Name = "comboBoxItemsName";
			this.comboBoxItemsName.Size = new System.Drawing.Size(121, 20);
			this.comboBoxItemsName.TabIndex = 0;
			this.comboBoxItemsName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxItemsNameSelectedIndexChanged);
			// 
			// textBoxLeaseUnit
			// 
			this.textBoxLeaseUnit.Location = new System.Drawing.Point(283, 10);
			this.textBoxLeaseUnit.Name = "textBoxLeaseUnit";
			this.textBoxLeaseUnit.ReadOnly = true;
			this.textBoxLeaseUnit.Size = new System.Drawing.Size(63, 21);
			this.textBoxLeaseUnit.TabIndex = 0;
			this.textBoxLeaseUnit.TabStop = false;
			// 
			// dateTimePickerLeaseDate
			// 
			this.dateTimePickerLeaseDate.Location = new System.Drawing.Point(84, 50);
			this.dateTimePickerLeaseDate.Name = "dateTimePickerLeaseDate";
			this.dateTimePickerLeaseDate.Size = new System.Drawing.Size(262, 21);
			this.dateTimePickerLeaseDate.TabIndex = 1;
			// 
			// textBoxQuality
			// 
			this.textBoxQuality.Location = new System.Drawing.Point(84, 89);
			this.textBoxQuality.Name = "textBoxQuality";
			this.textBoxQuality.Size = new System.Drawing.Size(63, 21);
			this.textBoxQuality.TabIndex = 2;
			// 
			// textBoxHandler
			// 
			this.textBoxHandler.Location = new System.Drawing.Point(283, 89);
			this.textBoxHandler.Name = "textBoxHandler";
			this.textBoxHandler.Size = new System.Drawing.Size(63, 21);
			this.textBoxHandler.TabIndex = 3;
			// 
			// textBoxAbstract
			// 
			this.textBoxAbstract.Location = new System.Drawing.Point(84, 134);
			this.textBoxAbstract.Name = "textBoxAbstract";
			this.textBoxAbstract.Size = new System.Drawing.Size(262, 21);
			this.textBoxAbstract.TabIndex = 4;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(190, 181);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "保存";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(271, 181);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// FormLeaseRecord1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(357, 215);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.dateTimePickerLeaseDate);
			this.Controls.Add(this.textBoxHandler);
			this.Controls.Add(this.textBoxAbstract);
			this.Controls.Add(this.textBoxQuality);
			this.Controls.Add(this.textBoxLeaseUnit);
			this.Controls.Add(this.comboBoxItemsName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormLeaseRecord1";
			this.Text = "租赁记录";
			this.Load += new System.EventHandler(this.FormLeaseRecord1Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
