using System;

namespace PayStation
{
    public class FixedBasedDateTimeStrategy : IDateTimeStrategy
    {
        private readonly DateTime _dateTime;

        public FixedBasedDateTimeStrategy(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public DateTime GetDateTime()
        {
            return _dateTime;
        }
    }
}