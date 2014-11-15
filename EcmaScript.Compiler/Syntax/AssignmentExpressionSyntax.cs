using EcmaScript.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{

    public class AssignmentExpressionSyntax : ExpressionSyntax
    {
        public ExpressionSyntax Left;
        public ExpressionSyntax Right;

        public AssignmentExpressionSyntax()
            : base(SyntaxKind.AssignmentExpression)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitAssignmentExpression(this);
        }
    }
}
