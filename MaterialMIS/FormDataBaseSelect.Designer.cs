/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-18
 * 时间: 12:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormDataBaseSelect
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button buttonEnter;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonRemove;
		private MaterialMIS.BaseTextBox baseTextBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private MaterialMIS.BaseTextBox baseTextBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		
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
			this.buttonEnter = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.baseTextBox2 = new MaterialMIS.BaseTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.baseTextBox1 = new MaterialMIS.BaseTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonEnter
			// 
			this.buttonEnter.Location = new System.Drawing.Point(496, 10);
			this.buttonEnter.Name = "buttonEnter";
			this.buttonEnter.Size = new System.Drawing.Size(75, 73);
			this.buttonEnter.TabIndex = 4;
			this.buttonEnter.Text = "进入帐套";
			this.buttonEnter.UseVisualStyleBackColor = true;
			this.buttonEnter.Click += new System.EventHandler(this.ButtonEnterClick);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.ItemHeight = 12;
			this.comboBox1.Location = new System.Drawing.Point(13, 35);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(477, 20);
			this.comboBox1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.panel1.Controls.Add(this.buttonAdd);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(589, 88);
			this.panel1.TabIndex = 2;
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(496, 56);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 0;
			this.buttonAdd.Text = "增加帐套";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Navy;
			this.panel2.Controls.Add(this.comboBox1);
			this.panel2.Controls.Add(this.buttonRemove);
			this.panel2.Location = new System.Drawing.Point(0, 85);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(589, 97);
			this.panel2.TabIndex = 0;
			// 
			// buttonRemove
			// 
			this.buttonRemove.Location = new System.Drawing.Point(496, 34);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(75, 23);
			this.buttonRemove.TabIndex = 0;
			this.buttonRemove.Text = "移除帐套";
			this.buttonRemove.UseVisualStyleBackColor = true;
			this.buttonRemove.Click += new System.EventHandler(this.ButtonRemoveClick);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel3.Controls.Add(this.groupBox2);
			this.panel3.Controls.Add(this.groupBox1);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.buttonEnter);
			this.panel3.Location = new System.Drawing.Point(0, 178);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(589, 98);
			this.panel3.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.baseTextBox2);
			this.groupBox2.Location = new System.Drawing.Point(77, 42);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(239, 30);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			// 
			// baseTextBox2
			// 
			this.baseTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.baseTextBox2.Location = new System.Drawing.Point(3, 11);
			this.baseTextBox2.Name = "baseTextBox2";
			this.baseTextBox2.Size = new System.Drawing.Size(233, 14);
			this.baseTextBox2.TabIndex = 0;
			this.baseTextBox2.UseSystemPasswordChar = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.baseTextBox1);
			this.groupBox1.Location = new System.Drawing.Point(77, 10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(239, 30);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// baseTextBox1
			// 
			this.baseTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.baseTextBox1.Location = new System.Drawing.Point(3, 11);
			this.baseTextBox1.Name = "baseTextBox1";
			this.baseTextBox1.Size = new System.Drawing.Size(233, 14);
			this.baseTextBox1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "密  码：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "用户名：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormDataBaseSelect
			// 
			this.AcceptButton = this.buttonEnter;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(583, 273);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormDataBaseSelect";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "帐套管理";
			this.Load += new System.EventHandler(this.FormDataBaseSelectLoad);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
