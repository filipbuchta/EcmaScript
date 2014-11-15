using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public struct SyntaxToken
    {
        public SyntaxKind Kind { get; set; }
        public Object Value { get; set; }

        public SyntaxToken(SyntaxKind kind)
            : this()
        {
            this.Kind = kind;
        }
        public SyntaxToken(SyntaxKind kind, Object value)
            : this()
        {
            this.Kind = kind;
            this.Value = value;
        }

        public override string ToString()
        {
            return String.Format("Value={0}; Kind={1}", Value, Kind);
        }

    }

}
