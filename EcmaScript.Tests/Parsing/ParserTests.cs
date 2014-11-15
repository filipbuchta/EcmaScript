using EcmaScript.Syntax;
using EcmaScript.Tests.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Tests
{



    public abstract class ParserTests
    {
        protected IEnumerator<SyntaxKind> _syntaxEnumerator;

        protected void UsingTree(String sourceCode, bool postprocess = false)
        {
            Scanner scanner = new Scanner(sourceCode);
            Parser parser = new Parser(scanner);

            SyntaxTree syntaxTree = parser.GetSyntaxTree();

            //if (postprocess)
            //{
            //    PostProcessWalker postProces = new PostProcessWalker();
            //    syntaxTree.Accept(postProces);
            //}

            
            var iteratingWalker = new IteratingWalker();
            syntaxTree.Root.Accept(iteratingWalker);
            _syntaxEnumerator = iteratingWalker.Flattened.GetEnumerator();

        }


        protected void N(SyntaxKind kind)
        {
            Assert.IsTrue(_syntaxEnumerator.MoveNext());
            Assert.AreEqual(kind, _syntaxEnumerator.Current);
        }

    }

}