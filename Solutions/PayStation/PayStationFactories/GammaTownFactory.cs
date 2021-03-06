namespace PayStation
{
    public class GammaTownFactory : IPayStationFactory
    {
        public IRateStrategy CreateRateStrategy()
        {
            return new AlternatingRateStrategy(new LinearRateStrategy(), new ProgressiveRateStrategy(),
                new ClockBasedDateTimeStrategy());
        }

        public IReceipt CreateReceipt(int parkingTimeInMinutes)
        {
            return new StandardReceipt(parkingTimeInMinutes);
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