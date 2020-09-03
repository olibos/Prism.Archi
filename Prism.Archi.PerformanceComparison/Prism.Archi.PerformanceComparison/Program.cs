namespace Prism.Archi.PerformanceComparison
{
    using System.Collections.Generic;

    using Prism.Archi.PerformanceComparison.Tests.Collections;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var comparison = new PerformanceComparer(100, new Dictionary<string, object> { { "hits", 100 }, { "itemsCount", 1000 } });
            comparison.PerformanceTests.Add(new FindInList());
            comparison.PerformanceTests.Add(new FindInDictionary());
            comparison.PerformanceTests.Add(new FindInDictionaryWithDistinct());
            comparison.Run();
        }
    }
}