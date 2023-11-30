public class Task<TPriority>
{
    public string Description { get; }
    public TPriority Priority { get; }

    public Task(string description, TPriority priority)
    {
        Description = description;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Description} (Priority: {Priority})";
    }
}