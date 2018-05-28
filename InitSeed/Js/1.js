//jquery
var lst = window.localStorage;
var __jquery=lst.getItem("jquery");


function loadScript(url) { 
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.src = url;
    document.body.appendChild(script);
}


if (__jquery) {
    eval(__jquery);
} else {
    loadScript('/Js/jquery-1.7.1.min.js');
}
/*
 var action = Common.QueryString("action"); //名称
        $.ajax({
            type: "GET",
            url: "/Handler/Do.ashx?Action=" + action + "&Type=2&Clear=1",
            dataType: "script",
            async: false
        });
        */

//regex
var regex_double = "^([-+]?[0-9]{1,}\.?[0-9]*)$";