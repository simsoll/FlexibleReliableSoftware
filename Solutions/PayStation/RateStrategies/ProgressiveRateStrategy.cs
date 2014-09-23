using System;

namespace PayStation
{
    public class ProgressiveRateStrategy : IRateStrategy
    {
        public int CalculateRate(int coinValue)
        {
            var remainingCoinValue = coinValue;
            var accumulatedMinutes = 0;

            if (350 < remainingCoinValue)
            {
                accumulatedMinutes += (remainingCoinValue - 350)/5*1;
                remainingCoinValue = 350;
            }
            if (150 < remainingCoinValue && remainingCoinValue <= 350)
            {
                accumulatedMinutes += Convert.ToInt32((remainingCoinValue - 150)/5*1.5);
                remainingCoinValue = 150;
            }
            if (remainingCoinValue <= 150)
            {
                accumulatedMinutes += (remainingCoinValue - 150) / 5 * 2;
            }

            return accumulatedMinutes;
        }
    }
}