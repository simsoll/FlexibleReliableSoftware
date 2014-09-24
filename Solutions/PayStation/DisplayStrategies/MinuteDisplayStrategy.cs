namespace PayStation
{
    public class MinuteDisplayStrategy : IDisplayStrategy
    {
        public int CalculateOutput(int minutes)
        {
            return minutes;
        }
    }
}