using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz.Handlers
{
    public class IntegerHandler : IFizzBuzzHandler
    {

        public void Handle(List<int> intsToHandle)
        {
            foreach (int currentInt in intsToHandle)
            {
                bool isDivisibleByThree = DivisibleByThree(currentInt);
                bool isDivisibleByFive = DivisibleByFive(currentInt);

                ProduceMessage(currentInt, isDivisibleByThree, isDivisibleByFive);
            }
        }

        private void ProduceMessage(int originalInt, bool isFizz, bool isBuzz)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (isFizz)
            {
                stringBuilder.Append("Fizz");
            }
            if (isBuzz)
            {
                stringBuilder.Append("Buzz");
            }

            if(stringBuilder.Length == 0)
            {
                stringBuilder.Append(originalInt);
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        private bool DivisibleByFive(int currentInt) => currentInt % 5 == 0;

        private bool DivisibleByThree(int currentInt) => currentInt % 3 == 0;
    }
}
