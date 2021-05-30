using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolOpg
{
    class ThreadPoolDemo
    {
        /// <summary>
        /// This method loops 3 times 
        /// Prints out a string on each loop
        /// </summary>
        /// <param name="obj"></param>
        public void task1(object obj)
        {
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Task 1 is being executed");
            }
        }
        /// <summary>
        /// This method loops 3 times 
        /// Prints out a string on each loop
        /// </summary>
        /// <param name="obj"></param>
        public void task2(object obj)
        {
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Task 2 is being executed");
            }

        }

        static void Main()
        {
            /* Øvelse 1 
            ThreadPoolDemo tpd = new ThreadPoolDemo();
            
            //Loops through 2 times
            for (int i = 0; i < 1000; i++)
            {
                //Queues up the method for execution
                ThreadPool.QueueUserWorkItem(tpd.task1);
                ThreadPool.QueueUserWorkItem(tpd.task2);
            }

            //Queues up the method for execution with a call back object
            //ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task1));
            //ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task2));
            Console.Read();
            */

            /* Øvelse 2
             
            //Queues up the method
            ThreadPool.QueueUserWorkItem(Process);
            Stopwatch mywatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");
            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();
            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());
            */

            
            //for (int i = 0; i < 2; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(PoolProcess);
            //}





            for (int i = 0; i < 2; i++)
            {
                Thread thread = new Thread(PoolProcess);
                thread.Start();
            }




            PoolProcess(new object());
            Console.Read();


        }

        static void PoolProcess(object callback)
        {   
            
            // if false the main Thread is done before this worker thread
            //Thread.CurrentThread.IsBackground = false;
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine(Thread.CurrentThread.IsBackground);
                Console.WriteLine(Thread.CurrentThread.IsAlive);
                Console.WriteLine(Thread.CurrentThread.Priority);
            };
            //Blocks the current thread if an int is passed as parameter
            Thread.CurrentThread.Join(1000);
            
            //Not supported anymore
            //Thread.CurrentThread.Abort();
            //Thread.CurrentThread.Resume();
            //Thread.CurrentThread.Suspend();
        }

        /// <summary>
        /// Empty method to show how ThreadPool Works
        /// Method that is being queued has to have a object parameter for this to work
        /// </summary>
        /// <param name="callback"></param>
        static void Process(object callback)
        {
            //The process will take longer to complete
            for (int i = 0; i < 100000; i++)
            {
                //Makes it even longer
                for (int j = 0; j < 100000; j++)
                {

                }
            }
        }
        static void ProcessWithThreadMethod()
        {
            //Will make 11 threads
            for (int i = 0; i <= 10; i++)
            {
                //Initailize new thread
                Thread obj = new Thread(Process);
                //Starts the thread
                obj.Start();
            }
        }
        static void ProcessWithThreadPoolMethod()
        {
            //Will make 11 Queues for Process method
            for (int i = 0; i <= 10; i++)
            {
                //Queues up the method
                ThreadPool.QueueUserWorkItem(Process);
            }
        }

    }
}
