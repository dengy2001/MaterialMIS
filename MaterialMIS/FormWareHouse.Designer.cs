/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-02
 * 时间: 12:32
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormWareHouse
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox textBoxWareHouseID;
		private System.Windows.Forms.TextBox textBoxWareHouseName;
		
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
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.textBoxWareHouseID = new System.Windows.Forms.TextBox();
			this.textBoxWareHouseName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "仓库ID：";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "仓库名称：";
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(183, 137);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 2;
			this.buttonSave.Text = "确定";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(274, 137);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// textBoxWareHouseID
			// 
			this.textBoxWareHouseID.Location = new System.Drawing.Point(78, 12);
			this.textBoxWareHouseID.Name = "textBoxWareHouseID";
			this.textBoxWareHouseID.ReadOnly = true;
			this.textBoxWareHouseID.Size = new System.Drawing.Size(271, 21);
			this.textBoxWareHouseID.TabIndex = 0;
			this.textBoxWareHouseID.TabStop = false;
			// 
			// textBoxWareHouseName
			// 
			this.textBoxWareHouseName.Location = new System.Drawing.Point(78, 61);
			this.textBoxWareHouseName.Name = "textBoxWareHouseName";
			this.textBoxWareHouseName.Size = new System.Drawing.Size(271, 21);
			this.textBoxWareHouseName.TabIndex = 1;
			// 
			// FormWareHouse
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(358, 178);
			this.Controls.Add(this.textBoxWareHouseName);
			this.Controls.Add(this.textBoxWareHouseID);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormWareHouse";
			this.Text = "FormWareHouse";
			this.Load += new System.EventHandler(this.FormWareHouseLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
