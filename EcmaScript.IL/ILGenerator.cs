using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.IL
{
    public class ILGenerator
    {
        private MemoryStream Code;
        private BinaryWriter Writer;

        private int[] Labels = new int[0];
        private List<Fixup> Fixups = new List<Fixup>();

        public int ILOffset
        {
            get 
            {
                return (int)Writer.BaseStream.Position;
            }
        }

        public ILGenerator(MemoryStream code)
        {
            Code = code;
            Writer = new BinaryWriter(Code);
        }

        public Label DefineLabel()
        {
            int length = Labels.Length;
            Array.Resize(ref Labels, length + 1);
            return length;
        }

        public void MarkLabel(Label label)
        {
            Labels[label] = ILOffset;
        }

        public void Emit(OpCode opcode)
        {
            Writer.Write(opcode.Value);
        }
        public void Emit(OpCode opcode, int arg)
        {
            Writer.Write(opcode.Value);
            Writer.Write(arg);
        }

        public void Emit(OpCode opcode, Label label)
        {
            Writer.Write(opcode.Value);
            AddFixup(label, ILOffset);
            Writer.Seek(sizeof(int), SeekOrigin.Current); // Leave space for offset
        }

        private void AddFixup(Label label, int position)
        {
            this.Fixups.Add(new Fixup(label, position));
        }

        public void Bake()
        {
            foreach (var fixup in this.Fixups)
            {
                
                int labelPosition = Labels[fixup.Label];
                int offset = labelPosition - fixup.Position;

                Writer.Seek(fixup.Position, SeekOrigin.Begin);
                Writer.Write(offset);
            }
        }
    }
}
