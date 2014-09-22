using System;

namespace Alarm
{
    public class AlarmClockSetHourState : IAlarmClock
    {
        private TimeSpan _alarm;

        public AlarmClockSetHourState(TimeSpan alarm)
        {
            _alarm = alarm;
        }

        public TimeSpan ReadDisplay()
        {
            return _alarm;
        }

        public void Mode()
        {
        }

        public void Increase()
        {
            _alarm = _alarm.Add(new TimeSpan(1, 0, 0));
        }

        public void Decrease()
        {
            _alarm = _alarm.Add(new TimeSpan(-1, 0, 0));
        }
    }
}