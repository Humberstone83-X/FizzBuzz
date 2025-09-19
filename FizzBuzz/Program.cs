using FizzBuzz.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Enumerable.Range(1, 100).ToList();

            IFizzBuzzHandler handler = new IntegerHandler();

            handler.Handle(input);
        }
    }
}
