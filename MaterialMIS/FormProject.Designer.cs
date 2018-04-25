/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-01
 * 时间: 12:37
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormProject
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxProjectID;
		private System.Windows.Forms.TextBox textBoxProjectName;
		private System.Windows.Forms.TextBox textBoxProjectAbstract;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxContractor;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxDevelpoer;
		
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
			this.textBoxProjectID = new System.Windows.Forms.TextBox();
			this.textBoxProjectName = new System.Windows.Forms.TextBox();
			this.textBoxProjectAbstract = new System.Windows.Forms.TextBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxContractor = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxDevelpoer = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(25, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "项目ID：";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(25, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "项目名称：";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(25, 161);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "项目详情：";
			// 
			// textBoxProjectID
			// 
			this.textBoxProjectID.Location = new System.Drawing.Point(94, 28);
			this.textBoxProjectID.Name = "textBoxProjectID";
			this.textBoxProjectID.ReadOnly = true;
			this.textBoxProjectID.Size = new System.Drawing.Size(323, 21);
			this.textBoxProjectID.TabIndex = 0;
			this.textBoxProjectID.TabStop = false;
			// 
			// textBoxProjectName
			// 
			this.textBoxProjectName.Location = new System.Drawing.Point(94, 71);
			this.textBoxProjectName.Name = "textBoxProjectName";
			this.textBoxProjectName.Size = new System.Drawing.Size(323, 21);
			this.textBoxProjectName.TabIndex = 0;
			// 
			// textBoxProjectAbstract
			// 
			this.textBoxProjectAbstract.Location = new System.Drawing.Point(94, 158);
			this.textBoxProjectAbstract.Multiline = true;
			this.textBoxProjectAbstract.Name = "textBoxProjectAbstract";
			this.textBoxProjectAbstract.Size = new System.Drawing.Size(323, 113);
			this.textBoxProjectAbstract.TabIndex = 3;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(342, 281);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(244, 281);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "保存";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(25, 105);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "承包商：";
			// 
			// textBoxContractor
			// 
			this.textBoxContractor.Location = new System.Drawing.Point(94, 101);
			this.textBoxContractor.Name = "textBoxContractor";
			this.textBoxContractor.Size = new System.Drawing.Size(323, 21);
			this.textBoxContractor.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(25, 132);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "发包商：";
			// 
			// textBoxDevelpoer
			// 
			this.textBoxDevelpoer.Location = new System.Drawing.Point(94, 128);
			this.textBoxDevelpoer.Name = "textBoxDevelpoer";
			this.textBoxDevelpoer.Size = new System.Drawing.Size(323, 21);
			this.textBoxDevelpoer.TabIndex = 2;
			// 
			// FormProject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 317);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.textBoxProjectAbstract);
			this.Controls.Add(this.textBoxDevelpoer);
			this.Controls.Add(this.textBoxContractor);
			this.Controls.Add(this.textBoxProjectName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxProjectID);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormProject";
			this.Text = "FormProject";
			this.Load += new System.EventHandler(this.FormProjectLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
