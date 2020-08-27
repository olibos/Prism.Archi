namespace Prism.Archi.PerformanceComparison
{
    using System.Collections.Generic;

    using Prism.Archi.PerformanceComparison.Tests.Collections;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var comparison = new PerformanceComparer(1000, new Dictionary<string, object> { { "hits", 2 }, { "itemsCount", 10000 } });
            comparison.PerformanceTests.Add(new FindInList());
            comparison.PerformanceTests.Add(new FindInDictionary());
            comparison.Run();
        }
    }
}