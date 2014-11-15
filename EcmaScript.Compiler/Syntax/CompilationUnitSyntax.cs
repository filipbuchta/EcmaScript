using System.Collections.Generic;

namespace EcmaScript.Syntax
{
    public class CompilationUnitSyntax : SyntaxNode
    {
        public List<StatementSyntax> Statements { get; set; }

        public CompilationUnitSyntax()
            : base(SyntaxKind.CompilationUnit)
        {
            Statements = new List<StatementSyntax>();
        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitCompilationUnit(this);
        }

    }

}
