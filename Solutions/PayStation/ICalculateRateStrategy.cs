namespace PayStation
{
    public interface ICalculateRateStrategy
    {
        int CalculateRate(int coinValue);
    }
}