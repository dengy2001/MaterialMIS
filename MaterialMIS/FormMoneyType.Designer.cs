/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-01
 * 时间: 21:10
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormMoneyType
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.TextBox textBoxMoneyTypeID;
		private System.Windows.Forms.TextBox textBoxMoneyTypeName;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label3;
		
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
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.textBoxMoneyTypeID = new System.Windows.Forms.TextBox();
			this.textBoxMoneyTypeName = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(26, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "收支项ID：";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(26, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "收支项名：";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(98, 114);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(104, 24);
			this.radioButton1.TabIndex = 2;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "收入项";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(195, 114);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(104, 24);
			this.radioButton2.TabIndex = 3;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "支出项";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// textBoxMoneyTypeID
			// 
			this.textBoxMoneyTypeID.Location = new System.Drawing.Point(98, 26);
			this.textBoxMoneyTypeID.Name = "textBoxMoneyTypeID";
			this.textBoxMoneyTypeID.ReadOnly = true;
			this.textBoxMoneyTypeID.Size = new System.Drawing.Size(268, 21);
			this.textBoxMoneyTypeID.TabIndex = 0;
			this.textBoxMoneyTypeID.TabStop = false;
			// 
			// textBoxMoneyTypeName
			// 
			this.textBoxMoneyTypeName.Location = new System.Drawing.Point(98, 67);
			this.textBoxMoneyTypeName.Name = "textBoxMoneyTypeName";
			this.textBoxMoneyTypeName.Size = new System.Drawing.Size(268, 21);
			this.textBoxMoneyTypeName.TabIndex = 1;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(195, 179);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "保存";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(291, 179);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(12, 141);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(353, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "不要随意改动，因为原来的数据中可能有使用！！！";
			// 
			// FormMoneyType
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(377, 216);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxMoneyTypeName);
			this.Controls.Add(this.textBoxMoneyTypeID);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormMoneyType";
			this.Text = "FormMoneyType";
			this.Load += new System.EventHandler(this.FormMoneyTypeLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
