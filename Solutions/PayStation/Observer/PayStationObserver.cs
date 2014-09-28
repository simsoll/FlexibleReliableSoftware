using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace PayStation.Observer
{
    public class PayStationObserver : IObserver<IPayStation>
    {
        private readonly IList<int> _displays;

        public PayStationObserver()
        {
            _displays = new List<int>();
        }

        public void Update(IPayStation state)
        {
            _displays.Add(state.ReadDisplay());
        }

        public IList<int> GetDisplays()
        {
            return _displays;
        }
    }
}