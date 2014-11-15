using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class PredefinedTypeSyntax : TypeSyntax
    {
        public SyntaxToken Keyword { get; set; }

        public PredefinedTypeSyntax()
            : base(SyntaxKind.PredefinedType)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitPredefinedType(this);
        }
    }

    public class ReferenceTypeSyntax : TypeSyntax
    {
        public SyntaxToken TypeName { get; set; }

        public ReferenceTypeSyntax()
            : base(SyntaxKind.ReferenceType)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class TypeSyntax : SyntaxNode
    {
        public TypeSyntax(SyntaxKind kind) : base(kind)
        {

        }
    }
}
