$('#approveChanges').submit(function (e) {
    e.preventDefault();

    // Extract request data from the form
    var id = $('#id').val();

    // Create an AJAX request to submit the form data
    $.ajax({
        url: approveChangesUrl,
        type: 'POST',
        headers: {
            RequestVerificationToken: $('#approveChangesAntiForgeryToken').val() // Include the anti-forgery token value
        },
        data: {
            id: id,
        },
        success: function (response) {
            // Handle success response
            // For example, close the modal
            $('#approveChanges').modal('hide');
            // Redirect to the Done view
            location.reload();
        },
        error: function (xhr, status, error) {
            // Handle error response
        }
    });
});