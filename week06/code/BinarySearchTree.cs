using System.Collections.Generic;

public class BinarySearchTree
{
    public Node? Root { get; private set; }

    public void Insert(int value)
    {
        if (Root == null)
            Root = new Node(value);
        else
            Root.Insert(value);
    }

    public bool Contains(int value)
    {
        return Root != null && Root.Contains(value);
    }

    public int GetHeight()
    {
        return Root?.GetHeight() ?? 0;
    }

    public IEnumerable<int> Reversed()
    {
        if (Root != null)
        {
            foreach (var value in Root.TraverseBackward())
                yield return value;
        }
    }

    public IEnumerable<int> TraverseForward()
    {
        if (Root != null)
        {
            foreach (var value in Root.TraverseForward())
                yield return value;
        }
    }
}
