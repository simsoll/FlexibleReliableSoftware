using System.Security.Cryptography.X509Certificates;

namespace PayStation
{
    public interface IPayStationFactory
    {
        IRateStrategy CreateRateStrategy();
        IReceipt CreateReceipt(int parkingTimeInMinutes);
        ICoinValidationStrategy CreateCoinValidationStrategy();
    }
}