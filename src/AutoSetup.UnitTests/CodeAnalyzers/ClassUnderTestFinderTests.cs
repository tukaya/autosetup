﻿using AutoSetup.CodeAnalyzers;
using AutoSetup.UnitTests.Helpers.IO;
using AutoSetup.UnitTests.Helpers.RoslynStubProviders;
using Xunit;

namespace AutoSetup.UnitTests.CodeAnalyzers
{
    public class ClassUnderTestFinderTests
    {
        private ClassUnderTestFinder _target;
        public ClassUnderTestFinderTests()
        {
            _target = new ClassUnderTestFinder();
        }

        [Theory]
        [InlineData("files.ClassUnderTestFinderTests_WithMultipleClasses.txt", "", "ClassUnderTest")]
        [InlineData("files.ClassUnderTestFinderTests_WithMultipleClasses.txt", "TestProject", "ClassUnderTest")]
        public void FindsClassUnderTest(string filePath,string projectName, string classUnderTestName)
        {
            var source = TextFileReader.ReadFile(filePath);
            var document = DocumentProvider.CreateDocument(source);

            var actual = _target.GetAsync(document.Project.Solution, projectName, classUnderTestName);
            Assert.NotNull(actual);
        }
    }
}
