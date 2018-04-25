/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-02
 * 时间: 12:23
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of WareHouse.
	/// </summary>
	public class WareHouse
	{
		public WareHouse()
		{
		}
		
		public virtual int WareHouseID
		{
			get;set;
		}
		
		public virtual string WareHouseName
		{
			get;set;
		}
	}
}
