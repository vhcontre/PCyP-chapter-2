using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyOnFaulted
{
    internal class CustomTask : Task
    {
        public CustomTask(Action action) : base(action)
        {
            
        }

        public void PerformRollback()
        {
            Console.WriteLine("Rollback...");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            CustomTask antecedent = new CustomTask(() =>
            {
                throw new Exception("Unhandled");
            });
            antecedent.ContinueWith((predTask) =>
            {
                ((CustomTask)predTask).PerformRollback();
            },
            TaskContinuationOptions.OnlyOnFaulted);
            antecedent.Start();
            try
            {
                antecedent.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
