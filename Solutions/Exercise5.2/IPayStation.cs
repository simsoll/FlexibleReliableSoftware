using System.Collections.Generic;

namespace Exercise5._2
{
    public interface IPayStation
    {
        void AddPayment(int coinValue);

        int ReadDisplay();

        IReceipt Buy();

        IDictionary<int, int> Cancel();
    }
}