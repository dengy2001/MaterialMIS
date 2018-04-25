/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-03
 * 时间: 14:41
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormAccountBill
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label labelCompanyType;
		private System.Windows.Forms.TextBox textBoxBillMemo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxBillNo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dateTimePickerBillDate;
		private System.Windows.Forms.ComboBox comboBoxComPany;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxProject;
		private System.Windows.Forms.Label labelMoneyType;
		private System.Windows.Forms.ComboBox comboBoxMoneyType;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label labelYW;
		private System.Windows.Forms.TextBox textBoxBillMoney;
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
			this.labelCompanyType = new System.Windows.Forms.Label();
			this.textBoxBillMemo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxBillNo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.dateTimePickerBillDate = new System.Windows.Forms.DateTimePicker();
			this.comboBoxComPany = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBoxProject = new System.Windows.Forms.ComboBox();
			this.labelMoneyType = new System.Windows.Forms.Label();
			this.comboBoxMoneyType = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.labelYW = new System.Windows.Forms.Label();
			this.textBoxBillMoney = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelCompanyType
			// 
			this.labelCompanyType.Location = new System.Drawing.Point(333, 61);
			this.labelCompanyType.Name = "labelCompanyType";
			this.labelCompanyType.Size = new System.Drawing.Size(61, 23);
			this.labelCompanyType.TabIndex = 0;
			this.labelCompanyType.Text = "客  户：";
			this.labelCompanyType.Click += new System.EventHandler(this.Label1Click);
			// 
			// textBoxBillMemo
			// 
			this.textBoxBillMemo.Location = new System.Drawing.Point(94, 130);
			this.textBoxBillMemo.Name = "textBoxBillMemo";
			this.textBoxBillMemo.Size = new System.Drawing.Size(174, 21);
			this.textBoxBillMemo.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(25, 133);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "说  明：";
			// 
			// textBoxBillNo
			// 
			this.textBoxBillNo.Location = new System.Drawing.Point(94, 58);
			this.textBoxBillNo.Name = "textBoxBillNo";
			this.textBoxBillNo.ReadOnly = true;
			this.textBoxBillNo.Size = new System.Drawing.Size(174, 21);
			this.textBoxBillNo.TabIndex = 3;
			this.textBoxBillNo.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(25, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "业务日期：";
			// 
			// dateTimePickerBillDate
			// 
			this.dateTimePickerBillDate.Location = new System.Drawing.Point(94, 22);
			this.dateTimePickerBillDate.Name = "dateTimePickerBillDate";
			this.dateTimePickerBillDate.Size = new System.Drawing.Size(174, 21);
			this.dateTimePickerBillDate.TabIndex = 0;
			// 
			// comboBoxComPany
			// 
			this.comboBoxComPany.FormattingEnabled = true;
			this.comboBoxComPany.Location = new System.Drawing.Point(414, 58);
			this.comboBoxComPany.Name = "comboBoxComPany";
			this.comboBoxComPany.Size = new System.Drawing.Size(174, 20);
			this.comboBoxComPany.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(333, 97);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "工程项目：";
			// 
			// comboBoxProject
			// 
			this.comboBoxProject.FormattingEnabled = true;
			this.comboBoxProject.Location = new System.Drawing.Point(414, 94);
			this.comboBoxProject.Name = "comboBoxProject";
			this.comboBoxProject.Size = new System.Drawing.Size(174, 20);
			this.comboBoxProject.TabIndex = 6;
			// 
			// labelMoneyType
			// 
			this.labelMoneyType.Location = new System.Drawing.Point(333, 133);
			this.labelMoneyType.Name = "labelMoneyType";
			this.labelMoneyType.Size = new System.Drawing.Size(75, 23);
			this.labelMoneyType.TabIndex = 0;
			this.labelMoneyType.Text = "收入项目：";
			// 
			// comboBoxMoneyType
			// 
			this.comboBoxMoneyType.FormattingEnabled = true;
			this.comboBoxMoneyType.Location = new System.Drawing.Point(414, 130);
			this.comboBoxMoneyType.Name = "comboBoxMoneyType";
			this.comboBoxMoneyType.Size = new System.Drawing.Size(174, 20);
			this.comboBoxMoneyType.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(25, 61);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "业务单号：";
			this.label6.Click += new System.EventHandler(this.Label1Click);
			// 
			// labelYW
			// 
			this.labelYW.Location = new System.Drawing.Point(25, 97);
			this.labelYW.Name = "labelYW";
			this.labelYW.Size = new System.Drawing.Size(100, 23);
			this.labelYW.TabIndex = 0;
			this.labelYW.Text = "业务金额：";
			// 
			// textBoxBillMoney
			// 
			this.textBoxBillMoney.Location = new System.Drawing.Point(94, 94);
			this.textBoxBillMoney.Name = "textBoxBillMoney";
			this.textBoxBillMoney.Size = new System.Drawing.Size(174, 21);
			this.textBoxBillMoney.TabIndex = 5;
			this.textBoxBillMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxBillMoneyKeyPress);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(414, 175);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 9;
			this.buttonSave.Text = "保存";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(513, 175);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 10;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// FormAccountBill
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(598, 217);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.comboBoxMoneyType);
			this.Controls.Add(this.comboBoxProject);
			this.Controls.Add(this.comboBoxComPany);
			this.Controls.Add(this.dateTimePickerBillDate);
			this.Controls.Add(this.textBoxBillNo);
			this.Controls.Add(this.textBoxBillMoney);
			this.Controls.Add(this.textBoxBillMemo);
			this.Controls.Add(this.labelMoneyType);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.labelYW);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.labelCompanyType);
			this.Name = "FormAccountBill";
			this.Text = "FormAccountBill";
			this.Load += new System.EventHandler(this.FormAccountBillLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
