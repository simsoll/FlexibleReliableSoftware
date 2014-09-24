using System;

namespace PayStation
{
    public class EndTimeDisplayStrategy : IDisplayStrategy
    {
        private readonly IDateTimeStrategy _dateTimeStrategy;

        public EndTimeDisplayStrategy(IDateTimeStrategy dateTimeStrategy)
        {
            _dateTimeStrategy = dateTimeStrategy;
        }

        public int CalculateOutput(int minutes)
        {
            var newTime = _dateTimeStrategy.GetDateTime().AddMinutes(minutes);

            return newTime.Hour*100 + newTime.Minute;
        }
    }
}