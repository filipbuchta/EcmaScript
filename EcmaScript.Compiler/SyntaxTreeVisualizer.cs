using EcmaScript.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript
{
    public class SyntaxTreeVisualizer : SyntaxWalker
    {
        private StringBuilder stringBuilder;
        private int indent = -1;

        public SyntaxTreeVisualizer(StringBuilder stringBuilder)
        {
            this.stringBuilder = stringBuilder;
        }

        private void DecreaseIndent()
        {
            indent--;

        }

        private void IncreaseIndent()
        {
            indent++;
        }

        private void Append(string text)
        {
            stringBuilder.Append(text);
        }
        private void AppendLine(string text)
        {
            for (var i = 0; i < indent; i++)
            {
                stringBuilder.Append("\t");
            }
            stringBuilder.AppendLine(text);
        }
        private void AppendLine(string text, params object[] args)
        {
            AppendLine(string.Format(text, args));
        }


        public override void Visit(SyntaxToken node)
        {
            IncreaseIndent();
            AppendLine("{" + node.Kind + "}");
            DecreaseIndent();
        }

        public override void Visit(SyntaxNode node)
        {
            AppendLine("[" + node.Kind + "]");
        }

        public override void BeforeVisit(SyntaxNode node)
        {
            IncreaseIndent();
        }

        public override void AfterVisit(SyntaxNode node)
        {
            DecreaseIndent();
        }
    }

}
