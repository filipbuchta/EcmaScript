using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EcmaScript.Syntax;
using System.Collections.Generic;
using System.Text;

namespace EcmaScript.Tests
{
 
    [TestClass]
    public class ClassTests : ParserTests
    {

        [TestMethod]
        [TestCategory("Parser")]
        public void MemberInvocation()
        {
            UsingTree(@"foo.bar()");
            N(SyntaxKind.CompilationUnit);
            {
                N(SyntaxKind.ExpressionStatement);
                {
                    N(SyntaxKind.InvocationExpression);
                    {
                        N(SyntaxKind.MemberAccessExpression);
                        {
                            N(SyntaxKind.IdentifierExpression); N(SyntaxKind.IdentifierToken);
                            N(SyntaxKind.IdentifierExpression); N(SyntaxKind.IdentifierToken);
                        }
                    }
                }
            }
        
        }

      
    }
}
