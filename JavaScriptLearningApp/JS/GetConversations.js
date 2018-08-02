$(document).ready(function () {
    var tableConversations = $('#tableConversations tbody');

    var urlPath = 'http://localhost:50808/api/Conversation';

    $(window).scroll(function() {        
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {
            getConversations();
        }
    });

    $('#btn').click(function () {
      getConversations();
    })

    function getConversations() {
        console.log('get all conversations clicked');
        $.ajax({
            type: 'GET',            
            url: urlPath,
            dataType: 'json',
            success: function (data) {
                console.log(data);
                tableConversations.empty();
                $.each(data, function (index, val) {
                    var conversationId = val.ConversationId;
                    var conversationMessage = val.Message;
                    var conversationDate = val.Date;
                    var markup = '<tr><td>' + conversationId + '</td><td>' + conversationMessage + '</td><td>' + conversationDate + '</td></tr>';
                    tableConversations.append(markup);
                });
            },
            error: function (data) {
                console.log('error');
            } 
        });
    };
});

