$('#gymTypeForm').submit(function (e) {
    e.preventDefault();

    // Extract exercise data from the form
    var id = $('#id').val();
    var type = $('#type').val();

    // Create an AJAX request to submit the form data
    $.ajax({
        url: changeGymTypeUrl,
        type: 'POST',
        data: {
            id: id,
            type: type
        },
        success: function (response) {
            // Handle success response
            // For example, close the modal
            $('#changeGymTypeModal').modal('hide');
            // Reload the page to refresh the added exercises
            location.reload();
        },
        error: function (xhr, status, error) {
            // Handle error response
        }
    });
});