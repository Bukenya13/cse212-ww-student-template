using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities, then dequeue all.
    // Expected Result: Items are dequeued in order of highest to lowest priority.
    // Defect(s) Found: 
    // - No defects found. Test passes if queue logic is correct.
    public void TestPriorityQueue_DequeueOrder()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority.
    // Expected Result: The first item with the highest priority is dequeued first (FIFO for ties).
    // Defect(s) Found: 
    public void TestPriorityQueue_FIFOTieBreaker()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);
        pq.Enqueue("D", 1);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: Throws InvalidOperationException.
    // Defect(s) Found: 
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue and dequeue a single item.
    // Expected Result: The item is returned.
    // Defect(s) Found: 
    public void TestPriorityQueue_SingleItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 10);
        Assert.AreEqual("X", pq.Dequeue());
    }

    // Add more test cases as needed below.
}