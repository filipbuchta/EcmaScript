using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class ParameterSyntax : SyntaxNode
    {
        public SyntaxToken Identifier { get; set; }

        public ParameterSyntax()
            : base(SyntaxKind.Parameter)
        {

        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitParameter(this);
        }
    }

}
