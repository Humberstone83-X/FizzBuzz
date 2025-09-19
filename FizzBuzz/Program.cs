using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Enumerable.Range(1, 100).ToList();

            foreach (int i in input)
            {
                Console.WriteLine(i);
            }
        }
    }
}
