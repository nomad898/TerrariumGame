var uri = '';

$(document).ready(function () {
    $('btnGetPosts').click(function () {
        JQuery.supports.cors = true;
        var recieverID = $('#RecieverID').val();

        $.ajax({
            url: "/api/Conversation",
            data: {
                username: recieverID
            },
            type: "GET",
            dataType: "json",
            error: function (request, status, error) {
                alert(request.responseText);
            },
            success: function(data) {
                alert(data);
            }
        });
    });
});