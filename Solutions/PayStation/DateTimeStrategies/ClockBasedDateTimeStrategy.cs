using System;

namespace PayStation
{
    public class ClockBasedDateTimeStrategy : IDateTimeStrategy
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}