using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class VariableStatementSyntax : StatementSyntax
    {
        public VariableDeclarationSyntax Declaration { get; set; }

        public VariableStatementSyntax()
            : base(SyntaxKind.VariableStatement)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitVariableStatement(this);
        }

    }
}
