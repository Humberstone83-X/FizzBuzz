using System.Collections.Generic;

namespace FizzBuzz.Handlers
{
    internal interface IFizzBuzzHandler
    {
        void Handle(List<int> intsToHandle);
    }
}
