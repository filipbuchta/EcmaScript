using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class MemberAccessExpressionSyntax : ExpressionSyntax
    {
        public ExpressionSyntax Expression { get; set; }
        public IdentifierExpressionSyntax Name { get; set; }

        public MemberAccessExpressionSyntax()
            : base(SyntaxKind.MemberAccessExpression)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitMemberAccessExpression(this);
        }

    }
}
