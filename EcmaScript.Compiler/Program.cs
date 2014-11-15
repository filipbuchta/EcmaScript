
using EcmaScript.IL;
using EcmaScript.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript
{
    public static class Program
    {
        public static void Main()
        {

            Compiler compiler = new Compiler();
            var result = compiler.Compile(File.ReadAllText(@"C:\Home\Projects\EcmaScript\EcmaScript.Compiler\test2.ts"));

            var list = new List<FunctionDefinition>();

            foreach (FunctionDefinition function in result.Functions)
            {
                Console.WriteLine(".function " +function.Name);
                function.Body.Code.Position = 0;
                while (true)
                {

                    var reader = new BinaryReader(function.Body.Code);
                    ushort opCode = reader.ReadUInt16();


                    OpCode op = OpCodes.GetOpCode(opCode);

                    Console.Write(op.Mnemonic);

                    switch (op.OperandType)
                    {
                        case OperandType.MetadataToken:
                            Console.Write(" ");
                            Console.Write("T("+reader.ReadInt32()+")");
                            break;
                        case OperandType.Integer:
                            Console.Write(" ");
                            Console.Write(reader.ReadInt32());
                            break;
                        case OperandType.None:
                            break;
                        default:
                            throw new NotImplementedException();
                    }

                    Console.WriteLine();
      
                    if (reader.BaseStream.Length == reader.BaseStream.Position)
                        break;
                }
                Console.WriteLine();
            }
           

            Console.ReadLine();

        }
    }
}
