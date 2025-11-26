using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // Problem 1: Insert Unique Values Only
    public void Insert(int value)
    {
        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data) // Only insert if value is greater
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value == Data, do nothing (prevents duplicates)
    }

    // Problem 2: Contains
    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        if (value < Data)
            return Left != null && Left.Contains(value);
        else
            return Right != null && Right.Contains(value);
    }

    // Problem 4: GetHeight
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }

    // Problem 3: Traverse Backwards
    public IEnumerable<int> TraverseBackward()
    {
        if (Right != null)
        {
            foreach (var value in Right.TraverseBackward())
                yield return value;
        }

        yield return Data;

        if (Left != null)
        {
            foreach (var value in Left.TraverseBackward())
                yield return value;
        }
    }

    // Optional helper: Traverse Forward (for reference)
    public IEnumerable<int> TraverseForward()
    {
        if (Left != null)
        {
            foreach (var value in Left.TraverseForward())
                yield return value;
        }

        yield return Data;

        if (Right != null)
        {
            foreach (var value in Right.TraverseForward())
                yield return value;
        }
    }
}
