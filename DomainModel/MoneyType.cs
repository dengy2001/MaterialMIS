﻿/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-01
 * 时间: 20:48
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of MoneyType.
	/// </summary>
	public class MoneyType
	{
		public MoneyType()
		{
		}
		
		public virtual int MoneyTypeID
		{
			get;set;
		}
		
		public virtual string MoneyTypeName
		{
			get;set;
		}
		
		public virtual int MoneyTypeClass
		{
			get;set;
		}
		
	}
}
