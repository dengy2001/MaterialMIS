/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-08-17
 * 时间: 13:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of ProjectSupplier.
	/// </summary>
	public class ProjectSupplier
	{
		public ProjectSupplier()
		{
		}
		
		public virtual ProjectSupply Ps
		{get;set;}		
		
		
	}
	
	public class ProjectSupply
	{
		public virtual int ProjectID { get; set; }
        public virtual int SupplierID { get; set; }

        /// <summary>
        /// 判断两个对象是否相同，这个方法需要重写
        /// </summary>
        /// <param name="obj">进行比较的对象</param>
        /// <returns>真true或假false</returns>
        public override bool Equals(object obj)
        {
            if (obj is ProjectSupply)
            {
                ProjectSupply pk = obj as ProjectSupply;
                if (this.ProjectID == pk.ProjectID && this.SupplierID == pk.SupplierID)
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
