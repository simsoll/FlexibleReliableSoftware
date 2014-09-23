namespace PayStation
{
    public class LinearRateStrategy : IRateStrategy
    {
        public int CalculateRate(int coinValue)
        {
            return coinValue/5*2;
        }
    }
}