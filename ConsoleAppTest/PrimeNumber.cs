namespace Erick.Prime
{

    public class PrimeNumber
    {

        public static int PrimeNumberQuantityGet(long number)
        {
            if (number < 2) return 0;
            var PrimeNumberQtd = 0;

            for (int i = 2; i <= number; i++)
            {
                if (IsPrime(i))
                {
                    PrimeNumberQtd++;
                }
            }

            return PrimeNumberQtd;
        }

        public async static Task<int> PrimeNumberQuantityGetAsync(long number)
        {
            if (number < 2) return 0;
            long remainder = 0;
            var numberFractionated = Math.DivRem(Int64.Parse(number.ToString()), 4, out remainder);

            int counter = 1;

            var primeNumbersList = new List<Task<int>>
        {
            PrimeNumberQuantityGetAssyncRange(2, numberFractionated*counter - 1),
            PrimeNumberQuantityGetAssyncRange(numberFractionated*counter, numberFractionated*++counter-1),
            PrimeNumberQuantityGetAssyncRange(numberFractionated*counter, numberFractionated*++counter-1),
            PrimeNumberQuantityGetAssyncRange(numberFractionated*counter, numberFractionated*++counter-1),
            PrimeNumberQuantityGetAssyncRange(numberFractionated*counter, numberFractionated*counter+remainder)
        };

            int[] resultList = await Task.WhenAll(primeNumbersList);
            return resultList.Sum();
        }

        public static Task<int> PrimeNumberQuantityGetAssyncRange(long start, long limit)
        {
            return Task.Run<int>(async () =>
            {

                List<Task<int>> listaNumeros = new List<Task<int>>();

                for (long i = start; i <= limit; i++)
                {
                    listaNumeros.Add(IsPrimeAssync(i));
                }

                var listaints = await Task.WhenAll(listaNumeros);
                return listaints.Sum();

            });
        }

        private static Task<int> IsPrimeAssync(long number)
        {
            return Task.Run<int>(() =>
            {
                if (number == 2)
                {
                    return 1;
                }
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                        return 0;
                }
                return 1;
            });
        }

        public static int PrimeNumberQuantityGetParallel(long number)
        {
            if (number < 2) return 0;
            var PrimeNumberQtd = 0;

            Parallel.For(2, number, i =>
            {
                if (IsPrime(i))
                {
                    PrimeNumberQtd++;
                }
            });
            return PrimeNumberQtd;
        }

        private static bool IsPrime(long number)
        {
            if (number == 2)
            {
                return true;
            }
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}