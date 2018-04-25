/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-22
 * 时间: 15:29
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DomainModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace MaterialMIS
{
	/// <summary>
	/// Description of FormGood.
	/// </summary>
	public partial class FormGood : Form
	{
		public int iGoodsID = 0;
		public string GoodsTypePName;
		public int GoodsTypePID;
		
		public FormGood()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormGoodLoad(object sender, EventArgs e)
		{
			//填充自定义控件
			BLL.GoodsTypeBLL.FillTreeView(comboBoxTreeView1.TreeView);
			if(this.Text == "货品-修改")
			{
				Goods t_Goods = new Goods();
				t_Goods = BLL.GoodsBLL.GetGoods(iGoodsID);
				
				textBoxGoodsName.Text = t_Goods.GoodsName;
				textBoxGoodsNamePY.Text = t_Goods.GoodsNamePY;
				textBoxGoodsPrice.Text = t_Goods.GoodsPrice.ToString();
				textBoxGoodsSpec.Text = t_Goods.GoodsSpec;
				textBoxGoodsUnit.Text = t_Goods.GoodsUnit;
				comboBoxTreeView1.Tag = t_Goods.GoodsTypeID;
				comboBoxTreeView1.Text = t_Goods.GoodsTypeInfo.GoodsTypeName;
				textBoxLimitLow.Text = t_Goods.LimitLow.ToString();
				textBoxLimitUP.Text = t_Goods.LimitUP.ToString();
				if(t_Goods.GoodsPic != null)
				{
					byte[] images = (byte[])t_Goods.GoodsPic;
					MemoryStream ms = new MemoryStream(images);
					Bitmap bmp = new Bitmap(ms);
					pictureBoxGoodsPic.Image = bmp;
				}
				else
				{
					pictureBoxGoodsPic.Image = null;
				}
			}
			else
			{
				comboBoxTreeView1.Text = GoodsTypePName;
				comboBoxTreeView1.Tag = GoodsTypePID;
			}
		}
		
		bool CheckFillOK()
		{
			Regex reg;
			string tStr;
			string pattern;

			if(textBoxGoodsName.Text.Trim() == "")
			{
				MessageBox.Show("未填写货品规格名称！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}

			//材料类别
			if(comboBoxTreeView1.Tag == null)
			{
				MessageBox.Show("未指定材料类别！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			tStr = comboBoxTreeView1.Tag.ToString();
			if(tStr == "1")
			{
				MessageBox.Show("不能指定材料全部类别！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			pattern = @"^\d+$";
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				MessageBox.Show("指定材料类别错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}

			//参考价格
			tStr = textBoxGoodsPrice.Text.Trim();
			pattern = @"^[0-9]+.([0-9]+)?$|^[0-9]*$";
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				MessageBox.Show("单价错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}

			//最低库存
			tStr = textBoxLimitLow.Text.Trim();
			pattern = @"^[0-9]+.([0-9]+)?$|^[0-9]*$";
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				MessageBox.Show("最低库存错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}

			//最高库存
			tStr = textBoxLimitUP.Text.Trim();
			pattern = @"^[0-9]+.([0-9]+)?$|^[0-9]*$";
			reg = new Regex(pattern);
			if(! reg.IsMatch(tStr))
			{
				MessageBox.Show("最高库存错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}

			return true;
		}
		void BtnSaveClick(object sender, EventArgs e)
		{
			if(!CheckFillOK())
			{
				return;
			}

			//保存数据
			if(this.Text == "货品-新增")
			{
				if(textBoxGoodsName.Text.Trim() == "")
				{
					return;
				}
				Goods g = new Goods();
				g.GoodsName = textBoxGoodsName.Text;
				g.GoodsNamePY = textBoxGoodsNamePY.Text;
				if(comboBoxTreeView1.Text.Trim().Length != 0)
				{
					g.GoodsTypeID = Int32.Parse(comboBoxTreeView1.Tag.ToString());
				}
				g.GoodsUnit = textBoxGoodsUnit.Text;
				g.GoodsSpec = textBoxGoodsSpec.Text;
				if(textBoxGoodsPrice.Text.Trim().Length != 0)
				{
					g.GoodsPrice = Convert.ToDecimal(textBoxGoodsPrice.Text);
				}
				if(textBoxLimitLow.Text.Trim().Length != 0)
				{
					g.LimitLow =Convert.ToDecimal(textBoxLimitLow.Text);
				}
				if(textBoxLimitUP.Text.Trim().Length != 0)
				{
					g.LimitUP = Convert.ToDecimal(textBoxLimitUP.Text);
				}
				//图片
				if(pictureBoxGoodsPic.Image != null)
				{
					byte[] defaultImageData = null;
		            System.IO.MemoryStream defaultImageStream = new System.IO.MemoryStream();
		            Bitmap NewImage = new Bitmap(pictureBoxGoodsPic.Image);
		            Image b = (Image)NewImage;
		            b.Save(defaultImageStream, System.Drawing.Imaging.ImageFormat.Bmp);
		            defaultImageData = new byte[defaultImageStream.Length];
		            defaultImageData = defaultImageStream.ToArray();
		            g.GoodsPic = defaultImageData;
				}

				BLL.GoodsBLL.AddGoods(g);
			}
			else
			{
				//编辑状态的保存
				if(textBoxGoodsName.Text.Trim() == "")
				{
					return;
				}
				Goods g = new Goods();
				g.GoodsID = iGoodsID;
				g.GoodsName = textBoxGoodsName.Text;
				g.GoodsNamePY = textBoxGoodsNamePY.Text;
				if(comboBoxTreeView1.Text.Trim().Length != 0)
				{
					g.GoodsTypeID = Int32.Parse(comboBoxTreeView1.Tag.ToString());
				}
				g.GoodsUnit = textBoxGoodsUnit.Text;
				g.GoodsSpec = textBoxGoodsSpec.Text;
				if(textBoxGoodsPrice.Text.Trim().Length != 0)
				{
					g.GoodsPrice = Convert.ToDecimal(textBoxGoodsPrice.Text);
				}
				if(textBoxLimitLow.Text.Trim().Length != 0)
				{
					g.LimitLow =Convert.ToDecimal(textBoxLimitLow.Text);
				}
				if(textBoxLimitUP.Text.Trim().Length != 0)
				{
					g.LimitUP = Convert.ToDecimal(textBoxLimitUP.Text);
				}
				//图片
				if(pictureBoxGoodsPic.Image != null)
				{
					byte[] defaultImageData = null;
		            System.IO.MemoryStream defaultImageStream = new System.IO.MemoryStream();
		            Bitmap NewImage = new Bitmap(pictureBoxGoodsPic.Image);
		            Image b = (Image)NewImage;
		            b.Save(defaultImageStream, System.Drawing.Imaging.ImageFormat.Bmp);
		            defaultImageData = new byte[defaultImageStream.Length];
		            defaultImageData = defaultImageStream.ToArray();
		            g.GoodsPic = defaultImageData;
				}

				BLL.GoodsBLL.UpdateGoods(g);
			}
			this.Close();
//			//清除一些内容准备下次的输入
//			textBoxGoodsName.Clear();
//			textBoxGoodsNamePY.Clear();
//			textBoxGoodsUnit.Clear();
//			textBoxGoodsSpec.Clear();
//			textBoxGoodsPrice.Clear();
//			textBoxLimitLow.Clear();
//			textBoxLimitUP.Clear();
//			pictureBoxGoodsPic.Image = null;
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void TextBoxLimitUPKeyPress(object sender, KeyPressEventArgs e)
		{
			//检测是否已经输入了小数点
			bool IsContainsDot = this.textBoxLimitUP.Text.Contains(".");
			if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
			{
				e.Handled = true;
			}
			else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入
			{
				e.Handled = true;
			}
		}
		void TextBoxLimitLowKeyPress(object sender, KeyPressEventArgs e)
		{
			//检测是否已经输入了小数点
			bool IsContainsDot = this.textBoxLimitLow.Text.Contains(".");
			if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
			{
				e.Handled = true;
			}
			else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入
			{
				e.Handled = true;
			}
		}
		void TextBoxGoodsPriceKeyPress(object sender, KeyPressEventArgs e)
		{
			//检测是否已经输入了小数点
			bool IsContainsDot = this.textBoxGoodsPrice.Text.Contains(".");
			if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
			{
				e.Handled = true;
			}
			else if (IsContainsDot && (e.KeyChar == 46)) //如果输入了小数点，并且再次输入
			{
				e.Handled = true;
			}
		}
		void TextBoxGoodsNameTextChanged(object sender, EventArgs e)
		{
			//取拼音首字母
			textBoxGoodsNamePY.Text = Chinese2PY.GetShortPY2(textBoxGoodsName.Text);
		}
		void PictureBoxGoodsPicDoubleClick(object sender, EventArgs e)
		{
			//选择图片，放到图形控件中
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Title = "请选择要插入的图片";
				ofd.Filter = "JPG图片|*.jpg|BMP图片|*.bmp|Gif图片|*.gif";
				ofd.CheckFileExists = true;
				ofd.CheckPathExists = true;
				ofd.Multiselect = false;
				if(ofd.ShowDialog() == DialogResult.OK)
				{
					pictureBoxGoodsPic.ImageLocation = ofd.FileName; //PictureBox
				}
				else
				{
					MessageBox.Show("你没有选择图片!", "信息提示");
				}

			}
		}
		void ButtonSaveAndNewClick(object sender, EventArgs e)
		{
			if(!CheckFillOK())
			{
				return;
			}

			//保存数据
			if(this.Text == "货品-新增")
			{
				if(textBoxGoodsName.Text.Trim() == "")
				{
					return;
				}
				Goods g = new Goods();
				g.GoodsName = textBoxGoodsName.Text;
				g.GoodsNamePY = textBoxGoodsNamePY.Text;
				if(comboBoxTreeView1.Text.Trim().Length != 0)
				{
					g.GoodsTypeID = Int32.Parse(comboBoxTreeView1.Tag.ToString());
				}
				g.GoodsUnit = textBoxGoodsUnit.Text;
				g.GoodsSpec = textBoxGoodsSpec.Text;
				if(textBoxGoodsPrice.Text.Trim().Length != 0)
				{
					g.GoodsPrice = Convert.ToDecimal(textBoxGoodsPrice.Text);
				}
				if(textBoxLimitLow.Text.Trim().Length != 0)
				{
					g.LimitLow =Convert.ToDecimal(textBoxLimitLow.Text);
				}
				if(textBoxLimitUP.Text.Trim().Length != 0)
				{
					g.LimitUP = Convert.ToDecimal(textBoxLimitUP.Text);
				}
				//图片
				if(pictureBoxGoodsPic.Image != null)
				{
					byte[] defaultImageData = null;
		            System.IO.MemoryStream defaultImageStream = new System.IO.MemoryStream();
		            Bitmap NewImage = new Bitmap(pictureBoxGoodsPic.Image);
		            Image b = (Image)NewImage;
		            b.Save(defaultImageStream, System.Drawing.Imaging.ImageFormat.Bmp);
		            defaultImageData = new byte[defaultImageStream.Length];
		            defaultImageData = defaultImageStream.ToArray();
		            g.GoodsPic = defaultImageData;
				}

				BLL.GoodsBLL.AddGoods(g);
			}
			else
			{
				//编辑状态的保存
				if(textBoxGoodsName.Text.Trim() == "")
				{
					return;
				}
				Goods g = new Goods();
				g.GoodsID = iGoodsID;
				g.GoodsName = textBoxGoodsName.Text;
				g.GoodsNamePY = textBoxGoodsNamePY.Text;
				if(comboBoxTreeView1.Text.Trim().Length != 0)
				{
					g.GoodsTypeID = Int32.Parse(comboBoxTreeView1.Tag.ToString());
				}
				g.GoodsUnit = textBoxGoodsUnit.Text;
				g.GoodsSpec = textBoxGoodsSpec.Text;
				if(textBoxGoodsPrice.Text.Trim().Length != 0)
				{
					g.GoodsPrice = Convert.ToDecimal(textBoxGoodsPrice.Text);
				}
				if(textBoxLimitLow.Text.Trim().Length != 0)
				{
					g.LimitLow =Convert.ToDecimal(textBoxLimitLow.Text);
				}
				if(textBoxLimitUP.Text.Trim().Length != 0)
				{
					g.LimitUP = Convert.ToDecimal(textBoxLimitUP.Text);
				}
				//图片
				if(pictureBoxGoodsPic.Image != null)
				{
					byte[] defaultImageData = null;
		            System.IO.MemoryStream defaultImageStream = new System.IO.MemoryStream();
		            Bitmap NewImage = new Bitmap(pictureBoxGoodsPic.Image);
		            Image b = (Image)NewImage;
		            b.Save(defaultImageStream, System.Drawing.Imaging.ImageFormat.Bmp);
		            defaultImageData = new byte[defaultImageStream.Length];
		            defaultImageData = defaultImageStream.ToArray();
		            g.GoodsPic = defaultImageData;
				}

				BLL.GoodsBLL.UpdateGoods(g);
			}
			//清除一些内容准备下次的输入
			this.Text = "货品-新增";
			textBoxGoodsName.Clear();
			textBoxGoodsNamePY.Clear();
			textBoxGoodsUnit.Clear();
			textBoxGoodsSpec.Clear();
			textBoxGoodsPrice.Clear();
			textBoxLimitLow.Clear();
			textBoxLimitUP.Clear();
			pictureBoxGoodsPic.Image = null;
		}

		
			
	}
}
