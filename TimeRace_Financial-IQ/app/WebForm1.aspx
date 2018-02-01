<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TimeRace_Financial_IQ.app.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        var Run = function () {
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
    </script>
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
            <input id="ipt_runs" type="button" onclick=""  value="Run"/>
        </div>
    </div>
       

    <a onclick="TabFilter()";>*</a>
    <asp:GridView ID="gridview" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
