using System.ServiceModel;

namespace CalculationInterfaces
{
    [ServiceContract]
    public interface ICalculationService
    {
        [OperationContract]
        int Add(int firstNumber, int secondNumber);

        [OperationContract]
        int Subtract(int firstNumber, int secondNumber);

        [OperationContract]
        int Multiply(int firstNumber, int secondNumber);

        [OperationContract]
        double Divide(int dividend, int divisor);

        [OperationContract]
        int GetRemainder(int dividend, int divisor);
    }
}