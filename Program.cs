using System;
using System.Collections.Generic;
using System.IO;

namespace collections_and_stuff_may_csharp_2021
{
    class Generator
    {
        private Random _random = new Random();

        public IEnumerable<int> NextInt()
        {
            while (true)
            {
                yield return _random.Next();
            }
        }

        public IEnumerable<string> NextString()
        {
            yield return "Ala";
            yield return "ma";
            yield return "kota";
            yield return "i";
            yield return "psa";
        }
    }

    public delegate int Operation(int a, int b);

    class Program
    {
        public static int Add(int a, int b) => a + b;
        public static int Subtract(int a, int b) => a - b;
        public static int Multiply(int a, int b) => a * b;
        public static int Divide(int a, int b) => a / b;

        public static Operation OperationFactory(string operationType) =>
            operationType switch
            {
                "+" => Add,
                "-" => Subtract,
                "*" => Multiply,
                "/" => (int a, int b) => a / b,
                _ => throw new NotImplementedException()
            };

        public static void WorkingWithDelegates()
        {
            Console.Write("Podaj symbol operacji: ");
            string operationType = Console.ReadLine();
            Operation operation = OperationFactory(operationType);
            Console.Write("Podaj a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            int result = operation(a, b);
            Console.WriteLine($"{a} {operationType} {b} = {result}");
        }

        static void Main(string[] args)
        {
            //BasicCollections();
            //WorkingWithEnumerators();
            //WorkingWithDelegates();
            //UsingAndIDisposable();
        }

        private static void UsingAndIDisposable()
        {
            using StreamWriter writer = new StreamWriter("plik.txt");
            writer.WriteLine("Ala ma kota");
        }

        private static void WorkingWithEnumerators()
        {
            int count = 0;
            Generator generator = new Generator();
            foreach (var i in generator.NextInt())
            {
                Console.WriteLine(i);
                count++;
                if (count > 10)
                {
                    break;
                }
            }

            foreach (var text in generator.NextString())
            {
                Console.WriteLine(text);
            }
        }

        private static void BasicCollections()
        {
            // dynamiczna tablica
            List<int> numbers = new List<int>() { 1, 2, 3, 4 };
            numbers.Add(1);
            numbers.Add(2);
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(numbers[0]);

            // słownik
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("key1", 1);
            dict.Add("key2", 2);

            foreach (var (key, value) in dict)
            {
                Console.WriteLine(key);
                Console.WriteLine(value);
            }

            Console.WriteLine(dict.GetValueOrDefault("key1", -1));

            // zbiór
            HashSet<int> uniqueNumbers = new HashSet<int>() { 1, 2, 3, 4, 4, 5 };
            uniqueNumbers.Add(6);
            foreach (var v in uniqueNumbers)
            {
                Console.WriteLine(v);
            }

            if (uniqueNumbers.Contains(6))
            {
                Console.WriteLine("Tak należy do zbioru!");
            }

            // stos
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            // kolejka
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
