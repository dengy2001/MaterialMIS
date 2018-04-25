/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-05-01
 * 时间: 13:40
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of GoodsType.
	/// </summary>
	public class GoodsType
	{
		private int i_GoodsTypeID;
		private string s_GoodsTypeName;
		private int i_GoodsTypePID;
		
		public virtual int GoodsTypeID
		{
			get
			{
				return i_GoodsTypeID;
			}
			set
			{
				i_GoodsTypeID = value;
			}
		}
		
		public virtual string GoodsTypeName
		{
			get
			{
				return s_GoodsTypeName;
			}
			set
			{
				s_GoodsTypeName = value;
			}
		}
		
		public virtual int GoodsTypePID
		{
			get
			{
				return i_GoodsTypePID;
			}
			set
			{
				i_GoodsTypePID = value;
			}
		}
		
		public GoodsType()
		{
			
		}
	}
}
