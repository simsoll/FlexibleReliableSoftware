using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayStation;

namespace Exercise5._2.PayStationDecorators
{
    public class MaxTen5CentsDecorator : IPayStation
    {
        private readonly IPayStation _payStation;
        private int _numberOfFiveCents;

        public MaxTen5CentsDecorator(IPayStation payStation)
        {
            _payStation = payStation;
        }

        public void AddPayment(int coinValue)
        {
            if (coinValue == 5)
            {
                _numberOfFiveCents++;
            }

            if (_numberOfFiveCents > 10)
            {
                _numberOfFiveCents = 0;
                _payStation.Cancel();
                return;
            }

            _payStation.AddPayment(coinValue);
        }

        public int ReadDisplay()
        {
            return _payStation.ReadDisplay();
        }

        public IReceipt Buy()
        {
            return _payStation.Buy();
        }

        public IDictionary<int, int> Cancel()
        {
            return _payStation.Cancel();
        }

        public void ReConfigure(IPayStationFactory payStationFactory)
        {
            _payStation.ReConfigure(payStationFactory);
        }
    }
}
