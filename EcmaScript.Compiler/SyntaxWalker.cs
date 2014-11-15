using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{
    public abstract class SyntaxWalker : ISyntaxVisitor
    {
        public virtual void Visit(SyntaxToken node) {}
        public virtual void Visit(SyntaxNode node) {}

        public virtual void BeforeVisit(SyntaxNode node) {}
        public virtual void AfterVisit(SyntaxNode node) {}

        public virtual void VisitCompilationUnit(CompilationUnitSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Statements.ForEach(n => n.Accept(this));
            AfterVisit(node);
        }

        public virtual void VisitIdentifierExpression(IdentifierExpressionSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            Visit(node.Name);
            AfterVisit(node);
        }

        public virtual void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Expression.Accept(this);
            node.ArgumentList.Accept(this);
            AfterVisit(node);
        }

        public virtual void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Expression.Accept(this);
            node.Name.Accept(this);
            AfterVisit(node);
        }

        public virtual void VisitLiteralExpresion(LiteralExpressionSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            Visit(node.Token);
            AfterVisit(node);
        }

        public virtual void VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Modifiers.ForEach(Visit);
            Visit(node.Identifier);
            if (node.Type != null)
            {
                node.Type.Accept(this);
            }
            if (node.Initializer != null)
            {
                node.Initializer.Accept(this);
            }
            AfterVisit(node);
        }

        public virtual void VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Left.Accept(this);
            Visit(node.Operator);
            node.Right.Accept(this);
            AfterVisit(node);
        }

        public virtual void VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Expression.Accept(this);
            AfterVisit(node);
        }

        public virtual void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            Visit(node.Identifier);
            node.Parameters.Accept(this);
            node.Body.Accept(this);
            AfterVisit(node);
        }

        public virtual void VisitBlock(BlockStatementSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Statements.ForEach(n => n.Accept(this));
            AfterVisit(node);
        }

        public virtual void VisitNewExpression(NewExpressionSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Function.Accept(this);
            AfterVisit(node);
        }

        public virtual void VisitVariableStatement(VariableStatementSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Declaration.Accept(this);
            AfterVisit(node);
        }

        public virtual void VisitParameterList(ParameterListSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Parameters.ForEach(n => n.Accept(this));
            AfterVisit(node);
        }

        public virtual void VisitParameter(ParameterSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            Visit(node.Identifier);
            AfterVisit(node);
        }

        public virtual void VisitArgumentList(ArgumentListSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Arguments.ForEach(n => n.Accept(this));
            AfterVisit(node);
        }

        public virtual void VisitArgument(ArgumentSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Expression.Accept(this);
            AfterVisit(node);
        }

        public virtual void VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Expression.Accept(this);
            AfterVisit(node);
        }

        public virtual void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            Visit(node.Identifier);
            node.Members.ForEach(n => n.Accept(this));
            AfterVisit(node);
        }

        public virtual void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            Visit(node.Identifier);
            node.Parameters.Accept(this);
            if (node.Body != null)
            {
                node.Body.Accept(this);
            }
            AfterVisit(node);
        }

        public virtual void VisitMemberDeclaration(MemberDeclarationSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            Visit(node.Identifier);
            AfterVisit(node);
        }

        public virtual void VisitIfStatement(IfStatementSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            node.Condition.Accept(this);
            node.Statement.Accept(this);
            AfterVisit(node);
        }


        public virtual void VisitPredefinedType(PredefinedTypeSyntax node)
        {
            BeforeVisit(node);
            Visit(node);
            Visit(node.Keyword);
            AfterVisit(node);
        }


        public void VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {

            BeforeVisit(node);
            Visit(node);
            node.Left.Accept(this);
            node.Right.Accept(this);
            AfterVisit(node);
        }
    }

}
