$('#addExerciseForm').submit(function (e) {
    e.preventDefault();

    // Extract exercise data from the form
    var exerciseMuscleGroup = $('#exerciseMuscleGroup').val();
    var exerciseId = $('#exerciseId').val();
    var liftedWeight = $('#liftedWeight').val();
    var repetitions = $('#repetitions').val();
    var sets = $('#sets').val();
    var seconds = $('#seconds').val();

    // Create an AJAX request to submit the form data
    $.ajax({
        url: addExerciseUrl,
        type: 'POST',
        data: {
            exerciseMuscleGroup: exerciseMuscleGroup,
            exerciseId: exerciseId,
            liftedWeight: liftedWeight,
            repetitions: repetitions,
            sets: sets,
            seconds: seconds
        },
        success: function (response) {
            // Handle success response
            // For example, close the modal
            $('#addExerciseModal').modal('hide');
            // Reload the page to refresh the added exercises
            location.reload();
        },
        error: function (xhr, status, error) {
            // Handle error response
        }
    });
});