using FizzBuzz.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace FizzBuzzTest.Handlers
{
    public class IntegerHandlerTests : IDisposable
    {
        private readonly IntegerHandler _handler;
        private readonly TextWriter _out;
        private readonly StringWriter _consoleWriter;

        public IntegerHandlerTests()
        {
            _handler = new IntegerHandler();

            //Mock Console
            _out = Console.Out;
            _consoleWriter = new StringWriter();
            Console.SetOut(_consoleWriter);
        }

        public void Dispose()
        {
            Console.SetOut(_out);
            _consoleWriter.Dispose();
        }

        private static List<int> ArrangeInputRange(int startInclusive, int endInclusive) 
            => Enumerable.Range(startInclusive, endInclusive).ToList();

        private void AssertLinesEqual(IEnumerable<string> expected)
        {
            var expectedList = expected.ToList();
            var actual = GetLines().ToList();

            Assert.Equal(expectedList.Count, actual.Count);

            for (int i = 0; i < expectedList.Count; i++)
            {
                Assert.Equal(expectedList[i], actual[i]);
            }
        }

        private string[] GetLines()
        {
            Console.Out.Flush();
            var all = _consoleWriter.ToString();
            return all.Replace("\r\n", "\n")
                      .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        [Fact]
        public void Handle_PrintsNumberWhenNotFizzOrBuzz()
        {
            var input = ArrangeInputRange(1, 1);

            _handler.Handle(input);

            AssertLinesEqual(new[] { "1" });
        }

        [Fact]
        public void Handle_PrintsFizzForMultiplesOf3()
        {
            var input = new List<int> { 3, 6, 9 };

            _handler.Handle(input);

            AssertLinesEqual(new[] { "Fizz", "Fizz", "Fizz" });
        }

        [Fact]
        public void Handle_PrintsBuzzForMultiplesOf5()
        {
            var input = new List<int> { 5, 10, 20 };

            _handler.Handle(input);

            AssertLinesEqual(new[] { "Buzz", "Buzz", "Buzz" });
        }

        [Fact]
        public void Handle_PrintsFizzBuzzForMultiplesOf3And5()
        {
            var input = new List<int> { 15, 30, 45 };

            _handler.Handle(input);

            AssertLinesEqual(new[] { "FizzBuzz", "FizzBuzz", "FizzBuzz" });
        }

        [Fact]
        public void Handle_PrintsOneLinePerInputInOrder()
        {
            var input = ArrangeInputRange(1, 16);

            _handler.Handle(input);

            var expected = new[]
            {
                "1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz",
                "11","Fizz","13","14","FizzBuzz","16"
            };
            AssertLinesEqual(expected);
        }

        [Fact]
        public void Handle_PrintsNothingWhenEmpty()
        {
            var input = new List<int>();

            _handler.Handle(input);

            AssertLinesEqual(new List<string>());
        }
    }
}
