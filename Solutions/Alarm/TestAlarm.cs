using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Alarm
{
    [TestFixture]
    public class TestAlarm
    {
        private AlarmClock _alarmClock;

        [SetUp]
        public void SetUp()
        {
            _alarmClock = new AlarmClock(new TimeSpan(11, 32, 0), new TimeSpan(6, 15, 0));
        }

        [Test]
        public void ShouldHandleAllAlarmSituations()
        {
            Assert.That(_alarmClock.ReadDisplay(), Is.EqualTo(new TimeSpan(11, 32, 0)));
            _alarmClock.Increase();
            Assert.That(_alarmClock.ReadDisplay(), Is.EqualTo(new TimeSpan(11, 32, 0)));
            _alarmClock.Decrease();
            Assert.That(_alarmClock.ReadDisplay(), Is.EqualTo(new TimeSpan(11, 32, 0)));

            _alarmClock.Mode();
            Assert.That(_alarmClock.ReadDisplay(), Is.EqualTo(new TimeSpan(6, 15, 0)));
            _alarmClock.Increase();
            _alarmClock.Increase();
            _alarmClock.Increase();
            Assert.That(_alarmClock.ReadDisplay(), Is.EqualTo(new TimeSpan(9, 15, 0)));

            _alarmClock.Mode();
            Assert.That(_alarmClock.ReadDisplay(), Is.EqualTo(new TimeSpan(9, 15, 0)));
            _alarmClock.Decrease();
            _alarmClock.Decrease();
            _alarmClock.Decrease();
            _alarmClock.Decrease();
            _alarmClock.Decrease();
            Assert.That(_alarmClock.ReadDisplay(), Is.EqualTo(new TimeSpan(9, 10, 0)));

            _alarmClock.Mode();
            Assert.That(_alarmClock.ReadDisplay(), Is.EqualTo(new TimeSpan(11, 32, 0)));

            _alarmClock.Mode();
            Assert.That(_alarmClock.ReadDisplay(), Is.EqualTo(new TimeSpan(9, 10, 0)));
        }
    }
}
