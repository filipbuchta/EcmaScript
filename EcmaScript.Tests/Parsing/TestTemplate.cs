using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EcmaScript.Syntax;
using System.Collections.Generic;
using System.Text;

namespace EcmaScript.Tests
{

    [TestClass]
    public class TestTemplate : ParserTests
    {
        [TestMethod]
        public void NoTest()
        {
            UsingTree(@"");

            N(SyntaxKind.CompilationUnit);
        }
    }
}
