using EcmaScript.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Tests.Parsing
{
    public class IteratingWalker : SyntaxWalker
    {
        public List<SyntaxKind> Flattened = new List<SyntaxKind>();

        public override void Visit(SyntaxToken token)
        {
            Flattened.Add(token.Kind);
        }

        public override void Visit(SyntaxNode node)
        {
            Flattened.Add(node.Kind);
        }

        public override void BeforeVisit(SyntaxNode node)
        {
        }

        public override void AfterVisit(SyntaxNode node)
        {
        }
    }
}
