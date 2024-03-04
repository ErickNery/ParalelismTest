using System.Diagnostics;

namespace Erick.Prime{

  public class PrimeNumber{

    public static int PrimeNumberQuantity(long number){
        if(number < 2) return 0;
        var PrimeNumberQtd = 0;
        
        //with task
        /*
        for (int i = 2; i <= number; i++)
        {
            await Task.Run( async () => 
            {
                if(await Task.Run(() => IsPrime(i))) {
                    PrimeNumberQtd++;
                }
            } );

        }*/


        //parallel for
        Parallel.For(2, number, i =>
        {
            if(IsPrime(i)) {
                PrimeNumberQtd++;
            }            
        });

        //Single thread
        /*for (int i = 2; i <= number; i++)
        {
            if(IsPrime(i)) {
                PrimeNumberQtd++;
            }
        }*/
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