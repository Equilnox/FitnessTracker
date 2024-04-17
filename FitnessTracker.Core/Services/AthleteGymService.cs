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

		/// <summary>
		/// Create new Athlete membership.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="athleteId"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Update the Start and End date for athlete membership.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task RenewAsync(GymMembershipRenewFormModel model)
		{
			var athleteMemberships = await repository.All<AthleteGym>()
				.Select(ag => ag)
				.FirstAsync(m => m.AthleteId == model.AthleteId && m.GymId == model.GymId);

			athleteMemberships.StartDate = DateTime.Parse(model.StartDate);
			athleteMemberships.EndDate = DateTime.Parse(model.EndDate);

			await repository.SaveAsync();
		}

		/// <summary>
		/// Performs a Check if Athlete is Registered.
		/// </summary>
		/// <param name="userEmail"></param>
		/// <returns></returns>
		public async Task<bool> AthleteExists(string userEmail)
		{
			string normalizedUserEmail = userEmail.ToUpper();

			var athletes = await repository.All<Athlete>()
				.Select(a => a.User.NormalizedEmail)
				.ToListAsync();

			return athletes.Any(u => u == normalizedUserEmail);
		}

		/// <summary>
		/// Return Athlete's Id. If there are more then one Athlete with the Same Email returns 0.
		/// </summary>
		/// <param name="userEmail"></param>
		/// <returns></returns>
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

		public async Task<bool> AthleteIsMember(int athleteId, int gymId)
		{
			return await repository.All<AthleteGym>()
				.AnyAsync(ag => ag.AthleteId == athleteId && ag.GymId == gymId);
		}
	}
}
