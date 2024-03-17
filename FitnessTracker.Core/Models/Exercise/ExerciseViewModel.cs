namespace FitnessTracker.Core.Models.Exercise
{
    /// <summary>
    /// Class is used for Viewing Exercises.
    /// </summary>
	public class ExerciseViewModel
    {
        /// <summary>
        /// Property for Exercise Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property for Exercise Name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Property for Exercise Description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Property for Exercise Muscle Group.
        /// </summary>
        public string MuscleGroup { get; set; } = string.Empty;
    }
}
