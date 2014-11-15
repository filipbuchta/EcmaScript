using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.IL
{
    public struct OpCode
    {
        public ushort Value;
        public string Mnemonic;
        public OperandType OperandType;

        public OpCode(string mnemonic, ushort value, OperandType operandType)
        {
            this.Mnemonic = mnemonic;
            this.Value = value;
            this.OperandType = operandType;
        }

    }

}
