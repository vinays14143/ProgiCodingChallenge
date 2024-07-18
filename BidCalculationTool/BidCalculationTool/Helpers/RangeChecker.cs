namespace BidCalculationTool.Helpers
{
    public static class RangeChecker
    {
        //Funnction to take range of vehicle price and return the associaction fee based on vehicle price
        private static readonly Dictionary<Func<double, bool>, int> _rangeChecks = new()
        {
            { value => value >= 1 && value <= 500, 5 },
            { value => value > 500 && value <= 1000, 10 },
            { value => value > 1000 && value <= 3000, 15 },
            { value => value > 3000, 20}
        };

        public static int GetAssociationFee(double value)
        {
            foreach (var rangeCheck in _rangeChecks)
            {
                if (rangeCheck.Key(value))
                {
                    return rangeCheck.Value;
                }
            }
            return 0;
        }
    }
}
