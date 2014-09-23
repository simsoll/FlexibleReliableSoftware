using System;

namespace PayStation
{
    public class FixedBasedDecisionStrategy : IWeekendDecisionStrategy
    {
        private readonly DayOfWeek _dayOfWeek;

        public FixedBasedDecisionStrategy(DayOfWeek dayOfWeek)
        {
            _dayOfWeek = dayOfWeek;
        }

        public bool IsWeekend()
        {
            return _dayOfWeek == DayOfWeek.Saturday || _dayOfWeek == DayOfWeek.Sunday;
        }
    }
}