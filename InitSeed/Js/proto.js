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



//避免已经设置过了,就不会重复设置,好!\(^o^)/~
(function(_window){

    //数组新增某些方法 
    //forEach方法从头到尾遍历数组，为每个数组元素调用指定函数并提供当前元素，当前索引与数组当做参数传给函数

    Array.prototype.forEach||(Array.prototype.forEach=function(fun){

        for(var i=0;i<this.length;i++){

            fun(this[i],i,this);

        }

    })

    //map方法遍历数组并调用指定函数，最后返回一个数组，数组由所有函数返回值组成

    Array.prototype.map||(Array.prototype.map=function(fun){

        var returnArray=[];

        for(var i=0;i<this.length;i++){

            returnArray.push(fun(this[i],i,this));

        }

        return returnArray;

    })

    //filter相当一个数组的帅选器，遍历数组并调用指定函数，并返回一个新数组，如果函数返回true则添加返回的数组。

    Array.prototype.filter||(Array.prototype.filter=function(fun){

        var returnArray=[];

        for(var i=0;i<this.length;i++){

            if(fun(this[i],i,this)){

                returnArray.push(this[i]);

            }

        }

        return returnArray;

    })

    //every 遍历数组调用指定函数，当所有函数都返回true 则every返回true否则返回false。

    Array.prototype.every||(Array.prototype.every=function(fun){

        if(this.length==0) return true;

        //every应该尽早结束循环

        for(var i=0;i<this.length;i++){

            if(!fun(this[i],i,this)){

                return false;

            }

        }

        return true;

    })

    //some 遍历数组调用指定函数，当有一个函数返回true就返回true,当所有函数都返回false就返回false

    Array.prototype.some||(Array.prototype.some=function(fun){

        if(this.length==0) return false;

        //some应该尽早结束循环

        for(var i=0;i<this.length;i++){

            if(fun(this[i],i,this)){

                return true;

            }

        }

        return false;

    })

    //reduce 遍历数组调用指定函数(函数需要2个参数)，每次把调用函数的返回值与下一个元素当做函数参数继续调用。

    //对数组进行求和等操作很实用

    Array.prototype.reduce||(Array.prototype.reduce=function(fun,initval){

        if(this.length==0) return "";

        if(this.length==1){

            return initval?fun(initval,this[0]):this[0];

        }

        var val=initval,

            firstindex=initval?0:2;

        if(!initval){

            val=fun(this[0],this[1]);            

        }

        for(var i=firstindex;i<this.length;i++){

            val=fun(val,this[i]);

        }

        return val;

    })

    //reduceRight 与reduce一样 只是从右到左遍历数组

    Array.prototype.reduceRight||(Array.prototype.reduceRight=function(fun,initval){

        if(this.length==0) return "";

        if(this.length==1){

            return initval?fun(initval,this[0]):this[0];

        }

        var val=initval,

            firstindex=initval?this.length-1:this.length-3;

        if(!initval){

            val=fun(this[this.length-1],this[this.length-2]);    

        }

        for(var i=firstindex;i>=0;i--){

            val=fun(val,this[i]);

        }

        return val;

    })

})(window);




//字符串转换成数组  
String.prototype.stringtoarr=function(){  
           var arr=[];  
           for(x=0;x<this.length;x++){  
           arr[x]=this.charAt(x);  
           }  
    return arr;      
}  
//将字符串倒序  
String.prototype.reverseto=function(){  
         var rr=this.stringtoarr();  
         for(var x=0,y=rr.length-1;x<y;x++,y--){  
             var temp=rr[x];  
             rr[x]=rr[y];  
             rr[y]=temp;       
    }  
    return rr.join("");  
      
}  

// 合并多个空白为一个空白  
        String.prototype.ResetBlank = function() {        //对字符串扩展
            var regEx = /\s+/g;  
            return this.replace(regEx, ' ');  
        };  

        
// 保留数字  
String.prototype.GetNum = function() {  
    var regEx = /[^\d]/g;  
    return this.replace(regEx, '');  
};  
  
// 保留中文  
String.prototype.GetCN = function() {  
    var regEx = /[^\u4e00-\u9fa5\uf900-\ufa2d]/g;  
    return this.replace(regEx, '');  
};  
  
// String转化为Number  
String.prototype.ToInt = function() {  
    return isNaN(parseInt(this)) ? this.toString() : parseInt(this);  
};  
  
// 得到字节长度  
String.prototype.GetLen = function() {  
    var regEx = /^[\u4e00-\u9fa5\uf900-\ufa2d]+$/;  
    if (regEx.test(this)) {  
        return this.length * 2;  
    } else {  
        var oMatches = this.match(/[\x00-\xff]/g);  
        var oLength = this.length * 2 - oMatches.length;  
        return oLength;  
    }  
};  
  
// 获取文件全名  
String.prototype.GetFileName = function() {  
    var regEx = /^.*\/([^\/\?]*).*$/;  
    return this.replace(regEx, '$1');  
};  


// 获取文件扩展名  
String.prototype.GetExtensionName = function() {  
    var regEx = /^.*\/[^\/]*(\.[^\.\?]*).*$/;  
    return this.replace(regEx, '$1');  
};  
  
//替换所有
String.prototype.replaceAll2 = function(reallyDo, replaceWith, ignoreCase) {  
    if (!RegExp.prototype.isPrototypeOf(reallyDo)) {  
        return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi" : "g")), replaceWith);  
    } else {  
        return this.replace(reallyDo, replaceWith);  
    }  
};  
//格式化字符串 add By 刘景宁 2010-12-09   
String.Format3 = function() {  
    if (arguments.length == 0) {  
        return '';  
    }  
  
    if (arguments.length == 1) {  
        return arguments[0];  
    }  
  
    var reg = /{(\d+)?}/g;  
    var args = arguments;  
    var result = arguments[0].replace(reg, function($0, $1) {  
        return args[parseInt($1) + 1];  
    });  
    return result;  
};  

// 数字补零  
Number.prototype.LenWithZero = function(oCount) {  
    var strText = this.toString();  
    while (strText.length < oCount) {  
        strText = '0' + strText;  
    }  
    return strText;  
};  
  
// Unicode还原  
Number.prototype.ChrW = function() {  
    return String.fromCharCode(this);  
};  
  
// 数字数组由小到大排序  
Array.prototype.Min2Max = function() {  
    var oValue;  
    for (var i = 0; i < this.length; i++) {  
        for (var j = 0; j <= i; j++) {  
            if (this[i] < this[j]) {  
                oValue = this[i];  
                this[i] = this[j];  
                this[j] = oValue;  
            }  
        }  
    }  
    return this;  
};  
  
// 数字数组由大到小排序  
Array.prototype.Max2Min = function() {  
    var oValue;  
    for (var i = 0; i < this.length; i++) {  
        for (var j = 0; j <= i; j++) {  
            if (this[i] > this[j]) {  
                oValue = this[i];  
                this[i] = this[j];  
                this[j] = oValue;  
            }  
        }  
    }  
    return this;  
};  
  
// 获得数字数组中最大项  
Array.prototype.GetMax = function() {  
    var oValue = 0;  
    for (var i = 0; i < this.length; i++) {  
        if (this[i] > oValue) {  
            oValue = this[i];  
        }  
    }  
    return oValue;  
};  
  
// 获得数字数组中最小项  
Array.prototype.GetMin = function() {  
    var oValue = 0;  
    for (var i = 0; i < this.length; i++) {  
        if (this[i] < oValue) {  
            oValue = this[i];  
        }  
    }  
    return oValue;  
};  
  
  

// 获取当前时间的中文形式  
Date.prototype.GetCNDate2 = function() {  
    var oDateText = '';  
    oDateText += this.getFullYear().LenWithZero(4) + new Number(24180).ChrW();  
    oDateText += this.getMonth().LenWithZero(2) + new Number(26376).ChrW();  
    oDateText += this.getDate().LenWithZero(2) + new Number(26085).ChrW();  
    oDateText += this.getHours().LenWithZero(2) + new Number(26102).ChrW();  
    oDateText += this.getMinutes().LenWithZero(2) + new Number(20998).ChrW();  
    oDateText += this.getSeconds().LenWithZero(2) + new Number(31186).ChrW();  
    oDateText += new Number(32).ChrW() + new Number(32).ChrW() + new Number(26143).ChrW() + new Number(26399).ChrW() + new String('26085199682010819977222352011620845').substr(this.getDay() * 5, 5).ToInt().ChrW();  
    return oDateText;  
};  
//扩展Date格式化  
Date.prototype.Format5 = function(format) {  
    var o = {  
        "M+": this.getMonth() + 1, //月份           
        "d+": this.getDate(), //日           
        "h+": this.getHours() % 12 == 0 ? 12 : this.getHours() % 12, //小时           
        "H+": this.getHours(), //小时           
        "m+": this.getMinutes(), //分           
        "s+": this.getSeconds(), //秒           
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度           
        "S": this.getMilliseconds() //毫秒           
    };  
    var week = {  
        "0": "\u65e5",  
        "1": "\u4e00",  
        "2": "\u4e8c",  
        "3": "\u4e09",  
        "4": "\u56db",  
        "5": "\u4e94",  
        "6": "\u516d"  
    };  
    if (/(y+)/.test(format)) {  
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));  
    }  
    if (/(E+)/.test(format)) {  
        format = format.replace(RegExp.$1, ((RegExp.$1.length > 1) ? (RegExp.$1.length > 2 ? "\u661f\u671f" : "\u5468") : "") + week[this.getDay() + ""]);  
    }  
    for (var k in o) {  
        if (new RegExp("(" + k + ")").test(format)) {  
            format = format.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));  
        }  
    }  
    return format;  
}      



  
//检测是否为空  
Object.prototype.IsNullOrEmpty = function() {  
    var obj = this;  
    var flag = false;  
    if (obj == null || obj == undefined || typeof (obj) == 'undefined' || obj == '') {  
        flag = true;  
    } else if (typeof (obj) == 'string') {  
        obj = obj.trim();  
        if (obj == '') {//为空  
            flag = true;  
        } else {//不为空  
            obj = obj.toUpperCase();  
            if (obj == 'NULL' || obj == 'UNDEFINED' || obj == '{}') {  
                flag = true;  
            }  
        }  
    }  
    else {  
        flag = false;  
    }  
    return flag;  
}


Function.prototype.method = function (name, func){
    if (!this.prototype[name]) {
        this.prototype[name] = func;
    }
    return this;
}
/*

Number.method ('integer', function (){
    return Math[ this < 0 ? 'ceil' : 'floor' ](this);
});
document.write( (-11 / 3).integer() ); //-11/3取整得-3

String.method('trim', function(){
    return this.replace(/^\s+|\s+$/g, '');
})

*/

