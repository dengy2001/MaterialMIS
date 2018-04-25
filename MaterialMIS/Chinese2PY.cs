/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-05-16
 * 时间: 16:07
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using Microsoft.International.Converters.PinYinConverter;

namespace MaterialMIS
{
	/// <summary>
	/// Description of Chinese2PY.
	/// </summary>
	public class Chinese2PY
	{
		public Chinese2PY()
		{
		}
		#region 得到拼音全称
        public static string GetPinyin(string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, t.Length - 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        } 
        #endregion

        #region 得到汉字首字母
        public static string GetShortPinyin(string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        } 
        #endregion
        
        /// <summary>
        /// 返回拼音的首字母，多音字返回[]包含的字母，不重复
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetShortPY2(string str)
        {
        	string r = string.Empty;
            foreach (char c in str)
            {
            	try
            	{
	            	ChineseChar chineseChar = new ChineseChar(c);
	
	                //因为一个汉字可能有多个读音，pinyins是一个集合
	                var pinyins = chineseChar.Pinyins;
	                String firstPinyin = null;
	                
	                foreach (var pinyin in pinyins)
	                {
	                    if (pinyin != null)
	                    {
	                        //取得拼音首字母
	                        firstPinyin += pinyin.Substring(0,1); 
	                    }
	                }
	                //下面的方法只是简单的获得了集合中第一个非空元素
	                //使用移除法  
	                string s = firstPinyin;
					for (int i = 0; i < s.Length; i++)  
					{  
						while (s.IndexOf(s.Substring(i, 1)) != s.LastIndexOf(s.Substring(i, 1)))  
						{  
							s = s.Remove(s.LastIndexOf(s.Substring(i, 1)), 1);  
						}  
					}  
		            if(s.Length > 1)
		            {
		            	r = r + "[" +s + "]";
		            }
		            else
		            {
		            	r += s;
		            }
            	}
            	catch
            	{
            		r += c.ToString();
            	}
		     
		            	

            }
        	 
            return r;
        }
	}
}
