using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.IL
{
    public struct Fixup
    {
        public Label Label;
        public int Position;

        public Fixup(Label label, int position)
            : this()
        {
            this.Label = label;
            this.Position = position;
        }
    }

}
