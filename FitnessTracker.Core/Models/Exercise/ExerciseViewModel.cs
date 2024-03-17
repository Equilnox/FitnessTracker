namespace FitnessTracker.Core.Models.Exercise
{
	public class ExerciseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string MuscleGroup { get; set; } = string.Empty;
    }
}
