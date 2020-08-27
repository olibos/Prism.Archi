// -----------------------------------------------------------------------
//  <copyright file="PerformanceComparer.cs" company="CPH">
//  Copyright (c) CPH. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.Archi.PerformanceComparison
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Prism.Archi.PerformanceComparison.Tests;

    public class PerformanceComparer
    {
        private readonly int iterations;
        private readonly Dictionary<string, object> parameters;

        public PerformanceComparer(int iterations, Dictionary<string, object> parameters = null)
        {
            this.parameters = parameters ?? new Dictionary<string, object>();
            this.iterations = iterations;
        }

        public List<IPerformanceTest> PerformanceTests { get; } = new List<IPerformanceTest>();

        public void Run()
        {
            this.Log("Start the performance comparison");

            for (var i = 0; i < this.PerformanceTests.Count; i++)
            {
                var test = this.PerformanceTests[i];
                this.Log($"Running test {i + 1} : {test.Name}");

                test.Init(this.parameters);

                // 3 preloads to ensure method is really preloaded :p
                for (var preload = 0; preload < 3; preload++)
                {
                    test.Execute();
                }

                // run !
                this.Log($"Starting {this.iterations} iterations");
                var sw = new Stopwatch();

                sw.Start();
                for (var iteration = 0; iteration < this.iterations; iteration++)
                {
                    test.Execute();
                }

                sw.Stop();

                this.Log($"Test {i + 1} - Iterations done, total time : {sw.Elapsed}");
                this.Log($"Test {i + 1} - Iterations done, average time per iteration : {sw.Elapsed.TotalMilliseconds / this.iterations} ms");
            }
        }

        private void Log(string content)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss} - {content}");
        }
    }
}