using System;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;

namespace Ganoy_EncryptAndDecrypt
{
    public class Program
    {
        static void Main(string[] args)
        {
            Start:
            Console.WriteLine("Pick a function: A. Encrypt B. Decrypt");
            string function = Console.ReadLine();
            Console.Write("Enter Data: ");
            string UserString = Console.ReadLine();
            Console.WriteLine("Pick a Mode:");
            Console.WriteLine("1: Ceasar, 2: Shift, 3: Block, 4: Vigenere");
            int mode = Convert.ToInt32(Console.ReadLine());
            switch(mode)
            {
                case 1:
                    {                      
                        if (function == "A" || function == "a")
                        {
                            Console.Write("Encrypted Data: ");
                            string cipherText = Ceasar.Encipher(UserString, 3);
                            Console.WriteLine(cipherText);
                        }
                        if (function == "B" || function == "b")
                        {
                            Console.Write("Decrypted Data: ");
                            string t = Ceasar.Decipher(UserString, 3);
                            Console.WriteLine(t);
                        }                      
                    }
                    break;
                case 2:
                    {
                        if (function == "A" || function == "a")
                        {
                            Console.Write("Enter your Key: ");
                            int key = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Encrypted Data: ");
                            string cipherText = Shift.Encipher(UserString, key);
                            Console.WriteLine(cipherText);
                        }
                        if(function == "B" || function == "b")
                        {
                            Console.Write("Enter your Key: ");
                            int key = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Decrypted Data: ");
                            string t = Shift.Decipher(UserString, key);
                            Console.WriteLine(t);
                        }                      
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    {
                        if (function == "A" || function == "a")
                        {
                            Console.Write("Enter key: ");
                            string key = Console.ReadLine();
                            Random rnd = new Random();
                            char randomChar = (char)rnd.Next('a', 'z');
                            string cipherText = Block.Encipher(UserString, key, randomChar);
                            Console.WriteLine("Encrypted: " + cipherText);
                        }
                        if (function == "B" || function == "b")
                        {
                            Console.Write("Enter key: ");
                            string key = Console.ReadLine();
                            string plainText = Block.Decipher(UserString, key);
                            Console.WriteLine("Decrypted: " + plainText);
                        }
                        Console.ReadKey();
                       
                    }
                    break;
                case 4:
                    {
                        if (function == "A" || function == "a")
                        {
                            Console.Write("Enter Key: ");
                            string key = Console.ReadLine();
                            string encipher = Vigenere.Encipher(UserString, key);
                            Console.WriteLine("Encrypted: " + encipher);
                        }
                        if (function == "B" || function == "b")
                        {
                            Console.Write("Enter Key: ");
                            string key = Console.ReadLine();
                            string decipher = Vigenere.Decipher(UserString, key);
                            Console.WriteLine("Decrypted: " + decipher);
                        }
                        Console.ReadKey();
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Not in the choices");
                    }
                    break;
        
            }
            
            Here:
            Console.WriteLine("Do you want to try again, yes or no");
            string choice = Console.ReadLine();
            if(choice == "yes")
            {
                goto Start;
            }
            if(choice == "no")
            {
                System.Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("Invalid answer");
                Console.ReadKey();
                goto Here;
            }

        }
    }
}
