using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class NewExpressionSyntax : ExpressionSyntax
    {
        public SyntaxNode Function { get; set; }

        public NewExpressionSyntax()
            : base(SyntaxKind.NewExpression)
        {

        }
        

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitNewExpression(this);
        }
    }
}
