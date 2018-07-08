namespace Common.Extensions
{
    using System;
    using System.Text;

    using Common.Consts;

    public static class StringExtensions
    {
        public static string GetFriendlyTitle(this string title, bool remapToAscii = true, int maxLength = 120)
    {
        if (title == null)
        {
            return string.Empty;
        }
 
        int titleLength = title.Length;
        bool isPreviousDash = false;
        var friendlyTitle = new StringBuilder(titleLength);

        for (int letterIndex = 0; letterIndex < titleLength; ++letterIndex)
        {
            var titleLetter = title[letterIndex];

            isPreviousDash = AddLetterInRange09az(titleLetter, friendlyTitle, isPreviousDash);

            isPreviousDash = AddLetterInRangeAZ(titleLetter, friendlyTitle, isPreviousDash);

            isPreviousDash = AddDashInsteadSpecialSign(titleLetter, friendlyTitle, isPreviousDash);

            isPreviousDash = AddAsciiChar(titleLetter, friendlyTitle, isPreviousDash, remapToAscii);
 
            if (letterIndex == maxLength)
            {
                break;
            }
        }
 
        if (isPreviousDash)
        {
            return friendlyTitle.ToString().Substring(0, friendlyTitle.Length - 1);
        }

        return friendlyTitle.ToString();
    }


        private static bool AddLetterInRange09az(char titleLetter, StringBuilder friendlyTitle, bool isPreviousDash)
        {
            if ((titleLetter >= 'a' && titleLetter <= 'z') || (titleLetter >= '0' && titleLetter <= '9'))
            {
                friendlyTitle.Append(titleLetter);
                isPreviousDash = false;
            }

            return isPreviousDash;
        }

        private static bool AddLetterInRangeAZ(char titleLetter, StringBuilder friendlyTitle, bool isPreviousDash)
        {
            if (titleLetter >= 'A' && titleLetter <= 'Z')
            {
                // tricky way to convert to lower-case
                friendlyTitle.Append((char)(titleLetter | 32));
                isPreviousDash = false;
            }
            
            return isPreviousDash;
        }

        private static bool AddDashInsteadSpecialSign(char titleLetter, StringBuilder friendlyTitle, bool isPreviousDash)
        {
            if ((titleLetter == ' ') || (titleLetter == ',') || (titleLetter == '.') || (titleLetter == '/') ||
                (titleLetter == '\\') || (titleLetter == '-') || (titleLetter == '_') || (titleLetter == '='))
            {
                if (!isPreviousDash && (friendlyTitle.Length > 0))
                {
                    friendlyTitle.Append('-');
                    isPreviousDash = true;
                }
            }

            return isPreviousDash;
        }

        private static bool AddAsciiChar(char titleLetter, StringBuilder friendlyTitle, bool isPreviousDash, bool remapToAscii)
        {
            var firstInternationalLetterNumber = 128;

            if (titleLetter >= firstInternationalLetterNumber)
            {
                int previousLength = friendlyTitle.Length;
 
                if (remapToAscii)
                {
                    friendlyTitle.Append(RemapInternationalCharToAscii(titleLetter));
                }
                else
                {
                    friendlyTitle.Append(titleLetter);
                }
 
                if (previousLength != friendlyTitle.Length)
                {
                    isPreviousDash = false;
                }
            }

            return isPreviousDash;
        }

        private static string RemapInternationalCharToAscii(char character)
        {
            string titleLetter = character.ToString().ToLowerInvariant();
            if ("àåáâäãåąā".Contains(titleLetter))
            {
                return "a";
            }

            if ("èéêëę".Contains(titleLetter))
            {
                return "e";
            }

            if ("ìíîïı".Contains(titleLetter))
            {
                return "i";
            }

            if ("òóôõöøőð".Contains(titleLetter))
            {
                return "o";
            }

            if ("ùúûüŭů".Contains(titleLetter))
            {
                return "u";
            }

            if ("çćčĉ".Contains(titleLetter))
            {
                return "c";
            }

            if ("żźž".Contains(titleLetter))
            {
                return "z";
            }

            if ("śşšŝ".Contains(titleLetter))
            {
                return "s";
            }

            if ("ñń".Contains(titleLetter))
            {
                return "n";
            }

            if ("ýÿ".Contains(titleLetter))
            {
                return "y";
            }

            if ("ğĝ".Contains(titleLetter))
            {
                return "g";
            }

            if (character == 'ř')
            {
                return "r";
            }

            if (character == 'ł')
            {
                return "l";
            }

            if (character == 'đ')
            {
                return "d";
            }

            if (character == 'ß')
            {
                return "ss";
            }

            if (character == 'Þ')
            {
                return "th";
            }

            if (character == 'ĥ')
            {
                return "h";
            }

            if (character == 'ĵ')
            {
                return "j";
            }

            return string.Empty;
        }

        public static string GetPostPreview(this string lead)
        {
            if (lead == null 
                || lead.Length < Const.PostPreviewLength 
                || lead.IndexOf(" ", Const.PostPreviewLength, StringComparison.Ordinal) == -1)
            {
                return lead;
            }

            return lead.Substring(0, lead.IndexOf(" ", Const.PostPreviewLength, StringComparison.Ordinal)) + "...";
        }
    }
}
