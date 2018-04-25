/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-03
 * 时间: 9:08
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormCompany
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxCompanyID;
		private System.Windows.Forms.TextBox textBoxComanyName;
		private System.Windows.Forms.TextBox textBoxLinkDetail;
		private System.Windows.Forms.TextBox textBoxSKName;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxSKBank;
		private System.Windows.Forms.TextBox textBoxSKAccount;
		private System.Windows.Forms.RadioButton radioButton4;
		
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
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxCompanyID = new System.Windows.Forms.TextBox();
			this.textBoxComanyName = new System.Windows.Forms.TextBox();
			this.textBoxLinkDetail = new System.Windows.Forms.TextBox();
			this.textBoxSKName = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxSKBank = new System.Windows.Forms.TextBox();
			this.textBoxSKAccount = new System.Windows.Forms.TextBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(22, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "单位ID:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(22, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(119, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "单位名称:";
			// 
			// radioButton1
			// 
			this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButton1.Location = new System.Drawing.Point(259, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(59, 24);
			this.radioButton1.TabIndex = 2;
			this.radioButton1.Text = "客户";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButton2.Location = new System.Drawing.Point(331, 16);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(65, 24);
			this.radioButton2.TabIndex = 3;
			this.radioButton2.Text = "供应商";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(22, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "联系信息:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(22, 169);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(84, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "收款人:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(22, 237);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(84, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "收款帐号:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxCompanyID
			// 
			this.textBoxCompanyID.Location = new System.Drawing.Point(128, 16);
			this.textBoxCompanyID.Name = "textBoxCompanyID";
			this.textBoxCompanyID.ReadOnly = true;
			this.textBoxCompanyID.Size = new System.Drawing.Size(45, 21);
			this.textBoxCompanyID.TabIndex = 0;
			this.textBoxCompanyID.TabStop = false;
			// 
			// textBoxComanyName
			// 
			this.textBoxComanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxComanyName.Location = new System.Drawing.Point(128, 52);
			this.textBoxComanyName.Name = "textBoxComanyName";
			this.textBoxComanyName.Size = new System.Drawing.Size(333, 21);
			this.textBoxComanyName.TabIndex = 4;
			// 
			// textBoxLinkDetail
			// 
			this.textBoxLinkDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLinkDetail.Location = new System.Drawing.Point(128, 96);
			this.textBoxLinkDetail.Multiline = true;
			this.textBoxLinkDetail.Name = "textBoxLinkDetail";
			this.textBoxLinkDetail.Size = new System.Drawing.Size(333, 58);
			this.textBoxLinkDetail.TabIndex = 5;
			// 
			// textBoxSKName
			// 
			this.textBoxSKName.Location = new System.Drawing.Point(128, 170);
			this.textBoxSKName.Name = "textBoxSKName";
			this.textBoxSKName.Size = new System.Drawing.Size(333, 21);
			this.textBoxSKName.TabIndex = 6;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(301, 284);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 9;
			this.buttonSave.Text = "保存";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(386, 284);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 10;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// radioButton3
			// 
			this.radioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButton3.Checked = true;
			this.radioButton3.Location = new System.Drawing.Point(188, 16);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(65, 24);
			this.radioButton3.TabIndex = 1;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "班组";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(22, 203);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(84, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "开户行:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxSKBank
			// 
			this.textBoxSKBank.Location = new System.Drawing.Point(128, 204);
			this.textBoxSKBank.Name = "textBoxSKBank";
			this.textBoxSKBank.Size = new System.Drawing.Size(333, 21);
			this.textBoxSKBank.TabIndex = 7;
			// 
			// textBoxSKAccount
			// 
			this.textBoxSKAccount.Location = new System.Drawing.Point(128, 238);
			this.textBoxSKAccount.Name = "textBoxSKAccount";
			this.textBoxSKAccount.Size = new System.Drawing.Size(333, 21);
			this.textBoxSKAccount.TabIndex = 8;
			// 
			// radioButton4
			// 
			this.radioButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButton4.Location = new System.Drawing.Point(402, 15);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(65, 24);
			this.radioButton4.TabIndex = 3;
			this.radioButton4.Text = "租赁商";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// FormCompany
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(473, 320);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.radioButton4);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.textBoxLinkDetail);
			this.Controls.Add(this.textBoxComanyName);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.textBoxSKAccount);
			this.Controls.Add(this.textBoxSKBank);
			this.Controls.Add(this.textBoxSKName);
			this.Controls.Add(this.textBoxCompanyID);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormCompany";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormCompany";
			this.Load += new System.EventHandler(this.FormCompanyLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
