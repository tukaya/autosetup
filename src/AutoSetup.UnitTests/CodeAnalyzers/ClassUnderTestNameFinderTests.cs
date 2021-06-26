using AutoSetup.CodeAnalyzers;
using Xunit;

namespace AutoSetup.UnitTests.CodeAnalyzers
{
    public class ClassUnderTestNameFinderTests
    {
        private ClassUnderTestNameFinder _target;
        public ClassUnderTestNameFinderTests()
        {
            _target = new ClassUnderTestNameFinder();
        }

        [Theory]
        [InlineData("SomeClassTest", "SomeClass")]
        [InlineData("SomeClassTests", "SomeClass")]
        [InlineData("SomeClassUnitTests", "SomeClass")]
        [InlineData("SomeClassUnitTests_SomeMethod", "SomeClass")]
        [InlineData("ClassUnderTestTests", "ClassUnderTest")]
        public void ReturnsClassUnderTestName(string testClassName, string expected)
        {
            var actual = _target.GetClassUnderTestName(testClassName);

            Assert.Equal(expected, actual);
        }
    }
}
