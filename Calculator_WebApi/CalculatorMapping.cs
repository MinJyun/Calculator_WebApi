using System.Collections.Concurrent;

namespace Calculator_WebApi
{
    /// <summary>
    /// 計算機對應的類別
    /// </summary>
    public class CalculatorMapping
    {
        /// <summary>
        /// 計算機對應字典
        /// </summary>
        public ConcurrentDictionary<string, CalculatorState> IdToCalculator = new ConcurrentDictionary<string, CalculatorState>();
    }
}
