using System.Text.RegularExpressions;

namespace Dinglo.Domain.Extensions
{
    public static class StringExtension
    {
        public static bool IsValidEmail(this string email)
        {
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$");
        }
        
        public static string OnlyNumbers(this string str)
        {
            return Regex.Replace(str, "[^0-9,]", "");
        }
    }
}