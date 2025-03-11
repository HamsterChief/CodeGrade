
namespace ToDo;

public class SequentialSearch
{
    public static int sequentialSearch(int[] a, int v)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == v)
            {
                return i;
            }
        }
        return -1;
    }

    public static int sequentialSearch<T>(T[] a, T v) where T : IComparable
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].CompareTo(v) == 0)
            {
                return i;
            }
        }
        return -1;
    }

}

// Search Algorithms
// - Sequential Search
// - Binary Search

// ISearch<T> is a generic interface declaring abstract methods for search algorithms 
// where generic type is IComparable<T>,

// public interface ISearch<T> where T:IComparable<T>
// {
//   static abstract int SequentialSearch(T[]data, T Item);
//   static abstract int BinarySearch(T[]data, T Item);
//   static abstract int BinarySearchRecursive(T[]data, T Item, int low, int high);
// }

//     Change/Implement the methods in class Search<T> implementing this interface (ISearch<T> )
//     Implement the methods in class SequentialSearch and BinarySearch.
//     The methods should return the index of the element if it exists in the array, or -1 
//     if the element is not found.

// Methods signatures should not be changed. This line of code Utils.ShowCallStack(); should never be removed.
