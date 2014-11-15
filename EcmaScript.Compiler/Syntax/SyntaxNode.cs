using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public abstract class SyntaxNode
    {
        public SyntaxKind Kind { get; set; }

        public SyntaxNode(SyntaxKind kind)
        {
            this.Kind = kind;
        }

        public abstract void Accept(ISyntaxVisitor visitor);

    }
}
