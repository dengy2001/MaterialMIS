/*
 * Created by SharpDevelop.
 * User: Dengyong
 * Date: 2016-11-22
 * Time: 10:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MaterialMIS
{
	partial class FormLeaseItem
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBoxLeasePrice;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxLeaseUnit;
		private System.Windows.Forms.TextBox textBoxMName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBoxRepairPrice;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBoxRepairFactor;
		private System.Windows.Forms.TextBox textBoxRepairUnit;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBoxLoadingPrice;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBoxLoadingUnit;
		private System.Windows.Forms.TextBox textBoxLoadingFactor;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxItemsID;
		private System.Windows.Forms.TextBox textBoxHTID;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBoxLeasePrice = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxLeaseUnit = new System.Windows.Forms.TextBox();
			this.textBoxMName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBoxRepairPrice = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBoxRepairFactor = new System.Windows.Forms.TextBox();
			this.textBoxRepairUnit = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBoxLoadingPrice = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxLoadingUnit = new System.Windows.Forms.TextBox();
			this.textBoxLoadingFactor = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxItemsID = new System.Windows.Forms.TextBox();
			this.textBoxHTID = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(42, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "租赁项ID：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(247, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "租赁合同ID：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBoxLeasePrice);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textBoxLeaseUnit);
			this.groupBox1.Controls.Add(this.textBoxMName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(36, 97);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(493, 56);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "租赁项";
			// 
			// textBoxLeasePrice
			// 
			this.textBoxLeasePrice.Location = new System.Drawing.Point(391, 18);
			this.textBoxLeasePrice.Name = "textBoxLeasePrice";
			this.textBoxLeasePrice.Size = new System.Drawing.Size(81, 21);
			this.textBoxLeasePrice.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(341, 17);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "单价：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxLeaseUnit
			// 
			this.textBoxLeaseUnit.Location = new System.Drawing.Point(261, 18);
			this.textBoxLeaseUnit.Name = "textBoxLeaseUnit";
			this.textBoxLeaseUnit.Size = new System.Drawing.Size(44, 21);
			this.textBoxLeaseUnit.TabIndex = 1;
			// 
			// textBoxMName
			// 
			this.textBoxMName.Location = new System.Drawing.Point(82, 18);
			this.textBoxMName.Name = "textBoxMName";
			this.textBoxMName.Size = new System.Drawing.Size(100, 21);
			this.textBoxMName.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(211, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "单位：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(30, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "名称：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBoxRepairPrice);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.textBoxRepairFactor);
			this.groupBox2.Controls.Add(this.textBoxRepairUnit);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Location = new System.Drawing.Point(36, 220);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(493, 56);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "维修";
			// 
			// textBoxRepairPrice
			// 
			this.textBoxRepairPrice.Location = new System.Drawing.Point(391, 20);
			this.textBoxRepairPrice.Name = "textBoxRepairPrice";
			this.textBoxRepairPrice.Size = new System.Drawing.Size(81, 21);
			this.textBoxRepairPrice.TabIndex = 2;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(341, 17);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(78, 23);
			this.label11.TabIndex = 0;
			this.label11.Text = "单价：";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxRepairFactor
			// 
			this.textBoxRepairFactor.Location = new System.Drawing.Point(261, 19);
			this.textBoxRepairFactor.Name = "textBoxRepairFactor";
			this.textBoxRepairFactor.Size = new System.Drawing.Size(44, 21);
			this.textBoxRepairFactor.TabIndex = 1;
			// 
			// textBoxRepairUnit
			// 
			this.textBoxRepairUnit.Location = new System.Drawing.Point(82, 20);
			this.textBoxRepairUnit.Name = "textBoxRepairUnit";
			this.textBoxRepairUnit.Size = new System.Drawing.Size(44, 21);
			this.textBoxRepairUnit.TabIndex = 0;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(30, 19);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 23);
			this.label6.TabIndex = 0;
			this.label6.Text = "单位：";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(192, 18);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(78, 23);
			this.label10.TabIndex = 0;
			this.label10.Text = "1/换算因子：";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBoxLoadingPrice);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.textBoxLoadingUnit);
			this.groupBox3.Controls.Add(this.textBoxLoadingFactor);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Location = new System.Drawing.Point(36, 159);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(493, 55);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "装卸";
			// 
			// textBoxLoadingPrice
			// 
			this.textBoxLoadingPrice.Location = new System.Drawing.Point(391, 20);
			this.textBoxLoadingPrice.Name = "textBoxLoadingPrice";
			this.textBoxLoadingPrice.Size = new System.Drawing.Size(81, 21);
			this.textBoxLoadingPrice.TabIndex = 2;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(341, 20);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(51, 23);
			this.label9.TabIndex = 0;
			this.label9.Text = "单价：";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxLoadingUnit
			// 
			this.textBoxLoadingUnit.Location = new System.Drawing.Point(82, 22);
			this.textBoxLoadingUnit.Name = "textBoxLoadingUnit";
			this.textBoxLoadingUnit.Size = new System.Drawing.Size(44, 21);
			this.textBoxLoadingUnit.TabIndex = 0;
			// 
			// textBoxLoadingFactor
			// 
			this.textBoxLoadingFactor.Location = new System.Drawing.Point(261, 20);
			this.textBoxLoadingFactor.Name = "textBoxLoadingFactor";
			this.textBoxLoadingFactor.Size = new System.Drawing.Size(44, 21);
			this.textBoxLoadingFactor.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(192, 20);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(78, 23);
			this.label8.TabIndex = 0;
			this.label8.Text = "1/换算因子：";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(30, 20);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(59, 23);
			this.label7.TabIndex = 0;
			this.label7.Text = "单位：";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxItemsID
			// 
			this.textBoxItemsID.Location = new System.Drawing.Point(114, 30);
			this.textBoxItemsID.Name = "textBoxItemsID";
			this.textBoxItemsID.ReadOnly = true;
			this.textBoxItemsID.Size = new System.Drawing.Size(100, 21);
			this.textBoxItemsID.TabIndex = 0;
			this.textBoxItemsID.TabStop = false;
			// 
			// textBoxHTID
			// 
			this.textBoxHTID.Location = new System.Drawing.Point(329, 30);
			this.textBoxHTID.Name = "textBoxHTID";
			this.textBoxHTID.ReadOnly = true;
			this.textBoxHTID.Size = new System.Drawing.Size(100, 21);
			this.textBoxHTID.TabIndex = 0;
			this.textBoxHTID.TabStop = false;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(353, 298);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "保存";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(454, 298);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(42, 67);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(104, 24);
			this.radioButton1.TabIndex = 5;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "租赁项";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(143, 67);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(285, 24);
			this.radioButton2.TabIndex = 5;
			this.radioButton2.Text = "单独计费项（按租赁项【单价*数量】计费）";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// FormLeaseItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(545, 331);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxHTID);
			this.Controls.Add(this.textBoxItemsID);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormLeaseItem";
			this.Text = "租赁项信息-新增";
			this.Load += new System.EventHandler(this.FormLeaseItemLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
