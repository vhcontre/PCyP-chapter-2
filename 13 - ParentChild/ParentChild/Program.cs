using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParentChild
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var parent = new Task(() =>
            {
                Console.WriteLine("Parent task.");
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Hijo trabajando.");
                    Thread.Sleep(5000);

                }, TaskCreationOptions.AttachedToParent);
            });

            parent.Start();

            if ((!(parent.Wait(2000)) && (parent.Status == TaskStatus.WaitingForChildrenToComplete)))
            {
                Console.WriteLine("El padre a finalizado, pero el hijo no terminó.");
                parent.Wait();
            }

            Console.WriteLine("Pulse Enter para salir");
            Console.ReadLine();

        }
    }
}
