using System;

namespace Task2 
{
    class MyEqualityComparer : IEqualityComparer<int>
    {
        public bool Equals(int x, int y) { return x == y; }
        public int GetHashCode(int x) { return EqualityComparer<int>.Default.GetHashCode(x); }
    }
}