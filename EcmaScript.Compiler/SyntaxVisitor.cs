using EcmaScript.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript
{
    public class SyntaxVisitor : ISyntaxVisitor
    {
        public virtual void VisitCompilationUnit(CompilationUnitSyntax node) { }
        public virtual void VisitIdentifierExpression(IdentifierExpressionSyntax node) { }
        public virtual void VisitInvocationExpression(InvocationExpressionSyntax node) { }
        public virtual void VisitMemberAccessExpression(MemberAccessExpressionSyntax node) { }
        public virtual void VisitLiteralExpresion(LiteralExpressionSyntax node) { }
        public virtual void VisitVariableDeclaration(VariableDeclarationSyntax node) { }
        public virtual void VisitBinaryExpression(BinaryExpressionSyntax node) { }
        public virtual void VisitParenthesizedExpression(ParenthesizedExpressionSyntax node) { }
        public virtual void VisitFunctionDeclaration(FunctionDeclarationSyntax node) { }
        public virtual void VisitBlock(BlockStatementSyntax node) { }
        public virtual void VisitNewExpression(NewExpressionSyntax node) { }
        public virtual void VisitVariableStatement(VariableStatementSyntax node) { }
        public virtual void VisitParameterList(ParameterListSyntax node) { }
        public virtual void VisitParameter(ParameterSyntax node) { }
        public virtual void VisitArgumentList(ArgumentListSyntax node) { }
        public virtual void VisitArgument(ArgumentSyntax node) { }
        public virtual void VisitExpressionStatement(ExpressionStatementSyntax node) { }
        public virtual void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node) { }
        public virtual void VisitMethodDeclaration(MethodDeclarationSyntax node) { }
        public virtual void VisitMemberDeclaration(MemberDeclarationSyntax node) { }
        public virtual void VisitIfStatement(IfStatementSyntax node) { }
        public virtual void VisitPredefinedType(PredefinedTypeSyntax node) { }
        public virtual void VisitAssignmentExpression(AssignmentExpressionSyntax node) { }
    }

}
