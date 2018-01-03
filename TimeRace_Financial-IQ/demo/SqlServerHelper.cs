using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// SQL Server 数据库操作类
/// </summary>
public class SqlServerHelper
{
    /// <summary>
    /// 禁止实例化
    /// </summary>
    private SqlServerHelper() { }

    /// <summary>
    /// 设置SqlServer的连接字符串
    /// </summary>
    public static readonly string CONNECTIONSTRING = "Data Source=" + ConfigurationManager.AppSettings["DataSource"] +  //要连接到Sql Server的实例名称
                                                     ";DataBase=" + ConfigurationManager.AppSettings["DataBase"] +      //要使用的数据库的名称
                                                     ";User ID=" + ConfigurationManager.AppSettings["UserID"] +         //登陆到数据库的用户名
                                                     ";Password=" + ConfigurationManager.AppSettings["Password"];       //登陆到数据库的密码

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
