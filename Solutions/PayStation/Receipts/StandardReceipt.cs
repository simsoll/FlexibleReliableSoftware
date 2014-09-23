namespace PayStation
{
    public class StandardReceipt : IReceipt
    {
        private readonly int _value;

        public StandardReceipt(int value)
        {
            _value = value;
        }

        public int Value()
        {
            return _value;
        }
    }
}