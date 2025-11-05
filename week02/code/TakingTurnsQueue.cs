using System;
using System.Collections.Generic;

/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private Queue<Person> queue = new Queue<Person>();

    public int Length => queue.Count;

    // Adds a person to the queue with the given name and turns
    public void AddPerson(string name, int turns)
    {
        queue.Enqueue(new Person(name, turns));
    }

    // Returns the next person in the queue, updating their turns as needed
    public Person GetNextPerson()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        var person = queue.Dequeue();

        // Infinite turns: 0 or less
        if (person.Turns <= 0)
        {
            queue.Enqueue(person);
            return person;
        }
        // Finite turns: decrement, only re-enqueue if turns left after this turn
        else if (person.Turns > 1)
        {
            queue.Enqueue(new Person(person.Name, person.Turns - 1));
        }
        // If turns == 1, do not re-enqueue

        return person;
    }
}