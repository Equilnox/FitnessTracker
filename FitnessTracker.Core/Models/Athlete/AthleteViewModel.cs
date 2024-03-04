using FitnessTracker.Infrastructure.Data.Models;

namespace FitnessTracker.Core.Models.Athlete
{
    public class AthleteViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string ProfilePictureURL { get; set; } = string.Empty;

        public int Age { get; set; }

        public int Height { get; set; }

        public double Weight { get; set; }

        public string UserId { get; set; } = string.Empty;

        public virtual IEnumerable<AthleteWorkoutsViewModel> Workouts { get; set; } = new List<AthleteWorkoutsViewModel>();

        public virtual IEnumerable<AthleteGym> AthletesGym { get; set; } = new List<AthleteGym>();
    }
}
