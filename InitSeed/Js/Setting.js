//-------------------------------------------
//js的加载
//-------------------------------------------

var lstorage = window.localStorage
var url = "/ashx/LoadSetting.ashx?key=";

function Setting(key) {
    this.key = key;
    this.setting = lstorage.getItem(key)
    if (this.setting) {
        this.setting = {};//Get Setting from ashx.url
    }
    return this; 
}

//function _GetUrl(key) {
//    
//    $.get(url + key, function (val) {
//        eval("_____@@@@" + key + "=" + val);
//    })
//}
//function _checkReturn(key) {
//    
//}

 
Setting.prototype.GetSetting = function (key, callback) {
    var _this = this
    var version = key.substring(key.lastIndexOf("?"))
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        switch (xhr.readyState) {
            case 4:
                if (xhr.status == 200) {
                    var filetext = xhr.responseText
                    if (callback) {
                        callback.call(_this, filetext)
                    }
                } else {
                    alert('加载失败')
                }
                break;
            default:
                break;
        }
    }
    xhr.open('GET', key, false);
    xhr.send();
}
 