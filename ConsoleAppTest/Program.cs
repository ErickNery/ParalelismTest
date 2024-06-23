using System.Diagnostics;
using Erick.Prime;
public class Program
{

    static async Task Main()
    {

        Console.WriteLine("Initializing...");
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        long number = 1000000;
        int option;
        Console.WriteLine("Choose method to process");
        Console.WriteLine(" 1 - Syncronous task");
        Console.WriteLine(" 2 - Assyncronous task");
        Console.WriteLine(" 3 - Parallel task");

        option = int.Parse(Console.ReadLine() ?? "0");

        switch (option)
        {
            case 1:
                Console.WriteLine($"Until {number} there are {PrimeNumber.PrimeNumberQuantityGet(number)}  numbers");
                break;
            case 2:
                int result = await PrimeNumber.PrimeNumberQuantityGetAsync(number);
                Console.WriteLine($"Until {number} there are {result}  numbers");
                break;
            case 3:
                Console.WriteLine($"Until {number} there are {PrimeNumber.PrimeNumberQuantityGetParallel(number)}  numbers");
                break;
            default:
                Console.WriteLine($"Invalid option");
                break;
        }
        TimeSpan ts = stopWatch.Elapsed;
        Console.WriteLine($"Total time spent: {ts.ToString()}");
    }

}