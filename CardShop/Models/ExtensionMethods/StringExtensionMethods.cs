using System.Text;

namespace CardShop.Models
{

    public static class StringExtensions
    {
        public static string Slug(this string str)
        {
            var sb = new StringBuilder();
            foreach (char c in str)
            {
                if (!char.IsPunctuation(c) || c == '-') { 
                    sb.Append(c);
                }
            }
            return sb.ToString().Replace(' ', '-').ToLower();
        }

        public static bool EqualsNoCase(this string str, string toCompare) =>
            str?.ToLower() == toCompare?.ToLower();
        public static bool ContainsNoCase(this string str, string toCompare) =>
            str.ToLower().Contains(toCompare.ToLower());

        public static int ToInt(this string str)
        {
            int.TryParse(str, out int value);
            return value;
        }

        public static string Capitalize(this string str) =>
            str?.Substring(0, 1)?.ToUpper() + str?.Substring(1)?.ToLower();
    }
}