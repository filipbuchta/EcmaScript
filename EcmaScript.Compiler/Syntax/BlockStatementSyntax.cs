using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class BlockStatementSyntax : StatementSyntax
    {
        public List<StatementSyntax> Statements { get; set; }

        public BlockStatementSyntax()
            : base(SyntaxKind.BlockStatement)
        {
            Statements = new List<StatementSyntax>();
        }


        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitBlock(this);
        }


    }
}
