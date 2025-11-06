using System;
using System.Collections.Generic;

public static class Arrays
{
    public static double[] MultiplesOf(double startingNumber, int numberOfMultiples)
    {
        // Step 1: Create an empty array with the correct size
        // The size should be equal to numberOfMultiples
        double[] result = new double[numberOfMultiples];
        
        // Step 2: Use a loop to fill the array with multiples
        // For each position i in the array, calculate startingNumber * (i + 1)
        // We use (i + 1) because we want: 1st multiple, 2nd multiple, etc.
        for (int i = 0; i < numberOfMultiples; i++)
        {
            result[i] = startingNumber * (i + 1);
        }
        
        // Step 3: Return the completed array
        return result;
    }
}