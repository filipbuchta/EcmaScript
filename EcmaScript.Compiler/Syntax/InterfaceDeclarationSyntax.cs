using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{

    public class InterfaceDeclarationSyntax : StatementSyntax
    {
        public SyntaxToken Identifier { get; set; }
        public List<MemberDeclarationSyntax> Members { get; set; }

        public InterfaceDeclarationSyntax()
            : base(SyntaxKind.InterfaceDeclaration)
        {
            Members = new List<MemberDeclarationSyntax>();
        }



        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitInterfaceDeclaration(this);
        }
    }
}
