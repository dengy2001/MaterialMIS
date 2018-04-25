/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-09-25
 * 时间: 14:46
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of ProjectCompanies.
	/// </summary>
	public class ProjectCompanies
	{
		public ProjectCompanies()
		{
		}
		public virtual ProjectCompany Ps
		{get;set;}
		public virtual int CompanyType
		{
			get;set;
		}
	}
	public class ProjectCompany
	{
		public virtual int ProjectID { get; set; }
        public virtual int CompanyID { get; set; }

        /// <summary>
        /// 判断两个对象是否相同，这个方法需要重写
        /// </summary>
        /// <param name="obj">进行比较的对象</param>
        /// <returns>真true或假false</returns>
        public override bool Equals(object obj)
        {
            if (obj is ProjectCompany)
            {
                ProjectCompany pk = obj as ProjectCompany;
                if (this.ProjectID == pk.ProjectID && this.CompanyID == pk.CompanyID)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
	}
	
	
}
