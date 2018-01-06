//Common = {
//    XmlHttp: XmlHttp,
//    Url: XmlHttp
//}


XmlHttp = {
    GetSQLXML: function (sql) {
        sendXml = "<Execute sql='" + sql + "' />";
        var xmlHttp = this.Request("POST", 'HandlerFactory.ashx?action=sql', sendXml);
        return xmlHttp.responseText;
    },

    ExecuteUrl: function (url) {
        xmlHttp = this.Request("GET", url);
        return xmlHttp.responseText;
    },

    ExecuteUrl_WithXml: function (url, sendXml) { //sendXml = "<Execute TagName='Test' rtype='M' />"  
        xmlHttp = this.Request("POST", url, sendXml);
        return xmlHttp.responseText;
    },


    //封装XmlHttp请求支持POST,GET方法；同步与异步调用  callback参数为异步调用必传参数  
    Request: function (method, url, data, callback) {
        var bAsync = false;
        if (callback != undefined && callback != null) bAsync = true;
        var oXmlHttp = this.Create();

        oXmlHttp.open(method, url, bAsync);
        if (bAsync) oXmlHttp.onreadystatechange = function () {
            if (oXmlHttp.readyState == 4 && oXmlHttp.status == 200)
                callback(oXmlHttp.responseText);
        };

        try {
            oXmlHttp.send(data);
        }
        catch (e) {
            alert("请求异常:" + e.Message + "\nUrl:" + url + "\n发送数据:" + data);
        }
        return oXmlHttp;
    },

    //创建XmlHttpRequest对象
    Create: function () {
        var xmlHttp = null;
        try {
            if (window.ActiveXObject) {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
                //确定方法后改为懒函数
                this.Create = function () { return new ActiveXObject("Microsoft.XMLHTTP"); };
            }
            else if (window.XMLHttpRequest) {
                xmlHttp = new XMLHttpRequest();
                //确定方法后改为懒函数
                this.Create = function () { return new XMLHttpRequest(); };
            }
        } catch (e) { }
        return xmlHttp;
    }

}