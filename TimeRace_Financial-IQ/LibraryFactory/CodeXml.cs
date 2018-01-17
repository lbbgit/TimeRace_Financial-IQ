using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

public enum enumType
{
    number,datetime,LongText,

    varchar1, varchar10, varchar50, varchar100, varchar200, varchar500,varcharMax
}
 
struct structCol
{
    public enumType enumColType;
    public string enname, displayname, remark; 
    public bool isPK;
    public structCol(enumType _colType, string _enname, string _displayName = "", string _remark = null,bool _isPk=false)
    {
        this.enumColType = _colType;
        this.enname = _enname;
        this.displayname = _displayName;
        this.remark = _remark;
        this.isPK = _isPk;
    }
    void SetPk(bool _isPk = true) { this.isPK = _isPk; }
}
struct structTable
{ 
    List<structCol> pkCols  ;
    List<structCol> cols ;
    //IDictionary<structCol, int> cols = null;
    IDictionary<structCol, structCol> pk ;
    string tableName, tableDisplayName ;
    public structTable(string tableName, string tableDisplayName = null)
    {
        this.tableName = tableName;
        this.tableDisplayName = tableDisplayName;
        pkCols = null;// new List<structCol>();
        cols = null;// new List<structCol>();
        pk = null;
    }
    public void AddCol(structCol new_col)
    {
        cols.Add(new_col);
    }
    public void AddCol(structCol[] new_cols)
    {
        foreach (structCol new_col in new_cols)
            cols.Add(new_col);
    }
    //public void FinishAddCol()
    //{
    //    for (int i = 0; i < cols.Count; i++)
    //    {
    //        for (int j = i + 1; j < cols.Count; j++)
    //        {
    //            if (_cols.enname == new_col.enname)
    //                _cols = new_col;
    //        }
    //    } 
    //}
    void WriteXml(string path)
    {

    }
}
struct structTable2
{
    IDictionary<string, structCol> col ;//= new Dictionary<structCol, structCol>();
}
public class TryDic
{
    public static void t1()
    {
        Dictionary<string ,string> dss=new Dictionary<string,string>();
        Dictionary<int,int> dii=new Dictionary<int,int>();
        
        dss.Add("a","b");
        dss.Add("b","a");
        dss.Add("a ","cc");
        dss.Add("x","b");

        dii.Add(1,2);
        //dii.Add(1,33);
        dii.Add(9,2);

        System.Collections.Hashtable ht = new System.Collections.Hashtable();
        ht.Add("ensd.,sd  ", dii);
        ht.Add(dii, " slaj,sjl sdjl ");
        dii.Add(4, 2); 
        //ht.Add(dii, " sl -%*&(* l ");

        structCol sc = new structCol(enumType.varchar1, "id", "name");
        ht.Add(sc, 233);
        sc.enname = "name222";
        ht.Add(sc, 9);
        //structCol sc2 = new structCol(enumType.varchar1, "id", "name");
        //ht.Add(sc2, 466);
        structCol sc3 = new structCol(enumType.varchar1, "3", "333");
        ht.Add(sc3, 6);
    }
}