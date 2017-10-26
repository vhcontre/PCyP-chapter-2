using System;
using System.Threading.Tasks;

namespace DivideByZero
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Task taskA = null;
            try
            {
                taskA = Task.Factory.StartNew(() =>
                {
                    const int a = 5;
                    var b = 0;
                    var div = a / b;
                });
                taskA.Wait();
            }
            catch (AggregateException ae)
            {
                if (taskA != null)
                    Console.WriteLine("La Tarea tiene " + taskA.Status);
                Console.WriteLine(ae.InnerException.Message);
            }
            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();
        }
    }
}
