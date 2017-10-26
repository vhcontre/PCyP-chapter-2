using System;
using System.Threading.Tasks;

namespace HandleException
{
    internal class Program
    {
        private static void MethodA() { throw new Exception("TaskA Exception"); }
        private static void MethodB() { throw new Exception("TaskB Exception"); }
        private static void MethodC() { throw new Exception("TaskC Exception"); }

        private static void Main(string[] args)
        {
            try
            {
                Parallel.Invoke(MethodA, MethodB, MethodC);
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex =>
                {
                    Console.WriteLine(ex.Message);
                    return true;
                });
            }
            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();
        }
    }
}
