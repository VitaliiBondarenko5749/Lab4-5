using CalculationInterfaces;

namespace CalculationServer
{
    public class CalculationService : ICalculationService
    {
        #region Public logic

        public int Add(int firstNumber, int secondNumber) => firstNumber + secondNumber;

        public int Subtract(int firstNumber, int secondNumber) => firstNumber - secondNumber;

        public int Multiply(int firstNumber, int secondNumber) => firstNumber * secondNumber;

        public double Divide(int dividend, int divisor)
        {
            if (divisor == 0)
                return double.NaN;

            return (double)dividend / divisor;
        }

        public int GetRemainder(int dividend, int divisor)
        {
            if(divisor == 0)
                return 0;

            return dividend % divisor;
        }

        #endregion
    }
}