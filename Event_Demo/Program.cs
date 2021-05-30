using Event_Demo.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Event_Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            #region First Example
            /*
            var num = Task.Run(() => Process());
            Console.WriteLine(num.Result);
            */
            #endregion

            #region MyRegion
            
            int num = 0;
            //Runs method
            Task.Run(() =>
            {
                
                num = Process();
                //Makes the task sleep
                Task.Delay(1000);
              //  Console.WriteLine(Process());
            })
            // Waits for the task to complete
            .Wait();

            //Console.WriteLine(num);

            #endregion

            Console.WriteLine("Thread Id: " + Thread.CurrentThread.ManagedThreadId);

            //Runs Task async
            var x = Task.Run(async () =>
            {
                Console.WriteLine("Thread Id: " + Thread.CurrentThread.ManagedThreadId);
                //Gets the task result 
                var x = await Task.FromResult<int>(ProcessAsync().Result);
                Console.WriteLine(x);
            });

            
            

            Console.WriteLine("Thread Id: " + Thread.CurrentThread.ManagedThreadId);

            Heart heart = new Heart();

            

            Console.Read();
        }

        /// <summary>
        /// Generates random number
        /// </summary>
        /// <returns></returns>
        static int Process()
        {
            Random ran = new Random();
            return ran.Next(5);
        }

        /// <summary>
        /// Simulates async Task
        /// </summary>
        /// <returns></returns>
        static async Task<int> ProcessAsync()
        {
            await Task.Delay(50000);
            Random ran = new Random();
            return ran.Next(10);
        }

    }
}
