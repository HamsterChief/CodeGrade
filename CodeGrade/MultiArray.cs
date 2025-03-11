using System.Numerics;

namespace ToDo;

public class MultiArray : IMultiArray
{
    //RowSum computes the sum of each row in a two-dimensional array 
    //arr2D and returns a one dimensional array storing the sums.
    public static T[]? RowSum<T>(T[,] arr2D) where T : INumber<T>
    {
        if (arr2D == null)
        {
            return null;
        }

        T[] rowSums = new T[arr2D.GetLength(0)];

        for (int i = 0; i < arr2D.GetLength(0); i++)
        {
            T sum = T.Zero;
            for (int j = 0; j < arr2D.GetLength(1); j++)
            {
                sum += arr2D[i, j];
            }
            rowSums[i] = sum;
        }

        return rowSums;
    }
    //ColSum computes the sum of each column in a two-dimensional array arr2D 
    //and returns a one dimensional array storing the sums.
    public static T[]? ColSum<T>(T[,] arr2D) where T : INumber<T>
    {
        if (arr2D == null)
        {
            return null;
        }

        T[] Colsums = new T[arr2D.GetLength(1)];

        for (int i = 0; i < arr2D.GetLength(1); i++)
        {
            T sum = T.Zero;
            for (int j = 0; j < arr2D.GetLength(0); j++)
            {
                sum += arr2D[j, i];
            }
            Colsums[i] = sum;
        }

        return Colsums;
    }
    //MaxRowIndexSum finds the index of the row with the maximum sum in a jagged array. 
    //returns a Tuple<int, T> where: the first item is the index of the row with the maximum sum 
    //and the second item is the sum of that row.
    public static Tuple<int, T>? MaxRowIndexSum<T>(T[][] arrJagged) where T : INumber<T>
    {
        if (arrJagged == null)
        {
            return null;
        }

        Tuple<int, T> Maxindex = new Tuple<int, T>(0, T.Zero);

        for (int i = 0; i < arrJagged.Length; i++)
        {
            T sum = T.Zero;
            if (arrJagged[i] != null)
            {
                for (int j = 0; j < arrJagged[i].Length; j++)
                {
                    sum += arrJagged[i][j];
                }
                if (sum > Maxindex.Item2)
                {
                    Maxindex = new Tuple<int, T>(i, sum);
                }
            }
        }

        if (Maxindex.Item2 == T.Zero)
        {
            return null;
        }

        return Maxindex;
    }


    //MaxCol identifies the column with the maximum sum in a jagged array 
    //returns an array of type T?[], where each element corresponds to the value in the column with the highest sum. Handle cases where columns have different lengths.
    //Example: A jagged array might have this form (the actual one though is unknown): 
    /* 
    var arr = new int[][]{ 
                           new int[] {3, 21, 34, 34},
                           new int[] {21, 0, 34},
                           new int[] {3, 21, 34, 34, 45, -12, 11}, 
                           null,
                           new int[0],
                           new int[] {3, 21}
                         }; 
    */
    //hint: the size of each sub-array may vary and it is a priori unknown, therefore it might be necessary to compute the maximum number of columns (in this specific case is equal to 7)

    public static T?[] MaxCol<T>(T[][] arrJagged) where T : INumber<T>
    {
        if (arrJagged == null)
        {
            return null;
        }

        // Determine the maximum number of columns manually
        int maxColumns = 0;
        for (int i = 0; i < arrJagged.Length; i++)
        {
            if (arrJagged[i] != null && arrJagged[i].Length > maxColumns)
            {
                maxColumns = arrJagged[i].Length;
            }
        }

        if (maxColumns == 0)
        {
            return new T?[0];
        }

        // Initialize an array to hold the sum of each column
        T[] columnSums = new T[maxColumns];
        for (int i = 0; i < columnSums.Length; i++)
        {
            columnSums[i] = default(T); // Initialize with default value
        }

        // Calculate the sum for each column
        for (int row = 0; row < arrJagged.Length; row++)
        {
            if (arrJagged[row] == null)
            {
                continue;
            }

            for (int col = 0; col < arrJagged[row].Length; col++)
            {
                if (col < maxColumns)
                {
                    columnSums[col] += arrJagged[row][col];
                }
            }
        }

        // Find the column with the maximum sum manually
        int maxColIndex = 0;
        T maxSum = columnSums[0];
        for (int i = 1; i < columnSums.Length; i++)
        {
            if (columnSums[i] > maxSum)
            {
                maxSum = columnSums[i];
                maxColIndex = i;
            }
        }

        // Extract the values from the column with the maximum sum
        T?[] maxColValues = new T?[arrJagged.Length];
        for (int row = 0; row < arrJagged.Length; row++)
        {
            if (arrJagged[row] != null && maxColIndex < arrJagged[row].Length)
            {
                maxColValues[row] = arrJagged[row][maxColIndex];
            }
            else
            {
                maxColValues[row] = default(T);
            }
        }

        return maxColValues;
    }

    /*Split takes an array of tuples, where each tuple contains three elements of type T. The method should qccept 
    an array of Tuple<T, T, T> as input and return a jagged array T[][] with three rows, where:
    The first row contains all the first elements from the tuples.
    The second row contains all the second elements from the tuples.
    The third row contains all the third elements from the tuples.*/
    public static T[][]? Split<T>(Tuple<T, T, T>[] input)
    {
        if (input == null)
        {
            return null;
        }

        T[][] Splittuple = new T[3][];

        Splittuple[0] = new T[input.Length];
        Splittuple[1] = new T[input.Length];
        Splittuple[2] = new T[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            Splittuple[0][i] = input[i].Item1;
            Splittuple[1][i] = input[i].Item2;
            Splittuple[2][i] = input[i].Item3;
        }
        return Splittuple;
    }
    /* Zip<T> that combines two arrays of type T[] into a two-dimensional array. The method should accept two arrays of type T[] and returns a two-dimensional array T[,], where:
    The first column contains elements from array a.
    The second column contains elements from array b.
    hint: If the arrays have different lengths, the shorter array should be padded with the default value of T (e.g., 0 for numeric types) in the missing positions */
    //Zip e.g  a = [1, 2, 3], b = [10, 12, 13] ==> [[1, 10], [2, 12], [3, 13]]
    public static T[,] Zip<T>(T[] a, T[] b)
    {
        // Determine the maximum length of the two arrays
        int maxLength;

        if (a.Length > b.Length) { maxLength = a.Length; }
        else { maxLength = b.Length; }

        // Create a 2D array with maxLength rows and 2 columns
        T[,] zipArray = new T[maxLength, 2];

        // Loop through the arrays and zip the elements
        for (int i = 0; i < maxLength; i++)
        {
            // Assign elements from array a, or default(T) if out of bounds
            zipArray[i, 0] = i < a.Length ? a[i] : default(T);

            // Assign elements from array b, or default(T) if out of bounds
            zipArray[i, 1] = i < b.Length ? b[i] : default(T);
        }

        return zipArray;
    }
}