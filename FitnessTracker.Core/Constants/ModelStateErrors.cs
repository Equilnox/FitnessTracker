namespace FitnessTracker.Core.Constants
{
    public static class ModelStateErrors
    {
        public const string ErrorKeyWhenUserDoesNotExists = "NoUser";

        public const string UserDoesNotExists = "User doesn't have an account in the application.";

        public const string ErrorKeyWhenThereAreTwoIdenticalEmails = "TwoIdenticalEmails";

        public const string MultipleUsersWithSameEmail = "There are more then one user with the same email address.";
    }
}
