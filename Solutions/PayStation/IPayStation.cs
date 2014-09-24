using System.Collections.Generic;

namespace PayStation
{
    public interface IPayStation
    {
        void AddPayment(int coinValue);

        int ReadDisplay();

        IReceipt Buy();

        IDictionary<int, int> Cancel();

        void ReConfigure(IPayStationFactory payStationFactory);
    }
}