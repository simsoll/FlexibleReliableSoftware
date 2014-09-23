namespace PayStation
{
    public class ExpensiveReceipt : IReceipt
    {
        private readonly int _value;
        private readonly int _multiplier;

        public ExpensiveReceipt(int value, int multiplier)
        {
            _value = value;
            _multiplier = multiplier;
        }

        public int Value()
        {
            return _value * _multiplier;
        }
    }
}