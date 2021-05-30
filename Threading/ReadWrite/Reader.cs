using System;
using System.Collections.Generic;
using System.Text;

namespace Threading.ReadWrite
{
    public static class Reader
    {
        public static char InputChar { get; set; } = '*';
        public static bool Running { get; set; }

        //This method will read the console if user press enter they can change output char
        public static void ReadInput()
        {
            char temp = '*';
            while (true)
            {
                temp = Console.ReadKey().KeyChar;
                if(Console.ReadKey().Key == ConsoleKey.Enter)
                InputChar = temp;
            }
        }

    }
}
