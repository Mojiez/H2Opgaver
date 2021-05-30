using System;
using System.Text;

namespace SymetriskKryptering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Alfinans.Applications
    {
        internal class Program
        {
            private static void Main()
            {
                DataSorter sorter = new DataSorter();
                User user = sorter.GetService<User>();

                user.Name = "Hello";

                Console.WriteLine(user.Name);
            }
        }
    }
}
