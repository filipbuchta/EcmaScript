using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class IdentifierExpressionSyntax : ExpressionSyntax
    {
        public SyntaxToken Name { get; set; }

        public IdentifierExpressionSyntax(SyntaxToken name)
            : base(SyntaxKind.IdentifierExpression)
        {
            this.Name = name;
        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitIdentifierExpression(this);
        }

    }

}
