using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class ExpressionStatementSyntax : StatementSyntax
    {
        public ExpressionSyntax Expression { get; set; }

        public ExpressionStatementSyntax()
            : base(SyntaxKind.ExpressionStatement)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitExpressionStatement(this);
        }

    }
}
