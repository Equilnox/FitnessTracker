$('#gymTypeForm').submit(function (e) {
    e.preventDefault();

    // Extract gym data from the form
    var id = $('#id').val();
    var type = $('#type').val();
    var name = $('#name').val();
    var address = $('#address').val();

    // Create an AJAX request to submit the form data
    $.ajax({
        url: changeGymTypeUrl,
        type: 'POST',
        headers: {
            RequestVerificationToken: $('#antiForgeryToken').val() // Include the anti-forgery token value
        },
        data: {
            id: id,
            type: type,
            name: name,
            address: address
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