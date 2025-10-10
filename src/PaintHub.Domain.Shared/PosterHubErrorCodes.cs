namespace PosterHub.Domain.Shared
{
    public static class PosterHubErrorCodes
    {
        public const string CategoryNameConNotBeNullOrEmpty = "Category name must have a value and not null or white spaces";
        public const string TreePathConNotBeNullOrEmpty = "Tree path can't be empty or null";
        public const string CategoryNotFound = "Category not found with Id: ";

        public const string UsernameRequired = "Username is required";
        public const string PasswordRequired = "Password is required";

        public const string SecretKeyNull = "Secret Key is missing";
        public const string WrongUsernameOrPassword = "Authentication failed: Wrong username or password.";
    }
}
