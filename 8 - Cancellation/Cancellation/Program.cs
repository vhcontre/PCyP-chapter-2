using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation
{
    internal class Program
    {
        private static void DoSomething()
        {
            //Thread.SpinWait(int.MaxValue);
            Thread.SpinWait(8000);
        }

        static void Main() {
            var cancellationSource = new CancellationTokenSource();
            var token = cancellationSource.Token;
            try {
                var taskA = Task.Factory.StartNew(() =>
                  {
                      while (true) {
                          DoSomething();
                          if (token.IsCancellationRequested) {
                              token.ThrowIfCancellationRequested();
                          }
                      }
                  }, token);
                Thread.Sleep(1000);
                cancellationSource.Cancel();
                taskA.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Error:{ex.InnerException.GetType().Name} - {ex.InnerException.Message}");
            }

            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();
        }
    }
}
