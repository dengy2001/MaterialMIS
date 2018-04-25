/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-10
 * 时间: 13:25
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MaterialMIS
{
	/// <summary>
	/// Description of TabControlEx.
	/// </summary>
	public partial class TabControlEx : TabControl
	{
		private Color _BoardColor = Color.FromArgb(157, 162, 168);
		public Color BoardColor {
			get { return _BoardColor; }
			set { _BoardColor = value; }
		}
		public Color LineColor
		{
			set{ _lineColor = value;}
			get{ return _lineColor;}
		}
		
		public Color ColorDefaultA
		{
			set{_ColorDefaultA = value;}
			get{return _ColorDefaultA;}
		}
		
		public Color ColorDefaultB
		{
			set{_ColorDefaultB = value;}
			get{return _ColorDefaultB;}
		}
		
		public Color ColorActivateA
		{
			set{_ColorActivateA = value;}
			get{return _ColorActivateA;}
		}
		
		public Color ColorActivateB
		{
			set{_ColorActivateB = value;}
			get{return _ColorActivateB;}
		}
		
		bool CloseEX = false;
		private Color _lineColor = Color.FromArgb(157, 162, 168); //边线颜色
		private Color _ColorDefaultA = Color.FromArgb(231, 231, 231);//默认标签渐变 a
		private Color _ColorDefaultB = Color.FromArgb(255, 255, 255);//默认标签渐变 b
		private Color _ColorActivateA = Color.FromArgb(184, 203, 217);//点击渐变a
		private Color _ColorActivateB = Color.FromArgb(255, 255, 255);//点击渐变a
		
		public TabControlEx()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			base.SetStyle(
				ControlStyles.UserPaint |                      // 控件将自行绘制，而不是通过操作系统来绘制
				ControlStyles.OptimizedDoubleBuffer |          // 该控件首先在缓冲区中绘制，而不是直接绘制到屏幕上，这样可以减少闪烁
				ControlStyles.AllPaintingInWmPaint |           // 控件将忽略 WM_ERASEBKGND 窗口消息以减少闪烁
				ControlStyles.ResizeRedraw |                   // 在调整控件大小时重绘控件
				ControlStyles.SupportsTransparentBackColor,    // 控件接受 alpha 组件小于 255 的 BackColor 以模拟透明
				true);                                         // 设置以上值为 true
			base.UpdateStyles();
			//		this.SizeMode = TabSizeMode.Fixed;  // 大小模式为固定
			//		this.ItemSize = new Size(80, 55);   // 设定每个标签的尺寸
		}
		

//		protected override void OnPaint(PaintEventArgs e)
//		{
//			for (int i = 0; i < this.TabCount; i++)
//			{
//				e.Graphics.DrawRectangle(Pens.Red, this.GetTabRect(i));
//				// Calculate text position
//				Rectangle bounds = this.GetTabRect(i);
//				PointF textPoint = new PointF();
//				SizeF textSize = TextRenderer.MeasureText(this.TabPages[i].Text, this.Font);
//
//				// 注意要加上每个标签的左偏移量X
//				textPoint.X
//					= bounds.X + 5;
//				textPoint.Y
//					= bounds.Bottom - textSize.Height - this.Padding.Y;
//
//				// Draw highlights
//				e.Graphics.DrawString(
//					this.TabPages[i].Text,
//					this.Font,
//					SystemBrushes.ControlText,    // 正常颜色
//					textPoint.X,
//					textPoint.Y);
//
//
//				if(this.SelectedIndex == i && this.SelectedIndex != 0)
//				{
//					//画关闭的X
//					Pen objpen = new Pen(Color.Black);
//					Pen objpen1 = new Pen(Color.White);
//					Point p1 = new Point(bounds.X + bounds.Width - 16 - 5 , bounds.Y + 5 );
//					Point p2 = new Point(bounds.X + bounds.Width - 5 , bounds.Y + 21);
//					Rectangle rt = new Rectangle(p1.X ,p1.Y,16,16);
//					if(CloseEX)
//					{
//						e.Graphics.DrawRectangle(objpen1,rt);
//					}
//					p1 = new Point(rt.X + 3,rt.Y + 3);
//					p2 = new Point(rt.X + 13,rt.Y + 13);
//					e.Graphics.DrawLine(objpen, p1, p2);
//
//					p1 = new Point(rt.X + 13,rt.Y + 3);
//					p2 = new Point(rt.X + 3,rt.Y + 13);
//					e.Graphics.DrawLine(objpen, p1, p2);
//				}
//
//			}
//		}
		
//		protected override void OnMouseEnter(EventArgs e)
//		{
//			mouseover = true;
//			base.OnMouseEnter(e);
//		}
//		protected override void OnMouseLeave(EventArgs e)
//		{
//			mouseover = false;
//			base.OnMouseLeave(e);
//		}
		
		protected override void OnMouseMove(MouseEventArgs e)
		{

			if (TabPageMouseClose(e.Location) != CloseEX)
			{
				CloseEX = !CloseEX;
				this.Invalidate();
			}
			
			base.OnMouseMove(e);
		}
		
		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (TabPageMouseClose(e.Location) )
			{
				this.SelectedTab.Dispose();
			}
			
			//base.OnMouseDown(e);
		}
		
		//判断鼠标是否在关闭按钮上
		private bool TabPageMouseClose(Point pt)
		{
			Rectangle rect = this.GetTabRect(this.SelectedIndex);
			rect = GetCloseRect(rect);
			return rect.Contains(pt);

		}
		
		private Rectangle GetCloseRect(Rectangle rect)
		{
			if(this.SelectedIndex != 0)
			{
				Rectangle rtnRect = new Rectangle(rect.X + rect.Width - 16 - 5,rect.Y + 5,16,16);
				return rtnRect;
			}
			else
			{
				Rectangle rtnRect = new Rectangle(0,0,0,0);
				return rtnRect;
			}
			
		}
		
		private void DrawCloseRect(Graphics graphics,Rectangle rect)
		{
			//画关闭的X
			Pen objpen = new Pen(Color.Black);
			Pen objpen1 = new Pen(Color.White);
			Point p1 = new Point(rect.X + rect.Width - 16 - 5 , rect.Y + 5 );
			Point p2 = new Point(rect.X + rect.Width - 5 , rect.Y + 21);
			Rectangle rt = new Rectangle(p1.X ,p1.Y,16,16);
			if(CloseEX)
			{
				graphics.DrawRectangle(objpen1,rt);
			}
			p1 = new Point(rt.X + 3,rt.Y + 3);
			p2 = new Point(rt.X + 13,rt.Y + 13);
			graphics.DrawLine(objpen, p1, p2);

			p1 = new Point(rt.X + 13,rt.Y + 3);
			p2 = new Point(rt.X + 3,rt.Y + 13);
			graphics.DrawLine(objpen, p1, p2);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
			// e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
			//绘制背景

			Rectangle rect = this.ClientRectangle;
			//e.Graphics.FillRectangle(new TextureBrush(Properties.Resources.bg), rect);

			//绘制边线
			int height = this.ItemSize.Height+3;
			Rectangle r = new Rectangle(DisplayRectangle.X - 1, DisplayRectangle.Y - 1, DisplayRectangle.Width + 1, DisplayRectangle.Height + 1);

			// e.Graphics.DrawLine(new Pen(Color.FromArgb(157, 162, 168)), new Point(rect.X, rect.Y + height), new Point(rect.Right, rect.Y + height));
			e.Graphics.DrawRectangle(new Pen(_lineColor), r);
			//绘制边框

			//绘制标头

			foreach (TabPage tp in this.TabPages)
			{
				DrawTabPage(e.Graphics, this.GetTabRect(this.TabPages.IndexOf(tp)),tp);
			}
			

		}
		
		private void DrawTabPage(Graphics graphics, Rectangle rectangle, TabPage tp)
		{
			//绘制底纹

			StringFormat sf = new StringFormat();
			
			sf.Trimming = StringTrimming.EllipsisCharacter;
			sf.FormatFlags = StringFormatFlags.NoWrap;
			Rectangle rect = new Rectangle (rectangle.X ,rectangle .Y +2,rectangle .Width ,rectangle .Height -2); //标准区域
			Rectangle fontRect = new Rectangle(rectangle.X + 5, rectangle.Bottom - tp.Font.Height - 5, rectangle.Width - 10, tp .Font .Height);//文字区域
			
			if (this.SelectedIndex > 0 && this.SelectedTab.Equals(tp))
			{
				rect = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
				fontRect = new Rectangle(rectangle.X + 5, rectangle.Bottom - tp.Font.Height - 5, rectangle.Width - 25, rectangle.Height - 7);
				
				//绘制边框
				graphics.FillPath(new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X, rect.Y + rect.Height), _ColorActivateA, _ColorActivateB), CreateTabPath(rect)); //填充颜色
				graphics.DrawString(tp.Text, tp.Font, new SolidBrush(tp.ForeColor), fontRect, sf); //文字绘制
				
				graphics.DrawPath(new Pen(_lineColor), CreateTabPath(rect));//绘制实边线

				//掩盖下部的绘制
				graphics.DrawLine(new Pen(_ColorActivateB, 3), rect.X - 9, rect.Bottom + 1, rect.X + rect.Width -1, rect.Bottom + 1);

				//绘制图片
				if(this.SelectedIndex != 0)
				{
					DrawCloseRect(graphics,rect);
				}
			}
			else
			{
				//绘制边框
				graphics.FillPath(new LinearGradientBrush (new Point (rect .X,rect .Y ),new Point (rect .X,rect .Y +rect .Height ),_ColorDefaultA,_ColorDefaultB), CreateTabPath(rect)); //填充颜色
				graphics.DrawString(tp.Text, tp.Font, new SolidBrush(tp.ForeColor), fontRect, sf); //文字绘制
				graphics.DrawPath(new Pen(Color.Wheat, 2), CreateTabPath(rect));//绘制高光边线
				graphics.DrawPath(new Pen(_lineColor), CreateTabPath(rect));//绘制实边线
			}

			//this.Invalidate();
		}
		
		private static readonly int Radius = 10;
		private GraphicsPath CreateTabPath(Rectangle rect)
		{

			GraphicsPath path = new GraphicsPath();
			rect.Width -= 1;
			path.AddLine(rect.X + Radius, rect.Y, rect.Right - Radius / 2, rect.Y);
			path.AddArc(rect.Right - Radius, rect.Y, Radius, Radius, 270F, 90F);
			path.AddLine(rect.Right, rect.Y + Radius / 2, rect.Right, rect.Bottom + 1);
			path.AddLine(rect.Right, rect.Bottom + 1, rect.X - Radius, rect.Bottom + 1);
			path.CloseFigure();
			//path.CloseFigure();
			return path;
		}
		
		
	}
}
