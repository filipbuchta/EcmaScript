using System.Collections.Generic;
using EcmaScript.CodeGen;
using System;
using System.Text;
using EcmaScript.Syntax;

namespace EcmaScript
{
    public class BoundNode
    {
        
    }

    public class BoundStatement : BoundNode
    {
        
    }

    public class BoundGlobalVariableDeclaration : BoundStatement
    {

    }

    public class BoundLocalVariableDeclaraion : BoundStatement
    {

    }

    public enum BoundKind
    {
        
    }
    public enum SymbolKind
    {
        
    }
    public class ModuleSymbol
    {
        
    }
    public class AssemblySymbol
    {
        public ModuleSymbol DefaultModule;
    }

    public class Binder
    {
        private List<SyntaxTree> syntaxTrees;

        private AssemblySymbol Assembly;

        public Binder(List<SyntaxTree> syntaxTrees)
        {
            this.syntaxTrees = syntaxTrees;
        }


        internal AssemblySymbol BindAssembly()
        {
            if (syntaxTrees.Count > 1)
            {
                throw new NotImplementedException();
            }

            Assembly = new AssemblySymbol();

            Assembly.DefaultModule = BindModule(syntaxTrees[0]);

            return Assembly;
        }

        internal ModuleSymbol BindModule(SyntaxTree tree)
        {
            ModuleSymbol module = new ModuleSymbol();

            foreach (StatementSyntax statement in tree.Root.Statements)
            {
                // Global variable declaration
                if (statement.Kind == SyntaxKind.VariableStatement)
                {
                        BoundGlobalVariableDeclaration node = new BoundGlobalVariableDeclaration();
                }
            }


            return module;
        }
    }

    public class Compiler
    {
        public Compilation Compile(String code)
        {
            Console.WriteLine(code);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            var compilation = new Compilation();


            var scanner = new Scanner(code);
            var parser = new Parser(scanner);

            SyntaxTree syntaxTree = parser.GetSyntaxTree();
            compilation.SetSyntaxTree(syntaxTree);



            StringBuilder sb = new StringBuilder();

            SyntaxTreeVisualizer printer = new SyntaxTreeVisualizer(sb);
            syntaxTree.Root.Accept(printer);

            Console.Write(sb.ToString());
            Console.WriteLine();
            Console.WriteLine();

            var binder = new Binder(new List<SyntaxTree>() { syntaxTree } );
            AssemblySymbol assembly = binder.BindAssembly();

            compilation.Assembly = assembly;

            
            CodeGenerator codeGenerator = new CodeGenerator(compilation);
            codeGenerator.EmitCompilationUnit(syntaxTree.Root);


            Console.WriteLine(code);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            return compilation;
        }


    }
}
