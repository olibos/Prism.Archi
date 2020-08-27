// -----------------------------------------------------------------------
//  <copyright file="FindInDictionary.cs" company="CPH">
//  Copyright (c) CPH. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Prism.Archi.PerformanceComparison.Tests.Collections
{
    using System.Collections.Generic;
    using System.Linq;

    using Prism.Archi.PerformanceComparison.Models;

    public class FindInDictionaryWithDistinct : BaseFindInList
    {
        public override string Name => "Find items in list with distinct dictionary";

        public override void Execute()
        {
            var keys = this.items.Select(x => x.Id).Distinct();
            var dictionary = new Dictionary<string, Foo>();

            foreach (var key in keys)
            {
                var item = this.items.First(x => x.Id == key);
                dictionary.Add(key, item);
            }

            for (var i = 0; i < this.hits; i++)
            {
                var id = this.dice.Next(0, this.itemsCount).ToString();
                var found = dictionary[id];
            }
        }
    }
}