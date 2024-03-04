namespace FitnessTracker.Core.Models.Athlete
{
    public class AthleteWorkoutsViewModel
    {
        public int Id { get; set; }

        public string WorkoutType { get; set; } = string.Empty;

        public string Date { get; set; } = string.Empty;

        public IEnumerable<AthleteExerciseIntensity> Exercises { get; set; } = new List<AthleteExerciseIntensity>();
    }
}
