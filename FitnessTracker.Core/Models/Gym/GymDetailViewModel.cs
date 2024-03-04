namespace FitnessTracker.Core.Models.Gym
{
    public class GymDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string PricePerMonth { get; set; } = string.Empty;

        public IEnumerable<GymMembersViewModel> Members { get; set; } = new List<GymMembersViewModel>();
    }
}
