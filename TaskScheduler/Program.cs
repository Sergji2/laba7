using System;
using System.Collections.Generic;
using System.Linq;

public delegate void TaskExecution<TTask>(TTask task);

class Program
{
    static void Main()
    {
        TaskScheduler<Task<int>, int> scheduler = new TaskScheduler<Task<int>, int>(ExecuteTask);

        while (true)
        {
            Console.WriteLine("\nTask Scheduler Menu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Execute Next Task");
            Console.WriteLine("3. Display Current Tasks");
            Console.WriteLine("4. Display Completed Tasks");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter task description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter task priority (integer): ");
                    if (int.TryParse(Console.ReadLine(), out int priority))
                    {
                        scheduler.AddTask(description, priority);
                    }
                    else
                    {
                        Console.WriteLine("Invalid priority. Please enter an integer.");
                    }
                    break;

                case "2":
                    scheduler.ExecuteNext();
                    break;

                case "3":
                    scheduler.DisplayCurrentTasks();
                    break;

                case "4":
                    scheduler.DisplayCompletedTasks();
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    static void ExecuteTask(Task<int> task)
    {
        Console.WriteLine($"Executing task: {task.Description}");
    }
}
