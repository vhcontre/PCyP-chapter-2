using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegerTask
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            var taskA = Task<int>.Factory.StartNew(
                val => ((string)val).Length, 
                "Parallel Programming in Visual Studio."
                );


            taskA.Wait();
            Console.WriteLine(taskA.Result);

            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();

        }
    }
}
