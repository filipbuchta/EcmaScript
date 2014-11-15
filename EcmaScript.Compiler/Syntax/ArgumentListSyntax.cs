using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public class ArgumentListSyntax : SyntaxNode
    {
        public List<ArgumentSyntax> Arguments { get; set; }

        public ArgumentListSyntax()
            : base(SyntaxKind.ArgumentList)
        {
            Arguments = new List<ArgumentSyntax>();
        }



        public override void Accept(ISyntaxVisitor visitor)
        {
            visitor.VisitArgumentList(this);
        }
    }
}
