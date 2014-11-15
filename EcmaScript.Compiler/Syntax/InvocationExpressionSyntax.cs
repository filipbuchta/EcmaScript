using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class InvocationExpressionSyntax : ExpressionSyntax
    {
        public ExpressionSyntax Expression { get; set; }
        public ArgumentListSyntax ArgumentList { get; set; }
         
        public InvocationExpressionSyntax()
            : base(SyntaxKind.InvocationExpression)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitInvocationExpression(this);
        }

    }
}
