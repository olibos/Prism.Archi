// -----------------------------------------------------------------------
//  <copyright file="IPerformanceTest.cs" company="CPH">
//  Copyright (c) CPH. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.Archi.PerformanceComparison.Tests
{
    using System.Collections.Generic;

    public interface IPerformanceTest
    {
        string Name { get; }

        void Init(Dictionary<string, object> configuration);

        void Execute();
    }
}