
$('#inputWords').bind('keypress', function (e) {
    //keycode 32 is for space
    if (e.keyCode == 32) {
        var words = $("#inputWords").val().toString();
        console.log("Whole string: " + words);
        //check for double pressing space and do nothing if so.
        if (!words.endsWith(' ')) {
            var word = words.trim().split(" ").splice(-1).toString();
            console.log("word to translate: " + word.toString());
            var source = "/Translate/" + word;
            $.ajax({
                type: "GET",
                dataType: "json",
                url: source,
                success: displayWord,
                error: detectedError
            });
        }
    }
});

function displayWord(data) {
    var WordData = data["gif"];
    //check to display image element or span element (for text)
    if (data["imageCheck"]) {
        console.log(WordData);
        var imageElement = document.createElement("img");
        imageElement.src = WordData;
        imageElement.alt = WordData;
        imageElement.style = "width:150px;height:150px;";
        $("#Result").append(imageElement);
    }
    else {
        var textElement = document.createElement("span");
        var test2 = " " + WordData;
        textElement.innerHTML = test2;
        textElement.style = "font-size:30px";
        $("#Result").append(textElement);
    }
}

function detectedError() {
    console.log("error");
}