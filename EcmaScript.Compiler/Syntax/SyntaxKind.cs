using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript.Syntax
{

    public enum SyntaxKind
    {
        StringLiteral,
        NumericLiteral,

        PlusToken,
        AsteriskToken,
        MinusToken,
        EqualsToken,
        EqualsEqualsToken,
        DotToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        CommaToken,
        SemicolonToken,
        EndOfFileToken,
        OpenBraceToken,
        CloseBraceToken,
        ColonToken,
        IdentifierToken,

        NumberKeyword,
        VarKeyword,
        FunctionKeyword,
        DeclareKeyword,
        NewKeyword,
        InterfaceKeyword,
        IfKeyword,
        ElseKeyword,
        AnyKeyword,


        VariableDeclaration,
        FunctionDeclaration,
        InterfaceDeclaration,
        MemberDeclaration,
        MethodDeclaration,

        IdentifierExpression,
        ParenthesizedExpression,
        MemberAccessExpression,
        NewExpression,
        LiteralExpression,
        BinaryExpression,
        InvocationExpression,
        AssignmentExpression,

        ExpressionStatement,
        VariableStatement,
        BlockStatement,
        IfStatement,

        CompilationUnit,
        ParameterList,
        Parameter,
        ArgumentList,
        Argument,
        PredefinedType,
        ReferenceType,
   }

}
