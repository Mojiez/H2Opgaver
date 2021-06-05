using System;

namespace Cypher
{
    class Program
    {
        public static char[] Chars { get; set; } = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'æ', 'ø', 'å' };

        public static string Cypher(string text)
        {

            char[] textMessage = text.ToLower().ToCharArray();
            // Iterates through the number of characters
            for (int i = 0; i < textMessage.Length; i++)
            {
                // Search through the Chars array finds the character from textMessage and returns the index where the character is found  
                int index = Array.IndexOf(Chars, textMessage[i]);

                // replace the char in textMessage with a char from chars
                textMessage[i] = Chars[index + 1];

            }
            text = new string(textMessage);
            return text;
        }

        public static string CypherBack(string text)
        {
            char[] textMessage = text.ToLower().ToCharArray();


            for (int i = 0; i < textMessage.Length; i++)
            {
                int index = Array.IndexOf(Chars, textMessage[i]);
                
                textMessage[i] = Chars[index - 1];
            }
            text = new string(textMessage);
            return text;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Cypher("Hello"));
            Console.WriteLine(CypherBack(Cypher("Hello")));
            Console.Read();
        }
    }
}
