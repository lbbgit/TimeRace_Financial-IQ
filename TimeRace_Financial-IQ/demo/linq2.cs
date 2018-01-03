using System;
using System.IO;
using System.Text;
using System.Collections; 
using System.Linq;

using System.Collections.Generic;//List 
public class linq2
{
    public class bauser { public string UserCode, UserName;} 
    public void t1()
    {
        //can Use class's class
        List<other.linq2_other.heng> list_other = new List<other.linq2_other.heng>();
        //List<heng> list_other2 = new List<heng>();

        List<bauser> list = new List<bauser>();
        list.Add(new bauser { UserCode = "111", UserName = "1111" });
        list.Add(new bauser { UserCode = "111", UserName = "0000" }); 
        list.Add(new bauser { UserCode = "222", UserName = "0000" });
        //using System.Linq
        var query = from l in list 
                    group l by l.UserCode into g
                    select new
                    {
                        Code = g.Key,
                        Name = g.Max(c => c.UserName)
                    };
        var result = query.ToList();
    }

   

}
namespace other
{
    public class linq2_other
    {
        public void t1() { linq2.bauser a = new linq2.bauser(); }
        public class heng { public string aha { get; set; } }
    }
}