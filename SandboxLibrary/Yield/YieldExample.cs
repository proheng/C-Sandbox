using System;
using System.Collections.Generic;

namespace SandboxLibrary.Yield
{
    public class YieldExample<T>
    {
        public IEnumerable<T> MyEnumerable { get; set; }

        // This method will execute multiple times 
        public IEnumerable<T> FilterWithYield(Predicate<T> predicate)
        {
            foreach (var item in MyEnumerable)
            {
                if (predicate.Invoke(item))
                {
                    yield return item;
                }
            }
        }

        // This method will only execute once
        public T[] FilterWithoutYield(Predicate<T> predicate)
        {
            var temp = new List<T>();
            foreach (var item in MyEnumerable)
            {
                if (predicate.Invoke(item))
                {
                    temp.Add(item);
                }
            }
            return temp.ToArray();
        }

        public IEnumerable<T> SummariseWithYield(Func<T,T,T> summarise)
        {
            T tempValue = default(T);
            foreach (var item in MyEnumerable)
            {
                tempValue = summarise(tempValue, item);
                yield return tempValue;
            }
        }
    }
}
