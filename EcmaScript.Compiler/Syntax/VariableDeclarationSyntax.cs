using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{

    public class VariableDeclarationSyntax : SyntaxNode
    {
        public List<SyntaxToken> Modifiers { get; set; }
        public PredefinedTypeSyntax Type { get; set; }
        public SyntaxToken Identifier { get; set; }
        public ExpressionSyntax Initializer { get; set; }

        public VariableDeclarationSyntax() : base(SyntaxKind.VariableDeclaration)
        {
            Modifiers = new List<SyntaxToken>();
        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitVariableDeclaration(this);
        }

    }
}
