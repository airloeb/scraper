$(function() {
    alert('hi');
    $('#delete-button').click(function () {
        alert('pushed!');
        id = $(this).data('id');
        $.post('Home/Delete', { id: id }, function() {
        });
    })
})