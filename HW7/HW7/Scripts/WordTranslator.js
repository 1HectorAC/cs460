
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
            success: displayWord,
            error: errorOnAjax
        });
    }
});

function displayWord(data) {
    var test = data["gif"];
    if (data["imageCheck"]) {
        console.log(test);
        var imageElement = document.createElement("img");
        imageElement.src = test;
        imageElement.alt = test;
        imageElement.style = "width:150px;height:150px;";
        $("#Result").append(imageElement);
    }
    else {
        var textElement = document.createElement("span");
        textElement.innerHTML = test;
        $("#Result").append(textElement);
    }
}

function errorOnAjax() {
    console.log("error");
}