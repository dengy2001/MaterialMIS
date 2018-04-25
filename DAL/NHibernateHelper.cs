/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-05-18
 * 时间: 17:27
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using NHibernate;
using NHibernate.Cfg;

namespace DAL
{
	/// <summary>
	/// Description of NHibernateHelper.
	/// </summary>
	public static class NHibernateHelper

    {
		private static ISessionFactory factory = null;
		static NHibernateHelper()
		{
			factory = new Configuration().Configure().BuildSessionFactory();
		}
		
		public static ISessionFactory sessionFactory
		{
			get {return factory;}
		}
		
		public static ISession OpenSession()
        {
			return factory.OpenSession();
        } 
		
		public static ISession GetCurrentSession() 
		{
			return factory.GetCurrentSession();
		}
		
		
    }

}
