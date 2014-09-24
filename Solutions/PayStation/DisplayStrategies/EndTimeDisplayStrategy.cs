using System;

namespace PayStation
{
    public class EndTimeDisplayStrategy : IDisplayStrategy
    {
        public int CalculateOutput(int minutes)
        {
            var newTime = DateTime.Now.AddMinutes(minutes);

            return newTime.Hour*100 + newTime.Minute;
        }
    }
}