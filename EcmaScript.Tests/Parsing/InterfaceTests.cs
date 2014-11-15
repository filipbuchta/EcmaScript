using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EcmaScript.Syntax;
using System.Collections.Generic;
using System.Text;

namespace EcmaScript.Tests
{

    [TestClass]
    public class InterfaceTests : ParserTests
    {

        [TestMethod]
        [TestCategory("Parser")]
        public void InterfaceDeclaration()
        {
            UsingTree(@"interface IFoo { test(message); }");
            N(SyntaxKind.CompilationUnit);
            {
                N(SyntaxKind.InterfaceDeclaration);
                {
                    N(SyntaxKind.IdentifierToken);
                    N(SyntaxKind.MethodDeclaration);
                    {
                        N(SyntaxKind.IdentifierToken);
                        N(SyntaxKind.ParameterList);
                        {
                            N(SyntaxKind.Parameter);
                            {
                                N(SyntaxKind.IdentifierToken);
                            }
                        }
                    }
                }
            }
        }
    }
}
