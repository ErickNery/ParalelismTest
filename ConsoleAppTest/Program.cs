// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using Erick.Prime;

public class Program{

static async Task Main()
{

    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    long number; int result = 0;
    
    Console.Write("What number do you want to test? ");
    number = long.Parse(Console.ReadLine() ?? "0");
    
    /*await Task.Run( async () => 
    {
        result = await Task.Run(() => PrimeNumber.PrimeNumberQuantityAsync(number));
    } );*/

    Console.WriteLine($"Until {number} there are {PrimeNumber.PrimeNumberQuantity(number)}  numbers");
    Console.WriteLine($"Until {number} there are {result}  numbers");
    
    TimeSpan ts = stopWatch.Elapsed;
    Console.WriteLine($"Total time spent: {ts.ToString()}");


    }

}