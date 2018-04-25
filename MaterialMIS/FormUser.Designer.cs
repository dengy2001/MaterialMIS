/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-20
 * 时间: 10:31
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormUser
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
		private System.Windows.Forms.TextBox textBoxUserID;
		private System.Windows.Forms.TextBox textBoxUserName;
		private System.Windows.Forms.TextBox textBoxUserDisplayName;
		private System.Windows.Forms.TextBox textBoxUserPassword;
		private System.Windows.Forms.TextBox textBoxUserPassword1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		
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
			this.textBoxUserID = new System.Windows.Forms.TextBox();
			this.textBoxUserName = new System.Windows.Forms.TextBox();
			this.textBoxUserDisplayName = new System.Windows.Forms.TextBox();
			this.textBoxUserPassword = new System.Windows.Forms.TextBox();
			this.textBoxUserPassword1 = new System.Windows.Forms.TextBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(34, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "UserID:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(34, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "登录名:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(34, 89);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "显示名:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(34, 129);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "密  码:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(34, 169);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "确认密码:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxUserID
			// 
			this.textBoxUserID.Location = new System.Drawing.Point(95, 10);
			this.textBoxUserID.Name = "textBoxUserID";
			this.textBoxUserID.ReadOnly = true;
			this.textBoxUserID.Size = new System.Drawing.Size(154, 21);
			this.textBoxUserID.TabIndex = 0;
			// 
			// textBoxUserName
			// 
			this.textBoxUserName.Location = new System.Drawing.Point(95, 50);
			this.textBoxUserName.Name = "textBoxUserName";
			this.textBoxUserName.Size = new System.Drawing.Size(154, 21);
			this.textBoxUserName.TabIndex = 1;
			// 
			// textBoxUserDisplayName
			// 
			this.textBoxUserDisplayName.Location = new System.Drawing.Point(95, 90);
			this.textBoxUserDisplayName.Name = "textBoxUserDisplayName";
			this.textBoxUserDisplayName.Size = new System.Drawing.Size(154, 21);
			this.textBoxUserDisplayName.TabIndex = 2;
			// 
			// textBoxUserPassword
			// 
			this.textBoxUserPassword.Location = new System.Drawing.Point(95, 130);
			this.textBoxUserPassword.Name = "textBoxUserPassword";
			this.textBoxUserPassword.PasswordChar = 'X';
			this.textBoxUserPassword.Size = new System.Drawing.Size(154, 21);
			this.textBoxUserPassword.TabIndex = 3;
			// 
			// textBoxUserPassword1
			// 
			this.textBoxUserPassword1.Location = new System.Drawing.Point(95, 170);
			this.textBoxUserPassword1.Name = "textBoxUserPassword1";
			this.textBoxUserPassword1.PasswordChar = 'X';
			this.textBoxUserPassword1.Size = new System.Drawing.Size(154, 21);
			this.textBoxUserPassword1.TabIndex = 4;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(174, 213);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(93, 213);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "确认";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// FormUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 250);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.textBoxUserPassword1);
			this.Controls.Add(this.textBoxUserPassword);
			this.Controls.Add(this.textBoxUserDisplayName);
			this.Controls.Add(this.textBoxUserName);
			this.Controls.Add(this.textBoxUserID);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormUser";
			this.Load += new System.EventHandler(this.FormUserLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
