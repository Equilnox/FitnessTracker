using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Gym;
using FitnessTracker.Infrastructure.Data.Common;
using FitnessTracker.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<GymViewModel> GetGymAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
