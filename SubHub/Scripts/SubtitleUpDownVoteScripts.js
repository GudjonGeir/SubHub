

$(document).on("click", ".vote-sub", function (e) {
    var currElem = $(this);
    $.post($(this).attr('href'), function (data) {

        if (data === "") {                                                      // If the data is empty the user isn't logged in
            currElem.closest("td").children(".upvote-error-message").show();    // And display the error message
        }
        else {
            currElem.closest("td").children(".rating-count").html(data);        // Replaces the rating with the resulting data
        }
    });
    return false;                                                               // Prevents the browser loading the anchor
});



