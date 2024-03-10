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

        public async Task<GymDetailViewModel> GetGymAsync(int id)
        {
            var gyms = await repository.AllReadOnly<Gym>()
                .Select(g => new GymDetailViewModel
                {
                    Id = id,
                    Name = g.Name,
                    Address = g.Address,
                    PhoneNumber = g.PhoneNumber,
                    PricePerMonth = g.PricePerMonth.ToString(),
                })
                .ToListAsync();

            var model = gyms.Find(g => g.Id == id);

            var members = await GetMembersAsync(id);

            if(members.Any())
            {
                model.Members = members;
            }

            return model;
        }

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
