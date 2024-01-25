using System;
using System.Security.Cryptography;
using System.Text;

namespace Junio2019
{
    public static class Utils
    {
        //For random char generation
        private static char[] chars =
            "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();

        private static Random r = new Random();

        /**
         * Obtains a random number between 0 and max.
         */
        public static int GetRandomNumber(int max)
        {
            return r.Next(max);
        }

        /**
         * Obtains a random character.
         */
        private static char GetRandomChar()
        {
            return chars[r.Next(chars.Length)];
        }

        /**
         * Obtains a string composed by random characters of arbitrary length between 0 and size.
         */
        public static string GetRandomString(int size)
        {
            StringBuilder sb = new StringBuilder();
            int max = GetRandomNumber(size);
            for (int i = 0; i < max; i++)
            {
                sb.Append(GetRandomChar());
            }

            return sb.ToString();
        }

        /**
         * Obtains a string composed by random characters of arbitrary length between min and size.
         */
        public static string GetRandomString(int min, int size)
        {
            StringBuilder sb = new StringBuilder();
            int max = min + GetRandomNumber(size - min);
            for (int i = 0; i < max; i++)
            {
                sb.Append(GetRandomChar());
            }

            return sb.ToString();
        }

        /**
         * Gets a string composed by random characters of arbitrary length between 0 and 100.
         */
        public static string GetRandomString()
        {
            return GetRandomString(100);
        }

        /**
         * Computes the SHA1 hash of the passed input string.
         */
        public static string CreateSha1(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        /**
         * Computes the MD5 hash of the passed input string.
         */
        public static string CreateMd5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}