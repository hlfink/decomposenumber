using DecomposeNumberApp.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DecomposeNumberApp.Services
{
    public class DecomposeNumberService
    {
         public async Task<Response> GetDecomposeAsync(int entryNumber) {

            return await Task.Run(() => {

                var response = new Response();

                response.DivisorNumbers.AddRange(GetDivisorNumber(entryNumber));
                response.PrimeDivisors.AddRange(GetPrimeDivisors(response.DivisorNumbers));

                return response;
            });
        
        }

        private IEnumerable<int> GetPrimeDivisors(List<int> divisorNumbers)
        {
            var result = new List<int>();

            divisorNumbers.ForEach(x => {

                if (CheckPrimeNumber(x))
                    result.Add(x);
            
            });

            return result;
        }

        private bool CheckPrimeNumber(int number)
        {
            if (number < 1)
                return false;

            if (number == 2)
                return true;

            var ruleRes = number % 2;

            if (ruleRes == 0)
                return false;

            var digitSum = GetDigitSum(number);
            ruleRes = digitSum % 3;

            if (ruleRes == 0 && number != 3)
                return false;

            if (number.ToString()[number.ToString().Length - 1].Equals("5") && number != 5)
                return false;


            return true;
        }

        private int GetDigitSum(int number)
        {
            var length = number.ToString().Length;
            var sum = 0;

            for (int i = 0; i < length; i++)
                sum += int.Parse(number.ToString().Substring(i, 1));

            return sum;
        }


        private IEnumerable<int> GetDivisorNumber(int entryNumber)
        {
            var result = new List<int>();

            for (int i = 1; i <= entryNumber; i++)
                if (entryNumber % i == 0)
                    result.Add(i);
            
            return result;
        }
    }
}
