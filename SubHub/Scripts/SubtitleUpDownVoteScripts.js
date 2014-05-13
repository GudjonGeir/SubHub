

$(document).on("click", ".vote-sub", function (e) {
    var currElem = $(this);
    $.post($(this).attr('href'), function (data) {

        if (data === "") {
            currElem.closest("td").children(".upvote-error-message").show();
        }
        else {
            currElem.closest("td").children(".rating-count").html(data);
        }
    });
    return false;
});



