/*
 * 由SharpDevelop创建。
 * 用户： Dengyong
 * 日期: 2017-05-19
 * 时间: 10:21
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormGoodsTypeChange
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private MaterialMIS.ComboBoxTreeView comboBoxTreeView1;
		private System.Windows.Forms.Button buttonChange;
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
			this.comboBoxTreeView1 = new MaterialMIS.ComboBoxTreeView();
			this.buttonChange = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(28, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(195, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "请指定将更改到的材料类别：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxTreeView1
			// 
			this.comboBoxTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxTreeView1.DropDownHeight = 120;
			this.comboBoxTreeView1.FormattingEnabled = true;
			this.comboBoxTreeView1.IntegralHeight = false;
			this.comboBoxTreeView1.ItemHeight = 12;
			this.comboBoxTreeView1.Location = new System.Drawing.Point(28, 35);
			this.comboBoxTreeView1.Name = "comboBoxTreeView1";
			this.comboBoxTreeView1.Size = new System.Drawing.Size(353, 20);
			this.comboBoxTreeView1.TabIndex = 20;
			// 
			// buttonChange
			// 
			this.buttonChange.Location = new System.Drawing.Point(225, 162);
			this.buttonChange.Name = "buttonChange";
			this.buttonChange.Size = new System.Drawing.Size(75, 23);
			this.buttonChange.TabIndex = 21;
			this.buttonChange.Text = "确认更改";
			this.buttonChange.UseVisualStyleBackColor = true;
			this.buttonChange.Click += new System.EventHandler(this.ButtonChangeClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(306, 162);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 21;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// FormGoodsTypeChange
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(412, 199);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonChange);
			this.Controls.Add(this.comboBoxTreeView1);
			this.Controls.Add(this.label1);
			this.Name = "FormGoodsTypeChange";
			this.Text = "批量更改货品所属类别";
			this.Load += new System.EventHandler(this.FormGoodsTypeChangeLoad);
			this.ResumeLayout(false);

		}
	}
}
