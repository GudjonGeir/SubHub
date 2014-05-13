

$(document).on("click", ".upvote-sub", function (e) {
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

$(document).on("click", ".downvote-sub", function (e) {
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

