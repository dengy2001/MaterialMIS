/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-10-27
 * 时间: 16:18
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace MaterialMIS
{
	partial class FormStock1
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.RadioButton radioButtonCurStock;
		private System.Windows.Forms.RadioButton radioButtonHisStock;
		private System.Windows.Forms.ComboBox comboBoxPeriod;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCX;
		private System.Windows.Forms.Button buttonPrint;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBoxFindGoods;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.Button buttonPrint1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 历史入库价ToolStripMenuItem;
		private System.Windows.Forms.ComboBox comboBoxWareHouseID;
		private System.Windows.Forms.Label label2;
		
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
			this.components = new System.ComponentModel.Container();
			this.panel2 = new System.Windows.Forms.Panel();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.历史入库价ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.radioButtonCurStock = new System.Windows.Forms.RadioButton();
			this.radioButtonHisStock = new System.Windows.Forms.RadioButton();
			this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonCX = new System.Windows.Forms.Button();
			this.buttonPrint = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.textBoxFindGoods = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.buttonPrint1 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBoxWareHouseID = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.treeView1);
			this.panel2.Controls.Add(this.dataGridView1);
			this.panel2.Location = new System.Drawing.Point(27, 135);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(693, 139);
			this.panel2.TabIndex = 6;
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.treeView1.Location = new System.Drawing.Point(13, 3);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(153, 133);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1AfterSelect);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Column1});
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridView1.Location = new System.Drawing.Point(172, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(509, 133);
			this.dataGridView1.TabIndex = 1;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Column1";
			this.Column1.Name = "Column1";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.历史入库价ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
			// 
			// 历史入库价ToolStripMenuItem
			// 
			this.历史入库价ToolStripMenuItem.Name = "历史入库价ToolStripMenuItem";
			this.历史入库价ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.历史入库价ToolStripMenuItem.Text = "历史入库价";
			this.历史入库价ToolStripMenuItem.Click += new System.EventHandler(this.历史入库价ToolStripMenuItemClick);
			// 
			// radioButtonCurStock
			// 
			this.radioButtonCurStock.Checked = true;
			this.radioButtonCurStock.Location = new System.Drawing.Point(27, 40);
			this.radioButtonCurStock.Name = "radioButtonCurStock";
			this.radioButtonCurStock.Size = new System.Drawing.Size(82, 24);
			this.radioButtonCurStock.TabIndex = 0;
			this.radioButtonCurStock.TabStop = true;
			this.radioButtonCurStock.Text = "当前库存";
			this.radioButtonCurStock.UseVisualStyleBackColor = true;
			this.radioButtonCurStock.Click += new System.EventHandler(this.RadioButtonCurStockClick);
			// 
			// radioButtonHisStock
			// 
			this.radioButtonHisStock.Location = new System.Drawing.Point(137, 40);
			this.radioButtonHisStock.Name = "radioButtonHisStock";
			this.radioButtonHisStock.Size = new System.Drawing.Size(91, 24);
			this.radioButtonHisStock.TabIndex = 1;
			this.radioButtonHisStock.Text = "历史库存";
			this.radioButtonHisStock.UseVisualStyleBackColor = true;
			this.radioButtonHisStock.Click += new System.EventHandler(this.RadioButtonHisStockClick);
			// 
			// comboBoxPeriod
			// 
			this.comboBoxPeriod.FormattingEnabled = true;
			this.comboBoxPeriod.Location = new System.Drawing.Point(402, 42);
			this.comboBoxPeriod.Name = "comboBoxPeriod";
			this.comboBoxPeriod.Size = new System.Drawing.Size(96, 20);
			this.comboBoxPeriod.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(284, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "请选择库存周期：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonCX
			// 
			this.buttonCX.Enabled = false;
			this.buttonCX.Location = new System.Drawing.Point(520, 41);
			this.buttonCX.Name = "buttonCX";
			this.buttonCX.Size = new System.Drawing.Size(115, 23);
			this.buttonCX.TabIndex = 3;
			this.buttonCX.Text = "查询历史库存";
			this.buttonCX.UseVisualStyleBackColor = true;
			this.buttonCX.Click += new System.EventHandler(this.ButtonCXClick);
			// 
			// buttonPrint
			// 
			this.buttonPrint.Location = new System.Drawing.Point(520, 76);
			this.buttonPrint.Name = "buttonPrint";
			this.buttonPrint.Size = new System.Drawing.Size(115, 23);
			this.buttonPrint.TabIndex = 5;
			this.buttonPrint.Text = "全库存打印";
			this.buttonPrint.UseVisualStyleBackColor = true;
			this.buttonPrint.Click += new System.EventHandler(this.ButtonPrintClick);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(27, 76);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(67, 23);
			this.label10.TabIndex = 0;
			this.label10.Text = "限定货品：";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxFindGoods
			// 
			this.textBoxFindGoods.Location = new System.Drawing.Point(100, 76);
			this.textBoxFindGoods.Name = "textBoxFindGoods";
			this.textBoxFindGoods.Size = new System.Drawing.Size(398, 21);
			this.textBoxFindGoods.TabIndex = 4;
			this.textBoxFindGoods.TextChanged += new System.EventHandler(this.TextBoxFindGoodsTextChanged);
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(27, 103);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(104, 24);
			this.checkBox1.TabIndex = 7;
			this.checkBox1.Text = "显示正库存";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(124, 103);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(104, 24);
			this.checkBox2.TabIndex = 7;
			this.checkBox2.Text = "显示零库存";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(216, 103);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(104, 24);
			this.checkBox3.TabIndex = 7;
			this.checkBox3.Text = "显示负库存";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.CheckBox3CheckedChanged);
			// 
			// buttonPrint1
			// 
			this.buttonPrint1.Location = new System.Drawing.Point(520, 103);
			this.buttonPrint1.Name = "buttonPrint1";
			this.buttonPrint1.Size = new System.Drawing.Size(115, 23);
			this.buttonPrint1.TabIndex = 5;
			this.buttonPrint1.Text = "打印非零库存";
			this.buttonPrint1.UseVisualStyleBackColor = true;
			this.buttonPrint1.Click += new System.EventHandler(this.ButtonPrint1Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(383, 103);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(115, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "打印选中库存";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// comboBoxWareHouseID
			// 
			this.comboBoxWareHouseID.FormattingEnabled = true;
			this.comboBoxWareHouseID.Location = new System.Drawing.Point(124, 12);
			this.comboBoxWareHouseID.Name = "comboBoxWareHouseID";
			this.comboBoxWareHouseID.Size = new System.Drawing.Size(183, 20);
			this.comboBoxWareHouseID.TabIndex = 8;
			this.comboBoxWareHouseID.SelectedIndexChanged += new System.EventHandler(this.ComboBoxWareHouseIDSelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(27, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "请指定库房：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormStock1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(732, 286);
			this.Controls.Add(this.comboBoxWareHouseID);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBoxFindGoods);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonPrint1);
			this.Controls.Add(this.buttonPrint);
			this.Controls.Add(this.buttonCX);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxPeriod);
			this.Controls.Add(this.radioButtonHisStock);
			this.Controls.Add(this.radioButtonCurStock);
			this.Controls.Add(this.panel2);
			this.Name = "FormStock1";
			this.Text = "库存信息";
			this.Load += new System.EventHandler(this.FormStock1Load);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
