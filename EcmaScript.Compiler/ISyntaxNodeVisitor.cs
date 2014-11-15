using EcmaScript.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript
{
    public interface ISyntaxVisitor
    {
        void VisitCompilationUnit(CompilationUnitSyntax node);

        void VisitIdentifierExpression(IdentifierExpressionSyntax node);

        void VisitInvocationExpression(InvocationExpressionSyntax node);

        void VisitMemberAccessExpression(MemberAccessExpressionSyntax node);

        void VisitLiteralExpresion(LiteralExpressionSyntax node);

        void VisitVariableDeclaration(VariableDeclarationSyntax node);

        void VisitBinaryExpression(BinaryExpressionSyntax node);

        void VisitParenthesizedExpression(ParenthesizedExpressionSyntax node);

        void VisitFunctionDeclaration(FunctionDeclarationSyntax node);

        void VisitBlock(BlockStatementSyntax node);

        void VisitNewExpression(NewExpressionSyntax node);

        void VisitVariableStatement(VariableStatementSyntax node);
        
        void VisitParameterList(ParameterListSyntax node);

        void VisitParameter(ParameterSyntax node);

        void VisitArgumentList(ArgumentListSyntax node);

        void VisitArgument(ArgumentSyntax node);

        void VisitExpressionStatement(ExpressionStatementSyntax node);

        void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node);

        void VisitMethodDeclaration(MethodDeclarationSyntax node);

        void VisitMemberDeclaration(MemberDeclarationSyntax node);

        void VisitIfStatement(IfStatementSyntax node);

        void VisitPredefinedType(PredefinedTypeSyntax node);

        void VisitAssignmentExpression(AssignmentExpressionSyntax node);
    }
}
