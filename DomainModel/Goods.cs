/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-05-16
 * 时间: 12:00
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of Goods.
	/// </summary>
	public class Goods
	{
		private int i_GoodsID;
		private string s_GoodsName;
		private string s_GoodsNamePY;
		private int i_GoodsTypeID;
		private GoodsType t_GoodsTypeInfo;
		private string s_GoodsUnit;
		private string s_GoodsSpec;
		private decimal d_GoodsPrice;
		private decimal d_LimitLow;
		private decimal d_LimitUP;
		private byte[] b_GoodsPic;
		
		public virtual int GoodsID
		{
			get	{return i_GoodsID;}
			set	{i_GoodsID = value;}
		}
		
		public virtual string GoodsName
		{
			get {return s_GoodsName;}
			set {s_GoodsName = value;}
		}
		
		public virtual string GoodsNamePY
		{
			get { return s_GoodsNamePY;}
			set { s_GoodsNamePY = value;}
		}
		
		public virtual int GoodsTypeID
		{
			get { return i_GoodsTypeID;}
			set { i_GoodsTypeID = value;}
		}
		
		public virtual GoodsType GoodsTypeInfo
		{
			get { return t_GoodsTypeInfo;}
			set { t_GoodsTypeInfo = value;}
		}
		
		public virtual string GoodsUnit
		{
			get { return s_GoodsUnit;}
			set {s_GoodsUnit = value;}
		}
		
		public virtual string GoodsSpec
		{
			get { return s_GoodsSpec;}
			set {s_GoodsSpec = value;}
		}
		
		public virtual byte[] GoodsPic
		{
			get { return b_GoodsPic;}
			set {b_GoodsPic = value;}
		}
		
		public virtual decimal GoodsPrice
		{
			get { return d_GoodsPrice;}
			set { d_GoodsPrice = value;}
		}
		
		public virtual decimal LimitLow
		{
			get { return d_LimitLow;}
			set { d_LimitLow = value;}
		}
		
		public virtual decimal LimitUP
		{
			get { return d_LimitUP;}
			set { d_LimitUP = value;}
		}
		
		
		public Goods()
		{
			t_GoodsTypeInfo = new GoodsType();
		}
	}
}
