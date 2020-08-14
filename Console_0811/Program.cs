using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Console_0811
{
    class Program
    {

        static string sharedValue = "---------";
        static void Main(string[] args)
        {

            Thread.CurrentThread.Name = "Main";
            show();
            Console.WriteLine("Main started");

            ThreadStart ts = new ThreadStart(ThreadEntry);
            Thread w1 = new Thread(ts);
            w1.IsBackground = true;
            w1.Name = "Thread 1";
            w1.Start();


            w1.Abort();
            Console.WriteLine($"{w1.Name}\t{w1.ThreadState}");


            //w1.Join();
            //Thread.Sleep(500);
            sharedValue = "...seted...";
            //w1.Join();
            Console.WriteLine($"{w1.Name}\t{w1.ThreadState}");


            //Thread.Sleep(3000);
            //w1.Resume();






            //ThreadStart ts2 = new ThreadStart(ThreadEntry2);
            //Thread w2 = new Thread(ts2);
            //w2.IsBackground = true;
            //w2.Name = "Thread 2";
            //w2.Start();



            Console.WriteLine("Main Ended");

            Console.ReadKey();

        }

        private static void ThreadEntry()
        {

            try
            {
                show();
                Thread.Sleep(200);
                Console.WriteLine($"Name : {Thread.CurrentThread.Name}\tStart");
                //Thread.CurrentThread.Suspend();


                Console.WriteLine("{0}:sharedValue: {1}", Thread.CurrentThread.Name, sharedValue.ToString());
                Console.WriteLine($"Name : {Thread.CurrentThread.Name}\tEnd");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"exception message: {ex.Message}");
            }

        }

        private static void ThreadEntry2()
        {
            show();
        }

        private static void show()
        {
            Console.WriteLine($"ID: {Thread.CurrentThread.ManagedThreadId}\t " +
                $"Name:{Thread.CurrentThread.Name}\t" +
                $"State:{Thread.CurrentThread.ThreadState}\t" +
                $"IsBackground:{Thread.CurrentThread.IsBackground}\t" +
                $"IsThreadPoolThread:{Thread.CurrentThread.IsThreadPoolThread}\t" +
                $"State:{Thread.CurrentThread.ThreadState}\t");
        }
    }
}
