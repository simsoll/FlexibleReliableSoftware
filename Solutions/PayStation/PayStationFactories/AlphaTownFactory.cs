namespace PayStation
{
    public class AlphaTownFactory : IPayStationFactory
    {
        public IRateStrategy CreateRateStrategy()
        {
            return new LinearRateStrategy();
        }

        public IReceipt CreateReceipt(int parkingTimeInMinutes)
        {
            return new StandardReceipt(parkingTimeInMinutes);
        }

        public ICoinValidationStrategy CreateCoinValidationStrategy()
        {
            return new USCoinValidationStrategy();
        }
    }
}