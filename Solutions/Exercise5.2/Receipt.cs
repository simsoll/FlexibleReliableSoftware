namespace Exercise5._2
{
    public class Receipt : IReceipt
    {
        private readonly int _value;

        public Receipt(int value)
        {
            _value = value;
        }

        public int Value()
        {
            return _value;
        }
    }
}