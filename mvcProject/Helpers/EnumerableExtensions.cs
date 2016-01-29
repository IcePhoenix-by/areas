using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Helpers
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<P> GetFilterOptionsFor<R, P>(this IEnumerable<R> records, Func<R, P> propertySelector, IComparer<P> propertyComparer)
        {
            var orderedColValues = records.Select(propertySelector).OrderBy(value => value, propertyComparer);
            var prevValue = orderedColValues.First();
            var distinctValues = new List<P>();
            distinctValues.Add(orderedColValues.First());

            foreach (var value in orderedColValues.Skip(1))
            {
                if (propertyComparer.Compare(value, prevValue) != 0)
                    distinctValues.Add(value);

                prevValue = value;
            }

            return distinctValues;
        }

        public static IEnumerable<P> GetFilterOptionsFor<R, P>(this IEnumerable<R> records, Func<R, P> propertySelector)
            where P : IComparable<P>
        {
            return GetFilterOptionsFor(records, propertySelector, Comparer<P>.Default);
        }

        public static IEnumerable<P> GetFilterOptionsFor<R, P>(this IEnumerable<R> records, Func<R, P> propertySelector, Comparison<P> comparison)
        {
            return GetFilterOptionsFor(records, propertySelector, Comparer<P>.Create(comparison));
        }
    }
}