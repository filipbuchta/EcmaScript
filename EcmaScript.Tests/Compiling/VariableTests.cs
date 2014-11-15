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
    public class VariableTests : CompilerTests
    {
        [TestMethod]
        [TestCategory("Compiler")]
        public void AssignVariable()
        {
            UsingSource(@"var x = 1;");

            F(Compilation.MainFunction);
            E(OpCodes.Push_I); E(1);
            E(OpCodes.Stloc); E(0);
            EOS();
        }

        [TestMethod]
        [TestCategory("Compiler")]
        public void AssignVariableToVariable()
        {
            UsingSource(@"var x = 1; var y = x;");

            F(Compilation.MainFunction);
            E(OpCodes.Push_I); E(1);
            E(OpCodes.Stloc); E(0);

            E(OpCodes.Ldloc); E(0);
            E(OpCodes.Stloc); E(1);

            EOS();
        }
    }
}
