using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OuterInner
{
    class Program
    {
        static void Main(string[] args)
        {
            Task outer = new Task(() =>
            {
                Console.WriteLine("Tarea externa.");
                var inner=Task.Factory.StartNew(() => Console.WriteLine("Tarea interna."));
                inner.Wait();
            });
            outer.Start();
            outer.Wait();

            Console.WriteLine("Presione enter para salir");
            Console.ReadLine();
        }
    }
}
