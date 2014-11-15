using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EcmaScript.Syntax;
using System.Collections.Generic;
using System.Text;
using EcmaScript.IL;
using System.Linq;
using System.IO;
using EcmaScript.Tests.Compiling;

namespace EcmaScript.Tests
{


    [TestClass]
    public class ArithmeticsTests : CompilerTests
    {
        [TestMethod]
        [TestCategory("Compiler")]
        public void Substraction()
        {
            UsingSource(@"1 - 2;");

            F(Compilation.MainFunction);
            E(OpCodes.Push_I); E(1);
            E(OpCodes.Push_I); E(2);
            E(OpCodes.Sub);
            EOS();
        }

        [TestMethod]
        [TestCategory("Compiler")]
        public void Addition()
        {
            UsingSource(@"1 + 2;");

            F(Compilation.MainFunction);
            E(OpCodes.Push_I); E(1);
            E(OpCodes.Push_I); E(2);
            E(OpCodes.Add);
            EOS();
        }

        [TestMethod]
        [TestCategory("Compiler")]
        public void Multiplication()
        {
            UsingSource(@"1 * 2;");

            F(Compilation.MainFunction);
            E(OpCodes.Push_I); E(1);
            E(OpCodes.Push_I); E(2);
            E(OpCodes.Mul);
            EOS();
        }

        [TestMethod]
        [TestCategory("Compiler")]
        public void OperatorPrecedence()
        {
            UsingSource(@"1 + 2 * 3;");

            F(Compilation.MainFunction);
            E(OpCodes.Push_I); E(1);
            E(OpCodes.Push_I); E(2);
            E(OpCodes.Push_I); E(3);
            E(OpCodes.Mul);
            E(OpCodes.Add);
            EOS();
        }
    }
}
