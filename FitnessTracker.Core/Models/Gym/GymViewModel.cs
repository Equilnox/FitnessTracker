﻿namespace FitnessTracker.Core.Models.Gym
{
    public class GymViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string PricePerMonth { get; set; } = string.Empty;
    }
}