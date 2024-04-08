namespace FitnessTracker.Infrastructure.Data.Constrains
{
    public static class DataConstrains
    {
        public const int ExerciseNameMinLength = 5;
        public const int ExerciseNameMaxLength = 25;

        public const int ExerciseDescriptionMinLength = 10;
        public const int ExerciseDescriptionMaxLength = 500;

        public const int UserFirstNameMinLength = 3;
        public const int UserFirstNameMaxLength = 25;

        public const int UserLastNameMinLength = 5;
        public const int UserLastNameMaxLength = 25;

        public const int UserIdMaxLength = 450;

        public const int GymNameMinLength = 5;
        public const int GymNameMaxLength = 50;

        public const int GymAddressMinLength = 4;
        public const int GymAddressMaxLength = 250;

        public const int GymOwnerMinLength = 10;
        public const int GymOwnerMaxLength = 50;

        public const int GymPhoneNumberMinLength = 10;
        public const int GymPhoneNumberMaxLength = 12;

        public const string GymMaxPricePerMonth = "120.00";

        public const string DateFormat = "dd/MM/yyyy";
    }
}
