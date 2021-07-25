using System.Text.RegularExpressions;

namespace SocialService.Management.Extensions
{
    public static class LoginCheckerExtension
    {
        private static readonly int LOGIN_LENGTH_LIMIT = 64;

        public static bool IsLoginCorrect(this string login)
        {
            if (login.Length > LOGIN_LENGTH_LIMIT)
            {
                return false;
            }

            var regexp = new Regex("^[A-Za-z ]+$");
            if (!regexp.IsMatch(login))
            {
                return false;
            }

            return true;
        }
    }
}
