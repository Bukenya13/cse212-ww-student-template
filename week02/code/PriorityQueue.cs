using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private class QueueItem
    {
        public string Value { get; }
        public int Priority { get; }
        public QueueItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }
    }

    private List<QueueItem> items = new List<QueueItem>();

    // Enqueue: Add to the back of the queue
    public void Enqueue(string value, int priority)
    {
        items.Add(new QueueItem(value, priority));
    }

    // Dequeue: Remove and return the value with the highest priority (FIFO for ties)
    public string Dequeue()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        int maxPriority = int.MinValue;
        int index = -1;
        // Find the first item with the highest priority
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Priority > maxPriority)
            {
                maxPriority = items[i].Priority;
                index = i;
            }
        }
        string result = items[index].Value;
        items.RemoveAt(index);
        return result;
    }

    // Override ToString() to show queue contents
    public override string ToString()
    {
        if (items.Count == 0)
            return "[]";
        var parts = new List<string>();
        foreach (var item in items)
        {
            parts.Add($"{item.Value}:{item.Priority}");
        }
        return "[" + string.Join(", ", parts) + "]";
    }
}