using System;
using System.Threading.Tasks;
namespace MultipleExceptions
{
    internal class Program
    {
        private static void MethodA()
        {
            throw new NullReferenceException("TaskA Exception::NullReferenceException");
        }
        private static void MethodB()
        {
            throw new ArgumentNullException($"TaskB Exception::ArgumentNullException");
        }
        private static void MethodC()
        {
            throw new Exception("TaskC Exception");
        }
        private static void Main(string[] args)
        {
            try
            {
                var taskA = Task.Factory.StartNew(MethodA);
                var taskB = Task.Factory.StartNew(MethodB);
                var taskC = Task.Factory.StartNew(MethodC);

                Task.WaitAll(new Task[] { taskA, taskB, taskC }); // Se observó una Excepción no controlada
            }

            catch (AggregateException ae)
            {
                foreach (var ex in ae.InnerExceptions)
                {
                    // ... Controlar las excepciones
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();
        }
    }
}
