

$(document).on("click", ".like-request", function (e) {                         // On like click
 var currElem = $(this);
    $.post($(this).attr('href'), function (data) {
        
        if (data != "") {                                                       // If data is empty the user isn't logged in
            currElem.closest("td").children(".rating-count").html(data);        // Replace the rating with the resulting data
        }
        else {
            currElem.closest("td").children(".upvote-error-message").show(); 
        }      
    });
    return false;                                                               // Prevent browser loading the anchor
});


$(document).on("click", ".complete-request", function (e) {                     // On complete click
    var currElem = $(this);
    $.post($(this).attr('href'), function (data) {
        location.reload(false);                                                 // Reloads the page to get current status
    });
    
    return false;                                                               // Prevent browser loading the anchor
});
