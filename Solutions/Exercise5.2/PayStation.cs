using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Exercise5._2
{
    public class PayStation : IPayStation
    {
        private int _coinAmount;
        private int _minutes;
        private IDictionary<int,int> _insertedCoins = new Dictionary<int, int>();

        public void AddPayment(int coinValue)
        {
            switch (coinValue)
            {
                case 5:
                case 10:
                case 25:
                    break;
                default:
                    throw new IllegalCoinException("Illegal coin value: " + coinValue);
            }

            _coinAmount += coinValue;
            _minutes = CoinAmountToMinutes(_coinAmount);

            _insertedCoins = IncrementCoinAdded(_insertedCoins, coinValue);
        }

        public int ReadDisplay()
        {
            return CoinAmountToMinutes(_coinAmount);
        }

        public IReceipt Buy()
        {
            IReceipt receipt = new Receipt(_minutes);
            Reset();
            return receipt;
        }
            
        public IDictionary<int,int> Cancel()
        {
            var insertedCoins = _insertedCoins;
            Reset();
            return insertedCoins;
        }

        private int CoinAmountToMinutes(int coin)
        {
            return coin/5*2;
        }

        private IDictionary<int, int> IncrementCoinAdded(IDictionary<int,int> insertedCoins, int coin)
        {
            var returnCoins = insertedCoins;

            if (returnCoins.ContainsKey(coin))
            {
                returnCoins[coin] = returnCoins[coin] + 1;
            }
            else
            {
                returnCoins.Add(coin, 1);
            }

            return returnCoins;
        }

        private void Reset()
        {
            _coinAmount = 0;
            _minutes = 0;
            _insertedCoins = new Dictionary<int, int>();
        }
    }
}