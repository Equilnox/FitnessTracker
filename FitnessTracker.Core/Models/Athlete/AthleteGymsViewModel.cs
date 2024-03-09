namespace FitnessTracker.Core.Models.Athlete
{
    public class AthleteGymsViewModel
    {
        public int AthleteId { get; set; }

        public int GymId { get; set; }

        public string GymName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
