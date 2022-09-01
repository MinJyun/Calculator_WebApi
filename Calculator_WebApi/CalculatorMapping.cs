using System.Collections.Concurrent;

namespace Calculator_WebApi
{
    /// <summary>
    /// 計算機對應的類別
    /// </summary>
    public static class CalculatorMapping
    {
        /// <summary>
        /// 計算機對應字典
        /// </summary>
        public static ConcurrentDictionary<string, CalculatorState> IdToCalculator = new ConcurrentDictionary<string, CalculatorState>();
    }
}
