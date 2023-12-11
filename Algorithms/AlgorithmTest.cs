 using System;
 using System.Collections.Generic;
 using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
        }

        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));  //It can't be that simple, right?.. Maybe you meant the other way around?
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void RemoveSeparators(string input, string[] expected)
        {
            Assert.Equivalent(expected, Algorithms.RemoveSeparators(input));
        }
        
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "a, b and c", new[] {"a", "b", "c"}},
                new object[] { "a and    and b  ", new[] {"a", "b"} },
                new object[] { "and and", Array.Empty<string>()},
                new object[] { "", Array.Empty<string>()},
                new object[] { string.Empty, Array.Empty<string>()},
            };
    }
}