using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
public class test4
{
    public static void t1()
    {
        DataSet ds = new DataSet("ddss");

        DataTable table = new DataTable("ddtt");
        table.Columns.Add("ID", typeof(string));
        table.Columns.Add("email", typeof(string));
        table.Columns.Add("telephone", typeof(string));
        table.Columns.Add("problem", typeof(string));
        table.Columns.Add("dt", typeof(DateTime));
        table.Columns.Add("int32", typeof(Int32));
        table.Columns.Add("mathtest", typeof(Math));
        table.Columns.Add("test4", typeof(test4));
        table.WriteXml(@"d:\1.xml");
        ds.Tables.Add(table);
        ds.WriteXml(@"d:\2.xml");
    }
    public static Random rd = new Random();
    public static string[] GetRandomList(int max, int length)
    {
        List<string> list = new List<string>();
        while (length-- >= 0)//★wait for mend 
            list.Add(rd.Next(max).ToString());
        return list.ToArray();
    }
}