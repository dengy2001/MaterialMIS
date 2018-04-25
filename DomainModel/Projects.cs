/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-05-31
 * 时间: 13:47
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of Projects.
	/// </summary>
	public class Projects
	{
		public Projects()
		{
		}
		
		public virtual int ProjectID
		{
			get;set;
		}
		
		public virtual string ProjectName
		{
			get;set;
		}
		
		public virtual string ProjectContractor
		{
			get;set;
		}
		
		public virtual string ProjectDeveloper
		{
			get;set;
		}
		
		public virtual string ProjectAbstract
		{
			get;set;
		}
		
	}
}
