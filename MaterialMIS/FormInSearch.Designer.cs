/*
 * 由SharpDevelop创建。
 * 用户： Dengyong
 * 日期: 2017-10-4
 * 时间: 12:50
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormInSearch
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxProject;
		private System.Windows.Forms.Button buttonCX;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonSC;
		
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
			this.comboBoxProject = new System.Windows.Forms.ComboBox();
			this.buttonCX = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonSC = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "项目：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxProject
			// 
			this.comboBoxProject.FormattingEnabled = true;
			this.comboBoxProject.Location = new System.Drawing.Point(58, 8);
			this.comboBoxProject.Name = "comboBoxProject";
			this.comboBoxProject.Size = new System.Drawing.Size(168, 20);
			this.comboBoxProject.TabIndex = 6;
			// 
			// buttonCX
			// 
			this.buttonCX.Location = new System.Drawing.Point(241, 7);
			this.buttonCX.Name = "buttonCX";
			this.buttonCX.Size = new System.Drawing.Size(75, 23);
			this.buttonCX.TabIndex = 8;
			this.buttonCX.Text = "查询";
			this.buttonCX.UseVisualStyleBackColor = true;
			this.buttonCX.Click += new System.EventHandler(this.ButtonCXClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 42);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(659, 205);
			this.dataGridView1.TabIndex = 9;
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(596, 7);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 8;
			this.buttonClose.Text = "取消";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// buttonSC
			// 
			this.buttonSC.Location = new System.Drawing.Point(337, 7);
			this.buttonSC.Name = "buttonSC";
			this.buttonSC.Size = new System.Drawing.Size(75, 23);
			this.buttonSC.TabIndex = 10;
			this.buttonSC.Text = "生成限价单";
			this.buttonSC.UseVisualStyleBackColor = true;
			this.buttonSC.Click += new System.EventHandler(this.ButtonSCClick);
			// 
			// FormInSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(683, 259);
			this.Controls.Add(this.buttonSC);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonCX);
			this.Controls.Add(this.comboBoxProject);
			this.Controls.Add(this.label1);
			this.Name = "FormInSearch";
			this.Text = "购入材料查询";
			this.Load += new System.EventHandler(this.FormInSearchLoad);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
