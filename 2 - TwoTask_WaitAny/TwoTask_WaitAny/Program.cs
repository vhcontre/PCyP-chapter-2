using System;
using System.Threading;
using System.Threading.Tasks;

namespace TwoTask_WaitAny
{
    internal class Program
    {
        private static void MethodA()
        {
            Thread.SpinWait(int.MaxValue / 1);
            Console.WriteLine("Método A");
        }

        private static void MethodB()
        {
            Thread.SpinWait(int.MaxValue);
            Console.WriteLine("Método B");
        }

        private static void Main()
        {
            var taskA = Task.Factory.StartNew(MethodA);
            var taskB = Task.Factory.StartNew(MethodB);

            Console.WriteLine($"TaskA id = {taskA.Id}");
            Console.WriteLine($"TaskB id = {taskB.Id}");

            var tasks = new[] { taskA, taskB };
            var whichTask = Task.WaitAny(tasks);
            Console.WriteLine($"La tarea {tasks[whichTask].Id} es la tarea de oro.");


            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();

        }
    }
}
