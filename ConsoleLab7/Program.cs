using System;

class Program
{
    static void Main()
    {
        Calculator<int> intCalculator = new Calculator<int>();
        Calculator<double> doubleCalculator = new Calculator<double>();

        Calculator<int>.AdditionDelegate intAdd = (a, b) => a + b;
        Calculator<int>.SubtractionDelegate intSubtract = (a, b) => a - b;
        Calculator<int>.MultiplicationDelegate intMultiply = (a, b) => a * b;
        Calculator<int>.DivisionDelegate intDivide = (a, b) => b != 0 ? a / b : throw new InvalidOperationException("Cannot divide by zero");

        Calculator<double>.AdditionDelegate doubleAdd = (a, b) => a + b;
        Calculator<double>.SubtractionDelegate doubleSubtract = (a, b) => a - b;
        Calculator<double>.MultiplicationDelegate doubleMultiply = (a, b) => a * b;
        Calculator<double>.DivisionDelegate doubleDivide = (a, b) => b != 0 ? a / b : throw new InvalidOperationException("Cannot divide by zero");

        Console.WriteLine("Integer Operations:");
        Console.WriteLine("Addition: " + intCalculator.Add(5, 3, intAdd));
        Console.WriteLine("Subtraction: " + intCalculator.Subtract(5, 3, intSubtract));
        Console.WriteLine("Multiplication: " + intCalculator.Multiply(5, 3, intMultiply));
        Console.WriteLine("Division: " + intCalculator.Divide(5, 3, intDivide));

        Console.WriteLine("\nDouble Operations:");
        Console.WriteLine("Addition: " + doubleCalculator.Add(5.5, 3.3, doubleAdd));
        Console.WriteLine("Subtraction: " + doubleCalculator.Subtract(5.5, 3.3, doubleSubtract));
        Console.WriteLine("Multiplication: " + doubleCalculator.Multiply(5.5, 3.3, doubleMultiply));
        Console.WriteLine("Division: " + doubleCalculator.Divide(5.5, 3.3, doubleDivide));

    }
}
