using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public abstract class StatementSyntax : SyntaxNode
    {

        public StatementSyntax(SyntaxKind kind)
            : base(kind)
        {
        }

    }
}
