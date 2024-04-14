using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Core.Contracts
{
    public interface IRequestModel
    {
        public string RequestType { get; set; }

        public string ExerciseName { get; set; }
    }
}
