using System;
using System.Runtime.InteropServices;

namespace Alarm
{
    public class AlarmClock : IAlarmClock
    {
        private AlarmClockState _currentState;
        private IAlarmClock _currentStateObject;
        private TimeSpan _time;
        private TimeSpan _alarm;


        public AlarmClock(TimeSpan time, TimeSpan alarm)
        {
            _time = time;
            _alarm = alarm;

            _currentState = AlarmClockState.DisplayTime;
            _currentStateObject = new AlarmClockDisplayTimeState(_time);
        }

        public TimeSpan ReadDisplay()
        {
            return _currentStateObject.ReadDisplay();
        }

        public void Mode()
        {
            if (_currentState == AlarmClockState.DisplayTime)
            {
                _time = _currentStateObject.ReadDisplay();
                _currentState = AlarmClockState.SetHourState;
                _currentStateObject = new AlarmClockSetHourState(_alarm);
            }
            else if (_currentState == AlarmClockState.SetHourState)
            {
                _alarm = _currentStateObject.ReadDisplay();
                _currentState = AlarmClockState.SetMinuteState;
                _currentStateObject = new AlarmClockSetMinuteState(_alarm);
            }
            else if (_currentState == AlarmClockState.SetMinuteState)
            {
                _alarm = _currentStateObject.ReadDisplay();
                _currentState = AlarmClockState.DisplayTime;
                _currentStateObject = new AlarmClockDisplayTimeState(_time);
            }
        }

        public void Increase()
        {
            _currentStateObject.Increase();
        }

        public void Decrease()
        {
            _currentStateObject.Decrease();
        }

        private enum AlarmClockState
        {
            DisplayTime,
            SetHourState,
            SetMinuteState
        }
    }
}