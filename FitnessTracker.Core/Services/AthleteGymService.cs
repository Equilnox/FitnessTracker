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

		public async Task AddNewMember(NewMembershipFormModel model, int athleteId)
		{
			AthleteGym member = new AthleteGym()
			{
				GymId = model.GymId,
				AthleteId = athleteId,
				StartDate = DateTime.Parse(model.StartDate),
				EndDate = DateTime.Parse(model.EndDate)
			};

			await repository.AddAsync(member);
			await repository.SaveAsync();
		}

		public async Task RenewAsync(GymMembershipRenewFormModel model)
		{
			var athleteMemberships = await repository.All<AthleteGym>()
				.Select(ag => ag)
				.FirstAsync(m => m.AthleteId == model.AthleteId && m.GymId == model.GymId);

			athleteMemberships.StartDate = DateTime.Parse(model.StartDate);
			athleteMemberships.EndDate = DateTime.Parse(model.EndDate);

			await repository.SaveAsync();
		}

		public async Task<bool> AthleteExists(string userEmail)
		{
			string normalizedUserEmail = userEmail.ToUpper();

			var athletes = await repository.All<Athlete>()
				.Select(a => a.User.NormalizedEmail)
				.ToListAsync();

			return athletes.Any(u => u == normalizedUserEmail);
		}

		public async Task<int> GetAthleteId(string userEmail)
		{
			string normalizedUserEmail = userEmail.ToUpper();

			var athleteId = await repository.AllReadOnly<Athlete>()
				.Where(a => a.User.Email == normalizedUserEmail)
				.Select(aId => aId.Id)
				.ToListAsync();

			if(athleteId.Count == 1)
			{
				return athleteId.First();
			}

			return 0;
		}
	}
}
