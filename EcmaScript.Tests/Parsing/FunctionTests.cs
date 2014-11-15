using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EcmaScript.Syntax;
using System.Collections.Generic;
using System.Text;

namespace EcmaScript.Tests
{
 
    [TestClass]
    public class FunctionTests : ParserTests
    {
        [TestMethod]
        [TestCategory("Parser")]
        public void FunctionInvocation()
        {
            UsingTree(@"foo();");
            N(SyntaxKind.CompilationUnit);
            {
                N(SyntaxKind.ExpressionStatement);
                {
                    N(SyntaxKind.InvocationExpression);
                    {
                        N(SyntaxKind.IdentifierExpression); N(SyntaxKind.IdentifierToken);
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("Parser")]
        public void FunctionInvocationWithParameter()
        {
            UsingTree(@"function foo(x) {}; var a = foo(1);");
            N(SyntaxKind.CompilationUnit);
            {
                N(SyntaxKind.FunctionDeclaration);
                {
                    N(SyntaxKind.IdentifierToken);
                    N(SyntaxKind.ParameterList);
                    {
                        N(SyntaxKind.Parameter);
                        {
                            N(SyntaxKind.IdentifierToken);
                        }
                    }
                    N(SyntaxKind.BlockStatement);
                }
                N(SyntaxKind.VariableStatement);
                {
                    N(SyntaxKind.VariableDeclaration);
                    {
                        N(SyntaxKind.IdentifierToken);
                        N(SyntaxKind.InvocationExpression);
                        {
                            N(SyntaxKind.IdentifierExpression); N(SyntaxKind.IdentifierToken);
                            N(SyntaxKind.ArgumentList);
                            {
                                N(SyntaxKind.Argument);
                                {
                                    N(SyntaxKind.LiteralExpression); N(SyntaxKind.NumericLiteral);
                                }
                            }
                        }
                    }
                }
            }
        
        }

      
    }
}
