using DecomposeNumberApp.Services;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecomposeNumberTests.Services
{
    [TestClass]
    public class DecomposeNumberServiceTest
    {
        private DecomposeNumberService service;

        public DecomposeNumberServiceTest()
        {
            service = new DecomposeNumberService();

        }

        [TestMethod]
        public void When_GetDecomposeAsync_Not_Prime_Number()
        {
            //Arrage
            var entryNumber = 20;

            //ACT
            var response = service.GetDecomposeAsync(entryNumber).GetAwaiter().GetResult();

            //Assert
            Assert.IsTrue(response.DivisorNumbers.Count == 6);
            Assert.IsTrue(response.PrimeDivisors.Count == 3);
            Assert.IsFalse(response.PrimeDivisors.Any(x => x == entryNumber));
        }

        [TestMethod]
        public void When_GetDecomposeAsync_Prime_Number()
        {
            //Arrage
            var entryNumber = 541;

            //ACT
            var response = service.GetDecomposeAsync(entryNumber).GetAwaiter().GetResult();

            //Assert
            Assert.IsTrue(response.DivisorNumbers.Count == response.PrimeDivisors.Count);
            Assert.IsTrue(response.PrimeDivisors.Any(x => x == entryNumber));
            Assert.IsTrue(response.PrimeDivisors.Any(x => x == 1));

        }
        [TestMethod]
        public void When_GetDecomposeAsync_Number_Equal_Two()
        {
            //Arrage
            var entryNumber = 2;

            //ACT
            var response = service.GetDecomposeAsync(entryNumber).GetAwaiter().GetResult();

            //Assert
            Assert.IsTrue(response.DivisorNumbers.Count == response.PrimeDivisors.Count);
            Assert.IsTrue(response.PrimeDivisors.Any(x => x == entryNumber));
            Assert.IsTrue(response.PrimeDivisors.Any(x => x == 1));

        }
        [TestMethod]
        public void When_GetDecomposeAsync_Number_LessThan_One()
        {
            //Arrage
            var entryNumber = 0;

            //ACT
            var response = service.GetDecomposeAsync(entryNumber).GetAwaiter().GetResult();

            //Assert
            Assert.IsTrue(response.DivisorNumbers.Count ==entryNumber);
            Assert.IsTrue(response.PrimeDivisors.Count == 0);
        }
        [TestMethod]
        public void When_GetDecomposeAsync_Number_Divisible_To_Three()
        {
            //Arrage
            var entryNumber = 6;

            //ACT
            var response = service.GetDecomposeAsync(entryNumber).GetAwaiter().GetResult();

            //Assert
            Assert.IsTrue(response.DivisorNumbers.Count == 4);
            Assert.IsTrue(response.PrimeDivisors.Count > 2);
            Assert.IsFalse(response.PrimeDivisors.Any(x => x == entryNumber));
        }

        [TestMethod]
        public void When_GetDecomposeAsync_Number_End_Five()
        {
            //Arrage
            var entryNumber = 345;

            //ACT
            var response = service.GetDecomposeAsync(entryNumber).GetAwaiter().GetResult();

            //Assert
            Assert.IsTrue(response.PrimeDivisors.Count > 2);
            Assert.IsFalse(response.PrimeDivisors.Any(x => x == entryNumber));
        }

    }
}

