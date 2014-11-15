using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EcmaScript.Syntax;
using System.Collections.Generic;
using System.Text;

namespace EcmaScript.Tests
{

    [TestClass]
    public class ConditonTests : ParserTests
    {
        [TestMethod]
        [TestCategory("Parser")]
        public void If()
        {
            UsingTree(@"if (0 == 1) { }");

            N(SyntaxKind.CompilationUnit);
            {
                N(SyntaxKind.IfStatement);
                {
                    N(SyntaxKind.BinaryExpression);
                    {
                        N(SyntaxKind.LiteralExpression); N(SyntaxKind.NumericLiteral);
                        N(SyntaxKind.EqualsEqualsToken);
                        N(SyntaxKind.LiteralExpression); N(SyntaxKind.NumericLiteral);
                    }
                    N(SyntaxKind.BlockStatement);
                }
            }

        }
    }
}
