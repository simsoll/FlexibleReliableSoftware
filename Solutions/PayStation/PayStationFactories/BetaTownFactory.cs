namespace PayStation
{
    public class BetaTownFactory : IPayStationFactory
    {
        public IRateStrategy CreateRateStrategy()
        {
            return new ProgressiveRateStrategy();
        }

        public IReceipt CreateReceipt(int parkingTimeInMinutes)
        {
            return new ExpensiveReceipt(parkingTimeInMinutes, 2);
        }

        public ICoinValidationStrategy CreateCoinValidationStrategy()
        {
            return new USCoinValidationStrategy();
        }

        public IDisplayStrategy CreateDisplayStrategy()
        {
            return new MinuteDisplayStrategy();
        }
    }
}