using FitnessTracker.Core.Contracts;

namespace FitnessTracker.Core.Models.Gym
{
    public class MyGymViewModel : IGymModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
    }
}
