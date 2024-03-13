// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Runtime.InteropServices;
using Erick.Prime;

//TODO Ver se a escrita esta certa, acertar nome de variavel e metodo

public class Program{

static async Task Main()
{

    Console.WriteLine("Initializing...");
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    long number = 1000000; int result = 0; int option;

    Console.WriteLine("Choose method to process");
    Console.WriteLine(" 1 - Syncronous task");
    Console.WriteLine(" 2 - Assyncronous task");
    Console.WriteLine(" 3 - Parallel task");

    option =  int.Parse(Console.ReadLine() ?? "0");
    
    /*await Task.Run( async () => 
    {
        result = await Task.Run(() => PrimeNumber.PrimeNumberQuantityAsync(number));
    } );*/

    switch (option)
    {
        case  1:
            Console.WriteLine($"Until {number} there are {PrimeNumber.PrimeNumberQuantityGet(number)}  numbers");
            break;
        case  2:
            result = await PrimeNumber.PrimeNumberQuantityGetAssync(number);
            Console.WriteLine($"Until {number} there are {result}  numbers");
            break;
        case  3:
            Console.WriteLine($"Until {number} there are {PrimeNumber.PrimeNumberQuantityGetParallel(number)}  numbers");
            break;
        default:
            Console.WriteLine($"Invalid option");
            break;
    }

    //Console.WriteLine($"Until {number} there are {PrimeNumber.PrimeNumberQuantityGet(number)}  numbers");
    //Console.WriteLine($"Until {number} there are {result}  numbers");
    
    TimeSpan ts = stopWatch.Elapsed;
    Console.WriteLine($"Total time spent: {ts.ToString()}");


    }

}