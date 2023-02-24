namespace NetActionFuncPredicatApp
{
    //delegate void VoidStringDelegate(string text);
    //delegate void VoidIntegerDelegate(int value);

    delegate void VoidTypeDelegate<in T>(T value);
    delegate TResult FuncBinary<out TResult, in TArg>(TArg value1, TArg value2);
    internal class Program
    {
        static void Main(string[] args)
        {
            //VoidStringDelegate delegateString1 = Hello;
            VoidTypeDelegate<string> delegateString2 = Hello;

            //VoidIntegerDelegate delegateInteger1 = PrintSqr;
            VoidTypeDelegate<int> delegateInteger2 = PrintSqr;

            FuncBinary<int, int> funcBinary = Sum;

            // Action
            Action action1 = HelloWorld;
            Action<string> action2 = Hello;
            Action<int> action3 = PrintSqr;

            // Func
            Func<int, int> func1 = DoubleNumber;
            Func<int, int, int> func2 = Sum;

            Func<string, int, string> func3 
                = (text, number) => text + number.ToString();

            //Predicate
            Predicate<int> predicate = (item) => item % 2 == 0;

            var counter1 = CreateCounter();
            var counter2 = CreateCounter(10, 3);

            for (int i = 0; i < 5; i++)
                Console.WriteLine(counter1());
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
                Console.WriteLine(counter2());
        }

        static void Hello(string name)
        {
            Console.WriteLine($"Hello {name}");
        }
        static void PrintSqr(int number)
        {
            Console.WriteLine($"{number * number}");
        }
        static void HelloWorld()
        {
            Console.WriteLine($"Hello world");
        }
        static int DoubleNumber(int a)
        {
            return 2 * a;
        }
        static int Sum(int a, int b)
        {
            return a + b;
        }

        static Func<int> CreateCounter(int initCount = 0, int step = 1)
        {
            int count = initCount;
            int Counter()
            {
                return count += step;
            }
            return Counter;
        }
    }
}