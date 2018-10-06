$("form").submit(function(event){
    //key variables used
    var nums = $("input");
    var hitnums = [0,0,0];
    var hitsTotal = 0;
    
    //alert if all inputs aren't different
    if(nums[0].value == nums[1].value || nums[0].value == nums[2].value || nums[1].value == nums[2].value){
        alert("Please enter 3 different numbers.");
        return;
    }
        
    //setup hitnums array with random numbers between 0 and 9
    var i;
    for(i = 0; i < 3; i++){
        hitnums[i] = Math.floor(Math.random() * 9);
    }
    
    //check that hitnums has unique values and change them if not
    while(hitnums[0] == hitnums[1]){
        hitnums[1] = Math.floor(Math.random() * 9);
    }
     while(hitnums[0] == hitnums[2] || hitnums[1] == hitnums[2]){
        hitnums[2] = Math.floor(Math.random() * 9);
    }
    
    //count total number of hits(matching numbers from nums and hitnums)
    var j;
    for(i=0; i < 3; i++){
        for(j=0; j < 3; j++){
            if(nums[i].value == hitnums[j])
                hitsTotal++;
        }
    }
    
    //edit text right after "Results:" text in html to announce amount of luck 
    if(hitsTotal == 0){
        $(anouncement).text("--Bad Luck--");
        $(anouncement).css("color", "#fe3e3e");   
    }
    if(hitsTotal == 1){
        $(anouncement).text("--Decent Luck--");
        $(anouncement).css("color", "rgba( 245, 231, 34, 0.995 )"); 
        
    }
    if(hitsTotal == 2){
        $(anouncement).text("--Good Luck--");
        $(anouncement).css("color", "#39fe6d");
    }
    if(hitsTotal == 3){
        $(anouncement).text("Amazing Luck");
        $(anouncement).css("color", "#39fe6d");
        
    }
    
    
    //added list
    $("div#result").after("<h5>Generated Numbers: </h5><ul><li>" + hitnums[0] + "</li><li>" + hitnums[1] + "</li><li>" + hitnums[2] + "</li></ul> <h5>Hits Total:"+hitsTotal+"</h5><hr>");

    //alert(nums[0].value);
    event.preventDefault();
});