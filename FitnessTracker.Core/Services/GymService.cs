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

		public GymService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task<IEnumerable<GymViewModel>> GetAllAsync()
		{
			IEnumerable<GymViewModel> model = await repository.AllReadOnly<Gym>()
				.Select(g => new GymViewModel 
				{
					Id = g.Id,
					Name = g.Name,
					Owner = g.Owner,
					Address = g.Address,
					PhoneNumber = g.PhoneNumber,
					PricePerMonth = g.PricePerMonth.ToString()
				})
				.ToListAsync();

			return model;
		}

        public async Task<GymViewModel> FindGymAsync(int id)
        {
			var gyms = await GetAllAsync();

			var model = gyms.FirstOrDefault(g => g.Id == id);

			return model;
        }
    }
}
