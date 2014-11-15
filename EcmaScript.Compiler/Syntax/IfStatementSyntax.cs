using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class IfStatementSyntax : StatementSyntax
    {
        public StatementSyntax Statement { get; set; }
        public ExpressionSyntax Condition { get; set; }

        public IfStatementSyntax() : base(SyntaxKind.IfStatement)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitIfStatement(this);
        }
    }
}
