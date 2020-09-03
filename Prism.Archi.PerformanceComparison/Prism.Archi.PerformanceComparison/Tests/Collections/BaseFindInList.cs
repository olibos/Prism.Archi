// -----------------------------------------------------------------------
//  <copyright file="BaseFindInList.cs" company="CPH">
//  Copyright (c) CPH. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.Archi.PerformanceComparison.Tests.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Prism.Archi.PerformanceComparison.Models;

    public abstract class BaseFindInList : IPerformanceTest
    {
        protected readonly Random dice = new Random();

        protected readonly List<Foo> items = new List<Foo>();

        protected int hits;
        protected int itemsCount;

        public abstract string Name { get; }

        public abstract void Execute();

        public void Init(Dictionary<string, object> configuration)
        {
            this.hits = (int)configuration["hits"];
            this.itemsCount = (int)configuration["itemsCount"];

            for (var i = 0; i < this.itemsCount; i++)
            {
                this.items.Add(new Foo { Id = i.ToString() });
            }

            this.Shuffle(this.items);
        }

        public void Shuffle<T>(IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = this.dice.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}