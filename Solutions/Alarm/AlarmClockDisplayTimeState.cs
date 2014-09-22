using System;

namespace Alarm
{
    public class AlarmClockDisplayTimeState : IAlarmClock
    {
        private TimeSpan _time;

        public AlarmClockDisplayTimeState(TimeSpan time)
        {
            _time = time;
        }

        public TimeSpan ReadDisplay()
        {
            return _time;
        }

        public void Mode()
        {
        }

        public void Increase()
        {
        }

        public void Decrease()
        {
        }
    }
}