using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ToDo;

public class Search<T> : ISearch<T> where T : IComparable<T>
{

    public static int SequentialSearch(T[] a, T v)
    {
        throw new NotImplementedException();
    }

    public static int BinarySearch(T[] a, T v)
    {
        throw new NotImplementedException();
    }

    public static int BinarySearchRecursive(T[] a, T v, int low, int high)
    {
        Utils.ShowCallStack();

        throw new NotImplementedException();
    }

}


