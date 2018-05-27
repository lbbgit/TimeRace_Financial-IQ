
var createTable = function (row, col, name) {
    var r = "<table ";
    r += ((!!name) ? ("id='" + name) : "") + "'>";
    for (var i = 0; i < row; i++) {
        //r+="<tr/>"
        r += createTr(col);
    }
    r += "</table>";
    return r;
}

var createTable_Tbody = function (row, col, name) {
    var r = "<table ";
    r += ((!!name) ? ("id='" + name) : "") + "'>";
    //tbody
    r += "<thead>";
    var tdd = createTr(col);
    tdd = tdd.replace("td>", "th>");
    r += tdd;
    r += "</thead>";
    /*
    <thead>
    <tr>
    <th>id</th>
    <th>Data</th>
    <th>name</th>
    <th>number</th>
    <th>price</th>
    </tr>
    </thead>
    */

    //tbody
    r += "<tbody>"

    for (var i = 0; i < row; i++) {
        //r+="<tr/>"
        r += createTr(col);
    }
    //tbody
    r += "</tbody>"

    r += "</table>";
    return r;
}
var createTr = function (col, trclass, tdclass) {
    var s = trclass ? ("<tr class='" + trclass + "'>") : "<tr>";
    for (var i = 0; i < col; i++) {
        s += tdclass ? ("<td class='" + tdclass + "'>") : "<td>";
    }
    s += "</tr>"
    return s;
}

var GetTable = function (name, tr, td) {
    var a = (!!name) ? ("#" + name) : "table ";
    a += " tr:eq(" + tr + ") td:eq(" + td + ")";
    return $(a);
}

var SetTable = function (name, tr, td, val) {
    GetTable(name, tr, td).text(val);
}


var SetTable_ByRow = function (name, tr, list) {
    for (var i = 0; i < list.length; i++) {
        GetTable(name, tr, i).text(list[i]);
    }
}

var randomTable = function (name, num) {
    var num = num ? num : 1000;
    var tds = $("#" + name + " td,th");
    var s;
    for (var i = 0; i < tds.length; i++) {
        s = Math.floor(Math.random(99) * num)
        tds[i].innerText = s;
    }
}

//连续的js地址分离开来
function jsurl(as) {
    var ll = as.split(',');
    for (var i = 0, s = ''; i < ll.length; i++) {

        s += '<script type="text/javascript" src="' + ll[i] + '"></script>';
    }
    return s;
}