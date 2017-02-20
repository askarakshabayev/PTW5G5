using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Example2
{
    class Worker
    {
        bool isActive = true;
        public void work()
        {
            int i = 0;
            while (isActive) {
                Console.WriteLine(i++);
            }
        }
        public void stop()
        {
            isActive = false;
        }
    }

    class Program
    {
        public static void func()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("thread #2 " + i);
                Thread.Sleep(0);
            }
        }

        public static void F1()
        {
            Thread thread = new Thread(func);
            thread.Start();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Main thread " + i);
                Thread.Sleep(0);
            }
            Console.ReadKey();

        }

        public static void F2()
        {
            Worker w = new Worker();
            Thread t = new Thread(w.work);
            t.Start();
            Thread.Sleep(1000);
            w.stop();
            Console.ReadKey();
        }

        public class MyThread
        {
            public void func()
            {
                for (int i = 0; i < 100; i++)
                    Console.WriteLine(Thread.CurrentThread.Name + " " + i);
            }
            public MyThread(string threadName)
            {
                Thread thread = new Thread(this.func);
                thread.Name = threadName;
                thread.Start();
            }
        }

        static void Main(string[] args)
        {
            //MyThread[] threads = new MyThread[5];
            MyThread thread1 = new MyThread("Thread 1");
            MyThread thread2 = new MyThread("Thread 2");
            MyThread thread3 = new MyThread("Thread 3");
            MyThread thread4 = new MyThread("Thread 4");
            MyThread thread5 = new MyThread("Thread 5");
            MyThread thread6 = new MyThread("Thread 6");
            Console.ReadKey();


        }


    }
}
