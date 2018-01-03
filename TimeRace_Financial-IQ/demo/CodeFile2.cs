using System.Data;
using System.Text;
using System.Collections;

public class CodeFile2
{

}
public interface IDBHelper
{
    DataTable GetDataTable(string sql);
    int ExecuteNonQuery(string sql);
    object ExecuteScelar(string sql); 
}
public class DBHelper 
{

}
public interface ITableHelper
{
    void AddRow();
}
public class TableHelper
{
    
}

/*
 * their technology show be Sql+Name ,+DocxFiles...
 * if sql more? no ...
 * 
 * table:Student/Book/
 * form: Page ,dataForm,btn ...
 * add del modify query
 * ------------
 * web ashx page same
 * ------------
 */