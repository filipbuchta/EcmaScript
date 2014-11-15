using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class ParenthesizedExpressionSyntax : ExpressionSyntax
    {
        public SyntaxNode Expression { get; set; }

        public ParenthesizedExpressionSyntax()
            : base(SyntaxKind.ParenthesizedExpression)
        {

        }
        
        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitParenthesizedExpression(this);
        }
    }
}
