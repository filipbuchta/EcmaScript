using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class ArgumentSyntax : SyntaxNode
    {
        public ExpressionSyntax Expression { get; set; }

        public ArgumentSyntax()
            : base(SyntaxKind.Argument)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitArgument(this);
        }

    }
}
