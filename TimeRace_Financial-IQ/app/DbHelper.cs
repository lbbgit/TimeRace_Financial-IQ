using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic; 
 

namespace SqlDbHelper_TEST
{
    /// <summary>  
    /// 数据访问抽象基础类  
    /// </summary>  
    public abstract class SqlDbHelper
    {
        public static string connectionString = "Data Source = 192.168.1.2;Initial Catalog = DBName;User Id = sa;Password =123456;";
        public SqlDbHelper()//可以用来初始化connectionString  
        {
        }

        #region 公用方法

        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        public static bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>  
        /// 执行多条SQL语句，实现数据库事务。  
        /// </summary>  
        /// <param name="SQLStringList">多条SQL语句</param>      
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    return 0;
                }
            }
        }
        /// <summary>  
        /// 执行带一个存储过程参数的的SQL语句。  
        /// </summary>  
        /// <param name="SQLString">SQL语句</param>  
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>  
        /// <returns>影响的记录数</returns>  
        public static int ExecuteSql(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>  
        /// 执行带一个存储过程参数的的SQL语句。  
        /// </summary>  
        /// <param name="SQLString">SQL语句</param>  
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>  
        /// <returns>影响的记录数</returns>  
        public static object ExecuteSqlGet(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>  
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)  
        /// </summary>  
        /// <param name="strSQL">SQL语句</param>  
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>  
        /// <returns>影响的记录数</returns>  
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>  
        /// 执行一条计算查询结果语句，返回查询结果（object）。  
        /// </summary>  
        /// <param name="SQLString">计算查询结果语句</param>  
        /// <returns>查询结果（object）</returns>  
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        public static object GetSingle(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        /// <summary>  
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )  
        /// </summary>  
        /// <param name="strSQL">查询语句</param>  
        /// <returns>SqlDataReader</returns>  
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }

        }
        /// <summary>  
        /// 执行查询语句，返回DataSet  
        /// </summary>  
        /// <param name="SQLString">查询语句</param>  
        /// <returns>DataSet</returns>  
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
        public static DataSet Query(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }



        #endregion

        #region 执行带参数的SQL语句

        /// <summary>  
        /// 执行SQL语句，返回影响的记录数  
        /// </summary>  
        /// <param name="SQLString">SQL语句</param>  
        /// <returns>影响的记录数</returns>  
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }


        /// <summary>  
        /// 执行多条SQL语句，实现数据库事务。  
        /// </summary>  
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>  
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //循环  
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>  
        /// 执行多条SQL语句，实现数据库事务。  
        /// </summary>  
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>  
        public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;
                        //循环  
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.InputOutput)
                                {
                                    q.Value = indentity;
                                }
                            }
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                {
                                    indentity = Convert.ToInt32(q.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>  
        /// 执行一条计算查询结果语句，返回查询结果（object）。  
        /// </summary>  
        /// <param name="SQLString">计算查询结果语句</param>  
        /// <returns>查询结果（object）</returns>  
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>  
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )  
        /// </summary>  
        /// <param name="strSQL">查询语句</param>  
        /// <returns>SqlDataReader</returns>  
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
            //      finally  
            //      {  
            //        cmd.Dispose();  
            //        connection.Close();  
            //      }    

        }

        /// <summary>  
        /// 执行查询语句，返回DataSet  
        /// </summary>  
        /// <param name="SQLString">查询语句</param>  
        /// <returns>DataSet</returns>  
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }


        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;  
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion

        #region 存储过程操作

        /// <summary>  
        /// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )  
        /// </summary>  
        /// <param name="storedProcName">存储过程名</param>  
        /// <param name="parameters">存储过程参数</param>  
        /// <returns>SqlDataReader</returns>  
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader returnReader;
            connection.Open();
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return returnReader;

        }


        /// <summary>  
        /// 执行存储过程  
        /// </summary>  
        /// <param name="storedProcName">存储过程名</param>  
        /// <param name="parameters">存储过程参数</param>  
        /// <param name="tableName">DataSet结果中的表名</param>  
        /// <returns>DataSet</returns>  
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = Times;
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }


        /// <summary>  
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)  
        /// </summary>  
        /// <param name="connection">数据库连接</param>  
        /// <param name="storedProcName">存储过程名</param>  
        /// <param name="parameters">存储过程参数</param>  
        /// <returns>SqlCommand</returns>  
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.  
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        /// <summary>  
        /// 执行存储过程，返回影响的行数      
        /// </summary>  
        /// <param name="storedProcName">存储过程名</param>  
        /// <param name="parameters">存储过程参数</param>  
        /// <param name="rowsAffected">影响的行数</param>  
        /// <returns></returns>  
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();  
                return result;
            }
        }

        /// <summary>  
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)    
        /// </summary>  
        /// <param name="storedProcName">存储过程名</param>  
        /// <param name="parameters">存储过程参数</param>  
        /// <returns>SqlCommand 对象实例</returns>  
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion

    }
}

namespace DbTools
{
    /// <summary>
    /// ClassName:SqlServerHelper
    /// Version:1.0
    /// DateTime:2009/8/12
    /// Author:暗夜亡灵
    /// Remark:MS SQL Server 数据库操作类
    /// </summary>
    public class SqlServerHelper
    {
        /// <summary>
        /// 禁止实例化
        /// </summary>
        private SqlServerHelper() { }

        #region 连接字符串配置

        private static readonly string CONNECTIONSTRING_key = ConfigurationManager.AppSettings["ConnectionKey"];
        
        private static readonly string CONNECTIONSTRING_SqlServer = string.Empty +
            "Data Source=" + ConfigurationManager.AppSettings["DataSource"] +  //要连接到Sql Server的实例名称
            ";DataBase=" + ConfigurationManager.AppSettings["DataBase"] +      //要使用的数据库的名称
                (Convert.ToString(ConfigurationManager.AppSettings["local"])       //是否开启本机认证
                    == "1" ? ";Integrated Security=True" : "") +
            ";User ID=" + ConfigurationManager.AppSettings["UserID"] +         //登陆到数据库的用户名
            ";Password=" + ConfigurationManager.AppSettings["Password"];       //登陆到数据库的密码

        private static readonly string _CONNECTIONSTRING = 
            string.IsNullOrWhiteSpace(CONNECTIONSTRING_key) ?
            CONNECTIONSTRING_SqlServer : ConfigurationManager.AppSettings[CONNECTIONSTRING_key];
        #endregion
        
        public static string CONNECTIONSTRING {
             get { return _CONNECTIONSTRING; } 
         }

        /// <summary>
        /// 获取一个连接
        /// </summary>
        /// <returns>返回SqlConnection</returns>
        public static SqlConnection ReturnConn()
        {
            SqlConnection conn;
 
            try
            {
                conn = new SqlConnection(CONNECTIONSTRING);
 
                if (conn.State.Equals(ConnectionState.Closed))
                {
                    conn.Open();
                }
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            return conn;
        }
 
        /// <summary>
        /// 存储过程函数
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <returns>返回SqlCommand</returns>
        public static SqlCommand CreatCmd(string procName)
        {
            SqlConnection conn = ReturnConn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = procName;
            return cmd;
        }
 
        /// <summary>
        /// 存储过程函数
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">存储过程参数</param>
        /// <returns>返回SqlCommand</returns>
        public static SqlCommand CreatCmd(string procName, SqlParameter[] prams)
        {
            SqlConnection conn = ReturnConn();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = procName;
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                {
                    if (parameter != null)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
            }
            return cmd;
        }
 
        /// <summary>
        /// 存储过程函数
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="connection">指定要用的连接</param>
        /// <returns>返回SqlCommand</returns>
        public static SqlCommand CreatCmd(string procName, SqlConnection connection)
        {
            SqlConnection conn = connection;
            if (conn.State.Equals(ConnectionState.Closed))
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = procName;
            return cmd;
        }
 
        /// <summary>
        /// 存储过程函数
        /// </summary>
        /// <param name="procName">存储过名</param>
        /// <param name="prams">存储过程参数</param>
        /// <param name="connection">指定要用的连接</param>
        /// <returns>返回SqlCommand</returns>
        public static SqlCommand CreatCmd(string procName, SqlParameter[] prams, SqlConnection connection)
        {
            SqlConnection conn = connection;
            if (conn.State.Equals(ConnectionState.Closed))
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = procName;
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                {
                    if (parameter != null)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
            }
            return cmd;
        }
 
        /// <summary>
        /// 执行存储过程函数获得SqlDataReader
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <returns>返回SqlDataReader</returns>
        public static SqlDataReader RunProcGetReader(string procName)
        {
            SqlCommand cmd = CreatCmd(procName);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);//参数CommandBehavior.CloseConnection表示当SqlDataReader关闭时候就关闭该连接
            return dr;
        }
 
        /// <summary>
        /// 执行存储过程函数获得SqlDataReader
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">存储过程参数</param>
        /// <returns>返回SqlDataReader</returns>
        public static SqlDataReader RunProcGetReader(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = CreatCmd(procName, prams);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);//参数CommandBehavior.CloseConnection表示当SqlDataReader关闭时候就关闭该连接
            return dr;
        }
 
        /// <summary>
        /// 执行存储过程函数获得SqlDataReader
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="connection">SqlConnection连接</param>
        /// <returns>返回SqlDataReader</returns>
        public static SqlDataReader RunProcGetReader(string procName, SqlConnection connection)
        {
            SqlCommand cmd = CreatCmd(procName, connection);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);//参数CommandBehavior.CloseConnection表示当SqlDataReader关闭时候就关闭该连接
            return dr;
        }
 
        /// <summary>
        /// 执行存储过程函数获得SqlDataReader
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">存储过程参数</param>
        /// <param name="conn">SqlConnection连接</param>
        /// <returns>返回SqlDataReader</returns>
        public static SqlDataReader RunProcGetReader(string procName, SqlParameter[] prams, SqlConnection connection)
        {
            SqlCommand cmd = CreatCmd(procName, prams, connection);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);//参数CommandBehavior.CloseConnection表示当SqlDataReader关闭时候就关闭该连接
            return dr;
        }
 
        /// <summary>
        /// 执行存储过程函数获得DataTable
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">存储过程参数</param>
        /// <param name="conn">SqlConnection连接</param>
        /// <returns>返回DataTable</returns>
        public static DataTable RunProcGetTable(string procName, SqlParameter[] prams, SqlConnection connection)
        {
            SqlCommand cmd = CreatCmd(procName, prams, connection);
            SqlDataAdapter dtr = new SqlDataAdapter();
            DataSet ds = new DataSet();
            dtr.SelectCommand = cmd;
            dtr.Fill(ds);
            DataTable dt = ds.Tables[0];
            connection.Close();
            return dt;
        }

        /// <summary>
        /// 执行sql获得DataTable
        /// </summary>
        /// <param name="sql">sql</param> 
        /// <param name="conn">SqlConnection连接</param>
        /// <returns>返回DataTable</returns>
        public static DataTable GetDTable(string sql)
        {
            SqlConnection conn = ReturnConn();
            if (conn.State.Equals(ConnectionState.Closed))
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            cmd.CommandText = sql; 
            SqlDataAdapter dtr = new SqlDataAdapter();
            DataSet ds = new DataSet();
            dtr.SelectCommand = cmd;
            dtr.Fill(ds);
            DataTable dt = ds.Tables[0];
            conn.Close();
            return dt;
        }

        /// <summary>
        /// 执行存储过程的ExecuteNonQuery()方法
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <returns>返回受影响的行数</returns>
        public static int RunExecute(string procName)
        {
            SqlConnection conn = ReturnConn();
            SqlCommand cmd = CreatCmd(procName, conn);
            int Reuslt = cmd.ExecuteNonQuery();
            conn.Close();
            return Reuslt;
        }
 
        /// <summary>
        /// 执行存储过程的ExecuteNonQuery()方法
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">存储过程参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int RunExecute(string procName, SqlParameter[] prams)
        {
            SqlConnection conn = ReturnConn();
            SqlCommand cmd = CreatCmd(procName, prams, conn);
            int Reuslt = cmd.ExecuteNonQuery();
            conn.Close();
            return Reuslt;
        }
 
        /// <summary>
        /// 执行存储过程的ExecuteScalar()方法放回首行首列并转换成int类型
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <returns>返回首行首列</returns>
        public static int RunExecuteScalarToInt(string procName)
        {
            SqlConnection conn = ReturnConn();
            SqlCommand cmd = CreatCmd(procName, conn);
            int Result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return Result;
        }
 
        /// <summary>
        /// 执行存储过程的ExecuteScalar()方法放回首行首列并转换成int类型
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">存储过程参数</param>
        /// <returns>返回首行首列</returns>
        public static int RunExecuteScalarToInt(string procName, SqlParameter[] prams)
        {
            SqlConnection conn = ReturnConn();
            SqlCommand cmd = CreatCmd(procName, prams, conn);
            int Result = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return Result;
        }
 
        /// <summary>
        /// 执行存储过程的ExecuteScalar()方法放回首行首列并转换成string类型
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <returns>返回首行首列</returns>
        public static string RunExecuteScalarToString(string procName)
        {
            SqlConnection conn = ReturnConn();
            SqlCommand cmd = CreatCmd(procName, conn);
            string Result = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();
            return Result;
        }
 
        /// <summary>
        /// 执行存储过程的ExecuteScalar()方法放回首行首列并转换成string类型
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">存储过程参数</param>
        /// <returns>返回首行首列</returns>
        public static string RunExecuteScalarToString(string procName, SqlParameter[] prams)
        {
            SqlConnection conn = ReturnConn();
            SqlCommand cmd = CreatCmd(procName, prams, conn);
            string Result = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();
            return Result;
        }
    }
}