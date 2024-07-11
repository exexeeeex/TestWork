using System.Net.Mail;
using Application.DTOS;

namespace Application.Services
{
    public class ValidationService
    {
        public static bool CheckCorrectEmail(string email)
        {
            if (!MailAddress.TryCreate(email, out var address)) return false;
            var hostParts = address.Host.Split('.');
            if (hostParts.Length == 1) return false;
            if (hostParts.Any(p => p == string.Empty)) return false;
            if (hostParts[^1].Length < 2) return false;

            return !address.User.Contains(' ')
                && address.User.Split('.').All(p => p != string.Empty);
        }
        public static bool CheckVoidField(PasswordDTO password) 
        {
            if(password.Name.Length == 0 || password.Value.Length == 0)
                return false;
            return true;
        }
        public static bool CheckPasswordLength(string password) =>
            password.Length >= 8;
    }
}