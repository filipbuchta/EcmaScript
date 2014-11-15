using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{

    public abstract class ExpressionSyntax : SyntaxNode
    {
        public ExpressionSyntax(SyntaxKind kind)
            : base(kind)
        {
        }
    }
}
