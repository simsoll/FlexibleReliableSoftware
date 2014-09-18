namespace PayStation
{
    public class LinearRateStrategy : ICalculateRateStrategy
    {
        public int CalculateRate(int coinValue)
        {
            return coinValue/5*2;
        }
    }
}