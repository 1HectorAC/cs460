var ajax_call = function () {
    //your jQuery ajax code
    var itemID = $("#ID").text().toString();
    //need item id
    var source = "/Home/ItemBids/" + itemID;
    console.log(source);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayWord,
        error: detectedError
    });
};
ajax_call();
var interval = 1000 * 5; // where X is your timer interval in X seconds

window.setInterval(ajax_call, interval);

function displayWord(data) {
    console.log("start displayWord");
    var TablePrices = data['TablePrice'];
    var TableBuyers = data['TableBuyer'];

    var table = $('<tbody>', {id:'TableContent'});
    //var table = $('Bob');
    for (i = 0; i < TablePrices.length; i++) {
        
        var column1 = $('<td>').text(TableBuyers[i]);
        var column2 = $('<td>').text(TablePrices[i]);
        var row = $('<tr>');
        row.append(column1);
        row.append(column2);
        table.append(row);
    }

    //$('.table').append(table);
    $('#TableContent').replaceWith(table);
    console.log("success");
}

function detectedError() {
    console.log("error");
}