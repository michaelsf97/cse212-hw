using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(12, 7, 5) will result in: {12, 24, 36, 48, 60}, {7, 14, 21, 28, 35}, {5, 10, 15, 20, 25}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        var result = new double[length];
        for (int i = 1; i <= length; i++)
        {
            result[i - 1] = number * i;
        }
        return result;
    }

    /// <summary>
    ///    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5} and an amount is 2 then the list after the function runs should be 
    /// List<int>{4, 5, 1, 2, 3}.  The value of amount will be in the range of 2 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        if (data.Count == 0) return;

        // Ensure amount is within the bounds of the list size
        amount = amount % data.Count;
        if (amount == 0) return;

        // 1. Grab the part that moves to the front
        var endPart = data.GetRange(data.Count - amount, amount);
        
        // 2. Grab the part that moves to the back
        var startPart = data.GetRange(0, data.Count - amount);

        // 3. Update the original list
        data.Clear();
        data.AddRange(endPart);
        data.AddRange(startPart);
    }
}

// This class handles the actual execution
class Program
{
    static void Main()
    {
        // Test Multiples 
        var m12 = Arrays.MultiplesOf(12, 5);
        Console.WriteLine("Multiples of 12: " + string.Join(", ", m12));

        var m7 = Arrays.MultiplesOf(7, 5);
        Console.WriteLine("Multiples of 7: " + string.Join(", ", m7));

        var m5 = Arrays.MultiplesOf(5, 5);
        Console.WriteLine("Multiples of 5: " + string.Join(", ", m5));

        // Test Rotation
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        Console.WriteLine("\nBefore Rotation: " + string.Join(", ", numbers));

        Arrays.RotateListRight(numbers, 2);
        Console.WriteLine("After Rotation (2): " + string.Join(", ", numbers));
    }
}
