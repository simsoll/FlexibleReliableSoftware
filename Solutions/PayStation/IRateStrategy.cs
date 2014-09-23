namespace PayStation
{
    public interface IRateStrategy
    {
        int CalculateRate(int coinValue);
    }
}