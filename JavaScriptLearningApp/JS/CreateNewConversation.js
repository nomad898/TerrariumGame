$(document).ready(function () {
    $('#btnCreate').click(function () {
        var apiUrl = 'http://localhost:50808/api/Conversation';
        var conversationVM = {
            ConversationId: '',            
            Date: '',
            Message: $('#Message').val() ,
        };  

        console.log(conversationVM);
        $.ajax({
            type: 'POST',
            url: apiUrl,
            data:  JSON.stringify(conversationVM), 
            contentType: "application/json",
            success: function (data) {
                console.log(data);
            },
            error: function (data) {
                console.log('error with creating');
                console.log(data);
            }
        });
    })
});

