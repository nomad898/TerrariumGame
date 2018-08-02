$(document).ready(function () {
    var tableConversations = $('#tableConversations tbody');

    $('#btnClear').click(function () {
        tableConversations.empty();
    });
});