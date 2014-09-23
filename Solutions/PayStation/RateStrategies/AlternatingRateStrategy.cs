namespace PayStation
{
    public class AlternatingRateStrategy : IRateStrategy
    {
        private readonly IRateStrategy _weekDayStrategy;
        private readonly IRateStrategy _weekendStrategy;

        private readonly IWeekendDecisionStrategy _weekendDecisionStrategy;

        public AlternatingRateStrategy(IRateStrategy weekDayStrategy, IRateStrategy weekendStrategy,
            IWeekendDecisionStrategy weekendDecisionStrategy)
        {
            _weekDayStrategy = weekDayStrategy;
            _weekendStrategy = weekendStrategy;

            _weekendDecisionStrategy = weekendDecisionStrategy;
        }

        public int CalculateRate(int coinValue)
        {
            if (IsWeekend())
            {
                return _weekendStrategy.CalculateRate(coinValue);
            }

            return _weekDayStrategy.CalculateRate(coinValue);
        }

        public bool IsWeekend()
        {
            return _weekendDecisionStrategy.IsWeekend();
        }
    }
}