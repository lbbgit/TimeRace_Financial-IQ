String.prototype.format =String.prototype.Format = function (args) {
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

var Format = {
    DelStr: function (str, innertext) {
        if (!str || !innertext)
            return;
        var result = innertext.replace(str, "");
        return result;
    },
    Format: function (text, args) {
        return text.format(args); 
    }
}









function Fun2Str(_function) {
    var a = _function.toString();
    var left = a.indexOf("/*");
    a = a.substr(left + 2);
    var right = a.indexOf("*/");
    a = a.substr(0, right);
    return a;
}
var fun2Str = fun2str = Fun2Str;

var ___f = function () {
    /*
    Id
    Name
    */
};
var charEnter = charNewLine = Fun2Str(___f)[0]; //换行符   /\n/g
 

//按换行符分隔
String.prototype.SplitRows = String.prototype.splitRows = function () { 
    return this.split(/\n/g);
};

String.prototype.ReplaceNewRow = String.prototype.replaceNewRow = function (newstr) {
    if(!newstr)
        newstr='<br>';
    return this..replace(/\n/g, newstr);
}; 



 
/**  
* 检索数组元素（原型扩展或重载）  
* @param {o} 被检索的元素值  
* @type int  
* @returns 元素索引  
*/   
Array.prototype.contains = function(o) {   
  var index = -1;   
  for(var i=0;i<this.length;i++){if(this[i]==o){index = i;break;}}   
  return index;   
}   
  
/**  
* 日期格式化（原型扩展或重载）  
* 格式 YYYY/yyyy/YY/yy 表示年份  
* MM/M 月份  
* W/w 星期  
* dd/DD/d/D 日期  
* hh/HH/h/H 时间  
* mm/m 分钟  
* ss/SS/s/S 秒  
* @param {formatStr} 格式模版  
* @type string  
* @returns 日期字符串  
*/   
Date.prototype.format2 = function(formatStr){   
    var str = formatStr;   
    var Week = ['日','一','二','三','四','五','六'];   
    str=str.replace(/yyyy|YYYY/,this.getFullYear());   
    str=str.replace(/yy|YY/,(this.getYear() % 100)>9?(this.getYear() % 100).toString():'0' + (this.getYear() % 100));   
    str=str.replace(/MM/,(this.getMonth()+1)>9?(this.getMonth()+1).toString():'0' + (this.getMonth()+1));   
    str=str.replace(/M/g,this.getMonth());   
    str=str.replace(/w|W/g,Week[this.getDay()]);   
    str=str.replace(/dd|DD/,this.getDate()>9?this.getDate().toString():'0' + this.getDate());   
    str=str.replace(/d|D/g,this.getDate());   
    str=str.replace(/hh|HH/,this.getHours()>9?this.getHours().toString():'0' + this.getHours());   
    str=str.replace(/h|H/g,this.getHours());   
    str=str.replace(/mm/,this.getMinutes()>9?this.getMinutes().toString():'0' + this.getMinutes());   
    str=str.replace(/m/g,this.getMinutes());   
    str=str.replace(/ss|SS/,this.getSeconds()>9?this.getSeconds().toString():'0' + this.getSeconds());   
    str=str.replace(/s|S/g,this.getSeconds());   
    return str;   
}   
  
/**  
* 比较日期差（原型扩展或重载）  
* @param {strInterval} 日期类型：'y、m、d、h、n、s、w'  
* @param {dtEnd} 格式为日期型或者 有效日期格式字符串  
* @type int  
* @returns 比较结果  
*/   
Date.prototype.dateDiff = function(strInterval, dtEnd) {   
    var dtStart = this;   
    if (typeof dtEnd == 'string' ) { //如果是字符串转换为日期型   
        dtEnd = StringToDate(dtEnd);   
    }   
    switch (strInterval) {   
        case 's' :return parseInt((dtEnd - dtStart) / 1000);   
        case 'n' :return parseInt((dtEnd - dtStart) / 60000);   
        case 'h' :return parseInt((dtEnd - dtStart) / 3600000);   
        case 'd' :return parseInt((dtEnd - dtStart) / 86400000);   
        case 'w' :return parseInt((dtEnd - dtStart) / (86400000 * 7));   
        case 'm' :return (dtEnd.getMonth()+1)+((dtEnd.getFullYear()-dtStart.getFullYear())*12) - (dtStart.getMonth()+1);   
        case 'y' :return dtEnd.getFullYear() - dtStart.getFullYear();   
    }   
}   
  
/**  
* 日期计算（原型扩展或重载）  
* @param {strInterval} 日期类型：'y、m、d、h、n、s、w'  
* @param {Number} 数量  
* @type Date  
* @returns 计算后的日期  
*/   
Date.prototype.DateAdd = Date.prototype.dateAdd = function(strInterval, Number) {   
    var dtTmp = this;   
    switch (strInterval) {   
        case 's' :return new Date(Date.parse(dtTmp) + (1000 * Number));   
        case 'n' :return new Date(Date.parse(dtTmp) + (60000 * Number));   
        case 'h' :return new Date(Date.parse(dtTmp) + (3600000 * Number));   
        case 'd' :return new Date(Date.parse(dtTmp) + (86400000 * Number));   
        case 'w' :return new Date(Date.parse(dtTmp) + ((86400000 * 7) * Number));   
        case 'q' :return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number*3, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());   
        case 'm' :return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());   
        case 'y' :return new Date((dtTmp.getFullYear() + Number), dtTmp.getMonth(), dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());   
    }   
}   
  
/**  
* 取得日期数据信息（原型扩展或重载）  
* @param {interval} 日期类型：'y、m、d、h、n、s、w'  
* @type int  
* @returns 指定的日期部分  
*/   
Date.prototype.datePart = function(interval){   
    var myDate = this;   
    var partStr='';   
    var Week = ['日','一','二','三','四','五','六'];   
    switch (interval)   
    {   
        case 'y' :partStr = myDate.getFullYear();break;   
        case 'm' :partStr = myDate.getMonth()+1;break;   
        case 'd' :partStr = myDate.getDate();break;   
        case 'w' :partStr = Week[myDate.getDay()];break;   
        case 'ww' :partStr = myDate.WeekNumOfYear();break;   
        case 'h' :partStr = myDate.getHours();break;   
        case 'n' :partStr = myDate.getMinutes();break;   
        case 's' :partStr = myDate.getSeconds();break;   
    }   
    return partStr;   
}   
  
/**  
* 把日期分割成数组（原型扩展或重载）  
* @type array  
* @returns 日期数组  
*/   
Date.prototype.toArray = function() {   
    var myDate = this;   
    var myArray = Array();   
    myArray[0] = myDate.getFullYear();   
    myArray[1] = myDate.getMonth()+1;   
    myArray[2] = myDate.getDate();   
    myArray[3] = myDate.getHours();   
    myArray[4] = myDate.getMinutes();   
    myArray[5] = myDate.getSeconds();   
    return myArray;   
}   
  
/**  
* 取得当前月份的天数（原型扩展或重载）  
* @type int  
* @returns 天数  
*/   
Date.prototype.daysOfMonth = function(){   
    var myDate = this;   
    var ary = myDate.toArray();   
    var date1 = (new Date(ary[0],ary[1]+1,1));   
    var date2 = date1.dateAdd('m',1);   
    var result = daysDiff(date1.format('yyyy-MM-dd'),date2.format('yyyy-MM-dd'));   
    return result;   
}   
  
/**  
* 判断闰年（原型扩展或重载）  
* @type boolean  
* @returns 是否为闰年 true/false  
*/   
Date.prototype.isLeapYear = function() {   
  return (0==this.getYear()%4&&((this.getYear()%100!=0)||(this.getYear()%400==0)));   
}   
  
/**  
* 比较两个日期的天数差（自定义）  
* @param {DateOne} 日期一  
* @param {DateOne} 日期二  
* @type int  
* @returns 比较结果  
*/   
function daysDiff(DateOne,DateTwo)   
{   
    var OneMonth = DateOne.substring(5,DateOne.lastIndexOf ('-'));   
    var OneDay = DateOne.substring(DateOne.length,DateOne.lastIndexOf ('-')+1);   
    var OneYear = DateOne.substring(0,DateOne.indexOf ('-'));   
  
    var TwoMonth = DateTwo.substring(5,DateTwo.lastIndexOf ('-'));   
    var TwoDay = DateTwo.substring(DateTwo.length,DateTwo.lastIndexOf ('-')+1);   
    var TwoYear = DateTwo.substring(0,DateTwo.indexOf ('-'));   
  
    var cha=((Date.parse(OneMonth+'/'+OneDay+'/'+OneYear)- Date.parse(TwoMonth+'/'+TwoDay+'/'+TwoYear))/86400000);   
    return Math.abs(cha);   
}   
  
/**  
* 日期计算（自定义）  
* @param {strInterval} 日期类型：'y、m、d、h、n、s、w'  
* @param {Number} 数量  
* @param {prmDate} 原日期  
* @type Date  
* @returns 计算后的日期  
*/   
function dateAdd(interval,number,prmDate){   
  number = parseInt(number);   
  if (typeof(prmDate)=="string"){   
    prmDate = prmDate.split(/\D/);   
    --prmDate[1];   
    eval("var prmDate = new Date("+prmDate.join(",")+")");   
  }   
  if (typeof(prmDate)=="object"){   
    var prmDate = prmDate   
  }   
  switch(interval){   
    case "y": prmDate.setFullYear(prmDate.getFullYear()+number); break;   
    case "m": prmDate.setMonth(prmDate.getMonth()+number); break;   
    case "d": prmDate.setDate(prmDate.getDate()+number); break;   
    case "w": prmDate.setDate(prmDate.getDate()+7*number); break;   
    case "h": prmDate.setHours(prmDate.getHour()+number); break;   
    case "n": prmDate.setMinutes(prmDate.getMinutes()+number); break;   
    case "s": prmDate.setSeconds(prmDate.getSeconds()+number); break;   
    case "l": prmDate.setMilliseconds(prmDate.getMilliseconds()+number); break;   
  }   
  return prmDate;   
}   
  
/**  
* 获取字符串长度（原型扩展或重载）  
* @type int  
* @returns 字符串长度  
*/   
String.prototype.len = String.prototype.ChineseLength = function() {   
  var arr=this.match(/[^\x00-\xff]/ig);   
  return this.length+(arr==null?0:arr.length);   
}   
  
/**  
* 字符串左取指定个数的字符（原型扩展或重载）  
* @param {num} 获取个数  
* @type string  
* @returns 匹配的字符串  
*/   
String.prototype.Left =String.prototype.left = function(num,mode) {   
  if(!/\d+/.test(num)) return(this);   
  var str = this.substr(0,num);   
  if(!mode) return str;   
  var n = str.len() - str.length;   
  num = num - parseInt(n/2);   
  return this.substr(0,num);   
}   
  
/**  
* 字符串右取指定个数的字符（原型扩展或重载）  
* @param {num} 获取个数  
* @type string  
* @returns 匹配的字符串  
*/   
String.prototype.Right = String.prototype.right = function(num,mode) {   
  if(!/\d+/.test(num)) return(this);   
  var str = this.substr(this.length-num);   
  if(!mode) return str;   
  var n = str.len() - str.length;   
  num = num - parseInt(n/2);   
  return this.substr(this.length-num);   
}   
  
/**  
* 字符串包含（原型扩展或重载）  
* @param {string: str} 要搜索的子字符串  
* @param {bool: mode} 是否忽略大小写  
* @type int  
* @returns 匹配的个数  
*/   
String.prototype.matchCount = function(str,mode) {   
  return eval("this.match(/("+str+")/g"+(mode?"i":"")+").length");   
}   
  
/**  
* 去除左右空格（原型扩展或重载）  
* @type string  
* @returns 处理后的字符串  
*/   
String.prototype.trim = function() {   
  return this.replace(/(^\s*)|(\s*$)/g,"");   
}   
  
/**  
* 去除左空格（原型扩展或重载）  
* @type string  
* @returns 处理后的字符串  
*/   
String.prototype.lTrim = function() {   
  return this.replace(/(^\s*)/g, "");   
}   
  
/**  
* 去除右空格（原型扩展或重载）  
* @type string  
* @returns 处理后的字符串  
*/   
String.prototype.rTrim = function() {   
  return this.replace(/(\s*$)/g, "");   
}   
  
/**  
* 字符串转换为日期型（原型扩展或重载）  
* @type Date  
* @returns 日期  
*/   
String.prototype.toDate = function() {    
  var converted = Date.parse(this);     
  var myDate = new Date(converted);    
  if (isNaN(myDate)) {var arys= this.split('-'); myDate = new Date(arys[0],--arys[1],arys[2]); }    
  return myDate;   
}
















Array.prototype.max = function()
{
    var i, max = this[0];
    for (i = 1; i < this.length; i++)
    {
        if (max < this[i])
            max = this[i];
    }
    return max;
};


//Number.prototype.add = function(num){return(this+num);}//数字相加
//Boolean.prototype.rev = function(){return(!this);} //bool取反

//一次性为Array追加多个元素
Array.prototype.pushPro = function() {
     var currentLength = this.length;
     for (var i = 0; i < arguments.length; i++) {
          this[currentLength + i] = arguments[i];
     }
     return this.length;
}
//4=4!=4*3*2*1;
Number.prototype.fact=function(){
    var num = Math.floor(this);
    if(num<0)return NaN;
    if(num==0 || num==1)
        return 1;
    else
        return (num*(num-1).fact());
}








/* 
 * 日期相关的工具  
 * author: XuJijun 
 */  
  
/** 
 * 返回ISO格式的日期字符串（去掉时分秒） 
 * 如："2016-09-22T08:37:43.438Z" --> "2016-09-22" 
 */  
Date.prototype.toIsoDateString = function() {  
    return this.toISOString().slice(0,-14);  
};  
  
/** 
 * 返回一个加上days天的新Date 
 */  
Date.prototype.plusDays = function(days) {  
    return new Date(this.getTime() + days*60*60*24*1000);  
};  
  
/** 
 * 返回一个减去days天的新Date 
 */  
Date.prototype.minusDays = function(days) {  
    return new Date(this.getTime() - days*60*60*24*1000);  
};  
  
/** 
 * 返回一个加上若干个月的新Date 
 * 注1：Date(2-28).plusMonth(1)=Date(3-28)。如果需要变成3-31，需要另外的函数来处理。 
 * 注2：Date(1-31).plusMonth(1)=Date(2-28)或Date(2-29) 
 */  
Date.prototype.plusMonths = function(num) {  
    var newDate = new Date(this);  
    newDate.setMonth(this.getMonth() + num); //setMonth()会自动除以12  
    //注意：此时，月数可能会自动进位，比如：1-31加上num=1的情况，会变成3-3（非闰年）或3-2（闰年），即2-31自动转换为下个月的某一天。  
      
    var currentMonth = this.getMonth() + this.getFullYear() * 12; //获得月的绝对值  
    var diff = (newDate.getMonth() + newDate.getFullYear() * 12) - currentMonth; //计算新旧两个月绝对值的差  
  
    if (diff != num) { //如果月绝对值的差和加上的月数不一样，说明月进位了，此时需要退一个月  
        //setDate(0)表示变成上个月的最后一天  
        newDate.setDate(0);  
    }  
          
    return newDate;   
};  
  
/** 
 * 返回下个月的第一天的Date对象 
 */  
Date.prototype.getStartOfNextMonth = function(){  
    var newDate = new Date(this);  
    newDate.setDate(15); //确保月数不会进位  
    newDate.setMonth(this.getMonth()+1);  
    newDate.setDate(1);  
    return newDate;  
}   
  
/** 
 * 返回下个月的最后一天的Date对象 
 */  
Date.prototype.getEndOfNextMonth = function(){  
    var newDate = new Date(this);  
    newDate.setDate(15); //确保月数不会进位  
    newDate.setMonth(this.getMonth() + 2); //加两个月  
    newDate.setDate(0); //再退回上个月的最后一天  
    return newDate;  
} ; 










 //检测字符串是否为空
String.prototype.isEmpty = function () { return !(/.?[^/s　]+/.test(this)); }
// 替换字符
String.prototype.reserve = function(type) {
 if (type == 'int') return this.replace(/^/d/g, ''); // 替换字符串中除了数字以外的所有字符
 else if (type == 'en') return this.replace(/[^A-Za-z]/g, ''); // 替换字符串中除了英文以外的所有字符
 else if (type == 'cn') return this.replace(/[^/u4e00-/u9fa5/uf900-/ufa2d]/g, ''); // 替换字符串中除了中文以外的所有字符
 else return this;
}
// 字符串反转
String.prototype.reverse = function() {
 return this.split('').reverse().join('');
}


// 以一个中文算两个字符长度计算字符串的长度
String.prototype.cnLength = function() { return this.replace(/[^/x00-/xff]/g, ' * * ' ).length; }
// 替换字符串中的空格
String.prototype.trim = function(type, char) {
 var type = type ? type.toUpperCase() : '';
 switch (type) {
  case 'B' : // 替换所有欲清除字符,未定义char则默认为替换空格
   return this.replace(char ? new RegExp(char, 'g') : /(/s+|　)/g, '');
  case 'O' : // 将两个以上的连续欲清除字符替换为一个,未定义char则默认为替换空格
   return char ? this.replace(new RegExp(char + '{2,}', 'g'), char) : this.replace(/[/s　]{2,}/g, ' ');
  case 'L' : // 替换除左边欲清除字符,未定义char则默认为替换空格
   return this.replace(char ? new RegExp('^(' + char + ') * ', 'g') : /^(/s|　) * /g, '');
  case 'R' : // 替换除右边欲清除字符,未定义char则默认为替换空格
   return this.replace(char ? new RegExp('(' + char + ') * $', 'g') : /(/s|　) * $/g, '');
  default : // 替换除左右两边欲清除字符,未定义char则默认为替换空格
   return this.replace(char ? new RegExp('^(' + char + ') * |(' + char + ') * $', 'g') : /(^/s * |　)|(　|/s * $)/g, '');
 }
}
// 判断字符串是否是数字
String.prototype.isNumer = function(flag) {
 if (isNaN(this)) {return false;}
 switch (flag) {
  case '+' : return /(^/+?|^/d?)/d * /.?/d+$/.test(this); // 正数
  case '-' : return /^-/d * /.?/d+$/.test(this); // 负数
  case 'i' : return /(^-?|^/+?|/d)/d+$/.test(this); // 整数
  case '+i' : return /(^/d+$)|(^/+?/d+$)/.test(this); // 正整数
  case '-i' : return /^-/d+$/.test(this); // 负整数
  case 'f' : return /(^-?|^/+?|^/d?)/d * /./d+$/.test(this); // 浮点数
  case '+f' : return /(^/+?|^/d?)/d * /./d+$/.test(this); // 正浮点数
  case '-f' : return /^-/d * /./d$/.test(this); // 负浮点数
  default : return true; // 缺省
 }
}


// 仿PHP的str_pad
String.prototype.pad = function (input, length, type) {
 if (!input) return this;
 if (!length || length < 1) var length = 1;
 var input = Array(length + 1).join(input), value;
 var type = type ? type.toUpperCase() : '';
 switch (type) {
  case 'LEFT' : return input + this;
  case 'BOTH' : return input + this + input;
  default : return this + input;
 }
}

// 获取url对应参数的值
String.prototype.getQuery = function(name) {
 var reg = new RegExp('(^|&)' + name + ' = ([^&] * )(&|$)');
 var r = this.substr(this.indexOf('/?') + 1).match(reg);
 return r[2]?unescape(r[2]) : null;
}

// 判断是否是日期格式(YYYY-MM-DD YYYY/MM/DD YYYY.MM.DD)
String.prototype.isDate = function() {
 result = this.match(/^(/d{1, 4})(-|//|.)(/d{1, 2})/2(/d{1, 2})$/);
 if (!result) return false;
 var d = new Date(result[1], result[3]-1, result[4])
 var str = d.getFullYear() + result[2] + (d.getMonth() + 1) + result[2] + d.getDate();
 return this == str;
}

// 将字符串转为日期
String.prototype.toDate = function() {
 var mDate = new Date(Date.parse(str));
 if (isNaN(mDate)) {
  var arr = this.split('-');
  mDate = new Date(arr[0], arr[1], arr[2]);
 }
 return mDate;
}

// 格式化日期, new Date().format('yyyy/mm/dd')
Date.prototype.format3 = function(format) {
 var format = format.toLowerCase();
 var type = {
  'm+' : this.getMonth()+1,
  'd+' : this.getDate(),
  'h+' : this.getHours(),
  'i+' : this.getMinutes(),
  's+' : this.getSeconds(),
  'q+' : Math.floor((this.getMonth()+3)/3),
  'ms' : this.getMilliseconds()
 }
 if (/(y+)/.test(format)) format = format.replace(RegExp.$1, (this.getFullYear() + '').substr(4 - RegExp.$1.length));
 for(var k in type) {
  if(new RegExp('('+ k +')').test(format)) {
   format = format.replace(RegExp.$1, RegExp.$1.length==1 ? type[k] : ('00'+ type[k]).substr((''+ type[k]).length));
  }
 }
 return format;
}


// 添加日期，对应参数分别是：类型(y-年, q-季, m-月, w-周, d-日, h-时, i-分, s-秒)和增加的值
Date.prototype.addDate2 = function(type, num) {
 var type = type.toLowerCase();
 switch (type) {
  case 's' : return new Date.parse(Date.parse(this) + (1000 * num));
  case 'i' : return new Date.parse(Date.parse(this) + (60000 * num));
  case 'h' : return new Date(Date.parse(this) + (3600000 * num));
  case 'd' : return new Date(Date.parse(this) + (86400000 * num));
  case 'w' : return new Date(Date.parse(this) + ((86400000 * 7) * num));
  case 'm' : return new Date(this.getFullYear(), (this.getMonth()) + num, this.getDate(), this.getHours(), this.getMinutes(), this.getSeconds());
  case 'q' : return new Date(this.getFullYear(), (this.getMonth()) + num * 3, this.getDate(), this.getHours(), this.getMinutes(), this.getSeconds());
  case 'y' : return new Date((this.getFullYear() + num), this.getMonth(), this.getDate(), this.getHours(), this.getMinutes(), this.getSeconds());
 }
}
// 计算两个日期
Date.prototype.dateDiff2 = function(type, date) {
 if (typeof date == 'string') date = date.toDate();
 switch (type) {
  case 's' : return parseInt((date - this) / 1000);
  case 'i' : return parseInt((date - this) / 60000);
  case 'h' : return parseInt((date - this) / 3600000);
  case 'd' : return parseInt((date - this) / 86400000);
  case 'w' : return parseInt((date - this) / (86400000 * 7));
  case 'm' : return (date.getMonth() + 1) + ((date.getFullYear() - this.getFullYear()) * 12) - (this.getMonth() + 1);
  case 'y' : return date.getFullYear() - this.getFullYear();
 }
}



// 判断对象是否是数组
Object.prototype.isArray = function() {return Object.prototype.toString.apply(this) == '[object Array]';}
// 判断数组内是否存在指定的元素
Array.prototype.inArray = function (value) {
 if (this.length < 2) return this[0] == value;
 this.sort(function(a) {
  return new RegExp('^' + value).test(a) ? -1 : 1;
 });
 return this[0] == value;
}


// 在数组中查找元素并返回第一次出现的位置索引，未找到则返回-1。
Array.prototype.indexOf = function(string) {
 var len = this.length, i = 0;
 if (len < 2) return this[0] == value ? 0 : -1;
 for (i; i < len; i++) {
  if (this[i] == string) return i;
 }
 return -1;
}

// [1, 2, 3].each(function(x) {return x+1}) 得到2, 3, 4
Array.prototype.each = function(c) {
 var ret = [];
 for(var i = 0; i < this.length; i++) {
  ret.push(c(this[i]));
 }
 return ret;
}


// [1, -1, 2].any(function(x) {return x < 0}) 判断是否数组中有一个元素小于0
Array.prototype.any = function(c) {
 for(var i = 0; i < this.length; i++) {
  if (c(this)) return true;
 }
 return false;
}


// [1, 2, 3].all(function(x) {return x > 0}) 判断是否数组中所有的元素都大于0
Array.prototype.all = function(c) {
 for(var i = 0; i < this.length; i++) {
  if (!c(this)) return false;
 }
 return true;
}


// 移除数组指定的元素,如果指定了limit,则仅移除limit个指定元素，如果省略limit或者其值为0，则所有指定元素都会被移除。
Array.prototype.unset = function(string, limit) {
 var len = this.length, i = 0, count = 0;
 for (i; i < len; i++) {
  if (this[i] == string) {
   this.splice(i, 1);
   if (limit && limit > 0) {
    count++;
    if (count == limit) break;
   }
  }
 }
 return this;
}


// 移除数组中重复的元素
Array.prototype.unique = function() {
 var arr = tmp = [], i, len = this.length;
 if (len < 2) return this;
 for (i = 0; i < len; i++) {
  if (tmp[this[i]]) {
   arr.push(this[i]);
   tmp[this[i]] = true;
  }
 }
 return arr;
}
Array.prototype.min = function() {return Math.min.apply(null, this)} // 求数组中最小值
Array.prototype.max = function() {return Math.max.apply(null, this)} // 求数组中最大值



