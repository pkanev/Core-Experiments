using System;
using System.Collections.Generic;

namespace WorkingWithVisualStudio.Tests
{
    public class Comparer
    {
        public static Comparer<U> Get<U>(Func<U, U, bool> func)
        {
            return new Comparer<U>(func);
        }
    }

    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> comparissonFunction;

        public Comparer(Func<T, T, bool> func)
        {
            this.comparissonFunction = func;
        }

        public bool Equals(T x, T y)
        {
            return this.comparissonFunction(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}
