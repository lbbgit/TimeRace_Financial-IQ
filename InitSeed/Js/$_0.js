//依赖jquery，兼容所有主流浏览器，目前有队列ajax、信息提示、字符串拼接、加载提示等
(function (a, b) { String.prototype.jsclass_Format = function (d) { var c = this; if (arguments.length < 1) { return c } var g = arguments; if (arguments.length == 1 && typeof (d) == "object") { g = d } for (var e in g) { var f = g[e]; if (undefined != f) { c = c.replace("{" + e + "}", f) } } return c }; a.jsclass = b() } (this, function () { var c = 0; var a = { loading: function () { return { parent: function () { var d = $("<div></div>"); d.attr("class", "loading"); d.css({ "position": "fixed", "width": "100%", "height": "100%", "background": "rgba(207, 207, 207, 0.35)", "left": "0", "top": "0", "z-index": "999999", "display": "none" }); return d }, mask: function () { var d = $("<div></div>"); d.css({ "background": "#ffffff", "margin": "0 auto", "width": "66px", "height": "66px", "border-radius": "10px", "position": "absolute", "left": "50%", "top": "50%", "margin-left": "-33px", "margin-top": "-33px" }); return d }, img: function () { var d = $("<img/>"); d.css({ "margin": "0 auto", "margin-top": "15px", "display": "block" }); d.attr({ "src": " data:image/gif;base64,R0lGODlhJQAlAJECAL3L2AYrTv///wAAACH/C05FVFNDQVBFMi4wAwEAAAAh+QQFCgACACwAAAAAJQAlAAACi5SPqcvtDyGYIFpF690i8xUw3qJBwUlSadmcLqYmGQu6KDIeM13beGzYWWy3DlB4IYaMk+Dso2RWkFCfLPcRvFbZxFLUDTt21BW56TyjRep1e20+i+eYMR145W2eefj+6VFmgTQi+ECVY8iGxcg35phGo/iDFwlTyXWphwlm1imGRdcnuqhHeop6UAAAIfkEBQoAAgAsEAACAAQACwAAAgWMj6nLXAAh+QQFCgACACwVAAUACgALAAACFZQvgRi92dyJcVJlLobUdi8x4bIhBQAh+QQFCgACACwXABEADAADAAACBYyPqcsFACH5BAUKAAIALBUAFQAKAAsAAAITlGKZwWoMHYxqtmplxlNT7ixGAQAh+QQFCgACACwQABgABAALAAACBYyPqctcACH5BAUKAAIALAUAFQAKAAsAAAIVlC+BGL3Z3IlxUmUuhtR2LzHhsiEFACH5BAUKAAIALAEAEQAMAAMAAAIFjI+pywUAIfkEBQoAAgAsBQAFAAoACwAAAhOUYJnAagwdjGq2amXGU1PuLEYBACH5BAUKAAIALBAAAgAEAAsAAAIFhI+py1wAIfkEBQoAAgAsFQAFAAoACwAAAhWUL4AIvdnciXFSZS6G1HYvMeGyIQUAIfkEBQoAAgAsFwARAAwAAwAAAgWEj6nLBQAh+QQFCgACACwVABUACgALAAACE5RgmcBqDB2MarZqZcZTU+4sRgEAIfkEBQoAAgAsEAAYAAQACwAAAgWEj6nLXAAh+QQFCgACACwFABUACgALAAACFZQvgAi92dyJcVJlLobUdi8x4bIhBQAh+QQFCgACACwBABEADAADAAACBYSPqcsFADs=" }); return d } } } (), Layer: function (f) { var e = "<style>.alert_box{display:none;position:fixed;width:100%;height:100%;background:rgba(0,0,0,0.33);z-index:99999;left:0;top:0}.alert_body{display:none;width:400px;position:fixed;background:#fff;z-index:999999;left:50%;margin-left:-200px;border-radius:0 0 10px 10px}.alert_body div{height:35px;line-height:35px}.alert_body h2{display:block;padding:15px;text-align:center}.alert_foot_left{background:#eaeaea;width:50%;float:left;border-radius:0 0 0 10px;text-align:center;cursor:pointer;font-weight:bold}.alert_foot_left:hover{opacity:.4}.alert_foot_right:hover{opacity:.6}.alert_foot_right{background:#e8b3ff;width:50%;float:left;border-radius:0 0 10px 0;text-align:center;color:#fff;font-weight:bold;cursor:pointer}</style>"; var d = $('<div class="alert_box"><div class="alert_body"><h2><strong>{0}</strong></h2><div><div class="alert_foot_left">取消</div><div class="alert_foot_right">确定</div></div></div></div>'.jsclass_Format({ 0: f })); d.append(e); $("body").append(d); $(".alert_box").fadeToggle(500); $(".alert_body").css({ "top": "-" + $(".alert_body").height() + "px" }).show().animate({ top: 0 }, 300); $(".alert_box").click(function (g) { if (g.target == this) { $(this).remove() } }); return d } }; var b = { Ajax_Func: function (g) { var e = $.type(g); if (e == "array") { for (var d = 0; d < g.length; d++) { (function (h) { var j = $.extend({ load: true, url: null, type: "post", data: null, success: null, async: true, contentType: "application/json;charset=utf-8" }, g[h]); if (b.layer.Loading.obj().length == 0 && j.load) { b.layer.Loading.open(); c = g.length } $.ajax({ type: j.type, url: j.url, data: j.data, contentType: j.contentType, async: j.async }).done(function (i) { if (typeof j.success === "function") { j.success(i) } --c; if (c == 0 && b.layer.Loading.obj().length > 0) { b.layer.Loading.close(); c = 0 } }) } (d)) } } else { if (e == "object") { var f = $.extend({ load: true, url: null, type: "post", data: null, success: null, async: true, contentType: "application/json;charset=utf-8" }, g); if (b.layer.Loading.obj().length == 0 && f.load) { b.layer.Loading.open() } $.ajax({ type: f.type, url: f.url, data: f.data, contentType: f.contentType, async: f.async }).done(function (h) { if (typeof f.success === "function") { f.success(h) } if (b.layer.Loading.obj().length > 0) { b.layer.Loading.close() } }) } } }, layer: { alert: function (d) { a.Layer(d); $(".alert_foot_left,.alert_foot_right").parent().hide() }, confirm: function (e) { var d = a.Layer(e.text); d.find(".alert_foot_left").click(function () { b.layer.close(); typeof e.no === "function" ? e.no() : undefined }); d.find(".alert_foot_right").click(function () { b.layer.close(); typeof e.ok === "function" ? e.ok() : undefined }); $(".alert_foot_left,.alert_foot_right").parent().show() }, Loading: { open: function () { $("body").append(a.loading.parent().append(a.loading.mask().append(a.loading.img()))); $(".loading").show() }, close: function () { $(".loading").remove() }, obj: function () { return $(".loading") } }, close: function () { $(".alert_box").remove() } } }; return b }));

(function (a, b) { String.prototype.jsclass_Format = function (d) { var c = this; if (arguments.length < 1) { return c } var g = arguments; if (arguments.length == 1 && typeof (d) == "object") { g = d } for (var e in g) { var f = g[e]; if (undefined != f) { c = c.replace("{" + e + "}", f) } } return c }; a.jsclass = b() } (this, function () { var c = 0; var a = { loading: function () { return { parent: function () { var d = $("<div></div>"); d.attr("class", "loading"); d.css({ "position": "fixed", "width": "100%", "height": "100%", "background": "rgba(207, 207, 207, 0.35)", "left": "0", "top": "0", "z-index": "999999", "display": "none" }); return d }, mask: function () { var d = $("<div></div>"); d.css({ "background": "#ffffff", "margin": "0 auto", "width": "66px", "height": "66px", "border-radius": "10px", "position": "absolute", "left": "50%", "top": "50%", "margin-left": "-33px", "margin-top": "-33px" }); return d }, img: function () { var d = $("<img/>"); d.css({ "margin": "0 auto", "margin-top": "15px", "display": "block" }); d.attr({ "src": " data:image/gif;base64,R0lGODlhJQAlAJECAL3L2AYrTv///wAAACH/C05FVFNDQVBFMi4wAwEAAAAh+QQFCgACACwAAAAAJQAlAAACi5SPqcvtDyGYIFpF690i8xUw3qJBwUlSadmcLqYmGQu6KDIeM13beGzYWWy3DlB4IYaMk+Dso2RWkFCfLPcRvFbZxFLUDTt21BW56TyjRep1e20+i+eYMR145W2eefj+6VFmgTQi+ECVY8iGxcg35phGo/iDFwlTyXWphwlm1imGRdcnuqhHeop6UAAAIfkEBQoAAgAsEAACAAQACwAAAgWMj6nLXAAh+QQFCgACACwVAAUACgALAAACFZQvgRi92dyJcVJlLobUdi8x4bIhBQAh+QQFCgACACwXABEADAADAAACBYyPqcsFACH5BAUKAAIALBUAFQAKAAsAAAITlGKZwWoMHYxqtmplxlNT7ixGAQAh+QQFCgACACwQABgABAALAAACBYyPqctcACH5BAUKAAIALAUAFQAKAAsAAAIVlC+BGL3Z3IlxUmUuhtR2LzHhsiEFACH5BAUKAAIALAEAEQAMAAMAAAIFjI+pywUAIfkEBQoAAgAsBQAFAAoACwAAAhOUYJnAagwdjGq2amXGU1PuLEYBACH5BAUKAAIALBAAAgAEAAsAAAIFhI+py1wAIfkEBQoAAgAsFQAFAAoACwAAAhWUL4AIvdnciXFSZS6G1HYvMeGyIQUAIfkEBQoAAgAsFwARAAwAAwAAAgWEj6nLBQAh+QQFCgACACwVABUACgALAAACE5RgmcBqDB2MarZqZcZTU+4sRgEAIfkEBQoAAgAsEAAYAAQACwAAAgWEj6nLXAAh+QQFCgACACwFABUACgALAAACFZQvgAi92dyJcVJlLobUdi8x4bIhBQAh+QQFCgACACwBABEADAADAAACBYSPqcsFADs=" }); return d } } } (), Layer: function (f) { var e = "<style>.alert_box{display:none;position:fixed;width:100%;height:100%;background:rgba(0,0,0,0.33);z-index:99999;left:0;top:0}.alert_body{display:none;width:400px;position:fixed;background:#fff;z-index:999999;left:50%;margin-left:-200px;border-radius:0 0 10px 10px}.alert_body div{height:35px;line-height:35px}.alert_body h2{display:block;padding:15px;text-align:center}.alert_foot_left{background:#eaeaea;width:50%;float:left;border-radius:0 0 0 10px;text-align:center;cursor:pointer;font-weight:bold}.alert_foot_left:hover{opacity:.4}.alert_foot_right:hover{opacity:.6}.alert_foot_right{background:#e8b3ff;width:50%;float:left;border-radius:0 0 10px 0;text-align:center;color:#fff;font-weight:bold;cursor:pointer}</style>"; var d = $('<div class="alert_box"><div class="alert_body"><h2><strong>{0}</strong></h2><div><div class="alert_foot_left">取消</div><div class="alert_foot_right">确定</div></div></div></div>'.jsclass_Format({ 0: f })); d.append(e); $("body").append(d); $(".alert_box").fadeToggle(500); $(".alert_body").css({ "top": "-" + $(".alert_body").height() + "px" }).show().animate({ top: 0 }, 300); $(".alert_box").click(function (g) { if (g.target == this) { $(this).remove() } }); return d } }; var b = { Ajax_Func: function (g) { var e = $.type(g); if (e == "array") { for (var d = 0; d < g.length; d++) { (function (h) { var j = $.extend({ load: true, url: null, type: "post", data: null, success: null, async: true, contentType: "application/json;charset=utf-8" }, g[h]); if (b.layer.Loading.obj().length == 0 && j.load) { b.layer.Loading.open(); c = g.length } $.ajax({ type: j.type, url: j.url, data: j.data, contentType: j.contentType, async: j.async }).done(function (i) { if (typeof j.success === "function") { j.success(i) } --c; if (c == 0 && b.layer.Loading.obj().length > 0) { b.layer.Loading.close(); c = 0 } }) } (d)) } } else { if (e == "object") { var f = $.extend({ load: true, url: null, type: "post", data: null, success: null, async: true, contentType: "application/json;charset=utf-8" }, g); if (b.layer.Loading.obj().length == 0 && f.load) { b.layer.Loading.open() } $.ajax({ type: f.type, url: f.url, data: f.data, contentType: f.contentType, async: f.async }).done(function (h) { if (typeof f.success === "function") { f.success(h) } if (b.layer.Loading.obj().length > 0) { b.layer.Loading.close() } }) } } }, layer: { alert: function (d) { a.Layer(d); $(".alert_foot_left,.alert_foot_right").parent().hide() }, confirm: function (e) { var d = a.Layer(e.text); d.find(".alert_foot_left").click(function () { b.layer.close(); typeof e.no === "function" ? e.no() : undefined }); d.find(".alert_foot_right").click(function () { b.layer.close(); typeof e.ok === "function" ? e.ok() : undefined }); $(".alert_foot_left,.alert_foot_right").parent().show() }, Loading: { open: function () { $("body").append(a.loading.parent().append(a.loading.mask().append(a.loading.img()))); $(".loading").show() }, close: function () { $(".loading").remove() }, obj: function () { return $(".loading") } }, close: function () { $(".alert_box").remove() } } }; return b }));



//测试各平台兼容性(主打FFX Chrome42.0)
$.BasePath = '/js/NS/'; //$.n1.n2.js
$.NS = { nspaces: [] };
$.NS.register = function (ns) {
    var nsArray = ns.split('.');
    var sEval = "";
    var sNS = "";
    for (var i = 0; i < nsArray.length; i++) {
        if (i != 0) sNS += ".";
        sNS += nsArray[i];
        sEval += "if (typeof(" + sNS + ") == 'undefined') " + sNS + " = new Object();"
    }
    if (sEval != "") eval(sEval);
    this.nspaces.push(ns);
}
$.NS.include = function (ns) {
    if (!ns || ns.toLowerCase() == '*' || ns.toLowerCase() == 'all') {
        for (var i = 0; i < this.nspaces.length; i++) {
            var sInclude = ["<script type='text/javascript' src='", $.BasePath, this.nspaces[i], ".js'><\/script>"].join('');
            document.write(sInclude);
        }
    }
    else {
        for (var i = 0; i < this.nspaces.length; i++) {
            if (this.nspaces[i] == ns) {
                var sInclude = ["<script type='text/javascript' src='", $.BasePath, this.nspaces[i], ".js'><\/script>"].join('');
                document.write(sInclude);
                break;
            }
        }
    }
}

//屏蔽鼠标右键功能
$(document).ready(function () {
    document.body.oncontextmenu = function () { return false; }
});
$(document).ready(function () {
    document.body.oncontextmenu = function () { return false; }
    document.onkeydown = function () {
        if (event.keyCode == 122 || event.keyCode == 123) {
            event.keyCode = 0; 
            event.cancelBubble = true; 
            return false; 
    } }

});
;





$.Trim = function (str) {
    return null == str ? str : str.replace(/^\s+|\s+$/g, "");
}



//客户端解析枚举类型 如0代表女 1代表男 ParamEnum(val, "0:女,1:男")
$.ParamEnum = function (val, enumstring) {
    var rvalue = null;
    var arrenums = enumstring.split(',');
    for (var i = 0; i < arrenums.length; i++) {
        if (val.toString().toLowerCase() == $.trim(arrenums[i].split(':')[0]).toLowerCase()) {
            rvalue = arrenums[i].split(':')[1];
            break;
        }
    }
    return rvalue;
}
// 创建一个XMLDOM实体对象
$.CreateXMLDOM = function () {
    try {
        this.xmlDoc = new ActiveXObject("MSXML2.DOMDocument");
        return this.xmlDoc;
    }
    catch (e) {
        alert("DOM document not created. Check MSXML version used in createXmlDomDocument.");
        return null;
    }
}






 
String.prototype.trim = function (value) {
    if (value) {
        var exp = eval("/^" + value + "+|" + value + "+$/g");
        return this.replace(exp, "");
    }
    return this.replace(/^\s+|\s+$/g, "");
}


//名称：日期格式转换
//参数：日期字符串和格式类型
//type： 0--用'-'分隔日期  1--用'/'分隔日期  2--年月日分隔日期  3--包含具体的时间信息
var DateFormat = $.DateFormat = function (date, type) {
    var dateFormat = "";
    var dateSplit = date.split("T");

    switch (type) {
        case "0": dateFormat = dateSplit[0];
            break;
        case "1": dateFormat = dateSplit[0].replace(/-/g, "/");
            break;
        case "2": var arrDate = dateSplit[0].split("-");
            dateFormat = arrDate[0] + "年" + arrDate[1] + "月" + arrDate[2] + "日";
            break;
        case "3":
            if (dateSplit[1].indexOf(".") != -1) {
                dateFormat = dateSplit[0] + " " + dateSplit[1].split(".")[0];
            }
            else if (dateSplit[1].indexOf("+") != -1) {
                dateFormat = dateSplit[0] + " " + dateSplit[1].split("+")[0];
            }
            break;
    }

    return dateFormat;
}
Date.prototype.Format = function (date, pattern) {
    return $.DateFormat(date, pattern);
}


//得到URL参数集合
$.GetUrlParam = function (url) {
    //如果URL为空或不带参数则直接返回null  
    url = (url || "").replace(/\?+/g, "?").replace(/[\s\#\?\&]+$/g, "");
    if (url.indexOf("?") == -1) {
        return null;
    }

    var argsUrl = url.split("?")[1];

    if (argsUrl.indexOf("=") == -1) {
        return null;
    }
    var result = {};
    var arrParams = argsUrl.split('&');
    for (var i = 0; i < arrParams.length; i++) {
        var pos = arrParams[i].indexOf("=");
        if (pos <= 0) continue;
        var paramName = arrParams[i].substr(0, pos);
        var paramValue = arrParams[i].substr(pos + 1);
        result[paramName] = paramValue;
    }

    return result;
}

$.QueryString = function (name) {
    return $.GetUrlParamValue(window.location.href, name);
}
//得到URL指定参数的值
$.GetUrlParamValue = function (paramName, url) {
    if (!url)
        url = window.location.href;
    if (typeof paramName == "undefined") return null;
    var queryString = $.GetUrlParam(url);
    if (!queryString) return null;
    for (var key in queryString) {
        if (key.toLowerCase() == paramName.toLowerCase()) {
            return queryString[key];
        }
    }
    return null;
}

//URL参数值替换
$.UpdateUrlParameter = function (url, p_name, p_value) {
    var u = url.split('?')[0];
    var ps = url.split('?')[1].split('&');
    var n;
    for (var i = 0; i < ps.length; i++) {
        n = ps[i].split('=')[0];
        if (n.toLowerCase() == p_name.toLowerCase()) {
            ps[i] = p_name + "=" + p_value;
            break;
        }
    }
    u = u + "?";
    for (var i = 0; i < ps.length; i++)
        u += ps[i] + "&"

    if (u.lastIndexOf("&") == u.length - 1)
        u = u.substring(0, u.length - 1);

    return u;
}




$.NS.register('$.Common');
$.NS.register('$.Tools.Common');

//支持json 
//$.SetCookie("AAA", "[{id:230,name:'sbf',theme:'green'},{id:240,name:'zlh',theme:'blue'}]");
// 写Cookie 默认保存1 year 
$.SetCookie = function (name, value, days) {
    var Days = days || 365;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString() + ";path=/";
}

// 读Cookie
$.GetCookie = function (name) {
    var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
    if (arr != null) return unescape(arr[2]); return null;

}

// 删除Cookie
$.DelCookie = function (name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = $.GetCookie(name);
    if (cval != null) document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString() + ";path=/";
}
// 选择颜色  隐藏域或文本框ID:valueId  呈现颜色的容器ID:viewId
$.ColorSelect = function (valueId, viewId, action) {
    action = action || "";
    var dEL = document.getElementById(valueId);
    var sEL = document.getElementById(viewId);
    var color = (dEL) ? dEL.value : "#ffffff";
    var url = "/selcolor.htm?color=" + encodeURIComponent(color) + "&action=" + action;
    var c = showModalDialog(url, window, "dialogWidth:250px;dialogHeight:250px;help:no;scroll:no;status:no");
    if (c) {
        if (dEL) dEL.value = c;
        if (sEL) sEL.style.backgroundColor = c;
        else if (event && event.srcElement) event.srcElement.style.backgroundColor = c;
    }
    return c;
}


//选择文件或文件夹，返回值 为用逗号分隔的文件或文件夹名称
/*  参数说明 
*    obj.IsSelFolder = false;  //标识是选择文件夹或文件（true:文件夹|false:文件）
*    obj.BeginCatalog = "/";   //搜索开始目录
*    obj.IsSelMore = true;  //标识是否选择多个文件或文件夹
*    obj.IsShowSearch = true;  //标识是否显示搜索栏
*    obj.SelFileName = "";  //搜索指定文件后缀或名称(多个用';'分隔)
*    obj.RemoveFileName = "*.ini;";   //排除指定文件后缀或名称(多个用';'分隔)
*    obj.RemoveFolderName = ".svn;bin;";  //排除指定文件夹名称(多个用';'分隔)
*/
$.SelFolder = function (obj) {
    var width = "600px";
    if (obj && obj.IsSelFolder === false) {
        width = "800px"
    }
    var result = window.showModalDialog("/FilePageChoosePage.htm", obj, "dialogHeight=550px; dialogWidth=" + width + ";center=1;scroll=0;resizable=no;help=0;status=0");
    return result;
}

// 选择图片 searchName:图片过滤名称，displaySize:图片大小,isAsyn:是否异步
$.ImagesSelect = function (img, searchName, displaySize, isAsyn) {
    if (typeof img == "string") {
        img = document.getElementById(img);
    }
    // 图片的地址    
    var strUrl = "/SelectImage.aspx";
    var obj = new Object();
    //	过滤图片名称
    (!searchName) ? obj.Name = "" : obj.Name = searchName;
    //	过滤图片尺寸（如：12,12|宽,高、16,16|宽,高。请用小写逗号间隔）
    (!displaySize) ? obj.Size = "14,14" : obj.Size = displaySize;
    // 是否异步
    obj.IsAsyn = (isAsyn == true);

    //var imgsrc = img.value;
    var resault = window.showModalDialog(strUrl, obj, 'dialogHeight:462px;dialogWidth:660px;resizable:no');
    if (resault != undefined) {
        if (resault) {
            if (resault != "false") {
                img.style.display = "";
                $(img).attr({ "src": resault, "value": resault });
            }
        }
        else {
            img.src = "";
            img.style.display = "none";
            $(img).attr({ "src": resault, "value": resault });
        }
    }

}










//设置容器的HTML 如果html包含脚本将重新激发脚本
$.SetInnerHtml = function (container, html) {
    if (typeof container == "string") {
        container = document.getElementById(container);
    }
    var re = /<script[^>]*>[\s|\S]*?<\/script>/igm;
    var s_re = /<script(.|\n)*?>((.|\n|\r\n)*)?<\/script>/im;
    var ssrc_re = /src=("|').*?("|')/gi;
    var style_re = /<style[^>]*>[\s|\S]*?<\/style>/igm;

    var ss = html.match(re); //得到所有脚本标记                    
    html = html.replace(re, ''); //删除所有脚本标记
    var styles = html.match(style_re); //得到所有样式
    html = html.replace(style_re, ''); //删除所有样式
    if (styles)
        html += styles.join(''); //添加样式
    container.innerHTML = html;

    //reignite script Dom
    var head = document.getElementsByTagName("head")[0];
    var s_all = [];
    if (ss) {
        for (var i = 0; i < ss.length; i++) {
            if (/ src=/gi.test(ss[i])) {
                var src = ss[i].match(ssrc_re)[0].replace(/src=/gi, '').replace(/("|')/gi, '');
                //脚本库JS不重复加载
                if (src.toLowerCase().indexOf("include/js/$.") != -1) {
                    if (eval("/src=('|\")*" + src.replace(/\//gi, '\\/') + "('|\")*/gi").test(head.innerHTML))
                        continue; //已引用就不再添加
                }
                //20150918 zhoulin, 改成公共方法引入Js
                var settings = { type: "GET", async: false, dataType: "script" };
                $.XmlHttp.RfAjax(src, "", settings);
            }
            else {
                var sss = ss[i];
                s_all.push(sss.match(s_re)[2]);
            }
        }

        setTimeout(function () {
            var scon = s_all.join('').replace(/<!--/gm, '').replace(/-->/gm, '');
            if (scon != "")
                window.execScript ? window.execScript(scon) : eval(scon);
        }, 0);
    }
}
//引用JS文件
$.IncludeScript = function (strScript) {
    var head = document.getElementsByTagName("head")[0];
    if (eval("/src=('|\")*" + strScript.replace(/\//gi, '\\/') + "('|\")*/gi").test(head.innerHTML)) {
        return; //已引用就不再添加
    }
    //    var a = document.createElement("script");
    //    a.type = "text/javascript";
    //    a.src = strScript;
    //    head.appendChild(a);

    //$("<script />").attr({ type: "text/javascript", src: strScript }).appendTo(head);
    //20150918 zhoulin, 改成公共方法引入Js
    $.XmlHttp.RfAjax(strScript, "", { type: "GET", dataType: "script", async: false });
}

//创建GUID
$.NewGuid = function () {
    var guid = "";
    for (var i = 1; i <= 32; i++) {
        var n = Math.floor(Math.random() * 16.0).toString(16);
        guid += n;
        if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
            guid += "-";
    }
    return guid.toUpperCase();
}

$.HTMLEncode = function (text) {
    if (typeof (text) != "string")
        text = text.toString();

    text = text.replace(/&/gi, "&amp;")
    .replace(/"/gi, "&quot;")
    .replace(/</gi, "&lt;")
    .replace(/>/gi, "&gt;")
    //.replace(/ /gi, "&nbsp;")
    .replace(/\xa1/gi, "&iexcl;")
    .replace(/\xa2/gi, "&cent;")
    .replace(/\xa3/gi, "&pound;")
    .replace(/\xa9/gi, "&copy;");
    return text;
}

$.HTMLDecode = function (text) {
    if (!text)
        return '';

    text = text.replace(/&(amp|#38);/gi, "&")
        .replace(/&(quot|#34);/gi, "\"")
        .replace(/&(lt|#60);/gi, "<")
        .replace(/&(gt|#62);/gi, ">")
    //.replace(/&(nbsp|#160);/gi, " ")
        .replace(/&(iexcl|#161);/gi, "\xa1")
        .replace(/&(cent|#162);/gi, "\xa2")
        .replace(/&(pound|#163);/gi, "\xa3")
        .replace(/&(copy|#169);/gi, "\xa9")

    return text;
}

