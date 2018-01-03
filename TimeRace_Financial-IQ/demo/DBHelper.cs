using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataBase
{
    /// <summary>
    /// SQL Server 数据库操作类(静态)
    /// </summary>
    public static class DBHelperTools
    {
        public static string sqlconnection_string = "";
        private static SqlConnection _sqlConnection;
        public static SqlConnection sqlConnection
        {
            get
            {
                if (_sqlConnection == null)
                    _sqlConnection = new SqlConnection(sqlconnection_string);
                return _sqlConnection;
            }
        }

        /// <summary>
        /// 打开连接,如果已打开则跳过
        /// </summary>
        public static void OpenConnection()
        {
            if (sqlConnection.State != System.Data.ConnectionState.Open)
                sqlConnection.Open();
        }

        /// <summary>
        /// 关闭连接,如果已关闭则跳过
        /// </summary>
        public static void CloseConnection()
        {
            if (sqlConnection.State != System.Data.ConnectionState.Closed)
                sqlConnection.Close();
        }


        public static DataTable GetDataTable(string sql, string tablename = "table")
        {
            DataSet ds = null;
            OpenConnection();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlAdapter.Fill(ds, tablename);
            CloseConnection();
            return ds.Tables[tablename];
        }

        public static int ExecuteNonQuery(string sql)
        {
            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            int i = sqlCommand.ExecuteNonQuery();
            CloseConnection();
            return i;
        }
    }

    /// <summary>
    /// SQL Server 数据库操作类
    /// </summary>
    public class SqlServer_DBHelper
    {
        /// <summary>
        /// Sql数据库连接字符串,从Web.config读取连接字符串
        /// </summary>
        public string sqlconnection_string = ConfigurationManager.AppSettings["sqlconnection"];
         
        public void InitSqlConnection()
        {
            SqlConnectionStringBuilder sconsb = new SqlConnectionStringBuilder();
            sconsb.DataSource = "localhost";
            sconsb.IntegratedSecurity = true;
            sconsb.InitialCatalog = "core";
            sqlconnection_string = sconsb.ConnectionString; 
        }

        public DataTable GetDataTable(string sql)
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(sqlconnection_string);
            sqlConnection.Open(); 
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlAdapter.Fill(dt); 
            sqlConnection.Close();
            return dt;
        }

        public int ExecuteNonQuery(string sql)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlconnection_string);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            int result = sqlCommand.ExecuteNonQuery(); 
            sqlConnection.Close();
            return result;
        }
    }


    /// <summary>
    /// sqlserver连接字符串的拼接程序,因为有自带的SqlConnectionStringBuilder,故而禁用
    /// </summary>
    public class SqlServer_Connection
    {
        /// <summary>
        /// 数据库所在的远程主机,默认为本机
        /// </summary>
        public string host ="localhost";

        /// <summary>
        /// 数据库库名
        /// </summary>
        public string InitialCatalog;

        /// <summary>
        /// 是否采用本机认证,如果开启则不使用用户名\密码,默认为开启
        /// </summary>
        public bool SelfDeny = true;

        /// <summary>
        /// 数据库用户名
        /// </summary>
        public string UserId;

        /// <summary>
        /// 数据库密码
        /// </summary>
        public string PassWd;


        /// <summary>
        /// 根据以上属性条件,生成连接字符串
        /// </summary> 
        public string GetConnectionString()
        {
            string str = "Data Source = " + host + ";Initial Catalog = " + InitialCatalog + ";";
            if (SelfDeny)
                str += "Integrated Security=True;";
            else
            {
                str += "User ID=" + UserId + ";Password=" + PassWd + ";";
            }
            return str;
        }
    }
}