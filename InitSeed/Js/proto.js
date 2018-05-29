String.prototype.format = function (args) {
    if (arguments.length > 0) {
        var result = this;
        if (arguments.length == 1 && typeof (args) == "object") {
            for (var key in args) {
                var reg = new RegExp("({" + key + "})", "g");
                result = result.replace(reg, args[key]);
            }
        }
        else {
            for (var i = 0; i < arguments.length; i++) {
                if (arguments[i] == undefined) {
                    return "";
                }
                else {
                    var reg = new RegExp("({[" + i + "]})", "g");
                    result = result.replace(reg, arguments[i]);
                }
            }
        }
        return result;
    }
    else {
        return this;
    }
} 




String.prototype.Replace = function(oldValue,newValue) 
    { 
        var reg = new RegExp(oldValue,"g"); 
        return this.replace(reg, newValue); 
    }
    //字符串替换；曾经很头疼写了很多代码，还是这个简单
    function replace(obj)
    {
        alert(obj.value.Replace("a","d"));
    }
    // 另存为文件
    function SaveCode(obj, filename) 
    {
        var win = window.open('', '_blank', 'top=100'); 
        var code = obj.innerText; 
        code = code == null || code == "" ? obj.value : code; 
        win.opener = null;
        win.document.write(code);
        win.document.execCommand('saveas', true, filename);
        win.close();
    }
//    //问候
//    window.onload = function()
//    {    
//        var now = new Date();
//        var hour = now.getHours();
//        var greeting;
//        if (hour < 6)
//            greeting = "凌晨好";
//        else if (hour < 10)
//            greeting = "早上好";
//        else if (hour < 14)
//            greeting = "中午好";
//        else if (hour < 18)
//            greeting = "下午好";
//        else 
//            greeting = "晚上好";
//            
//        document.getElementById("hi").innerHTML = "<font color=red>" + greeting + "</font>" ;
//    }
    //将光标停在对象的最后
    function PutCursorAtLast(obj) 
    { 　
        obj.focus();
        var range = obj.createTextRange(); 
        range.moveStart('character',obj.value.length); 
        range.collapse(true); 
        range.select(); 
    }

    // 将光标停在对象的最前
    function PutCursorAtFirst(obj) 
    { 　
        obj.focus();
        var range = obj.createTextRange(); 
        range.moveStart('character',0); 
        range.collapse(true); 
        range.select(); 
    }
 
// 返回字符的长度，一个中文算2个
String.prototype.ChineseLength=function()
{ 
    return this.replace(/[^/x00-/xff]/g,"**").length;
}
// 判断字符串是否以指定的字符串结束
String.prototype.EndsWith = function(str) 
{
    return this.substr(this.length - str.length) == str;
}
// 去掉字符左端的的空白字符
String.prototype.LeftTrim = function()
{
    return this.replace(/(^[//s]*)/g, "");
}
// 去掉字符右端的空白字符
String.prototype.RightTrim = function()
{
    return this.replace(/([//s]*$)/g, "");
}
// 判断字符串是否以指定的字符串开始
String.prototype.StartsWith = function(str) 
{
    return this.substr(0, str.length) == str;
}
// 去掉字符两端的空白字符
String.prototype.Trim = function()
{
    return this.replace(/(^/s*)|(/s*$)/g, "");
} 
String.prototype.trim = function (value) {
    if (value) {
        var exp = eval("/^" + value + "+|" + value + "+$/g");
        return this.replace(exp, "");
    }
    return this.replace(/^\s+|\s+$/g, "");
}


/*
//<input type="text" id="txtone" value="例子test"/><input type='button' value="返回字符的长度，一个中文算2个"
 onclick="alert(document.getElementById('txtone').value.ChineseLength())" /><br/>
//<input type="text" id="txttwo" value="例子test"/> 结尾字符串：<input type="text" id="txttwo1" value="test"/>
//<input type='button' value="判断字符串是否以指定的字符串结束" 
onclick="alert(document.getElementById('txttwo').value.EndsWith(document.getElementById('txttwo1').value))" /><br/>
//<input type="text" id="txtthree" value=" 例子test "/><input type='button' value="去掉字符左端的的空白字符"
 onclick="document.getElementById('txtthree').value = document.getElementById('txtthree').value.LeftTrim()" /><br/>
//<input type="text" id="txtfour" value=" 例子test "/><input type='button' value="去掉字符右端的空白字符"
 onclick="document.getElementById('txtfour').value = document.getElementById('txtfour').value.LeftTrim()" /><br/>
//<input type='text' type="text" id="txtfive" value=" sstest "/> 开始字符串：<input type="text" id="txtfive1" value="ss"/>
//<input type='button' value="判断字符串是否以指定的字符串开始"
 onclick="alert(document.getElementById('txtfive').value.StartsWith(document.getElementById('txtfive1').value))" /><br/>
//<input type="text" id="txtsix" value=" 例子test "/><input type='button' value="去掉字符两端的空白字符"
 onclick="document.getElementById('txtsix').value = document.getElementById('txtsix').value.Trim();" /><br/>
*/


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

Date.prototype.Format = function (date, type) { 
    //return $.DateFormat(date, type);
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

Date.prototype.add = function (strInterval, Number) {
    var dtTmp = this;
    switch (strInterval) {
        case 's' :
            return new Date(Date.parse(dtTmp) + (1000 * Number));
        case 'n' :
            return new Date(Date.parse(dtTmp) + (60000 * Number));
        case 'h' :
            return new Date(Date.parse(dtTmp) + (3600000 * Number));
        case 'd' :
            return new Date(Date.parse(dtTmp) + (86400000 * Number));
        case 'w' :
            return new Date(Date.parse(dtTmp) + ((86400000 * 7) * Number));
        case 'q' :
            return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number * 3, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());
        case 'm' :
            return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());
        case 'y' :
            return new Date((dtTmp.getFullYear() + Number), dtTmp.getMonth(), dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());
    }
}


function extend_base(){ 
    if(!String.prototype.format ){
        String.prototype.format = function() {
            var e = arguments;
            return this.replace(/{(\d+)}/g,function(t, n) {
                return typeof e[n] != "undefined" ? e[n] : t
            })
        };
    }
    
    if (!Array.prototype.forEach && typeof Array.prototype.forEach !== "function") {
        Array.prototype.forEach = function(callback, context) {
           // 遍历数组,在每一项上调用回调函数，这里使用原生方法验证数组。
           if (Object.prototype.toString.call(this) === "[object Array]") {
               var i,len;
               //遍历该数组所有的元素
               for (i = 0, len = this.length; i < len; i++) {
                   if (typeof callback === "function"  && Object.prototype.hasOwnProperty.call(this, i)) {
                       if (callback.call(context, this[i], i, this) === false) {
                           break; // or return;
                       }
                   }
               }
           }
        };
    }
    
    if(!String.prototype.format ){
        Array.isArray = function(obj){
            return obj.constructor.toString().indexOf('Array') != -1;
        }
    }


    //待补充 ...
    
}();//run it
 
 // ------------------------ 工具包---------------------------------//
var utils = {
            center : function(dom){
                dom.style.position = 'absolute';
                dom.style.top = '50%';
                dom.style.left = '50%';
                dom.style['margin-top'] = - dom.offsetHeight / 2 + 'px';
                dom.style['margin-left'] = - dom.offsetWidth / 2 + 'px';
            },
        
            /** dom相关 * */
            isDom : ( typeof HTMLElement === 'object' ) ?
                function(obj){
                    return obj instanceof HTMLElement;
                } :
                function(obj){
                    return obj && typeof obj === 'object' && obj.nodeType === 1 && typeof obj.nodeName === 'string';
                } ,
             
            /** 数组相关 * */
            isArray : function(obj){
                return obj.constructor.toString().indexOf('Array') != -1;
            }
            
        } 