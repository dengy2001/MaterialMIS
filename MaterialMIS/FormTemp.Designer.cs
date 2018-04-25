/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-05-16
 * 时间: 12:25
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormTemp
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private MaterialMIS.PageDataGridView pageDataGridView1;
		private System.Windows.Forms.Button button1;
		
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
			this.pageDataGridView1 = new MaterialMIS.PageDataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pageDataGridView1
			// 
			this.pageDataGridView1.CurPage = 0;
			this.pageDataGridView1.Location = new System.Drawing.Point(12, 23);
			this.pageDataGridView1.Name = "pageDataGridView1";
			this.pageDataGridView1.PageRecords = 0;
			this.pageDataGridView1.Size = new System.Drawing.Size(684, 226);
			this.pageDataGridView1.TabIndex = 0;
			this.pageDataGridView1.TotalRecord = 0;
			this.pageDataGridView1.PageFirstButtonClick += new System.EventHandler(this.PageDataGridView1PageFirstButtonClick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(291, 255);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// FormTemp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(708, 318);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pageDataGridView1);
			this.Name = "FormTemp";
			this.Text = "FormTemp";
			this.Load += new System.EventHandler(this.FormTempLoad);
			this.ResumeLayout(false);

		}
	}
}
