namespace ToDo;
public class Sort<T> : ISort<T> where T : IComparable<T>
{
    public static void BubbleSort(T[] data)
    {
        int n = data.Length;
        bool swapped;
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (data[j].CompareTo(data[j + 1]) > 0)
                {
                    T temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped)
                break;
        }
    }

    public static void InsertionSort(T[] data)
    {
        for (int i = 1; i < data.Length; i++)
        {
            var key = data[i];
            var flag = false;
            for (int j = i - 1; j >= 0 && flag != true;)
            {
                if (key.CompareTo(data[j]) < 0)
                {
                    data[j + 1] = data[j];
                    j--;
                    data[j + 1] = key;
                }
                else flag = true;
            }
        }
    }


    // MergeSort implementation
    public static void MergeSort(T[] array, int low, int high)
    {
        if (low < high)
        {
            int middle = low + (high - low) / 2; // Find the middle point

            // Recursively sort the left and right halves
            MergeSort(array, low, middle);
            MergeSort(array, middle + 1, high);

            // Merge the sorted halves
            Merge(array, low, middle, high);
        }
    }

    // Merge implementation
    private static void Merge(T[] array, int low, int middle, int high)
    {
        // Sizes of the two subarrays to be merged
        int n1 = middle - low + 1;
        int n2 = high - middle;

        // Create temporary arrays to hold the left and right subarrays
        T[] left = new T[n1];
        T[] right = new T[n2];

        // Copy data to temporary arrays
        for (int i = 0; i < n1; i++)
            left[i] = array[low + i];
        for (int j = 0; j < n2; j++)
            right[j] = array[middle + 1 + j];

        // Merge the temporary arrays back into the original array
        int iLeft = 0, iRight = 0; // Initial indexes of the subarrays
        int k = low; // Initial index of the merged array

        while (iLeft < n1 && iRight < n2)
        {
            // Compare elements of left and right subarrays
            if (left[iLeft].CompareTo(right[iRight]) <= 0)
            {
                array[k] = left[iLeft];
                iLeft++;
            }
            else
            {
                array[k] = right[iRight];
                iRight++;
            }
            k++;
        }

        // Copy remaining elements of left subarray (if any)
        while (iLeft < n1)
        {
            array[k] = left[iLeft];
            iLeft++;
            k++;
        }

        // Copy remaining elements of right subarray (if any)
        while (iRight < n2)
        {
            array[k] = right[iRight];
            iRight++;
            k++;
        }
    }

}

// Sorting Algorithms

// ISort<T> is a generic interface declaring abstract methods for search algorithms where generic type is IComparable<T> as follows:

// public interface ISort<T> where T:IComparable<T>
// {
//   static abstract void InsertionSort(T[]data);
//   static abstract void BubbleSort(T[]data);
//   static abstract void MergeSort(T[]data, int low, int high);
// }

// Implement the interface methods such that :

//InsertionSort <T> and BubbleSort<T> implements the insertion and bugle sort algorithms respectively. These method should accept an array of type T[], where T is any type that implements the IComparable<T> interface.
//MergeSort<T> implements the merge sort algorithm. The method should accept an array of type T[], where T is any type that implements the IComparable<T> interface, and two integers low and high indicating the indices of the subarray to be sorted. HINT: Implement a helper method Merge<T> that merges two sorted subarrays into one sorted array by comparing the elements of each subarray and placing the smaller element in the original array.
//Sort the arrays in ascending order.
//Modify the arrays in place (i.e., no new array is created) except for the Merge method used for MergeSort.
//The Merge method in the explained implementation (in the slides) makes use of auxiliary arrays to store the left and right partitions,
//therefore introduces a O(n) space complexity.

