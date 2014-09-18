namespace PayStation
{
    public class ProgressiveRateStrategy : ICalculateRateStrategy
    {
        public int CalculateRate(int coinValue)
        {
            return coinValue * 7;
        }
    }
}