using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Dt_Str.d1();
        }

        static void test1()
        {
            int i = 2555;
            i = string.Compare(" sElect", "select");
            i = string.Compare(" sElect", "select", true);
            i = string.Compare("sElect", "select");
            i = string.Compare("sElect", "seLEct", true);
            Console.WriteLine(i);

            "sEleCt".IndexOf("select2", StringComparison.OrdinalIgnoreCase);

            sqlType haha = GetSqlType(" selEct iNSErt haha * from ");
            Console.WriteLine(haha.ToString());
        }

         static sqlType GetSqlType(string sql)
        {
            IDictionary<string, sqlType> key_type = new Dictionary<string, sqlType>
            {
                {"update",sqlType.Update},
                {"insert",sqlType.Add},
                {"delete",sqlType.Delete},
                {"select",sqlType.View} //the item“select”should be last ，for maybe the othertype's dataSource
            };
            foreach (KeyValuePair<string, sqlType> _key_type in key_type)
            {
                if(sql.IndexOf(_key_type.Key, StringComparison.OrdinalIgnoreCase)>=0)
                    return _key_type.Value; 
            }
            return sqlType.Execute; 
        }
         enum sqlType
         {
             View, Add, Delete, Update, Execute
         }
    }
}
