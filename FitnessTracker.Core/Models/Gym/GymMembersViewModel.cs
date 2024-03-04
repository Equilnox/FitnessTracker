namespace FitnessTracker.Core.Models.Gym
{
    public class GymMembersViewModel
    {
        public int MemberId { get; set; }

        public int GymId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Height { get; set; }

        public double Weight { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
