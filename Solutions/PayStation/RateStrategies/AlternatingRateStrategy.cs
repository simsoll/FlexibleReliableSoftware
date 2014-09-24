using System;

namespace PayStation
{
    public class AlternatingRateStrategy : IRateStrategy
    {
        private readonly IRateStrategy _weekDayStrategy;
        private readonly IRateStrategy _weekendStrategy;

        private readonly IDateTimeStrategy _dateTimeStrategy;

        public AlternatingRateStrategy(IRateStrategy weekDayStrategy, IRateStrategy weekendStrategy,
            IDateTimeStrategy dateTimeStrategy)
        {
            _weekDayStrategy = weekDayStrategy;
            _weekendStrategy = weekendStrategy;

            _dateTimeStrategy = dateTimeStrategy;
        }

        public int CalculateRate(int coinValue)
        {
            if (IsWeekend())
            {
                return _weekendStrategy.CalculateRate(coinValue);
            }

            return _weekDayStrategy.CalculateRate(coinValue);
        }

        public bool IsWeekend()
        {
            var dayOfWeek = _dateTimeStrategy.GetDateTime().DayOfWeek;

            return dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday;
        }
    }
}