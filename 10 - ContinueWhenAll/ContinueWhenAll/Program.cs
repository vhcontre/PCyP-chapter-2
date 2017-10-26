using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContinueWhenAll
{
    internal class Program
    {
        private static int PerformCalculation() { return 42; }

        static void Main()
        {
            var taskA = new Task<int>(() =>
            {
                Console.WriteLine("Tarea A iniciada.");
                return PerformCalculation();
            });
            var taskB = new Task<int>(() =>
            {
                Console.WriteLine("Tarea B iniciada.");
                return PerformCalculation();
            });

            var total = Task.Factory.ContinueWhenAll(
                new[] { taskA, taskB },
                tasks => Console.WriteLine("Total = {0}", tasks[0].Result + tasks[1].Result));

            taskA.Start();
            taskB.Start();

            Task.WaitAll(taskA, taskB);
            total.Wait();

            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();

        }
    }
}
