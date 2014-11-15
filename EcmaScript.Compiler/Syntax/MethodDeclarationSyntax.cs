using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class MethodDeclarationSyntax : MemberDeclarationSyntax
    {
        public ParameterListSyntax Parameters { get; set; }
        public BlockStatementSyntax Body { get; set; }

        public MethodDeclarationSyntax()
            : base(SyntaxKind.MethodDeclaration)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitMethodDeclaration(this);
        }
    }
}
