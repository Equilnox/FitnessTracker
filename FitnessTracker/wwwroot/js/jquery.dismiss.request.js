$('#dismissRequest').submit(function (e) {
    e.preventDefault();

    // Extract request data from the form
    var id = $('#id').val();

    // Create an AJAX request to submit the form data
    $.ajax({
        url: dismissRequestUrl,
        type: 'POST', headers: {
            RequestVerificationToken: $('#dismissAntiForgeryToken').val() // Include the anti-forgery token value
        },
        data: {
            id: id,
        },
        success: function (response) {
            // Handle success response
            // For example, close the modal
            $('#dismissRequest').modal('hide');
            // Redirect to the Done view
            location.reload();
        },
        error: function (xhr, status, error) {
            // Handle error response
        }
    });
});