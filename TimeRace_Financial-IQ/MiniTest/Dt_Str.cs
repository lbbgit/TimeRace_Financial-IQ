using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using InitSeed;
using InitSeed.Common.Tools;
namespace MiniTest
{
    public  class Dt_Str
    {
        public static void d1()
        {
            DataSet ds=new DataSet();
            DataTable dt1=DataTableTools.DataTable32();
            DataTable dt2=DataTableTools.DataTable32("tb2",2,2);
            DataTable dt3 = DataTableTools.DataTable32("tb3", 3, 3);
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            ds.Tables.Add(dt3);

            byte[] xml = Serialize.SerializeObject(ds);
            int ixml = xml.Length;
            DataSet ds2 = (DataSet)Serialize.DeserializeObject(xml);

            string json = JsonTools.ToJSON(ds);
            int ijson = json.Length;
            DataSet ds3 = JsonTools.FromJSON<DataSet>(json);
        }
    }
}
