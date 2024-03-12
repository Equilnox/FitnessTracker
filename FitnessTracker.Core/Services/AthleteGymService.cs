using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.AthleteGym;
using FitnessTracker.Infrastructure.Data.Common;
using FitnessTracker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Core.Services
{
    public class AthleteGymService : IAthleteGymService
	{
		private readonly IRepository repository;

		public AthleteGymService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task RenewAsync(GymMembershipRenewFormModel model)
		{
			var memberships = await repository.All<AthleteGym>()
				.Select(ag => ag).ToListAsync();

			var membershipOfAthlete = memberships.Find(m => m.AthleteId == model.AthleteId && m.GymId == model.GymId);

			membershipOfAthlete.StartDate = DateTime.Parse(model.StartDate);
			membershipOfAthlete.EndDate = DateTime.Parse(model.EndDate);

			repository.SaveAsync();
		}
	}
}
