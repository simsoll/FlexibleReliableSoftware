using System;

namespace PayStation
{
    public class TestAlphaTownFactory : IPayStationFactory
    {
        private readonly DateTime _dateTime;

        public TestAlphaTownFactory(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

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

        public IDisplayStrategy CreateDisplayStrategy()
        {
            return new EndTimeDisplayStrategy(new FixedBasedDateTimeStrategy(_dateTime));
        }
    }
}