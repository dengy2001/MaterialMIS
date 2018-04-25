/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-05-07
 * 时间: 21:32
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using NHibernate;
using NHibernate.Cfg;
using DomainModel;
using System.Data.SQLite;
using DAL;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace BLL
{
	/// <summary>
	/// Description of FormGoodTypeBLL.
	/// </summary>
	public class GoodsTypeBLL
	{
		public GoodsTypeBLL()
		{
		}
		
		// 添加货品类别
		public static void AddGoodType(GoodsType gt)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				session.Save(gt);
				tx.Commit();
				session.Close();	
				//更新dslocal				
				FillGoodType();
				
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
				tx.Rollback();
				session.Close();
			}

		}
		
		// 修改货品类别
		public static void ModifyGoodType(GoodsType gt)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			IQuery query = session.CreateQuery("FROM GoodsType WHERE GoodsTypeID = :sGoodsTypeID").SetString("sGoodsTypeID", gt.GoodsTypeID.ToString());
			IList<GoodsType> eList = query.List<GoodsType>(); 
			try
			{
				foreach (GoodsType item in eList) 
				{ 
					item.GoodsTypeName = gt.GoodsTypeName;
					item.GoodsTypePID = gt.GoodsTypePID;
					session.Update(item); 
				} 
				tx.Commit(); 
				session.Close();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
				tx.Rollback();
				session.Close();
			}

		}
		
		//指定的商品类别能删除？
		private static bool CanDelGoodsType(int iGoodsTypeID)
		{
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			int i_rtn = 0;
			//查询是否有下级类别存在
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM GoodsType WHERE GoodsTypePID = @PID",iGoodsTypeID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的类别有下级类别，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			
			//查询此商品类别是否在Goods表中有
			i_rtn = Convert.ToInt32(SQLiteHelper.ExecuteScalar("SELECT Count(*) FROM Goods WHERE GoodsTypeID = @GoodsTypeID",iGoodsTypeID));
			if(i_rtn > 0)
			{
				MessageBox.Show("要删除的类别在商品表中有使用，不能删除！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
				session.Close();
				return false;
			}
			session.Close();
			return true;
		}
		
		//删除指定的货品类别
		public static void DelGoodType(int iGoodsTypeID)
		{
			//ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
			ISession session = NHibernateHelper.sessionFactory.OpenSession();
			ITransaction tx = session.BeginTransaction();
			try
			{
				IQuery query = session.CreateQuery("FROM GoodsType WHERE GoodsTypeID = :sGoodsTypeID").SetString("sGoodsTypeID", iGoodsTypeID.ToString());
				IList<GoodsType> eList = query.List<GoodsType>(); 

				foreach (GoodsType item in eList) 
				{ 
					if(!CanDelGoodsType(iGoodsTypeID))
					{
						session.Close();
						return;
					}
					session.Delete(item); 
				} 
				tx.Commit(); 
				session.Close();
			}
			catch(Exception e)
			{
				Debug.Assert(false,e.Message);
				tx.Rollback();
				session.Close();
			}
		}
		
		public static void FillGoodType()
		{
			LocalData.FillGoodsType();
			
		}
		
		// 填充treeview
		public static void FillTreeView(TreeView tv)
		{
			TreeNode td = new TreeNode();
			td.Tag = 1;
			td.Text = "全部类别";
			AddAllNodes(td);
			tv.Nodes.Add(td);
			tv.ExpandAll();
		}
		
		//刷新treeview
		public static void RefreshView(TreeView tv)
		{
			//tv.Nodes.Clear();
			FillTreeView(tv);
		}
		
		private static void AddAllNodes(TreeNode td)
		{
			//DataTable dt = LocalData.dsLocal.Tables[0];
			DataTable dt = LocalData.dsLocal.Tables["GoodsType"];
            DataRow[] drs;
            if (td.Tag == null || Int32.Parse(td.Tag.ToString()) == 0)
            {
                drs = dt.Select("GoodsTypePID = 0","GoodsTypeName");
            }
            else
            {
                drs = dt.Select("GoodsTypePID=" + td.Tag,"GoodsTypeName");
            }
            for (int i = 0; i < drs.Length; i++)
            {
                TreeNode childNode = new TreeNode();
                //下面的if语句防止GoodTypePID=0时GoodsTypeID=0死循环
                if(Convert.ToInt32(drs[i]["GoodsTypeID"]) == 0)
                {
                	continue;
                }
                childNode.Tag = drs[i]["GoodsTypeID"];
                childNode.Text = drs[i]["GoodsTypeName"].ToString();
                td.Nodes.Add(childNode);
                AddAllNodes(childNode);
            }

		}
		

		public static DataSet GetAllGoodsType()
		{
			DataSet ds = new DataSet();
			ds = SQLiteHelper.ExecuteDataSet("SELECT GoodsTypeID,GoodsTypeName,GoodsTypePID,0 AS GoodsTypeQty,0 AS GoodsTypeAmt FROM GoodsType");
			return ds;				
		}
	}
}
