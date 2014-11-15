using EcmaScript.CodeGen;
using EcmaScript.IL;
using EcmaScript.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.CodeGen
{
    public class CodeGenerator
    {
        public Compilation CompiledUnit;

        public Stack<FunctionContext> DeclarationStack = new Stack<FunctionContext>();


        public FunctionContext CurrentFunction
        {
            get { return DeclarationStack.Peek(); }
        }

        public CodeGenerator(Compilation compiledUnit)
        {
            CompiledUnit = compiledUnit;
        }

        public ILGenerator Generator
        {
            get { return CurrentFunction.Generator; }
        }

        public void EmitFunctionDeclaration(FunctionDeclarationSyntax node)
        {
            var definition = new FunctionDefinition();
            definition.Name = (String)node.Identifier.Value;
            definition.Body = new FunctionBody();

            FunctionContext context = new FunctionContext(definition);


            CompiledUnit.Functions.Add(context.Definition);

            var function = CompiledUnit.Functions.First( f => f.Name.Equals(node.Identifier.Value));

        
            Generator.Emit(OpCodes.Init, function.MetadataToken);
            DeclarationStack.Push(context);

            EmitBlock(node.Body);

            DeclarationStack.Pop();

            context.Generator.Bake();
        }

        public void EmitExpression(ExpressionSyntax node)
        {
            switch (node.Kind)
            {
                case SyntaxKind.MemberAccessExpression:
                    {
                        //EmitMemberAccessExpression((MemberAccessExpressionSyntax)node);
                    }
                    break;
                case SyntaxKind.InvocationExpression:
                    {
                        EmitInvocationExpression((InvocationExpressionSyntax)node);
                    }
                    break;
                case SyntaxKind.BinaryExpression:
                    {
                        EmitBinaryExpression((BinaryExpressionSyntax)node);
                    }
                    break;
                case SyntaxKind.LiteralExpression:
                    {
                        EmitLiteralExpresion((LiteralExpressionSyntax)node);
                    }
                    break;
                case SyntaxKind.AssignmentExpression:
                    {
                        EmitAssignmentExpression((AssignmentExpressionSyntax)node);
                    }
                    break;
                case SyntaxKind.IdentifierExpression:
                    {
                        EmitIdentifierExpression((IdentifierExpressionSyntax)node);
                    }
                    break;
                default:
                    throw new NotImplementedException("Not implemented: " + node.Kind);
            }
        }


        public void EmitStatement(StatementSyntax node)
        {
            switch (node.Kind)
            {
                case SyntaxKind.InterfaceDeclaration:
                    {
                        EmitInterfaceDeclaration((InterfaceDeclarationSyntax)node);
                    }
                    break;
                case SyntaxKind.IfStatement:
                    {
                        EmitIfStatement((IfStatementSyntax)node);
                    }
                    break;
                case SyntaxKind.VariableStatement:
                    {
                        EmitVariableStatement((VariableStatementSyntax)node);
                    }
                    break;
                case SyntaxKind.ExpressionStatement:
                    {
                        EmitExpression(((ExpressionStatementSyntax)node).Expression);
                    }
                    break;
                case SyntaxKind.BlockStatement:
                    {
                        EmitBlock(((BlockStatementSyntax)node));
                    }
                    break;
                default:
                    throw new NotImplementedException("Not implemented: " + node.Kind);
            }
        }

        public void EmitCompilationUnit(CompilationUnitSyntax node)
        {
            var definition = CompiledUnit.Main = new FunctionDefinition();
            definition.Name = "main";
            definition.Body = new FunctionBody();

            var context = new FunctionContext(definition);

            CompiledUnit.Functions.Add(CompiledUnit.Main);

            

            DeclarationStack.Push(context);

            foreach (var statement in node.Statements)
            {
                EmitStatement(statement);
            }

            DeclarationStack.Pop();

            context.Generator.Bake();
        }

        public void EmitBlock(BlockStatementSyntax node)
        {
            foreach (var statement in node.Statements)
            {
                EmitStatement(statement);
            }
        }

        public void EmitVariableStatement(VariableStatementSyntax node)
        {
            EmitVariableDeclaration(node.Declaration);
        }


        public void EmitIfStatement(IfStatementSyntax node)
        {
            EmitExpression(node.Condition);

            Generator.Emit(OpCodes.Push_I, 1);
            Generator.Emit(OpCodes.Ceq);


            var falseLabel = Generator.DefineLabel();
            Generator.Emit(OpCodes.Brtrue, falseLabel);

            EmitStatement(node.Statement);

            Generator.MarkLabel(falseLabel);
        }


        public void EmitMemberAccess(MemberAccessExpressionSyntax node)
        {

        }

        public class Symbol
        {

        }
        public class LocalSymbol
        {

        }

        //public LocalSymbol LookupLocal(LiteralExpressionSyntax node)
        //{
        //    if (this.CurrentFunction.)
        //}

        //public Symbol DeterimeReturnType(ExpressionSyntax node)
        //{
        //    if (node.Kind == SyntaxKind.LiteralExpression)
        //    {
        //        var local = LookupLocal((LiteralExpressionSyntax)node);
        //        if (local == null)
        //        {
        //            throw new NotImplementedException();
        //        }
        //    }
        //    else if (node.Kind == SyntaxKind.MemberAccessExpression)
        //    {

        //    } else 
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public void EmitInvocationExpression(InvocationExpressionSyntax node)
        {
            int metadataToken = 0;
            if (node.Expression.Kind == SyntaxKind.IdentifierExpression)
            {
                var function = CompiledUnit.Functions.First(f => f.Name.Equals(((IdentifierExpressionSyntax)node.Expression).Name.Value));
                metadataToken = function.MetadataToken;
            }
            else if (node.Expression.Kind == SyntaxKind.MemberAccessExpression)
            {
//                DeterimeReturnType(node.Expression);

  //              EmitMemberAccess();
            }

            foreach (ArgumentSyntax argument in node.ArgumentList.Arguments.Reverse<ArgumentSyntax>()) {
                EmitExpression(argument.Expression);
            }
            Generator.Emit(OpCodes.Call, -1);
        }

        private void EmitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            EmitExpression(node.Right);

            EmitStore(node.Left);
        }

        private void EmitStore(ExpressionSyntax node)
        {
            //Symbol symbol = LookupSymbol(node);
            //switch (symbol.Kind)
            //{
            //    case SymbolKind.Local:
            //        {
                            
            //        }
            //        break;

            //}
            if (node.Kind == SyntaxKind.IdentifierExpression)
            {
                // lookup local
                string variableName = (string)((IdentifierExpressionSyntax)node).Name.Value;
                var localVariable = CurrentFunction.Definition.Body.Locals.FirstOrDefault(v => v.Name == variableName);

                Generator.Emit(OpCodes.Stloc, localVariable.Index);
            }
            else
            {
                throw new NotImplementedException();
            }
        }


        public void EmitLiteralExpresion(LiteralExpressionSyntax node)
        {
            if (node.Token.Kind == SyntaxKind.NumericLiteral)
            {
                Generator.Emit(OpCodes.Push_I, (int)node.Token.Value);
            }
            else if (node.Token.Kind == SyntaxKind.StringLiteral)
            {
                var token = CompiledUnit.GetStringConstant((String)node.Token.Value);
                Generator.Emit(OpCodes.Ldstr, token);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void EmitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {

        }

        public void EmitVariableDeclaration(VariableDeclarationSyntax node)
        {
            // lookup variable kind
            var local = new LocalVariableDefinition();
            local.Name = (string)node.Identifier.Value;
            local.Index = CurrentFunction.Definition.Body.Locals.Count;

            CurrentFunction.Definition.Body.Locals.Add(local);

            if (node.Initializer != null)
            {
                EmitExpression(node.Initializer);

                Generator.Emit(OpCodes.Stloc, local.Index);
            }

        }

        public void EmitIdentifierExpression(IdentifierExpressionSyntax node)
        {
            string variableName = (string)node.Name.Value;
            var localVariable = CurrentFunction.Definition.Body.Locals.FirstOrDefault(v => v.Name == variableName);
            if (localVariable != null)
            {
                Generator.Emit(OpCodes.Ldloc, localVariable.Index);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void EmitBinaryExpression(BinaryExpressionSyntax node)
        {
            EmitExpression(node.Left);
            EmitExpression(node.Right);

            switch (node.Operator.Kind)
            {
                case SyntaxKind.PlusToken:
                    Generator.Emit(OpCodes.Add);
                    break;
                case SyntaxKind.AsteriskToken:
                    Generator.Emit(OpCodes.Mul);
                    break;
                case SyntaxKind.MinusToken:
                    Generator.Emit(OpCodes.Sub);
                    break;
                case SyntaxKind.EqualsEqualsToken:
                    Generator.Emit(OpCodes.Ceq);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
