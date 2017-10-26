using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwoTasks
{
    class Program
    {
        static void MethodA()
        {
            Console.WriteLine("Método A");
            Thread.Sleep(1000);
            
        }
        static void MethodB()
        {
            Console.WriteLine("Método B");
            Thread.Sleep(3000);
            
        }
        /// <summary>
        /// Otra forma de ejecución de una tarea consiste en utilizar el método TaskFactory.StartNew. La clase TaskFactory es una abstracción de  
        /// un programador de tareas. En la clase Task, la propiedad de la fábrica devuelve la implementación por defecto de la fábrica de tareas, 
        /// que emplea el pool de Threads NET Framework 4. TaskFactory tiene un método StartNew para ejecutar las tareas utilizando la fábrica de 
        /// tareas por defecto. Aquí es código de ejemplo que ejecuta dos tareas utilizando TaskFactory.StartNew.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var TaskA = Task.Factory.StartNew(MethodA);
            var TaskB = Task.Factory.StartNew(MethodB);
            Task.WaitAll(TaskA, TaskB);
            Console.WriteLine("Presione enter para salir");
            Console.WriteLine("TaskA id = {0}", TaskA.Id);
            Console.WriteLine("TaskB id = {0}", TaskB.Id);
            Console.ReadLine();
        }
    }
}
