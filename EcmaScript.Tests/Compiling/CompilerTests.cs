using EcmaScript.IL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Tests.Compiling
{
    public abstract class CompilerTests
    {
        private Compilation _compilation;
        private FunctionDefinition CurrentFunction;
        private BinaryReader CodeReader;

        protected void UsingSource(string code)
        {
            Compiler compiler = new Compiler();
            _compilation = compiler.Compile(code);


        }

        protected void F(string functionName)
        {
            CurrentFunction = _compilation.Functions.FirstOrDefault(f => f.Name == functionName);
            CurrentFunction.Body.Code.Position = 0;
            if (CurrentFunction == null)
            {
                Assert.Fail();
            }
            CodeReader = new BinaryReader(CurrentFunction.Body.Code);
        }

        protected void E(OpCode opCode)
        {
            ushort data = CodeReader.ReadUInt16();
            if (opCode.Value != data)
            {
                Assert.Fail(string.Format("Expected: {0}. Actual: {1}", opCode.Mnemonic, OpCodes.GetOpCode(data).Mnemonic));
            }
        }

        protected void E(int value)
        {
            int data = CodeReader.ReadInt32();
            Assert.AreEqual(value, data);
        }
        protected void EOS()
        {
            Assert.IsTrue(CodeReader.BaseStream.Position == CodeReader.BaseStream.Length);
        }
    }
}
