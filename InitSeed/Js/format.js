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


















































