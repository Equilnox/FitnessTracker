using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Data.Constrains
{
    public static class ErrorMessages
    {
        public const string RequiredFieldMessage = "The {0} field is required!";

        public const string StringLengthMessage = "The {0} field must be between {2} and {1} characters long!";
    }
}
