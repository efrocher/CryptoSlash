using System.Text.RegularExpressions;

namespace CryptoSlash
{
    internal static partial class Extensions
    {
        /// <summary>
        /// A/a = 0, B/b = 1, C/c = 2, ..., Z/z = 25 <br/>
        /// Other -> throw
        /// </summary>
        public static int ToAlphabetValue(this char c)
        {
            int utf16Code = c;
            return utf16Code switch
            {
                (> 0x40 and < 0x5b) => utf16Code - 0x41, // A - Z
                (> 0x60 and < 0x7b) => utf16Code - 0x61, // a - z
                _ => throw new ArgumentOutOfRangeException(c.ToString()),
            };
        }

        /// <summary>
        /// 0 = A, 1 = B, 2 = C, ..., 25 = Z <br/>
        /// Other -> throw
        /// </summary>
        public static char ToChar(this int i)
        {
            if(i < 0 || i > 25)
                throw new ArgumentOutOfRangeException(i.ToString());

            return (char)(i + 0x41);
        }

        [GeneratedRegex("[^A-Z]+")]
        private static partial Regex KeepOnlyLettersRegex();
        /// <summary>
        /// "You're so good at this, George." -> "YOURESOGOODATTHISGEORGE"
        /// </summary>
        public static string ToUpperLettersOnly(this string str)
        {
            return KeepOnlyLettersRegex().Replace(str.ToUpper(), "");
        }


        /// <summary>
        /// "ACAB" -> [0, 2, 0, 1]
        /// </summary>
        public static int[] ToKeyVals(this string str)
        {
            return str.Select(c => c - 0x41).ToArray();
        }
    }
}
