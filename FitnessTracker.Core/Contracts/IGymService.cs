using FitnessTracker.Core.Models.Gym;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Core.Contracts
{
	public interface IGymService
	{
		Task<IEnumerable<GymViewModel>> GetAllAsync();

		Task<GymViewModel> FindGymAsync(int id);
	}
}
