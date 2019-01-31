using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main()
        {
            Task.WaitAll(
                Task.Run(() => printHeader(100, 5)),
                Task.Run(() => threadWorker("B", 1500)),
                Task.Run(() => threadWorker("A", 1500)),
                Task.Run(() => threadWorker("C", 1500)),
                Task.Run(() => threadWorker("D", 1500))
                );
            Console.WriteLine("\n\nIt is finished.");
            Console.ReadLine();
        }

        static void threadWorker(string threadName, int countStop)
        {
            for (int i = 0; i < countStop; i++)
            {
                Console.Write($",{threadName}:{i}of{countStop}");
            }
            Console.WriteLine($"Thread {threadName} is DONE!");
        }

        static void printHeader(int durationInMilliseconds, int numCycles)
        {
            Console.WriteLine("\nCYCLE-0");

            for (int i = 1; i < numCycles; i++)
            {
                Thread.Sleep(durationInMilliseconds);
                Console.WriteLine($"\nCYCLE-{i}");
            }

            Console.WriteLine($"\nCYCLE-{numCycles}");
        }
    }
}
