using System;
using System.ServiceModel;
using CalculationInterfaces;

namespace CalculationClient
{
    internal class Program
    {
        #region Costants

        private const string EndpointName = "CalculationServiceEndpoint";

        #endregion

        #region Private logic

        private static void Main(string[] args)
        {
            var channel = new ChannelFactory<ICalculationService>(EndpointName);

            var proxy = channel.CreateChannel();

            int a = 15, b = 4;

            Console.WriteLine($"Add: {a} + {b} = {proxy.Add(a, b)}");

            Console.WriteLine($"Subtract: {a} - {b} = {proxy.Subtract(a, b)}");
            Console.WriteLine($"Multiply: {a} * {b} = {proxy.Multiply(a, b)}");

            Console.WriteLine($"Divide: {a} / {b} = {proxy.Divide(a, b)}");

            Console.WriteLine($"Remainder: {a} % {b} = {proxy.GetRemainder(a, b)}");

            Console.ReadLine();
        }

        #endregion
    }
}