<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TimeRace_Financial_IQ.app.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        var urlAshx = "/app/GetDataTable.ashx?action=";
        var Run = function () {
            var ipt = document.getElementById("ipt");
            var sendXml = "<Execute Sql='" + ipt.value + "' TagName='Test' rtype='M' />";
            var url = GetPath(urlAshx) + "GetDataTable&sql=" + ipt.value;
            debugger;
            test2(url);
            var result = XmlHttp.ExecuteUrl(url);
            //var result = XmlHttp.ExecuteUrl_WithXml(url, sendXml); 
        };
        var TabFilter = function () {
            var asp = document.getElementById("asp");
            var html5 = document.getElementById("html5");
            if (asp.style && asp.style.display != "none") {
                asp.style.display = "none";
                html5.style.display = "";
            }
            else {
                asp.style.display = "";
                html5.style.display = "none";
            }
        };
        var GetPath = function (str) {
            var href = window.location.href;
            var index = href.match(/[^\/]\/[^\/]/).index + 1 ;
            return href.substr(0, index) + str;
        }

        //xmlhttp not work,test this
        function test2(url, data) {
            url = url ? url : 'HandlerFactory.ashx?action=test';
            $.ajax({
                url: url, // 'HandlerFactory.ashx?action=test',
                type: 'POST',
                data: data, //{ 'username': username, 'password': password },
                //dataType: 'json',
                timeout: 50000,
                success: function (response) {
                    debugger;
                    alert(response); 
                    return response;
                },
                error: function (err) {
                    alert("执行失败" + (err ? err : ''));
                }
            });
        }

    </script>
    <script src="../Js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../Js/Common.js" type="text/javascript"></script>
    <script src="CreateTable.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <div id="filter">
            <div id="asp">
                <asp:TextBox ID="textSql" runat="server" Text="select * from dictionarys" ></asp:TextBox>
                <asp:Button ID="btnRunSql" runat="server" Text="aspRun" />
            </div>
            <div id="html5" style="display:none">
                <input id="ipt" type="text" value="select * from dictionarys"/>
                <input id="ipt_runs" type="button" onclick="Run();"  value="Run"/>
            </div>
        </div>
       

        <a onclick="TabFilter()";>*</a>
        <asp:GridView ID="gridview" runat="server"
             PagerStyle-ForeColor="LightGray">
            <EmptyDataTemplate>No Data!</EmptyDataTemplate>
            <SelectedRowStyle BackColor="LightBlue" /> 
            <RowStyle />
        </asp:GridView>
        <div id="div-table"></div>
    </div>
    </form>
</body>
</html>
