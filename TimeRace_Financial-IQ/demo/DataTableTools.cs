using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Xml;
using System.Web.Script.Serialization;//反序列化命名空间
public class DataTableTools
{
    public static string DataTableToJson(DataTable dt)
    {
        var sb = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            sb.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        sb.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        sb.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\"");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    sb.Append("}");
                }
                else
                {
                    sb.Append("},");
                }
            }
            sb.Append("]");
        }
        return sb.ToString();
    }

    //JavaScriptSerializer这个类是由异步通信层内部使用来序列化和反序列化数据。
    //反序列化Json字符串，使用Deserialize或DeserializeObject方法
    public static string DataTable2Json(DataTable dt)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in dt.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);
            }
            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);    
    }



    public static string ConvertDataTableToXML(DataTable dt)
    {
        MemoryStream stream = null;
        XmlTextWriter writer = null;
        try
        {
            stream = new MemoryStream();
            writer = new XmlTextWriter(stream, Encoding.Default);
            dt.WriteXml(writer);
            int count = (int)stream.Length;
            byte[] arr = new byte[count];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(arr, 0, count);
            UTF8Encoding utf = new UTF8Encoding();
            return utf.GetString(arr).Trim();
        }
        catch
        {
            return String.Empty;
        }
        finally
        {
            if (writer != null) writer.Close();
        }
    }

    public static DataSet ConvertXMLToDataSet(string xmlData)
    {
        StringReader stream = null;
        XmlTextReader reader = null;
        try
        {
            DataSet dt = new DataSet();
            stream = new StringReader(xmlData);
            reader = new XmlTextReader(stream);
            dt.ReadXml(reader);
            return dt;
        }
        catch (Exception ex)
        {
            string strTest = ex.Message;
            return null;
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
    }

}