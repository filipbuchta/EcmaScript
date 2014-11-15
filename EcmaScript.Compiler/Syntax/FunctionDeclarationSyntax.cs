using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{

    public class FunctionDeclarationSyntax : StatementSyntax
    {
        public SyntaxToken Identifier { get; set; }
        public BlockStatementSyntax Body { get; set; }
        public ParameterListSyntax Parameters { get; set; }

        public FunctionDeclarationSyntax()
            : base(SyntaxKind.FunctionDeclaration)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitFunctionDeclaration(this);
        }

    }
}
