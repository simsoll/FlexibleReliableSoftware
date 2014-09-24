namespace PayStation
{
    public interface IDisplayStrategy
    {
        int CalculateOutput(int minutes);
    }
}