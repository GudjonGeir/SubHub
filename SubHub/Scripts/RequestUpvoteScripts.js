

$(document).on("click", ".like-request", function (e) {
    //alert("Fallo");

    var currElem = $(this);
    $.post($(this).attr('href'), function (data) {
        var bla = data;
        //alert($(this).html());
        currElem.closest("td").children(".rating-count").html(data);
        //$(this).siblings(".rating-count").text(data);
    });
    return false;
});


