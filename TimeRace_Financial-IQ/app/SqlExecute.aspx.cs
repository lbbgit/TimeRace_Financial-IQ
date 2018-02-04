using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace TimeRace_Financial_IQ.app
{
    public partial class SqlExecute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //bind click event
            btnRunSql.Click += btnRunSql_Click;

            string sql="select * from dictionarys ";
            ExecuteSqlAndBind(sql);
        }


        protected void btnRunSql_Click(object sender, EventArgs e)
        {
            string sql = textSql.Text;
            ExecuteSqlAndBind(sql);
        }

        void ExecuteSqlAndBind(string sql)
        { 
            DataTable dt = DbTools.SqlServerHelper.GetDTable(sql);
            gridview.DataSource = dt;
            gridview.DataBind();
        }
    }
}