// Write your JavaScript code.
$(document).ready(function () {
    // Wire up the Add button to send the new item to the server
    $('#add-item-button').on('click', addItem);
    // Wire up all of the checkboxes to run markCompleted()
    $('.done-checkbox').on('click', function (e) { markCompleted(e.target); });
});

function addItem() {
    //hide the error message
    $('#add-item-error').hide();
    //take the words for a new title and pass it to newTitle – this is the important heart of the function
    var newTitle = $('#add-item-title').val();
    $.post('/Todo/AddItem', { title: newTitle }, function () {
            window.location = '/Todo';
        })
        //do stuff when there is an error
        .fail(function (data) {
            if (data && data.responseJSON) {
                var firstError = data.responseJSON[Object.keys(data.responseJSON)[0]];
                $('#add-item-error').text(firstError);
                $('#add-item-error').show();
            }
        });


}
function markCompleted(checkbox) { // Pass through all the properties of the checkbox you clicked on
    checkbox.disabled = true; // set it to disabled so you can’t click it again.
    // Adds done to the database in the line where the guid
    $.post('/Todo/MarkDone', { id: checkbox.name }, function () {
        var row = checkbox.parentElement.parentElement;
        $(row).addClass('done');
    });
}