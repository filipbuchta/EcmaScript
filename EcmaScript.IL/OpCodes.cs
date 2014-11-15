using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.IL
{

    
    public class OpCodes
    {
        public static OpCode Push_I = new OpCode("push.i", 1, OperandType.Integer);
        public static OpCode Pop = new OpCode("pop", 2, OperandType.None);
        public static OpCode Ldloc = new OpCode("ldloc", 3, OperandType.Integer);
        public static OpCode Stloc = new OpCode("stloc", 4, OperandType.Integer);
        public static OpCode Add = new OpCode("add", 5, OperandType.None);
        public static OpCode Mul = new OpCode("mul", 6, OperandType.None);
        public static OpCode Sub = new OpCode("sub", 7, OperandType.None);
        public static OpCode Init = new OpCode("init", 8, OperandType.MetadataToken);
        public static OpCode Call = new OpCode("call", 9, OperandType.MetadataToken);
        public static OpCode Ceq = new OpCode("ceq", 10, OperandType.None);
        public static OpCode Brtrue = new OpCode("brtrue", 11, OperandType.Integer);
        public static OpCode Ldstr = new OpCode("ldstr", 12, OperandType.MetadataToken);

        public static OpCode GetOpCode(ushort opCode)
        {
            foreach (FieldInfo fi in typeof(OpCodes).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                OpCode op = ((OpCode)fi.GetValue(null));
                if (op.Value == opCode)
                {
                    return op;
                }

            }
            throw new NotSupportedException();
        }
    }
    
}
