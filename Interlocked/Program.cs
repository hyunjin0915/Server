using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        static int number = 0;

        static void Thread_1()
        {
            for (int i = 0; i < 100000; i++)
            {
                Interlocked.Increment(ref number);
                //number++;
                //Increment 된 값이 궁금하면 int afterValue = Interlocked.Increment(ref number) 이런 식으로 사용해야 함
                //int afterValue = number; 이런식으로 사용하면 안됨.
            }
        }
        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                Interlocked.Decrement(ref number);
                //number--;
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);
            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(number);
        }
    }
}
