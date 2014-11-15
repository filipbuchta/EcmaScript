using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EcmaScript.Syntax;
using System.Collections.Generic;
using System.Text;

namespace EcmaScript.Tests
{
 
    [TestClass]
    public class Statements : ParserTests
    {
        [TestMethod]
        [TestCategory("Parser")]
        public void VariableDeclare()
        {
            UsingTree(@"declare var x: number;");
            N(SyntaxKind.CompilationUnit);
            {
                N(SyntaxKind.VariableStatement);
                {
                    N(SyntaxKind.VariableDeclaration);
                    {
                        N(SyntaxKind.DeclareKeyword); // declare modifier
                        N(SyntaxKind.IdentifierToken);
                        N(SyntaxKind.PredefinedType); N(SyntaxKind.NumberKeyword);
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("Parser")]
        public void VariableDeclarationTyped()
        {
            UsingTree(@"var x: number = 1;");
            N(SyntaxKind.CompilationUnit);
            {
                N(SyntaxKind.VariableStatement);
                {
                    N(SyntaxKind.VariableDeclaration);
                    {
                        N(SyntaxKind.IdentifierToken);
                        N(SyntaxKind.PredefinedType); N(SyntaxKind.NumberKeyword);
                        N(SyntaxKind.LiteralExpression); N(SyntaxKind.NumericLiteral);
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("Parser")]
        public void VariableToVariableAssignment()
        {
            UsingTree(@"var x = 1; var y = x;");

            N(SyntaxKind.CompilationUnit);
            {
                N(SyntaxKind.VariableStatement);
                {
                    N(SyntaxKind.VariableDeclaration);
                    {
                        N(SyntaxKind.IdentifierToken);
                        N(SyntaxKind.LiteralExpression); N(SyntaxKind.NumericLiteral);
                    }
                }
                N(SyntaxKind.VariableStatement);
                {
                    N(SyntaxKind.VariableDeclaration);
                    {
                        N(SyntaxKind.IdentifierToken);
                        N(SyntaxKind.IdentifierExpression); N(SyntaxKind.IdentifierToken);
                    }
                }
            }
        }


        [TestMethod]
        [TestCategory("Parser")]
        public void VariableAssignment()
        {
            UsingTree(@"var x = 1;");

            N(SyntaxKind.CompilationUnit);
            {
                N(SyntaxKind.VariableStatement);
                {
                    N(SyntaxKind.VariableDeclaration);
                    {
                        N(SyntaxKind.IdentifierToken);
                        N(SyntaxKind.LiteralExpression); N(SyntaxKind.NumericLiteral);
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("Parser")]
        public void VariableDeclaration()
        {
            UsingTree(@"var x;");

            N(SyntaxKind.CompilationUnit);
            {
                N(SyntaxKind.VariableStatement);
                {
                    N(SyntaxKind.VariableDeclaration);
                    {
                        N(SyntaxKind.IdentifierToken);
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("Parser")]
        public void VariableDeclarationAndAssignment()
        {
            UsingTree(@"var x; x = 1;");

            N(SyntaxKind.CompilationUnit);
            {
                N(SyntaxKind.VariableStatement);
                {
                    N(SyntaxKind.VariableDeclaration);
                    {
                        N(SyntaxKind.IdentifierToken);
                    }
                }
                N(SyntaxKind.ExpressionStatement);
                {
                    N(SyntaxKind.AssignmentExpression);
                    {
                        N(SyntaxKind.IdentifierExpression); N(SyntaxKind.IdentifierToken);
                        N(SyntaxKind.LiteralExpression); N(SyntaxKind.NumericLiteral);
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("Parser")]
        public void FunctionDeclaration()
        {
            UsingTree(@"function foo(x) { }");

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
            }
        }


        [TestMethod]
        [TestCategory("Parser")]
        public void Block()
        {
            UsingTree(@"{}");

            N(SyntaxKind.CompilationUnit);
            {
                N(SyntaxKind.BlockStatement);
            }
        }
    }
}
