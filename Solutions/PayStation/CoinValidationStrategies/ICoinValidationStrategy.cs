namespace PayStation
{
    public interface ICoinValidationStrategy
    {
        bool IsCoinValid(int coinValue);
    }
}