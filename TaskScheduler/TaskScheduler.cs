public class TaskScheduler<TTask, TPriority> where TTask : Task<TPriority>
{
    private PriorityQueue<TTask, TPriority> taskQueue;
    private TaskExecution<TTask> taskExecution;
    private List<TTask> completedTasks;
    private List<TTask> currentTasks;

    public TaskScheduler(TaskExecution<TTask> taskExecution)
    {
        taskQueue = new PriorityQueue<TTask, TPriority>();
        this.taskExecution = taskExecution;
        completedTasks = new List<TTask>();
        currentTasks = new List<TTask>();
    }

    public void AddTask(string description, TPriority priority)
    {
        TTask newTask = (TTask)Activator.CreateInstance(typeof(TTask), description, priority);
        taskQueue.Enqueue(newTask, priority);
        currentTasks.Add(newTask);
        Console.WriteLine($"Task added: {description} (Priority: {priority})");
    }

    public void ExecuteNext()
    {
        if (taskQueue.Count > 0)
        {
            KeyValuePair<TTask, TPriority> nextTask = taskQueue.Dequeue();
            taskExecution(nextTask.Key);
            Console.WriteLine($"Task executed: {nextTask.Key} (Priority: {nextTask.Value})");
            currentTasks.Remove(nextTask.Key);
            completedTasks.Add(nextTask.Key);
        }
        else
        {
            Console.WriteLine("No tasks to execute.");
        }
    }

    public void DisplayCurrentTasks()
    {
        Console.WriteLine("\nCurrent Tasks:");

        foreach (var task in currentTasks.OrderBy(t => t.Priority))
        {
            Console.WriteLine($"- {task}");
        }
    }

    public void DisplayCompletedTasks()
    {
        Console.WriteLine("\nCompleted Tasks:");
        foreach (var task in completedTasks)
        {
            Console.WriteLine($"- {task}");
        }
    }
}