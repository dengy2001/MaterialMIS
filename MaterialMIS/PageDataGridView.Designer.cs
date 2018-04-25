/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-17
 * 时间: 17:00
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class PageDataGridView
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button buttonFirst;
		private System.Windows.Forms.Button buttonPrev;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Button buttonLast;
		private System.Windows.Forms.Label labelPage;
		private System.Windows.Forms.TextBox textBoxGo;
		private System.Windows.Forms.Button buttonJump;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.buttonFirst = new System.Windows.Forms.Button();
			this.buttonPrev = new System.Windows.Forms.Button();
			this.buttonNext = new System.Windows.Forms.Button();
			this.buttonLast = new System.Windows.Forms.Button();
			this.labelPage = new System.Windows.Forms.Label();
			this.textBoxGo = new System.Windows.Forms.TextBox();
			this.buttonJump = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(533, 273);
			this.dataGridView1.TabIndex = 0;
			// 
			// buttonFirst
			// 
			this.buttonFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonFirst.Location = new System.Drawing.Point(3, 282);
			this.buttonFirst.Name = "buttonFirst";
			this.buttonFirst.Size = new System.Drawing.Size(54, 23);
			this.buttonFirst.TabIndex = 1;
			this.buttonFirst.Text = "首页";
			this.buttonFirst.UseVisualStyleBackColor = true;
			this.buttonFirst.Click += new System.EventHandler(this.ButtonFirstClick);
			// 
			// buttonPrev
			// 
			this.buttonPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonPrev.Location = new System.Drawing.Point(63, 282);
			this.buttonPrev.Name = "buttonPrev";
			this.buttonPrev.Size = new System.Drawing.Size(54, 23);
			this.buttonPrev.TabIndex = 1;
			this.buttonPrev.Text = "上一页";
			this.buttonPrev.UseVisualStyleBackColor = true;
			this.buttonPrev.Click += new System.EventHandler(this.ButtonPrevClick);
			// 
			// buttonNext
			// 
			this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonNext.Location = new System.Drawing.Point(123, 282);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.Size = new System.Drawing.Size(54, 23);
			this.buttonNext.TabIndex = 1;
			this.buttonNext.Text = "下一页";
			this.buttonNext.UseVisualStyleBackColor = true;
			this.buttonNext.Click += new System.EventHandler(this.ButtonNextClick);
			// 
			// buttonLast
			// 
			this.buttonLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonLast.Location = new System.Drawing.Point(183, 282);
			this.buttonLast.Name = "buttonLast";
			this.buttonLast.Size = new System.Drawing.Size(54, 23);
			this.buttonLast.TabIndex = 1;
			this.buttonLast.Text = "末页";
			this.buttonLast.UseVisualStyleBackColor = true;
			this.buttonLast.Click += new System.EventHandler(this.ButtonLastClick);
			// 
			// labelPage
			// 
			this.labelPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.labelPage.Location = new System.Drawing.Point(243, 282);
			this.labelPage.Name = "labelPage";
			this.labelPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.labelPage.Size = new System.Drawing.Size(197, 23);
			this.labelPage.TabIndex = 2;
			this.labelPage.Text = "第 000 页 共 000 页";
			this.labelPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxGo
			// 
			this.textBoxGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxGo.Location = new System.Drawing.Point(439, 283);
			this.textBoxGo.Name = "textBoxGo";
			this.textBoxGo.Size = new System.Drawing.Size(37, 21);
			this.textBoxGo.TabIndex = 3;
			this.textBoxGo.Text = "1";
			this.textBoxGo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// buttonJump
			// 
			this.buttonJump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonJump.Location = new System.Drawing.Point(482, 282);
			this.buttonJump.Name = "buttonJump";
			this.buttonJump.Size = new System.Drawing.Size(54, 23);
			this.buttonJump.TabIndex = 1;
			this.buttonJump.Text = "跳转";
			this.buttonJump.UseVisualStyleBackColor = true;
			this.buttonJump.Click += new System.EventHandler(this.ButtonJumpClick);
			// 
			// PageDataGridView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textBoxGo);
			this.Controls.Add(this.labelPage);
			this.Controls.Add(this.buttonJump);
			this.Controls.Add(this.buttonLast);
			this.Controls.Add(this.buttonNext);
			this.Controls.Add(this.buttonPrev);
			this.Controls.Add(this.buttonFirst);
			this.Controls.Add(this.dataGridView1);
			this.Name = "PageDataGridView";
			this.Size = new System.Drawing.Size(539, 307);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
