
using EcmaScript.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript
{
    public class Parser
    {
        private Scanner Scanner;

        private SyntaxToken CurrentToken;

        public Parser(Scanner scanner)
        {
            this.Scanner = scanner;
        }
        private void NextToken()
        {
            CurrentToken = Scanner.Scan();
        }

        private CompilationUnitSyntax ParseCompilationUnit()
        {
            CompilationUnitSyntax unit = new CompilationUnitSyntax();
            NextToken();


            while (true)
            {
                if (ParseOptional(SyntaxKind.EndOfFileToken))
                {
                    break;
                }
                unit.Statements.Add(ParseStatement());
            }

            return unit;
            
        }

        private StatementSyntax ParseStatement()
        {
            switch (CurrentToken.Kind)
            {
                case SyntaxKind.DeclareKeyword:
                    {
                        ParseExpected(SyntaxKind.DeclareKeyword);
                        VariableStatementSyntax node = ParseVariableStatement();
                        node.Declaration.Modifiers.Add(new SyntaxToken(SyntaxKind.DeclareKeyword));
                        return node;
                    }
                case SyntaxKind.IfKeyword:
                    {
                        return ParseIfStatement();
                    }
                case SyntaxKind.InterfaceKeyword:
                    {
                        return ParseInterfaceDeclaration();
                    }
                case SyntaxKind.FunctionKeyword:
                    {
                        return ParseFunctionDeclaration();
                    }
                case SyntaxKind.VarKeyword:
                    {
                        return ParseVariableStatement();
                    }
                    break;
                case SyntaxKind.OpenBraceToken:
                    {
                        return ParseBlockStatement();    
                    }
                    break;
                default:
                    {
                        return ParseExpressionStatement();
                    }
                    break;
            }
        }

        private IfStatementSyntax ParseIfStatement()
        {
            IfStatementSyntax node = new IfStatementSyntax();
            ParseExpected(SyntaxKind.IfKeyword);
            ParseExpected(SyntaxKind.OpenParenthesisToken);
            node.Condition = ParseExpression();
            ParseExpected(SyntaxKind.CloseParenthesisToken);

            node.Statement = ParseStatement();

            if (ParseOptional(SyntaxKind.ElseKeyword))
            {
                throw new NotImplementedException();
            }

            return node;
        }

        private ParameterListSyntax ParseParameterList()
        {
            ParameterListSyntax node = new ParameterListSyntax();
            ParseExpected(SyntaxKind.OpenParenthesisToken);
            while (true)
            {
                if (ParseOptional(SyntaxKind.CloseParenthesisToken))
                {
                    break;
                }

                ParameterSyntax parameterNode = new ParameterSyntax();
                parameterNode.Identifier = ParseExpected(SyntaxKind.IdentifierToken);
                node.Parameters.Add(parameterNode);

                if (ParseOptional(SyntaxKind.CommaToken))
                {
                    ParseExpected(SyntaxKind.CloseParenthesisToken);
                    break;
                }
            }
            return node;
        }

        private InterfaceDeclarationSyntax ParseInterfaceDeclaration()
        {
            var node = new InterfaceDeclarationSyntax();
            ParseExpected(SyntaxKind.InterfaceKeyword);
            node.Identifier = ParseExpected(SyntaxKind.IdentifierToken);
            node.Members = ParseMembers();

            return node;
        }

        private List<MemberDeclarationSyntax> ParseMembers()
        {
            List<MemberDeclarationSyntax> members = new List<MemberDeclarationSyntax>();
            ParseExpected(SyntaxKind.OpenBraceToken);
            while (true)
            {
                if (ParseOptional(SyntaxKind.CloseBraceToken))
                {
                    break;
                }

                members.Add(ParseMember());
            }
            return members;
        }

        private MemberDeclarationSyntax ParseMember()
        {
            var identifier = ParseExpected(SyntaxKind.IdentifierToken);

            MemberDeclarationSyntax member;
            if (CurrentToken.Kind == SyntaxKind.OpenParenthesisToken)
            {
                member = new MethodDeclarationSyntax();
                ((MethodDeclarationSyntax)member).Parameters = ParseParameterList();
                if (ParseOptional(SyntaxKind.OpenBraceToken))
                {
                    ((MethodDeclarationSyntax)member).Body = ParseBlockStatement();
                }
            }
            else
            {
                throw new NotImplementedException();
            }
            member.Identifier = identifier;

            ParseOptional(SyntaxKind.SemicolonToken);

            return member;
        }

        private FunctionDeclarationSyntax ParseFunctionDeclaration()
        {
            var node = new FunctionDeclarationSyntax();

            ParseExpected(SyntaxKind.FunctionKeyword);

            node.Identifier = ParseExpected(SyntaxKind.IdentifierToken);
            
            node.Parameters = ParseParameterList();

            node.Body = ParseBlockStatement();

            ParseOptional(SyntaxKind.SemicolonToken);

            return node;
        }


        private VariableStatementSyntax ParseVariableStatement()
        {
            var node = new VariableStatementSyntax();
            node.Declaration = ParseVariableDeclaration();
            ParseOptional(SyntaxKind.SemicolonToken);
            return node;   
        }

        private VariableDeclarationSyntax ParseVariableDeclaration()
        {
            var variableExpression = new VariableDeclarationSyntax();
            ParseExpected(SyntaxKind.VarKeyword);

            variableExpression.Identifier = ParseExpected(SyntaxKind.IdentifierToken);
            if (ParseOptional(SyntaxKind.ColonToken))
            {
                var type = CurrentToken.Kind;
                NextToken();
                variableExpression.Type = new PredefinedTypeSyntax() { Keyword = new SyntaxToken(type) };
            }
            if (ParseOptional(SyntaxKind.EqualsToken)) {
                variableExpression.Initializer = ParseInitializerExpression();
            }

            return variableExpression;
        }

        private ExpressionSyntax ParseInitializerExpression()
        {
            return ParseAssignmentExpression();
        }




        // Statements

        private BlockStatementSyntax ParseBlockStatement()
        {
            ParseExpected(SyntaxKind.OpenBraceToken);
            var node = new BlockStatementSyntax();
            node.Statements = new List<StatementSyntax>();
            while (true)
            {
                if (ParseOptional(SyntaxKind.CloseBraceToken))
                {
                    break;
                }
                node.Statements.Add(ParseStatement());
            }
            ParseOptional(SyntaxKind.SemicolonToken);
            return node;
        }

        private ExpressionStatementSyntax ParseExpressionStatement()
        {
            var node = new ExpressionStatementSyntax();
            node.Expression = ParseExpression();
            ParseOptional(SyntaxKind.SemicolonToken);
            return node;   
        }

        // Expression

        private ExpressionSyntax ParseExpression()
        {
            return ParseAssignmentExpression(); 
        }

        private ArgumentListSyntax ParseArgumentList()
        {
            ArgumentListSyntax node = new ArgumentListSyntax();
            
            while (true)
            {
                if (ParseOptional(SyntaxKind.CloseParenthesisToken))
                {
                    break;
                }
                ArgumentSyntax argument = new ArgumentSyntax();
                argument.Expression = ParseExpression();
                node.Arguments.Add(argument);
                if (!ParseOptional(SyntaxKind.CommaToken))
                {
                    ParseExpected(SyntaxKind.CloseParenthesisToken);
                    break;
                }
            }
            return node;
        }
        private ExpressionSyntax ParseCallAndAccess(ExpressionSyntax identifier)
        {
            ExpressionSyntax expression = identifier;
            while (true)
            {
                if (ParseOptional(SyntaxKind.DotToken))
                {
                    var memberAccess = new MemberAccessExpressionSyntax();
                    memberAccess.Expression = identifier;
                    memberAccess.Name = ParseIdentifierExpression();

                    expression = memberAccess;
                    continue;
                }

                if (ParseOptional(SyntaxKind.OpenParenthesisToken))
                {
                    var callExpression = new InvocationExpressionSyntax();
                    callExpression.Expression = expression;
                    callExpression.ArgumentList = ParseArgumentList();

                    expression = callExpression;
                    continue;
                }

                return expression;
            }

            throw new NotImplementedException();
        }

        private ExpressionSyntax ParseBinaryExpression(ExpressionSyntax expression, int minPrecedence)
        {
            while (true)
            {
                var precedence = GetOperatorPrecedence();
                if (precedence != -1 && precedence > minPrecedence)
                {
                    var op = CurrentToken.Kind;

                    NextToken();

                    var binaryExpression = new BinaryExpressionSyntax();
                    binaryExpression.Left = expression;
                    binaryExpression.Right = ParseBinaryExpression(ParseUnaryExpression(), precedence);
                    binaryExpression.Operator = new SyntaxToken(op);
                    expression = binaryExpression;

                    continue;
                }
                return expression;
            }
        }

        private int GetOperatorPrecedence()
        {
            switch (CurrentToken.Kind)
            {
                case SyntaxKind.EqualsEqualsToken:
                    return 1;
                case SyntaxKind.MinusToken:
                case SyntaxKind.PlusToken:
                    return 2;
                case SyntaxKind.AsteriskToken:
                    return 3;
                default:
                    return -1;
            }
        }

        private ExpressionSyntax ParseNewExpression()
        {
            var node = new NewExpressionSyntax();
            ParseExpected(SyntaxKind.NewKeyword);
            node.Function = ParseCallAndAccess(ParseExpression());
            return node;
        }

        private ExpressionSyntax ParseParenthesisExpression()
        {
            ParseExpected(SyntaxKind.OpenParenthesisToken);
            var node = new ParenthesizedExpressionSyntax();
            node.Expression = ParseExpressionStatement();
            ParseExpected(SyntaxKind.CloseParenthesisToken);
            return node;
        }

        private ExpressionSyntax ParseAssignmentExpression()
        {
            var node = ParseBinaryExpression(ParseUnaryExpression(), 0);

            if (IsLeftHandSideExpression(node.Kind) && CurrentToken.Kind == SyntaxKind.EqualsToken)
            {
                var assignmentExpression = new AssignmentExpressionSyntax();
                
                assignmentExpression.Left = node;
                ParseExpected(SyntaxKind.EqualsToken);
                assignmentExpression.Right = ParseAssignmentExpression();

                node = assignmentExpression;
            }


            return node;
        }

        private bool IsLeftHandSideExpression(SyntaxKind kind)
        {
            switch (kind)
            {
                    case SyntaxKind.NewExpression:
                    case SyntaxKind.InvocationExpression:
                    case SyntaxKind.IdentifierExpression:
                    case SyntaxKind.NumericLiteral:
                    case SyntaxKind.StringLiteral:
                    case SyntaxKind.MemberAccessExpression:
                        return true;
                default:
                        return false;
            }
        }

        private ExpressionSyntax ParseUnaryExpression()
        {
            switch (CurrentToken.Kind)
            {
                case SyntaxKind.FunctionKeyword:
                    {
                        throw new NotImplementedException();
                    }
                    break;
                case SyntaxKind.NewKeyword:
                    {
                        return ParseNewExpression();
                    }
                    break;
                case SyntaxKind.OpenParenthesisToken:
                    {
                        return ParseParenthesisExpression();
                    }
                    break;
                case SyntaxKind.IdentifierToken:
                    {
                        var identifier = ParseIdentifierExpression();
                        return ParseCallAndAccess(identifier);
                    }
                    break;
                case SyntaxKind.NumericLiteral:
                case SyntaxKind.StringLiteral:
                    {
                        return ParseLiteral();
                    }
                    break;
                default:
                    throw new NotImplementedException("Unexpected token " + CurrentToken.Kind);
            }
        }

        private LiteralExpressionSyntax ParseLiteral()
        {
            var node = new LiteralExpressionSyntax();
            node.Token = Scanner.Token;
            NextToken();
            return node;
        }

        private IdentifierExpressionSyntax ParseIdentifierExpression()
        {
            var identifier = new IdentifierExpressionSyntax(Scanner.Token);
            NextToken();
            return identifier;
        }


        private SyntaxToken ParseExpected(SyntaxKind expected)
        {
            var token = CurrentToken;
            NextToken();

            if (token.Kind != expected)
            {
                //TODO: return new SyntaxToken(expected) IsMising = true
                throw new NotSupportedException();
            }


            return token;
        }

        private bool ParseOptional(SyntaxKind expected)
        {
            if (CurrentToken.Kind == expected)
            {
                NextToken();
                return true;
            }
            return false;
        }

        public SyntaxTree GetSyntaxTree()
        {
            return new SyntaxTree() {Root = ParseCompilationUnit()};
        }
    }
}
