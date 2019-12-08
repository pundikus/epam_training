using System;

namespace TaskArray
{
    
    public interface IComparer<in T>
    {
        int Compare(T a, T b);
    }
}

