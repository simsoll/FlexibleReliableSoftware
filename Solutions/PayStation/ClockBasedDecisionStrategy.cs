using System;

namespace PayStation
{
    public class ClockBasedDecisionStrategy : IWeekendDecisionStrategy
    {
        public bool IsWeekend()
        {
            var dayOfWeek = DateTime.Now.DayOfWeek;

            return dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday;
        }
    }
}