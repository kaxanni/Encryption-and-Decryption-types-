using System;
using System.Collections.Generic;
using System.Text;

namespace Ganoy_EncryptAndDecrypt
{
    public class Block
    {
        public static string Encipher(string input, string key, char padChar)
        {
            input = (input.Length % key.Length == 0) ? input : input.PadRight(input.Length - (input.Length % key.Length) + key.Length, padChar);
            StringBuilder output = new StringBuilder();
            char[,] temp = new char[key.Length, input.Length];
            char[] msg = input.ToCharArray();        
            int x = 0;
            int y = 0;
            for (int i = 0; i < msg.Length; i++)
            {
                temp[x, y] = msg[i];          
                if (x == (key.Length - 1))
                {                 
                    x = 0;
                    y = y + 1;
                }
                else x++;
            }
            char[] t = new char[key.Length];
            t = key.ToCharArray();
            Array.Sort(t);
            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    int pos = 0;
                    for (pos = 0; pos < t.Length; pos++)
                    {
                        if (key[pos] == t[i])
                        {
                            output.Append(temp[pos,j]);                       
                        }
                    }
                }
            }        
            return output.ToString();
        }
        public static string Decipher(string input, string key)
        {
            StringBuilder output = new StringBuilder();
            StringBuilder output2 = new StringBuilder();
            char[,] temp = new char[key.Length, input.Length];
            char[] msg = input.ToCharArray();
            int x = 0;
            int y = 0;
            for (int i = 0; i < msg.Length; i++)
            {
                temp[x, y] = msg[i];
                if (x == (key.Length - 1))
                {
                    x = 0;
                    y = y + 1;
                }
                else x++;
            }
            char[] t = new char[key.Length];
            t = key.ToCharArray();
            Array.Sort(t);
            for (int j = 0; j < y; j++)
            {

                for (int i = 0; i < key.Length; i++)
                {
                    int pos = 0;
                    for (pos = 0; pos < key.Length; pos++)
                    {
                        if (key[i] == t[pos])
                        {
                            output.Append(temp[pos, j]);
                        }
                    }
                }
            }
            return output.ToString();
        }
    }
}
