using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContinuationResult
{
    internal class Program
    {
        private static void Main() {
            var calculate = new Task<int>(() =>
            {
                Console.WriteLine("Calcular resultado.");
                Thread.Sleep(1000);
                return 42;
            });

            var answer = calculate.ContinueWith(o =>
            {
                Console.WriteLine($"La respuesta es {o.Result}.");
            });

            calculate.Start();
            Task.WaitAll(calculate, answer);

            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();
        }
    }
}
