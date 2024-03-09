using System.Runtime.CompilerServices;

namespace FitnessTracker.Core.Models.Athlete
{
    public class AthleteExerciseIntensity
    {
        public int Id { get; set; }

        public string ExerciseName { get; set; }

        public int LiftedWeight { get; set; }

        public int Sets { get; set; }

        public int Repetitions { get; set; }

        public int Seconds { get; set; }

        public int WorkoutId { get; set; }
    }
}
