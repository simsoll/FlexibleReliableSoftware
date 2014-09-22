using System;

namespace Alarm
{
    public class AlarmClockSetMinuteState : IAlarmClock
    {
        private TimeSpan _alarm;

        public AlarmClockSetMinuteState(TimeSpan alarm)
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
            _alarm = _alarm.Add(new TimeSpan(0, 1, 0));
        }

        public void Decrease()
        {
            _alarm = _alarm.Add(new TimeSpan(0, -1, 0));
        }
    }
}