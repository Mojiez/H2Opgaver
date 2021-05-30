using System;
using System.Threading;

namespace Threading.ThreadTalking
{
    public class ThreadTalk
    {
        /// <summary>
        /// This method will print out some text depending og thread name
        /// </summary>
        public void SaySomethingAboutCSharp()
        {
            switch (Thread.CurrentThread.Name)
            {
                case "Master":
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("C#-trådning er nemt!");
                    }
                    break;

                case "Slave":
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Også med flere tråde...");
                    }
                    break;

                default:
                    break;
            }

                
        }

        /// <summary>
        /// Will print out thread name 5 times
        /// </summary>
        public void WorkThreadFunction()
        {
            //loops 5 times and print thread name to console
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thread: {Thread.CurrentThread.Name}");
            }
        }
    }
}