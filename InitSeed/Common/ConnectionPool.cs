using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


class DbConn
{
    //usingSystem.Data;
    //usingSystem.Data.SqlClient;
    private const int MaxPool = 10;//最大连接数
    private const int MinPool = 5;//最小连接数
    private const bool Asyn_Process = true;//设置异步访问数据库
    //在单个连接上得到和管理多个、仅向前引用和只读的结果集(ADO.NET2.0)
    private const bool Mars = true;
    private const int Conn_Timeout = 15;//设置连接等待时间
    private const int Conn_Lifetime = 15;//设置连接的生命周期
    private string ConnString = "";//连接字符串
    private SqlConnection SqlDrConn = null;//连接对象
    public DbConn()//构造函数
    {
        ConnString = GetConnString();
        SqlDrConn = new SqlConnection(ConnString);
    }
    private string GetConnString()
    {
        return "server=localhost;"
        + "integratedsecurity=sspi;"
        + "database=pubs;"
        + "MaxPoolSize=" + MaxPool + ";"
        + "MinPoolSize=" + MinPool + ";"
        + "ConnectTimeout=" + Conn_Timeout + ";"
        + "ConnectionLifetime=" + Conn_Lifetime + ";"
        + "AsynchronousProcessing=" + Asyn_Process + ";";
        //+"MultipleActiveResultSets="+Mars+";";
    }
    public DataTable GetDataReader(string StrSql)//数据查询
    {
        //当连接处于打开状态时关闭,然后再打开,避免有时候数据不能及时更新
        if (SqlDrConn.State == ConnectionState.Open)
        {
            SqlDrConn.Close();
        }
        try
        {
            SqlDrConn.Open();
            SqlCommand SqlCmd = new SqlCommand(StrSql, SqlDrConn);
            SqlDataReader SqlDr = SqlCmd.ExecuteReader();
            if (SqlDr.HasRows)
            {
                DataTable dt = new DataTable();
                //读取SqlDataReader里的内容
                dt.Load(SqlDr);
                //关闭对象和连接
                SqlDr.Close();
                SqlDrConn.Close();
                return dt;
            }
            return null;
        }
        catch (Exception ex)
        {
             //Show(ex.Message);
            return null;
        }
        finally
        {
            SqlDrConn.Close();
        }
    }
}

#if err
//多线程连接数据库的连接池类：

    public static class ConnectionPool
    {
        private static object locker = new object();
        private static Dictionary<string, SqlConnection> Connections = null;
        public static SqlConnection GetConnection<T>() where T : class, new()
        {
            string databaseName = NA.Common.Extensions.GetDatabaseName<T>();
            if (string.IsNullOrEmpty(databaseName))
                return null;
            if (Connections == null)
            {
                lock (locker)
                {
                    Connections = new Dictionary<string, SqlConnection>();
                }
            }
            string connKey = FindFreeSqlConnection(databaseName);
            if (connKey != null)
                return Connections[connKey];
            else
            {
                string strconn = NA.Common.Extensions.GetConnectionString<T>();
                int poolSize = NA.Common.Extensions.GetConnectionPoolSize<T>();
                lock (locker)
                {
                    for (int i = 0; i < poolSize; ++i)
                    {
                        SqlConnection conn = new SqlConnection(strconn);
                        conn.Open();
                        Connections.Add(databaseName + "_" + i.ToString(), conn);
                        conn.Close();
                    }
                }
                return Connections[FindFreeSqlConnection(databaseName)];
            }
        }

        private static string FindFreeSqlConnection(string databaseName)
        {
            IEnumerable<string> connKeys = Connections.Keys.Where(item => item.StartsWith(databaseName));
            if (connKeys != null && connKeys.Count() > 0)
            {
                foreach (string key in connKeys)
                {
                    if (Connections[key].State == ConnectionState.Closed)
                        return key;
                }
            }
            return null;
        }
   
    }

public class test_ConnectionPool{
//附加上其中用到的三个方法：

        public static int GetConnectionPoolSize<T>() where T : class, new()
        {
            string database = GetDatabaseName<T>();
            string[] poolSizeArray = ConfigurationManager.AppSettings["ConnectionsPoolSize"].Split('|');
            if (poolSizeArray != null)
            {
                foreach (string sizeItem in poolSizeArray)
                {
                    string[] sizeItemArray = sizeItem.Split(':');
                    if (database == sizeItemArray[0])
                        return int.Parse(sizeItemArray[1]);
                }
            }
            return 50;
        }
        public static string GetConnectionString<T>() where T : class, new()
        {
            string tableName = GetTableName<T>();
            string[] databaseArray = ConfigurationManager.AppSettings["DatabaseArray"].Split('|');
            if (databaseArray != null)
            {
                foreach (string database in databaseArray)
                {
                    string tableNameList = ConfigurationManager.AppSettings[database];
                    string[] tables = ConfigurationManager.AppSettings[database].Split('|');
                    if (tables != null && tables.Length > 0)
                        if (tables.Contains(tableName))
                            return ConfigurationManager.ConnectionStrings[database].ConnectionString;
                }
            }
            return string.Empty;
        }
        public static string GetDatabaseName<T>() where T : class, new()
        {
            string tableName = GetTableName<T>();
            string[] databaseArray = ConfigurationManager.AppSettings["DatabaseArray"].Split('|');
            if (databaseArray != null)
            {
                foreach (string database in databaseArray)
                {
                    string tableNameList = ConfigurationManager.AppSettings[database];
                    string[] tables = ConfigurationManager.AppSettings[database].Split('|');
                    if (tables != null && tables.Length > 0)
                        if (tables.Contains(tableName))
                            return database;
                }
            }
            return string.Empty;
        }

}

#endif