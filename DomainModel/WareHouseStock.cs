/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-06-24
 * 时间: 10:46
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DomainModel
{
	/// <summary>
	/// Description of WareHouseStock.
	/// </summary>
	public class WareHouseStock
	{
		public WareHouseStock()
		{
		}
		
		public virtual PKModel Pk
		{
			get;set;
		}		
		
		public virtual decimal LastPrice
		{
			get;set;
		}
		public virtual decimal Number
		{
			get;set;
		}
		
		public virtual decimal Price
		{
			get;set;
		}
		
		public virtual decimal Amount
		{
			get;set;
		}
	}
	
	public class PKModel
    {
		
        public virtual int GoodsID { get; set; }
        public virtual int WareHouseID { get; set; }

        /// <summary>
        /// 判断两个对象是否相同，这个方法需要重写
        /// </summary>
        /// <param name="obj">进行比较的对象</param>
        /// <returns>真true或假false</returns>
        public override bool Equals(object obj)
        {
            if (obj is PKModel)
            {
                PKModel pk = obj as PKModel;
                if (this.GoodsID == pk.GoodsID && this.WareHouseID == pk.WareHouseID)
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
