using System;

namespace FamilyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string encryptedText = Encrypt("abcde");
            Console.WriteLine(encryptedText);

        }

        // dit gaat de hele text omzetten
        public static string Encrypt(string text)
        {
            string result = "";
            foreach(char letter in text){
                result += convertChar(letter);
            }
            return result;
        }

        //dit gaat 1 letter omzetten
        public static char convertChar(char letter)
        {
            // a -> z               0 -> 25
            // b -> y               1 -> 24
            // c -> x               2 -> 23

            //index of the letter in the alphabet
            int index = letter - (int)'a';

            //find converted letter
            char newLetter = (char)('z' - index);

            Console.WriteLine(letter + " " + index + " " + newLetter);
            return newLetter;
        }
    }
}
