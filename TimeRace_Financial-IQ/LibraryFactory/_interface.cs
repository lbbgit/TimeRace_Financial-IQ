using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LibraryFactory
{
    public interface ICon
    { 
        //string _name;//err
    }
    public interface IConTrue
    {
        void InitCon();
        DataTable GetTable();
        string GetName(); 
    }


    public class con1 : ICon { }
    public class con2 : ICon { }

    public class CreateIconer
    {
        public static ICon CreateIcon(string name)
        {
            ICon a = null;
            switch (name)
            {
                case "con1": a = new con1(); break;
                case "con2": a = new con2(); break;
            }
            return a;
        }
    }

}
