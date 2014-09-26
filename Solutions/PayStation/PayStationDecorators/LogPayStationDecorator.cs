using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayStation;

namespace Exercise5._2.Decorators
{
    public class LogPayStationDecorator : IPayStation
    {
        private readonly IPayStation _payStation;

        public LogPayStationDecorator(IPayStation payStation)
        {
            _payStation = payStation;
        }

        public void AddPayment(int coinValue)
        {
            Console.WriteLine("{0} : {1}", coinValue, DateTime.Now);
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
