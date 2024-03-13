using System.Diagnostics;
using System.Net.NetworkInformation;

namespace Erick.Prime{

  public class PrimeNumber{

    public static int PrimeNumberQuantityGet(long number){
        if(number < 2) return 0;
        var PrimeNumberQtd = 0;
        
        for (int i = 2; i <= number; i++)
        {
            if(IsPrime(i)) {
                PrimeNumberQtd++;
            }
        }

        return PrimeNumberQtd;
    }

    public async static Task<int> PrimeNumberQuantityGetAssync(long number){

        if(number < 2) return 0;
        Int64 remainder = 0;
        var numberFractionated = Math.DivRem(Int64.Parse(number.ToString()), 4,out remainder);

        //Console.WriteLine(numberFractionated-1);
        //Console.WriteLine(numberFractionated*2-1);
        //Console.WriteLine(numberFractionated*3-1);
        //Console.WriteLine(numberFractionated*4);


        var primeNumbersList = new List<Task<int>>
        {
            Task.Run(() => PrimeNumberQuantityGetAssyncRange(2, numberFractionated - 1)),
            Task.Run(() => PrimeNumberQuantityGetAssyncRange(numberFractionated/2, numberFractionated*2-1)),
            Task.Run(() => PrimeNumberQuantityGetAssyncRange(numberFractionated*2, numberFractionated*3-1)),
            Task.Run(() => PrimeNumberQuantityGetAssyncRange(numberFractionated*2, numberFractionated*4)),
            Task.Run(() => PrimeNumberQuantityGetAssyncRange(numberFractionated*4, numberFractionated*4+remainder))
        };

        int[] resultList = await Task.WhenAll(primeNumbersList);
        return resultList.Sum();
    }

    public static int PrimeNumberQuantityGetAssyncRange(long start,long limit){
        int counter = 0; 
        for (long i = start; i <= limit; i++)
        {
            if(IsPrime(i)) counter++;
        }
        return counter;
    }

    private static async Task IsPrimeAssync(long number, int counter){
        if(IsPrime(number)) counter++;
        return;
    }

    public static int PrimeNumberQuantityGetParallel(long number){
        if(number < 2) return 0;
        var PrimeNumberQtd = 0;

        Parallel.For(2, number, i =>
        {
            if(IsPrime(i)) {
                PrimeNumberQtd++;
            }            
        });
        return PrimeNumberQtd;
    }

    private static bool IsPrime(long number)
    {
        if(number == 2) return true;
        for (int i = 2; i < number; i++)
        {
            if (number%i == 0)
            return false;
        }
        return true;
    }
  }
}