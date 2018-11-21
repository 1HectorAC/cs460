var ajax_call = function () {
    var itemID = $("#ID").text().toString();
    //need item id
    var source = "/Home/ItemBids/" + itemID;
    console.log(source);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayTable,
        error: detectedError
    });
};
ajax_call();
var interval = 1000 * 5; 

window.setInterval(ajax_call, interval);

function displayTable(data) {
    console.log("start displayWord");
    var TablePrices = data['TablePrice'];
    var TableBuyers = data['TableBuyer'];

    var table = $('<tbody>', {id:'TableContent'});
    for (i = 0; i < TablePrices.length; i++) {
        
        var column1 = $('<td>').text(TableBuyers[i]);
        var column2 = $('<td>').text(TablePrices[i]);
        var row = $('<tr>');
        row.append(column1);
        row.append(column2);
        table.append(row);
    }

    //This part will replace the element with TableContent ID to update the table
    $('#TableContent').replaceWith(table);
    console.log("success");
}

function detectedError() {
    console.log("error");
}