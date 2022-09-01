using System.Collections.Concurrent;

namespace Calculator_WebApi
{
    public interface IMap
    {
        public ConcurrentDictionary<string, CalculatorState> IdToCalculator { set; get; }
    }
}
