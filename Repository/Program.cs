using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        Repository<int> intRepository = new Repository<int>();

        intRepository.Add(5);
        intRepository.Add(10);
        intRepository.Add(15);
        intRepository.Add(20);

        Criteria<int> evenCriteria = x => x % 2 == 0;

        List<int> evenNumbers = intRepository.Find(evenCriteria);
        Console.WriteLine("Even Numbers:");
        foreach (int number in evenNumbers)
        {
            Console.WriteLine(number);
        }

        Repository<string> stringRepository = new Repository<string>();

        stringRepository.Add("apple");
        stringRepository.Add("banana");
        stringRepository.Add("orange");
        stringRepository.Add("grape");

        Criteria<string> startsWithACriteria = s => s.StartsWith("a", StringComparison.OrdinalIgnoreCase);

        List<string> startsWithAStrings = stringRepository.Find(startsWithACriteria);
        Console.WriteLine("\nStrings Starting with 'a':");
        foreach (string str in startsWithAStrings)
        {
            Console.WriteLine(str);
        }

    }
}
