using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace tfidfv7.articles.parser
{
    public class Generics
    {
        public static char RemoveAcute(char c)
        {
            // Map characters to their non-acute equivalents.
            switch (c)
            {
                case 'á':
                case 'à':
                case 'ä':
                    return 'a';
                case 'é':
                case 'è':
                case 'ë':
                    return 'e';
                case 'í':
                case 'ì':
                case 'ï':
                    return 'i';
                case 'ó':
                case 'ò':
                case 'ö':
                    return 'o';
                case 'ú':
                case 'ù':
                case 'ü':
                    return 'u';

                case 'Á':
                case 'À':
                case 'Ä':
                    return 'A';
                case 'É':
                case 'È':
                case 'Ë':
                    return 'E';
                case 'Í':
                case 'Ì':
                case 'Ï':
                    return 'I';
                case 'Ó':
                case 'Ò':
                case 'Ö':
                    return 'O';
                case 'Ú':
                case 'Ù':
                case 'Ü':
                    return 'U';
            }

            return c;
        }

        public static List<string> ExtractTokens(string token)
        {
            List<string> res = new List<string>();

            // Use a regular expression to extract tokens.
            var pattern = new Regex(@"(\w+)|([A-Z]{2})", RegexOptions.IgnorePatternWhitespace);
            token = token.Replace("&nbsp;", "") // Yes, it exists.
                         .ToLower(); // Convert to lowercase for consistent matching.

            foreach (Match item in pattern.Matches(token))
            {
                if (!string.IsNullOrWhiteSpace(item.Groups[1].Value))
                    res.Add(item.Groups[1].Value);
            }

            return res;
        }
    }
}
