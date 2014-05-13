$(document).ready(function () {
    var theId = $("#subtitleId").val();
    getAllComments(theId);
});


function AddComment() {
    var thecomment = $("#CommentText").val();
    var theId = $("#subtitleId").val();
    $.post("/Subtitle/AddComment", { CommentText: thecomment, SubtitleId: parseInt(theId) }, function () {
        $('#CommentText').val('');
        getAllComments(theId);
    })
}

function getAllComments(theId) {
    $.ajax(
        {
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "/Subtitle/GetComments/",
            data: { id: parseInt(theId) },
            dataType: "json",
            success: function (model) {
                var posts = [];
                for (var i = 0; i < model.length ; i++) {
                    posts.push({
                        user: model[i].UserName,
                        theDateSubmitted: model[i].DateSubmitted = ConvertStringToJSDate(model[i].DateSubmitted),
                        theComment: model[i].CommentText,
                    });

                }
                $(".comments").loadTemplate($("#comment-template"), posts);
            },
            error: function (xhr, err) {
                alert("Shits fucked");
            }
        });  
}

function ConvertStringToJSDate(dt) {
    var dtE = /^\/Date\((-?[0-9]+)\)\/$/.exec(dt);
    if (dtE) {
        var dt = new Date(parseInt(dtE[1], 10));
        return dt;
    }
    return null;
}