using FitnessTracker.Core.Contracts;
using System.Text.RegularExpressions;

namespace FitnessTracker.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetExerciseInformation(this IExerciseModel exerciseModel)
        {
            string info = exerciseModel.Name.Replace(" ", "-") + GetMuscleGroup(exerciseModel.MuscleGroup);

            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        private static string GetMuscleGroup(string muscleGroup)
        {
            return muscleGroup.Replace(" ", "-");
        }

        public static string GetGymInformation(this IGymModel gymModel)
        {
            string info = gymModel.Name.Replace(" ", "-") + GetGymAddress(gymModel.Address);

            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);
            
            return info;
        }

        private static string GetGymAddress(string address)
        {
            address = string.Join("-", address.Split(" ").Take(1));

            return address;
        }

        public static string GetRequestInformation(this IRequestModel requestModel)
        {
            string info = requestModel.ExerciseName.Replace(" ", "-") + GetRequestType(requestModel.RequestType);

            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        private static string GetRequestType(string requestType)
        {
            requestType = string.Join("-", requestType.Split(" ").Take(2));

            return requestType;
        }

        public static string GetAthleteInformation(this IAthleteModel athleteModel)
        {
            string info = string.Join("-", athleteModel.FirstName, athleteModel.LastName);

            return info;
        }
    }
}
