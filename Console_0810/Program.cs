using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Console_0810
{

    public delegate void ThreadStart();
    public delegate void ParameterizedThreadStart(object obj);
    class Program
    {

        private static object s_logLock = new object();

        static void Main(string[] args)
        {

            //Console.WriteLine("Hello ...");
            //Console.ReadLine();

            //Test1();
            //Test2();
            //Test3();
            //Test4();
            //Test5();

            //Console.WriteLine(Greeting("Neson"));
            //Console.WriteLine("...end...");


            //CallerWithAsync();


            Console.WriteLine($"ID: {Thread.CurrentThread.ManagedThreadId}");
            System.Threading.ThreadStart ts = new System.Threading.ThreadStart(ThreadEntry);
            System.Threading.ParameterizedThreadStart ts2 = new System.Threading.ParameterizedThreadStart(ThreadEntry2);

            Thread worker = new Thread(ts);
            worker.Start();

            //Thread worker2 = new Thread(ts2);
            //worker2.Start();

            Console.WriteLine("Main Thread ends");
            Console.WriteLine($"Main Thread State {Thread.CurrentThread.ThreadState}");
            Console.WriteLine($"Main Thread Name:  {Thread.CurrentThread.Name}");

            int c = 0;
            while (true)
            {
                Thread.Sleep(1000);
                c++;
                Console.WriteLine($"count: {c.ToString()}");

            }


            //Console.ReadKey();

        }

        private static void ThreadEntry2(object obj)
        {
            SharedResource resource = new SharedResource();
            Console.WriteLine($"ThreadEntry2 ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"ThreadEntry2 Task ID: {Task.CurrentId}");
            Thread.Sleep(3000);
            Console.WriteLine($"ThreadEntry2 Thread State {Thread.CurrentThread.ThreadState}");
            Console.WriteLine($"ThreadEntry2 Thread Name:  {Thread.CurrentThread.Name}");
        }

        public static void ThreadEntry()
        {
            SharedResource resource = new SharedResource();
            Console.WriteLine($"ThreadEntry ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"ThreadEntry Task ID: {Task.CurrentId}");


            Console.WriteLine($"ThreadEntry Thread State {Thread.CurrentThread.ThreadState}");
            Console.WriteLine($"ThreadEntry Thread Name:  {Thread.CurrentThread.Name}");


            try
            {
                int c = 0;
                while (true)
                {
                    Thread.Sleep(1000);
                    c++;
                    Console.WriteLine($"thread count : {c.ToString()}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void Test1()
        {
            var tf = new TaskFactory();
            Task t1 = tf.StartNew(TaskMethod, "using a task factory");

            Task t2 = Task.Factory.StartNew(TaskMethod, "factory via a task");

            var t3 = new Task(TaskMethod, "using a task constructor and start");
            t3.Start();

            Task t4 = Task.Run(() => TaskMethod("using the Run method"));
        }

        public static void Test2()
        {
            TaskMethod("just the main thread");
            var t1 = new Task(TaskMethod, "run sync");
            t1.RunSynchronously();
        }

        public static void Test3()
        {
            var t1 = new Task(TaskMethod, "long running", TaskCreationOptions.LongRunning);
            t1.Start();
        }

        public static void Test4()
        {
            Task t1 = new Task(DoOnFirst);
            Task t2 = t1.ContinueWith(DoOnSecond);
            Task t3 = t2.ContinueWith(DoOnSecond);
            Task t4 = t3.ContinueWith(DoOnSecond);
            t1.Start();
        }

        public static void Test5()
        {
            var parent = new Task(ParentTask);
            Console.WriteLine(parent.Status);
            Task.Delay(3000).Wait();
            parent.Start();
            Console.WriteLine(parent.Status);
            Task.Delay(3000).Wait();
            Console.WriteLine(parent.Status);
            Console.WriteLine();


        }

        public static void ParentTask()
        {
            Console.WriteLine($"task id {Task.CurrentId}");
            var child = new Task(ChildTask);
            child.Start();
            Task.Delay(3000).Wait();
            Console.WriteLine("parent started child");
            Console.WriteLine();

        }
        public static void ChildTask()
        {
            Console.WriteLine("child");
            Task.Delay(3000).Wait();
            Console.WriteLine("Child finished");
            Console.WriteLine();
        }


        public static void TaskMethod(object o)
        {
            Log(o?.ToString());
        }

        public static (int Result, int Remainder) TaskWithResult(object division)
        {
            int result = 0, remainder = 0;

            return (result, remainder);

        }

        public static void DoOnFirst()
        {
            Console.WriteLine($"doing some task {Task.CurrentId}");
            Console.WriteLine();
            Task.Delay(2000).Wait();
        }

        public static void DoOnSecond(Task t)
        {
            Console.WriteLine($"task {t.Id} finished");
            Console.WriteLine($"this task id {Task.CurrentId}");
            Console.WriteLine("do some cleanup");
            Console.WriteLine();

            Task.Delay(2000).Wait();
        }

        public static void TraceThreadAndTask(string info)
        {
            string taskInfo = Task.CurrentId == null ? "no task" : "task: " + Task.CurrentId;
            Console.WriteLine($"{info} in thread {Thread.CurrentThread.ManagedThreadId}" + $"and {taskInfo}");
            Console.WriteLine();
        }

        public static string Greeting(string name)
        {
            TraceThreadAndTask($"running {nameof(Greeting)}");
            Task.Delay(3000).Wait();
            return $"Hello, {name}";
        }

        private async static void CallerWithAsync()
        {

            TraceThreadAndTask($"started {nameof(CallerWithAsync)}");
            string result = await GreetingAsync("...xinchin...");
            Console.WriteLine(result);
            TraceThreadAndTask($"ended {nameof(CallerWithAsync)}");
        }

        public static Task<string> GreetingAsync(string name) =>
            Task.Run<string>(() =>
            {
                TraceThreadAndTask($"running {nameof(GreetingAsync)}");
                return Greeting(name);
            });


        public static void Log(string title)
        {
            lock (s_logLock)
            {
                Console.WriteLine(title);
                Console.WriteLine($"Task id: {Task.CurrentId?.ToString() ?? "no task"}");
                Console.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId }");
                Console.WriteLine("is pooled thread: " + $"{Thread.CurrentThread.IsThreadPoolThread}");
                Console.WriteLine("is background thread: " + $"{Thread.CurrentThread.IsBackground}");
                Console.WriteLine();
            }
        }

        private class SharedResource
        {
        }
    }
}
