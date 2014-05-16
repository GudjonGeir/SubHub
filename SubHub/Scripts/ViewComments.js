//When the page loads we get the value of a hidden
//id inside the html document which contains the id
//for the subtitle so we can load the comments
//for the corresponding id
$(document).ready(function () {
    var theId = $("#subtitleId").val();
    getAllComments(theId);
});

//If a user wants to delete his comment he needs to confirm it
//and if he does we send a ajax request and load all the comments again
function DeleteComment(tala) {
    if (confirm("Ertu viss um að þú viljir eyða athugasemd ?") == true) {
        var theId = $("#subtitleId").val();
        $.post("/Subtitle/DeleteComment", { id: parseInt(tala) }, function () {
            getAllComments(theId);
        })
    }

}

//The requirements for posting a comment is that the comment box isnt
//empty and the user must be logged in, if he isnt we show a nice error message
//indicating him that he needs to logged in or that the comment box cannot be empty
function AddComment() {
    var user = $("#user").val();
    var thecomment = $("#CommentText").val();
    var theId = $("#subtitleId").val();
    if (thecomment != "" && user != "") {
        $("#emptyText").hide();
        $.post("/Subtitle/AddComment", { CommentText: thecomment, SubtitleId: parseInt(theId) }, function () {
            $('#CommentText').val('');
            getAllComments(theId);
        })
    }
    if(user == "")
    {
        $("#errorMessage").show();
    }
    if(thecomment == "")
    {
        $("#emptyText").show();
    }
}

//Sends a ajax request to get all the comments
// for the corresponding subtitleid, if everything
//goes as planned, the request returns a model which we push
//into a template and if the current user has any comments
//in the model he gets a link to delete the comment he made
function getAllComments(theId) {
    var user = $("#user").val();
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
                    if (user == model[i].UserName) {
                        posts.push({
                            deletelink: "javascript: DeleteComment(" + model[i].Id + ")",
                            user: model[i].UserName,
                            theDateSubmitted: model[i].DateSubmitted = ConvertStringToJSDate(model[i].DateSubmitted),
                            theComment: model[i].CommentText,
                        });
                    }
                    else {
                        posts.push({
                            user: model[i].UserName,
                            theDateSubmitted: model[i].DateSubmitted = ConvertStringToJSDate(model[i].DateSubmitted),
                            theComment: model[i].CommentText,
                        });
                    }

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