

$("form").submit(function(event){
    
    var nums = $("input");
    var hitnums = [0,0,0];
    var hitsTotal = 0;
    var hitsClose = 0;
    
    
    var i;
    
    for(i = 0; i < 3; i++){
        hitnums[i] = Math.floor(Math.random() * 9);
    }
    
    //text edit
    $(anouncement).text("--New text based on result--");
    
    
    //added list
    $("div#result").after("<h5>Generated Numbers: </h5><ul><li>" + hitnums[0] + "</li><li>" + hitnums[1] + "</li><li>" + hitnums[2] + "</li></ul> <h5>Hits Total:"+hitsTotal+"</h5><h5>CloseHits Total(1 off):"+hitsClose+"</h5>");

    //alert(nums[0].value);
    event.preventDefault();
});