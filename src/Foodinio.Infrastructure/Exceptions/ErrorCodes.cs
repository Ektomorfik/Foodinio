namespace Foodinio.Infrastructure.Exceptions
{
    public class ErrorCodes
    {
        public static string InvalidPassword => "invalid_password";
        public static string UserAlreadyExists => "user_already_exists";
        public static string InvalidCredentials => "invalid_credentials";
        public static string UserNotFound => "user_not_found";
    }
}