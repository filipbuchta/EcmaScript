using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
 
    public class ParameterListSyntax : SyntaxNode
    {
        public List<ParameterSyntax> Parameters { get; set; }

        public ParameterListSyntax() : base(SyntaxKind.ParameterList)
        {
            Parameters = new List<ParameterSyntax>();;
        }

        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitParameterList(this);
        }

    }
}
