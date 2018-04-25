/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-19
 * 时间: 18:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of Users.
	/// </summary>
	public class Users
	{
		public Users()
		{
		}
		
		public virtual int UserID
		{
			get;set;
		}
		
		public virtual string UserName
		{
			get;set;
		}
		
		public virtual string UserDisplayName
		{
			get;set;
		}
		
		public virtual string UserPassword
		{
			get;set;
		}
		public virtual string UserStatus
		{
			get;set;
		}
		
	}
}
