public class PriorityQueue<TItem, TPriority>
{
    private SortedDictionary<TPriority, Queue<TItem>> priorityQueue;

    public int Count => priorityQueue.Values.Sum(q => q.Count);

    public PriorityQueue()
    {
        priorityQueue = new SortedDictionary<TPriority, Queue<TItem>>(Comparer<TPriority>.Create((x, y) => Comparer<TPriority>.Default.Compare(x, y)));
    }

    public void Enqueue(TItem item, TPriority priority)
    {
        if (!priorityQueue.ContainsKey(priority))
        {
            priorityQueue[priority] = new Queue<TItem>();
        }

        priorityQueue[priority].Enqueue(item);
    }

    public KeyValuePair<TItem, TPriority> Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var firstPair = priorityQueue.First();
        var item = firstPair.Value.Dequeue();
        if (firstPair.Value.Count == 0)
        {
            priorityQueue.Remove(firstPair.Key);
        }

        return new KeyValuePair<TItem, TPriority>(item, firstPair.Key);
    }
}