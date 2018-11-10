
$('#inputWords').bind('keypress', function (e) {
    //keycode 32 is for space
    if (e.keyCode == 32) {
        var words = $("#inputWords").val().toString();
        console.log("Whole string" + words);
        var word = words.trim().split(" ").splice(-1);
        console.log("word to translate: " + word.toString());
        var source = "/Translator/Translate/" + word;


        
        $.ajax({
            type: "GET",
            dataType: "json",
            url: source,
            success: displayData,
            error: errorOnAjax
        });
    }
});

function displayData(data) {
    //$("Result").add(data["test"])
    console.log("display next:");
}

function errorOnAjax() {
    console.log("error");
}