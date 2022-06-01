using DecomposeNumberApp.Services;
using System;

namespace DecomposeNumberConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var service = new DecomposeNumberService();
            var stop = false;

            while (!stop)
            {
                Console.WriteLine("\n\nDigite o número a ser decomposto: ");
                var input = Console.ReadLine();
                var entryNumber = 0;

                if (int.TryParse(input,out entryNumber))
                {
                    var response = service.GetDecomposeAsync(entryNumber);

                    Console.WriteLine($"\n Número de entrada: {entryNumber}");
                    Console.WriteLine($"\n Números divisores: {string.Join(",", response.GetAwaiter().GetResult().DivisorNumbers)}");
                    Console.WriteLine($"\n Divisores primos: {string.Join(",", response.GetAwaiter().GetResult().PrimeDivisors)}");

                    Console.WriteLine("\n\nDigite \"S\" para interromper a execução: ");
                    input = Console.ReadLine();

                    if (input.ToUpper().Equals("S"))
                        stop = true;
                }
            }
        }
    }
}
