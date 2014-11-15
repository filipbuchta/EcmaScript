using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class BinaryExpressionSyntax : ExpressionSyntax
    {
        public ExpressionSyntax Left { get; set; }
        public ExpressionSyntax Right { get; set; }
        public SyntaxToken Operator { get; set; }

        public BinaryExpressionSyntax()
            : base(SyntaxKind.BinaryExpression)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitBinaryExpression(this);
        }
    }
}
