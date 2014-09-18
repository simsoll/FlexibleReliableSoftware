namespace Exercise5._2
{
    public class DanishCalculateRateStrategy : ICalculateRateStrategy
    {
        public int CalculateRate(int coinValue)
        {
            return coinValue * 7;
        }
    }
}