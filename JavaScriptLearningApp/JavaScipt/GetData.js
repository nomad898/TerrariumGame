$(document).ready(function () {
    var ulConversations = $('#ulConversations');

    $('#btn').click(function () {
        console.log('clicked');
        $.ajax({
            type: 'GET',            
            url: 'http://10.12.9.38:8080/api/Conversation/',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                ulConversations.empty();
                $.each(data, function (index, val) {
                    var conversationData = val.ConversationId + ' ' + val.Message + ' ' + val.Date;
                  
                    ulConversations.append('<li>' + conversationData + '</li>');
                    
                });
            },
            error: function (data) {
                console.log('error');
            } 
        });
    })

    $('#btnClear').click(function () {
        ulConversations.empty();
    });
});