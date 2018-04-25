/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-13
 * 时间: 14:50
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of ProgOPtions.
	/// </summary>
	public class ProgOptions
	{
		public ProgOptions()
		{
		}
		
		public virtual int OptionsID
		{
			get;set;
		}
		
		public virtual string OptionsKey
		{
			get;set;
		}
		
		public virtual string OptionsValue
		{
			get;set;
		}
		
		public virtual string OptionsRemark
		{
			get;set;
		}
		
	}
}
