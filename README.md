
[![Build Status](https://dev.azure.com/tubakaya/autosetup/_apis/build/status/autosetup?branchName=master)](https://dev.azure.com/tubakaya/autosetup/_build/latest?definitionId=25&branchName=master)
[![Nuget Downloads](https://img.shields.io/nuget/dt/autosetup.svg)](https://www.nuget.org/packages/AutoSetup/)

# AutoSetup

**AutoSetup** is a code analyzer that automates instantiating mocks for a class under test (using [Moq](https://github.com/moq/moq) & [XUnit](https://github.com/xunit/xunit)).

While writing unit tests, instantiating mocks for a class under test is a time consuming task. AutoSetup saves you time by automatically detecting class under test, its dependencies and generating code to instantiate mocks. 

Just install the nuget package in your test project and generate the code for instantiating mocks with click of a button.

AutoSetup can find class under test based on naming conventions (e.g for CalculatorTests the class name is expected to be Calculator). Class under test should be anywhere within the currently open solution in Visual Studio for AutoSetup to be able to find it.

## Usage

1. **Install nuget package** on your unit test project
(`Install-Package AutoSetup`)
2. In your unit test project **create a new test class** (e.g. CalculatorTests)
3. Locate cursor on test class name 
4. Click **"(Re-)generate Setup"**


![Steps](https://user-images.githubusercontent.com/6681935/49291645-535d2b80-f4ab-11e8-9676-0d8a2c1e466e.gif)

Please note:
* Currently only supports XUnit and Moq. 
* Class under test is detected based on naming convention. For a test class with name "CalculatorTests", class under test is assumed to have the name "Calculator".
* Locate the cursor on test class name to see "(Re-)Generate Setup" option.

## Contributing

AutoSetup is a code analyzer/refactoring tool based on [the .NET Compiler Platform (Roslyn)]([https://github.com/dotnet/roslyn](https://github.com/dotnet/roslyn)). Please install .NET Compiler Platform SDK on your PC to be able to build and debug. 

Please create a new branch from master and a Pull Request with your changes. Thanks.

## License

This project is licensed under the [Apache 2.0 License](LICENSE.txt).
