namespace ToDo;

public class BinarySearch
{
    // Iterative Binary Search
    public static int binarySearch<T>(T[] a, T v) where T : IComparable
    {
        int low = 0;
        int high = a.Length - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            int comparison = a[mid].CompareTo(v);

            if (comparison == 0)
            {
                return mid;
            }
            else if (comparison < 0)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return -1;
    }

    // Recursive Binary Search
    public static int binarySearchRecursive<T>(T[] a, int low, int high, T v) where T : IComparable
    {
        Utils.ShowCallStack(); // DO NOT comment this line of code

        if (low > high)
        {
            return -1; // Element not found
        }

        int mid = low + (high - low) / 2;
        int comparison = a[mid].CompareTo(v); // if result is less results in -1 equals 0 and greater 1

        if (comparison == 0)
        {
            return mid; // Element found
        }
        else if (comparison < 0)
        {
            return binarySearchRecursive(a, mid + 1, high, v); // Search in the right half
        }
        else
        {
            return binarySearchRecursive(a, low, mid - 1, v); // Search in the left half
        }
    }
}