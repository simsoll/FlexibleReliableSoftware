using System.Collections.Generic;
using PayStation.Observer;

namespace PayStation
{
    public class PayStation : IPayStation
    {
        private int _coinAmount;
        private int _minutes;
        private IDictionary<int,int> _insertedCoins = new Dictionary<int, int>();
        private IPayStationFactory _payStationFactory;
        private ICoinValidationStrategy _coinValidationStrategy;
        private IRateStrategy _rateStrategy;
        private IDisplayStrategy _displayStrategy;
        private IList<IObserver<IPayStation>> _observers; 

        public PayStation(IPayStationFactory payStationFactory)
        {
            ReConfigure(payStationFactory);
            _observers = new List<IObserver<IPayStation>>();
        }

        public void AddPayment(int coinValue)
        {
            if (!_coinValidationStrategy.IsCoinValid(coinValue))
            {
                throw new IllegalCoinException("Illegal coin value: " + coinValue);
            }

            _coinAmount += coinValue;
            _minutes = _rateStrategy.CalculateRate(_coinAmount);

            _insertedCoins = IncrementCoinAdded(_insertedCoins, coinValue);
        }

        public int ReadDisplay()
        {
            return _displayStrategy.CalculateOutput(_rateStrategy.CalculateRate(_coinAmount));
        }

        public IReceipt Buy()
        {
            NotifyObservers();
            IReceipt receipt = _payStationFactory.CreateReceipt(_minutes);
            Reset();
            return receipt;
        }
            
        public IDictionary<int,int> Cancel()
        {
            var insertedCoins = _insertedCoins;
            Reset();
            return insertedCoins;
        }

        public void ReConfigure(IPayStationFactory payStationFactory)
        {
            _payStationFactory = payStationFactory;

            _coinValidationStrategy = _payStationFactory.CreateCoinValidationStrategy();
            _rateStrategy = _payStationFactory.CreateRateStrategy();
            _displayStrategy = _payStationFactory.CreateDisplayStrategy();
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

        public void AddObserver(IObserver<IPayStation> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IObserver<IPayStation> observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}