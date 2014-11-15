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
    public class ConditionTests : CompilerTests
    {
        [TestMethod]
        [TestCategory("Compiler")]
        public void ConditionWithVariable()
        {
            UsingSource(@"var x = 1; if (x == 1) { x = 2; }");

            F(Compilation.MainFunction);
            // var x = 1;
            E(OpCodes.Push_I); E(1);
            E(OpCodes.Stloc); E(0); // x

            // x == 1
            E(OpCodes.Ldloc); E(0); // x
            E(OpCodes.Push_I); E(1);
            E(OpCodes.Ceq);

            // if
            E(OpCodes.Push_I); E(1);
            E(OpCodes.Ceq);
            E(OpCodes.Brtrue); E(16);

            E(OpCodes.Push_I); E(2);
            E(OpCodes.Stloc); E(0); // x

            EOS();
        }

    
    }
}
