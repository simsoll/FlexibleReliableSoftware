namespace Exercise5._2
{
    public class EnglishCalculateRateStrategy : ICalculateRateStrategy
    {
        public int CalculateRate(int coinValue)
        {
            return coinValue/5*2;
        }
    }
}