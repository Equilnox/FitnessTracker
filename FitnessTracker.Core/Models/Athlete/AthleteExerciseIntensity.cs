using System.Runtime.CompilerServices;

namespace FitnessTracker.Core.Models.Athlete
{
    public class AthleteExerciseIntensity
    {
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public int LiftedWeight { get; set; }

        public int Sets { get; set; }

        public int Repetitions { get; set; }

        public int Seconds { get; set; }

        public int WorkoutId { get; set; }

        public double Intensity()
        {
            double intensity = LiftedWeight*Repetitions*Sets/Seconds;

            return intensity;
        }
    }
}
