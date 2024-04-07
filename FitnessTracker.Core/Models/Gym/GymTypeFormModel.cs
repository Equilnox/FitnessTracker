using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Data.Constrains.ErrorMessages;

namespace FitnessTracker.Core.Models.Gym
{
    /// <summary>
    /// Class is used to change Gym Type from Personal to Public or from Public to Personal
    /// </summary>
    public class GymTypeFormModel
    {
        /// <summary>
        /// Property for Gym Identifier.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Property for Gym Type.
        /// </summary>
        [Required(ErrorMessage = RequiredFieldMessage)]
        public string Type { get; set; } = string.Empty;
    }
}
