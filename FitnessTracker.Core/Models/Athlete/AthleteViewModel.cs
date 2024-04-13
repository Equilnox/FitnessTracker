using FitnessTracker.Core.Contracts;

namespace FitnessTracker.Core.Models.Athlete
{
    /// <summary>
    /// Class is used for Athletes Home Page.
    /// </summary>
    public class AthleteViewModel : IAthleteModel
    {
        /// <summary>
        /// Property for Athlete identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property for Athlete Firs Name.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Property for Athlete Last Name.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Property for Athlete profile picture.
        /// </summary>
        public string ProfilePictureURL { get; set; } = string.Empty;

        /// <summary>
        /// Property for Athlete Age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Property for Athlete Hight.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Property for Athlete Weight.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Property for User identifier, with witch the Athlete has Registered.
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Collection of Athletes Workouts.
        /// </summary>
        public virtual IEnumerable<AthleteWorkoutsViewModel> Workouts { get; set; } = new List<AthleteWorkoutsViewModel>();

        /// <summary>
        /// Collection of Athletes Memberships.
        /// </summary>
        public virtual IEnumerable<AthleteGymsViewModel> AthletesGym { get; set; } = new List<AthleteGymsViewModel>();
    }
}
