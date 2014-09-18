using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Exercise5._2
{
    public class PayStation : IPayStation
    {
        private int _coinAmount;
        private int _minutes;
        private IDictionary<int,int> _insertedCoins = new Dictionary<int, int>();
        private ICoinValidationStrategy _coinValidationStrategy = new EnglishCoinValidationStrategy();
        private ICalculateRateStrategy _calculateRateStrategy = new EnglishCalculateRateStrategy();

        public void AddPayment(int coinValue)
        {
            if (!_coinValidationStrategy.IsCoinValid(coinValue))
            {
                throw new IllegalCoinException("Illegal coin value: " + coinValue);
            }

            _coinAmount += coinValue;
            _minutes = _calculateRateStrategy.CalculateRate(_coinAmount);

            _insertedCoins = IncrementCoinAdded(_insertedCoins, coinValue);
        }

        public int ReadDisplay()
        {
            return _calculateRateStrategy.CalculateRate(_coinAmount);
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