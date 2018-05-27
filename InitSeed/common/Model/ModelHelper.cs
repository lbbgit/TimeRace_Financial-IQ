using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
namespace InitSeed.Common.Model
{
    public class ModelHelper
    {
        /*
         create table classes(
         id number(9) not null primary key,
         classname varchar2(40) not null
        ) 
         */
        public static string CreateTable(Model md)
        {
            StringBuilder sb = new StringBuilder();
            int iLen=50;
            for (int i = 0; i < md.columns.Count; i++)
            {
                if(md.columns[i].length!=0)
                    iLen=md.columns[i].length;
                sb.AppendFormat("{0} varchar2({1}) {2} {3}",
                      md.columns[i].colName, md.columns[i].length,
                     (md.columns[i].allowDBNull == 0 ? " not null" : ""),
                     (md.columns[i].isPk == 1 ? " primary key" : ""),
                     (i < md.columns.Count - 1 ? "," : "")
                   );
            }


            string sql = string.Format(@"create table {0}( {2}   ) ", md.tableName, sb  );
            return sql;
        }
    }

    public class Model
    {
        public string tableName;
        public List<Col> columns = new List<Col>();
    }

    public class Col
    {
        public string colName,  colType;//type?
        public int length = 0, isPk = 0, allowDBNull = 1; 
    }
}