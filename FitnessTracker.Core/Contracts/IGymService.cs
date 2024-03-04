using FitnessTracker.Core.Models.Gym;
using FitnessTracker.Infrastructure.Data.Common;
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

        Task<GymViewModel> GetGymAsync(int id);
    }
}
