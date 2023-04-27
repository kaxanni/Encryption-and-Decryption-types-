using System;
using System.Collections.Generic;
using System.Text;

namespace Ganoy_EncryptAndDecrypt
{
    public class Ceasar
    {
        public static char cipher(char ch, int key)
        {

            if (!char.IsLetter(ch))
            {
                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }
        public static char dicipher(char ch, int key)
        {

            if (!char.IsLetter(ch))
            {
                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch - key) - d) % 26) + d);
        }
        public static string Encipher(string input, int key = 3)
        {
            string output = string.Empty;
            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }
        public static string Decipher(string input, int key = 3)
        {

            string output = string.Empty;
            foreach (char ch in input)
                output += dicipher(ch, key);

            return output;
        }
    }
}
