using System.Collections.Generic;

namespace DecomposeNumberApp.Contracts
{
    public class Response
    {
        public List<int> DivisorNumbers { get; set; } = new List<int>();
        public List<int> PrimeDivisors { get; set; } = new List<int>();
    }
}
