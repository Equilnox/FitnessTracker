using System.Runtime.CompilerServices;

namespace FitnessTracker.Core.Models.Athlete
{
    /// <summary>
    /// Class is used for Viewing exercises of workouts.
    /// </summary>
    public class AthleteExerciseIntensity
    {
        /// <summary>
        /// Intensity Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Exercise Name
        /// </summary>
        public string ExerciseName { get; set; }

        /// <summary>
        /// Amount of weight lifted for the Exercise.
        /// </summary>
        public int LiftedWeight { get; set; }

        /// <summary>
        /// Number of Sets performed of the Exercise.
        /// </summary>
        public int Sets { get; set; }

        /// <summary>
        /// Number of Repetitions per Set performed for the Exercise.
        /// </summary>
        public int Repetitions { get; set; }

        /// <summary>
        /// Average time spent on Repetition.
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// Workout identifier to witch the performed exercise belongs.
        /// </summary>
        public int WorkoutId { get; set; }
    }
}
