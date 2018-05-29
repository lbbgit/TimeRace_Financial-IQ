using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

namespace InitSeed.Common.Tools
{
    public class DataTableTools
    {
        //public static DataTable GetDataTable(string tablename = "", string[] cols = null, object[][] vals = null)
        //{ 
        //    DataTable dt = new DataTable(tablename);
        //    if (cols == null || cols.Length == 0)
        //        return dt;
        //    foreach (string col in cols)
        //        dt.Columns.Add(col);
        //    if (vals != null && vals.Length != 0)
        //    {
        //        for (int r = 0; r < vals.Length; r++)
        //        {
        //            DataRow dr = dt.NewRow();
        //            for (int cindex = 0; cindex < vals[r].Length && cindex < cols.Length; cindex++)
        //            {
        //                dr[cols[cindex]] = vals[r][cindex];
        //            }
        //            dt.Rows.Add(dr);//is it necessary ?
        //        }
        //    }
        //    return dt;
        //}
        public static DataTable GetDataTable(string tablename = "", string[] cols = null, string[,] vals = null)
        {
            DataTable dt = new DataTable(tablename);
            if (cols == null || cols.Length == 0)
                return dt;
            foreach (string col in cols)
                dt.Columns.Add(col);
            if (vals != null && vals.Length != 0)
            {
                for (int r = 0; r < vals.Rank; r++)
                {
                    DataRow dr = dt.NewRow();
                    for (int cindex = 0; cindex < vals.GetLength(r) && cindex < cols.Length; cindex++)
                    {
                        dr[cols[cindex]] = vals[r,cindex];
                    }
                    dt.Rows.Add(dr);//is it necessary ?
                }
            }
            return dt;
        }
        public static DataTable RandomDataTable()
        {
            string tablename = "RandomTable";
            int rows = 2 + RandomTools.rd.Next(3);
            int cols = 2 + RandomTools.rd.Next(4);
            return DataTable32(tablename, rows, cols);
        }
        public static DataTable DataTable32( string tablename = "3_2", int rowi=3,int coli=2)
        {
           
            string[] cols = new string[] { "id", "name", "pid", "value", "remark","text" };
            string[,] aa=new string[3,2];
            for (int i = 0; i < aa.Rank; i++)
            {
                for (int j = 0; j < aa.GetLength(i); j++)
                {
                    aa[i, j] = (i * 100 + j).ToString() ;//"数组:aa[" + i + "," + j + "]";
                }
            }


            /////vals[0]=new string[]{1,3};

            // 要写出二维数组中横坐标的个数和纵坐标的个数，这里是 [2,2]
            string[,] a=new string[2,2] 
{
{"腾","讯"},
{" Q:","Q "}
};

           // object[][] vals = new object[][]
           // {
           //     {},
           //     {},
           // };
            //object[][] vals = new object[][]();
            //string[][] strs=new string[2][2]();
 

            return GetDataTable(tablename, cols, aa);
        }
    }
}