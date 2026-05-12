using System;
using System.Collections.Generic;

class ArrayClass
{    
    static void Main()
    {
        //Multiples of 12(5 numbers)
        var multiplesof12 = MultiplesOf(12,5);
        Console.WriteLine("Multiples of 12: " + string.Join(", ", multiplesof12));

        //Multiples of 7(5 numbers)
        var multiplesof7 = MultiplesOf(7,5);
        Console.WriteLine("Multiples of 7: " + string.Join(", ", multiplesof7));

        //Multiples of 5(5 numbers)
        var multiplesof5 = MultiplesOf(5,5);
        Console.WriteLine("Multiples of 5: " + string.Join(", ", multiplesof5));
    
        // RotateRight example
        var numbers = new List<int>{1,2, 3, 4, 5};
        RotateRight(numbers, 2);
        Console.WriteLine("Original list: " + string.Join(", ", numbers));
        Console.WriteLine("Rotated list: " + string.Join(", ", numbers));
    }


     private static double[] MultiplesOf(int start, int count)
    {
        var result = new double[count];

        for (int i=1; i<= count; i++)
        {
            result[i-1] = start * i;
        }
        return result;
    }

    private static List<int> RotateRight(List<int> data, int amount)
    {
        amount = amount % data.Count;
        var endPart = data.GetRange(data.Count - amount, amount);
        var startPart = data.GetRange(0, data.Count - amount);

        data.Clear();
        data.AddRange(endPart);
        data.AddRange(startPart);

        return data;
    }
}



