namespace PayStation
{
    public class DKCoinValidationStrategy : ICoinValidationStrategy
    {
        public bool IsCoinValid(int coinValue)
        {
            switch (coinValue)
            {
                case 1:
                case 2:
                case 5:
                case 10:
                case 25:
                    return true;
                default:
                    return false;
            }
        }
    }
}