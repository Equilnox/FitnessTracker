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
        /// Method is used to change basic details for Gym.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> ChangeGymDetailsAsync(GymDetailsFormViewModel model)
        {
            var gym = await repository.All<Gym>()
                .FirstAsync(g => g.Id == model.Id);

            gym.Name = model.GymName;
            gym.Address = model.Address;
            gym.PhoneNumber = model.PhoneNumber;
            gym.PricePerMonth = model.PricePerMonth;
            gym.GymType = model.GymType;

            await SaveGymAsync();

            return gym.Id;
        }

		/// <summary>
		/// When a new user registers, the method will create a new Personal Gym. 
		/// </summary>
		/// <returns></returns>
		public async Task AddPersonalGymAsync(GymFromModel personalGym)
		{
			var model = new Gym()
			{
				Name = personalGym.GymName,
				Address = personalGym.Address,
				PhoneNumber = personalGym.PhoneNumber,
				OwnerId = personalGym.OwnerId,
				GymType = personalGym.GymType,
				PricePerMonth = personalGym.PricePerMonth,
			};

			var athleteId = await repository.AllReadOnly<Athlete>()
				.Where(a => a.UserId == personalGym.OwnerId)
				.Select(a => a.Id)
				.FirstOrDefaultAsync();

			model.AthletesGyms.Add(new AthleteGym()
			{
				AthleteId = athleteId,
				StartDate = DateTime.Now,
				EndDate = DateTime.MaxValue
			});

			await repository.AddAsync(model);
			await SaveGymAsync();
		}

		/// <summary>
		/// Return all Gyms.
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<GymViewModel>> GetAllPublicAsync()
        {
            var model = await repository.AllReadOnly<Gym>()
                .Where(g => g.GymType == Infrastructure.Data.Models.Enums.GymType.Public)
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
            var gymList = await repository.AllReadOnly<Gym>()
                .Select(g => new GymDetailViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Address = g.Address,
                    PhoneNumber = g.PhoneNumber,
                    OwnerId = g.OwnerId,
                    PricePerMonth = g.PricePerMonth.ToString(),
                })
                .ToListAsync();

            var model = gymList.Find(g => g.Id == id);

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
        /// Method returns basic details of Gym.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GymDetailsFormViewModel> GetGymDetailsAsync(int id)
        {
            var gym = await repository.AllReadOnly<Gym>()
                .Select(g => new GymDetailsFormViewModel
                {
                    Id = g.Id,
                    GymName = g.Name,
                    Address = g.Address,
                    PhoneNumber = g.PhoneNumber,
                    PricePerMonth = g.PricePerMonth
                })
                .FirstAsync(g => g.Id == id);

            return gym;
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

        /// <summary>
        /// Method saves changes to Data Base.
        /// </summary>
        /// <returns></returns>
        public async Task SaveGymAsync()
        {
            await repository.SaveAsync();
        }
    }
}
