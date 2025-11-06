using System;
using System.Collections.Generic;

public static class Lists
{
    public static List<int> RotateListRight(List<int> data, int amount)
    {
        // Step 1: Handle null input
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        // Step 2: If the list is empty or has 1 element, return a new copy (no mutation)
        if (data.Count <= 1)
            return new List<int>(data);

        // Normalize the rotation amount
        amount = ((amount % data.Count) + data.Count) % data.Count;

        // If no rotation needed, return a new copy
        if (amount == 0)
            return new List<int>(data);

        // Step 3: Create a new list to hold the rotated result
        List<int> rotated = new List<int>(data.Count);

        // Step 4: Calculate the split point
        int splitIndex = data.Count - amount;

        // Step 5: Build rotated list (last 'amount' elements first, then the rest)
        rotated.AddRange(data.GetRange(splitIndex, amount));
        rotated.AddRange(data.GetRange(0, splitIndex));

        // Return the new rotated list (do not mutate the original)
        return rotated;
    }
}   