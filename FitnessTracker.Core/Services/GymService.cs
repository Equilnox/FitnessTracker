using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Gym;
using FitnessTracker.Infrastructure.Data.Common;
using FitnessTracker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Core.Services
{
	public class GymService : IGymService
    {
        private readonly IRepository repository;

        public GymService (IRepository _repository)
        {
            repository = _repository;
        }

		/// <summary>
		/// Return all Gyms.
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<GymViewModel>> GetAllAsync()
        {
            var model = await repository.AllReadOnly<Gym>()
                .Select(g => new GymViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Address = g.Address,
                    PhoneNumber = g.PhoneNumber,
                    PricePerMonth = g.PricePerMonth.ToString()
                })
                .ToListAsync();

            return model;
        }

		/// <summary>
		/// Return specific Gym.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<GymDetailViewModel> GetGymAsync(int id)
        {
            var model = await repository.AllReadOnly<Gym>()
                .Select(g => new GymDetailViewModel
                {
                    Id = id,
                    Name = g.Name,
                    Address = g.Address,
                    PhoneNumber = g.PhoneNumber,
                    OwnerId = g.OwnerId,
                    PricePerMonth = g.PricePerMonth.ToString(),
                })
                .FirstAsync(g => g.Id == id);

            var owner = await GetOwnerName(model.OwnerId);

            model.Owner = owner;

            var members = await GetMembersAsync(id);

            if(members.Any())
            {
                model.Members = members;
            }

            return model;
        }

        /// <summary>
        /// Method returns Gym Id by receiving User Id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<int> GetGymIdByUserIdAsync(string userId)
        {
            var gymId = await repository.AllReadOnly<Gym>()
                .Where(g => g.OwnerId == userId)
                .Select(g => g.Id)
                .ToListAsync();

            if(gymId.Count == 1)
            {
                return gymId.First();
            }

            return 0;
        }

        /// <summary>
        /// Return Athletes Memberships, who have joined the gym.
        /// </summary>
        /// <param name="gymId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GymMembersViewModel>> GetMembersAsync(int gymId)
        {
            var allMembers = await repository.AllReadOnly<AthleteGym>()
                .Select(a => new GymMembersViewModel
                {
                    MemberId = a.AthleteId,
                    GymId = a.GymId,
                    Name = $"{a.Athlete.FirstName} {a.Athlete.LastName}",
                    Height = a.Athlete.Height,
                    Weight = a.Athlete.Weight,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate
                })
                .ToListAsync();

            var members = allMembers.Where(g => g.GymId == gymId);

            return members;
        }

        /// <summary>
        /// Method returns Gym Owner First and Last Name by receiving User Id.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
		public async Task<GymOwner> GetOwnerName(string UserId)
		{
			var owner = await repository.AllReadOnly<Athlete>()
                .Where(a => a.UserId == UserId)
                .Select(o => new GymOwner()
                {
                    FirstName = o.FirstName,
                    LastName = o.LastName
                })
                .ToListAsync();

            return owner.First();
        }
	}
}
