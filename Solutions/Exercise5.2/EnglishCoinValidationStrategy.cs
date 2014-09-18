namespace Exercise5._2
{
    public class EnglishCoinValidationStrategy : ICoinValidationStrategy
    {
        public bool IsCoinValid(int coinValue)
        {
            switch (coinValue)
            {
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