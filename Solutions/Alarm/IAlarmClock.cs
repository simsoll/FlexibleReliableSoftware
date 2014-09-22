using System;

namespace Alarm
{
    public interface IAlarmClock
    {
        /** return the contents of the display depending on the
         * state of the alarm clock.
         * @return the display contents
         */
        TimeSpan ReadDisplay();

        /** press the "mode" button on the clock */
        void Mode();

        /** press the "increase" (+) button on the clock */
        void Increase();

        /** press the "decrease" (-) button on the clock */
        void Decrease();
    }
}