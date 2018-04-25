/*
 * 由SharpDevelop创建。
 * 用户： Deng
 * 日期: 2016-05-07
 * 时间: 19:15
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using System.Collections;
using System.Data.SQLite;
using System.Configuration;//添加.net引用

namespace DAL
{
    /// <summary>
    /// 对SQLite操作的类
    /// 引用：System.Data.SQLite.dll【版本：3.6.23.1（原始文件名：SQlite3.DLL）】
    /// </summary>
    public class SQLiteHelper
    {
        /// <summary>
        /// 所有成员函数都是静态的，构造函数定义为私有
        /// </summary>
        private SQLiteHelper()
        {
        }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                ////(AppSettings节点下的"SQLiteConnectionString")
                string text = ConfigurationManager.AppSettings["SQLiteConnectionString"];
                return text;
            }
        }
        private static SQLiteConnection _Conn = null;
        /// <summary>
        /// 连接对象
        /// </summary>
        public static SQLiteConnection Conn
        {
            get
            {
                if (_Conn == null) _Conn = new SQLiteConnection(ConnectionString);
                return SQLiteHelper._Conn;
            }
            set { SQLiteHelper._Conn = value; }
        }
        
        
        #region ExecuteDataSet(commandText,paramList[])
        /// <summary>
        /// 查询数据集
        /// </summary>
        /// <param name="cn">连接.</param>
        /// <param name="commandText">查询语句.</param>
        /// <param name="paramList">object参数列表.</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet( string commandText,params object[] paramList)
        {

            SQLiteCommand cmd = Conn.CreateCommand();
            cmd.CommandText = commandText;
            if (paramList != null)
            {
                AttachParameters(cmd, commandText, paramList);
            }
            DataSet ds = new DataSet();
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            da.Fill(ds);
            da.Dispose();
            cmd.Dispose();
            Conn.Close();
            return ds;
        } 
        #endregion
        
        #region AttachParameters(SQLiteCommand,commandText,object[] paramList)
        /// <summary>
        /// 增加参数到命令（自动判断类型）
        /// </summary>
        /// <param name="commandText">命令语句</param>
        /// <param name="paramList">object参数列表</param>
        /// <returns>返回SQLiteParameterCollection参数列表</returns>
        /// <remarks>Status experimental. Regex appears to be handling most issues. Note that parameter object array must be in same ///order as parameter names appear in SQL statement.</remarks>
        private static SQLiteParameterCollection AttachParameters(SQLiteCommand cmd, string commandText, params  object[] paramList)
        {
            if (paramList == null || paramList.Length == 0) return null;

            SQLiteParameterCollection coll = cmd.Parameters;
            string parmString = commandText.Substring(commandText.IndexOf("@"));
            // pre-process the string so always at least 1 space after a comma.
            parmString = parmString.Replace(",", " ,");
            // get the named parameters into a match collection
            string pattern = @"(@)\S*(.*?)\b";
            Regex ex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection mc = ex.Matches(parmString);
            string[] paramNames = new string[mc.Count];
            int i = 0;
            foreach (Match m in mc)
            {
                paramNames[i] = m.Value;
                i++;
            }

            // now let's type the parameters
            int j = 0;
            Type t = null;
            foreach (object o in paramList)
            {
                t = o.GetType();

                SQLiteParameter parm = new SQLiteParameter();
                switch (t.ToString())
                {

                    case ("DBNull"):
                    case ("Char"):
                    case ("SByte"):
                    case ("UInt16"):
                    case ("UInt32"):
                    case ("UInt64"):
                        throw new SystemException("Invalid data type");


                    case ("System.String"):
                        parm.DbType = DbType.String;
                        parm.ParameterName = paramNames[j];
                        parm.Value = (string)paramList[j];
                        coll.Add(parm);
                        break;

                    case ("System.Byte[]"):
                        parm.DbType = DbType.Binary;
                        parm.ParameterName = paramNames[j];
                        parm.Value = (byte[])paramList[j];
                        coll.Add(parm);
                        break;

                    case ("System.Int32"):
                        parm.DbType = DbType.Int32;
                        parm.ParameterName = paramNames[j];
                        parm.Value = (int)paramList[j];
                        coll.Add(parm);
                        break;

                    case ("System.Boolean"):
                        parm.DbType = DbType.Boolean;
                        parm.ParameterName = paramNames[j];
                        parm.Value = (bool)paramList[j];
                        coll.Add(parm);
                        break;

                    case ("System.DateTime"):
                        parm.DbType = DbType.DateTime;
                        parm.ParameterName = paramNames[j];
                        parm.Value = Convert.ToDateTime(paramList[j]);
                        coll.Add(parm);
                        break;

                    case ("System.Double"):
                        parm.DbType = DbType.Double;
                        parm.ParameterName = paramNames[j];
                        parm.Value = Convert.ToDouble(paramList[j]);
                        coll.Add(parm);
                        break;

                    case ("System.Decimal"):
                        parm.DbType = DbType.Decimal;
                        parm.ParameterName = paramNames[j];
                        parm.Value = Convert.ToDecimal(paramList[j]);
                        break;

                    case ("System.Guid"):
                        parm.DbType = DbType.Guid;
                        parm.ParameterName = paramNames[j];
                        parm.Value = (System.Guid)(paramList[j]);
                        break;

                    case ("System.Object"):

                        parm.DbType = DbType.Object;
                        parm.ParameterName = paramNames[j];
                        parm.Value = paramList[j];
                        coll.Add(parm);
                        break;

                    default:
                        throw new SystemException("Value is of unknown data type");

                } // end switch

                j++;
            }
            return coll;
        } 
        #endregion

        #region ExecuteNonQuery(commandText,paramList)
        /// <summary>
        /// 执行ExecuteNonQuery方法
        /// </summary>
        /// <param name="cn">连接</param>
        /// <param name="commandText">语句</param>
        /// <param name="paramList">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string commandText, params  object[] paramList)
        {

            SQLiteCommand cmd = Conn.CreateCommand();
            cmd.CommandText = commandText;
            AttachParameters(cmd, commandText, paramList);
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            Conn.Close();

            return result;
        } 
        #endregion

        #region ExecuteNonQuery(SQLiteTransaction,commandText,paramList)
        /// <summary>
        /// 执行ExecuteNonQuery方法,带事务
        /// </summary>
        /// <param name="transaction">之前创建好的SQLiteTransaction对象</param>
        /// <param name="commandText">语句.</param>
        /// <param name="paramList">参数.</param>
        /// <returns>返回影响的行数</returns>
        /// <remarks>
        /// 定义事务  DbTransaction trans = conn.BeginTransaction();
        ///     或者：SQLiteTransaction trans = Conn.BeginTransaction();
        /// 操作代码示例：
        /// try
        ///{
        ///    // 连续操作记录 
        ///    for (int i = 0; i < 1000; i++)
        ///    {
        ///        ExecuteNonQuery(trans,commandText,[] paramList);
        ///    }
        ///    trans.Commit();
        ///}
        ///catch
        ///{
        ///    trans.Rollback();
        ///    throw;
        ///}
        ///trans.Connection.Close();//关闭事务连接
        ///transaction.Dispose();//释放事务对象
        /// </remarks>
        public static int ExecuteNonQuery(SQLiteTransaction transaction, string commandText, params  object[] paramList)
        {
            if (transaction == null) throw new ArgumentNullException("transaction is null");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rolled back or committed,please provide an open transaction.", "transaction");
            using (IDbCommand cmd = transaction.Connection.CreateCommand())
            {
                cmd.CommandText = commandText;
                AttachParameters((SQLiteCommand)cmd, cmd.CommandText, paramList);
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();
                int result = cmd.ExecuteNonQuery(); 
                return result;
            }
            
        } 
        #endregion

        #region ExecuteNonQuery(IDbCommand)
        /// <summary>
        /// 执行ExecuteNonQuery方法
        /// </summary>
        /// <param name="cmd">创建好的命令.</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(IDbCommand cmd)
        {
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            cmd.Dispose();
            return result;
        } 
        #endregion

        #region ExecuteScalar(commandText,paramList)
        /// <summary>
        /// 执行ExecuteScalar
        /// </summary>
        /// <param name="commandText">语句s</param>
        /// <param name="paramList">参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string commandText, params  object[] paramList)
        {
            SQLiteConnection cn = new SQLiteConnection(ConnectionString);
            SQLiteCommand cmd = cn.CreateCommand();
            cmd.CommandText = commandText;
            AttachParameters(cmd, commandText, paramList);
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            object result = cmd.ExecuteScalar();
            cmd.Dispose();
            cn.Close();
            return result;
        } 
        #endregion
     
    }
}

