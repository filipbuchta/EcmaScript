using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public abstract class MemberDeclarationSyntax : SyntaxNode
    {
        public SyntaxToken Identifier { get; set; }

        public MemberDeclarationSyntax(SyntaxKind kind)
            : base(kind)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitMemberDeclaration(this);
        }
    }
}
