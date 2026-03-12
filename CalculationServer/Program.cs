using System;
using System.ServiceModel;

namespace CalculationServer
{
    internal class Program
    {
        #region Private logic

        private static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(CalculationService)))
            {
                host.Open();

                Console.WriteLine("CalculationService is running...");
                Console.WriteLine("Press Enter to stop service.");
                
                Console.ReadLine();

                host.Close();
            }
        }

        #endregion
    }
}