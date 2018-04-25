/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-13
 * 时间: 15:35
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormProgOption
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxOptionsID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxOptionsKey;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxOptionsValue;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxOptionsRemark;
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxOptionsID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxOptionsKey = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxOptionsValue = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxOptionsRemark = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "选项ID：";
			// 
			// textBoxOptionsID
			// 
			this.textBoxOptionsID.Location = new System.Drawing.Point(102, 6);
			this.textBoxOptionsID.Name = "textBoxOptionsID";
			this.textBoxOptionsID.ReadOnly = true;
			this.textBoxOptionsID.Size = new System.Drawing.Size(226, 21);
			this.textBoxOptionsID.TabIndex = 0;
			this.textBoxOptionsID.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "选项Key：";
			// 
			// textBoxOptionsKey
			// 
			this.textBoxOptionsKey.Location = new System.Drawing.Point(102, 49);
			this.textBoxOptionsKey.Name = "textBoxOptionsKey";
			this.textBoxOptionsKey.Size = new System.Drawing.Size(226, 21);
			this.textBoxOptionsKey.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 95);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "选项Value：";
			// 
			// textBoxOptionsValue
			// 
			this.textBoxOptionsValue.Location = new System.Drawing.Point(102, 93);
			this.textBoxOptionsValue.Multiline = true;
			this.textBoxOptionsValue.Name = "textBoxOptionsValue";
			this.textBoxOptionsValue.Size = new System.Drawing.Size(226, 57);
			this.textBoxOptionsValue.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 163);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(84, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "选项说明：";
			// 
			// textBoxOptionsRemark
			// 
			this.textBoxOptionsRemark.Location = new System.Drawing.Point(102, 160);
			this.textBoxOptionsRemark.Multiline = true;
			this.textBoxOptionsRemark.Name = "textBoxOptionsRemark";
			this.textBoxOptionsRemark.Size = new System.Drawing.Size(226, 57);
			this.textBoxOptionsRemark.TabIndex = 3;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(163, 235);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "保存";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(253, 235);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// FormProgOpion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(342, 265);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxOptionsRemark);
			this.Controls.Add(this.textBoxOptionsValue);
			this.Controls.Add(this.textBoxOptionsKey);
			this.Controls.Add(this.textBoxOptionsID);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormProgOption";
			this.Text = "FormProgOption";
			this.Load += new System.EventHandler(this.FormProgOptionLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
