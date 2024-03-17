namespace FitnessTracker.Core.Models.Athlete
{
    /// <summary>
    /// Class is used for Viewing Athletes Workouts.
    /// </summary>
    public class AthleteWorkoutsViewModel
    {
        /// <summary>
        /// Property for Workout Identity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property for Athlete Identity.
        /// </summary>
        public int AthleteId { get; set; }

        /// <summary>
        /// Property for Workout Type.
        /// </summary>
        public string WorkoutType { get; set; } = string.Empty;

        /// <summary>
        /// Property for when the Workout was performed.
        /// </summary>
        public string Date { get; set; } = string.Empty;

        /// <summary>
        /// Property for in witch gym the Workout was Performed.
        /// </summary>
        public string GymName { get; set; } = string.Empty;

        /// <summary>
        /// Collection of Exercises of the Workout.
        /// </summary>
        public IEnumerable<AthleteExerciseIntensity> Exercises { get; set; } = new List<AthleteExerciseIntensity>();
    }
}
