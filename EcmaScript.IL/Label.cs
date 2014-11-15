using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.IL
{
    public struct Label
    {
        private int Value;

        public Label(int value)
            : this()
        {
            this.Value = value;
        }

        public static bool operator ==(Label a, Label b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Label a, Label b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Label)
                return this.Equals((Label)obj);
            else
                return false;
        }

        public bool Equals(Label obj)
        {
            return obj.Value == this.Value;
        }

        public static implicit operator int(Label label)
        {
            return label.Value;
        }
        public static implicit operator Label(int label)
        {
            return new Label(label);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
