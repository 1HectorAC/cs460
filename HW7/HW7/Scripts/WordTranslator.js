
$('#inputWords').bind('keypress', function (e) {
    //keycode 32 is for space
    if (e.keyCode == 32) {
        var words = $("#inputWords").val().toString();
        console.log("Whole string: " + words);
        //check for double space and do nothing if so.
        if (!words.endsWith(' ')) {
            var word = words.trim().split(" ").splice(-1).toString();
            console.log("word to translate: " + word.toString());

            //check for boring or amazing words
            var commonWords = ["a", "am", "as", "are", "and", "are", "at", "be", "for", "from", "have", "he", "his", "i", "in", "is", "it", "me", "of", "on", "or", "she", "the", "that", "they", "this", "to", "want", "was", "with", "you"];
            var wordLowerCased = word.toLowerCase();
            //check if not a common word or if not a number
            if (commonWords.indexOf(wordLowerCased) == -1) {
                //translate amazing word
                var source = "/Translate/" + word;
                $.ajax({
                    type: "GET",
                    dataType: "json",
                    url: source,
                    success: displayWord,
                    error: detectedError
                });
            }
            else {
                //display boring word
                console.log("boring check works");
                var textElement = document.createElement("span");
                var wordWithSpace = " " + word;
                textElement.innerHTML = wordWithSpace;
                textElement.style = "font-size:30px";
                $("#Result").append(textElement);
            }
        }
    }
});

function displayWord(data) {
    var WordData = data["gif"];
    //check to display image element or span element (for text)
    console.log(WordData);
    var imageElement = document.createElement("img");
    imageElement.src = WordData;
    imageElement.alt = WordData;
    imageElement.style = "width:150px;height:150px;";
    $("#Result").append(imageElement);

}

function detectedError() {
    console.log("error");
}