﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Editing;

namespace TestSetupGenerator.CodeAnalysis.CodeGenerators
{
    public interface IExpressionStatementGenerator
    {
        SyntaxNode RhinoMocksStubAssignmentExpression(string parameterType, string fieldName, SyntaxGenerator generator);
        SyntaxNode MoqStubAssignmentExpression(string parameterType, string fieldName, SyntaxGenerator generator);
        SyntaxNode TargetObjectAssignmentExpression(IEnumerable<string> fieldNames, string className, SyntaxGenerator generator);
    }

    public class ExpressionStatementGenerator : IExpressionStatementGenerator
    {
        public SyntaxNode RhinoMocksStubAssignmentExpression(string parameterType, string fieldName, SyntaxGenerator generator)
        {
            var fieldIdentifier = generator.IdentifierName(fieldName);
            var mocksRepositoryIdentifier = generator.IdentifierName("MockRepository");
            var parameterTypeIdentifier = generator.IdentifierName(parameterType);

            var memberAccessExpression = generator.MemberAccessExpression(mocksRepositoryIdentifier, generator.GenericName("GenerateStub", parameterTypeIdentifier));
            var invocationExpression = generator.InvocationExpression(memberAccessExpression);

            return generator.AssignmentStatement(fieldIdentifier, invocationExpression);
        }

        public SyntaxNode MoqStubAssignmentExpression(string parameterType, string fieldName, SyntaxGenerator generator)
        {
            var parameterTypeIdentifier = generator.IdentifierName(parameterType);
            var mocksRepositoryIdentifier = generator.GenericName("Mock", parameterTypeIdentifier);
            var fieldIdentifier = generator.IdentifierName(fieldName);

            var fieldInitializationExpression = generator.ObjectCreationExpression(mocksRepositoryIdentifier);
            return generator.AssignmentStatement(fieldIdentifier, fieldInitializationExpression);
        }

        public SyntaxNode TargetObjectAssignmentExpression(IEnumerable<string> fieldNames, string className, SyntaxGenerator generator)
        {
            var targetObjectCreationExpression = generator.ObjectCreationExpression(generator.IdentifierName(className), fieldNames.Select(generator.IdentifierName));

            return generator.AssignmentStatement(generator.IdentifierName("_target"), targetObjectCreationExpression);
        }
    }
}
