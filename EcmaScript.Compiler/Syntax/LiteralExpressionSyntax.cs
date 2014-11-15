using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{

    public class LiteralExpressionSyntax : ExpressionSyntax
    {
        public SyntaxToken Token { get; set; }

        public LiteralExpressionSyntax()
            : base(SyntaxKind.LiteralExpression)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitLiteralExpresion(this);
        }

    }
}
