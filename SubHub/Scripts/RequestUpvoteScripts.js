

$(document).on("click", ".like-request", function (e) {
 var currElem = $(this);
    $.post($(this).attr('href'), function (data) {
        
        if (data != "") {
            currElem.closest("td").children(".rating-count").html(data);
        }
        else {
            currElem.closest("td").children(".upvote-error-message").show();
        }      
    });
    return false;
});


$(document).on("click", ".complete-request", function (e) {
    var currElem = $(this);
    $.post($(this).attr('href'), function (data) {
        location.reload(false);
    });
    
    return false;
});
