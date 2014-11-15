using EcmaScript.IL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript
{
    public class VirtualMachine
    {

        internal void Run(string filename)
        {

            //while (true)
            //{

            //    var reader = new BinaryReader(compilerWalker.MainFunction.ByteCode);
            //    short opCode = (short)reader.ReadInt16();


            //    OpCode op = OpCodes.GetOpCode(opCode);

            //    Console.Write(op.Mnemonic);

            //    switch (op.OperandType)
            //    {
            //        case OperandType.Integer:
            //            Console.Write(" ");
            //            Console.Write(reader.ReadInt32());
            //            break;
            //        case OperandType.None:
            //            break;
            //        default:
            //            throw new NotImplementedException();
            //    }

            //    Console.WriteLine();

            //    if (reader.BaseStream.Length == reader.BaseStream.Position)
            //        break;
            //}

        }
    }
}
