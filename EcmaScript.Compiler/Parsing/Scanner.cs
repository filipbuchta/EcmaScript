using EcmaScript.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcmaScript
{
    public class Scanner
    {
        public int Position;
        public int StartPosition;

        public int Length
        {
            get { return (int)SourceCode.Length; }
        }

        public SyntaxToken Token;
        
        private string SourceCode;

        public Scanner(string sourceCode)
        {
            this.SourceCode = sourceCode;
        }

        private char GetChar(int position)
        {
            return SourceCode[position];
        }
        private string GetString(int startPosition, int endPosition)
        {
            return SourceCode.Substring(startPosition, endPosition - startPosition);
        }

        public SyntaxToken Scan()
        {
            while (true)
            {
                StartPosition = Position;

                if (Position == Length)
                {
                    Token.Kind = SyntaxKind.EndOfFileToken;
                    return Token;
                }
                var ch = GetChar(Position);
                switch (ch)
                {
                    case ':':
                        {
                            Position++;
                            Token.Kind = SyntaxKind.ColonToken;
                            return Token;
                        }
                        break;
                    case '*':
                        {
                            Position++;
                            Token.Kind = SyntaxKind.AsteriskToken;
                            return Token;
                        }
                        break;
                    case '+':
                        {
                            Position++;
                            Token.Kind = SyntaxKind.PlusToken;
                            return Token;
                        }
                        break;
                    case '-':
                        {
                            Position++;
                            Token.Kind = SyntaxKind.MinusToken;
                            return Token;
                        }
                        break;
                    case '=':
                        {
                            Position++;
                            if (GetChar(Position) == '=')
                            {
                                Position++;
                                Token.Kind = SyntaxKind.EqualsEqualsToken;
                            }
                            else
                            {
                                Token.Kind = SyntaxKind.EqualsToken;
                            }
                            return Token;
                        }
                        break;
                    case ';':
                        {
                            Position++;
                            Token.Kind = SyntaxKind.SemicolonToken;
                            return Token;
                        }
                        break;
                    case '\'':
                    case '"':
                        {
                            char quote = ch;
                            Position++;
                            while (Position < Length && quote != (ch = GetChar(Position)))
                            {
                                Position++;
                            }
                            Position++;
                            Token.Value = GetString(StartPosition + 1, Position - 1);
                            Token.Kind = SyntaxKind.StringLiteral;
                            return Token;
                        }
                        break;
                    case '.':
                        Position++;
                        Token.Kind = SyntaxKind.DotToken;
                        return Token;

                    case '(':
                        Position++;
                        Token.Kind = SyntaxKind.OpenParenthesisToken;
                        return Token;

                    case ')':
                        Position++;
                        Token.Kind = SyntaxKind.CloseParenthesisToken;
                        return Token;
                    case '{':
                        Position++;
                        Token.Kind = SyntaxKind.OpenBraceToken;
                        return Token;

                    case '}':
                        Position++;
                        Token.Kind = SyntaxKind.CloseBraceToken;
                        return Token;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        {
                            while (Char.IsDigit(GetChar(Position)))
                            {
                                Position++;
                            }

                            Token.Value = int.Parse(GetString(StartPosition, Position));
                            Token.Kind = SyntaxKind.NumericLiteral;
                            return Token;
                        }
                        break;
                    default:
                        {
                            if (IsIdentifierStart(ch))
                            {
                                Position++;
                                while (Position < Length && IsIdentifierPart(ch = GetChar(Position)))
                                {
                                    Position++;
                                }

                                Token.Value = GetString(StartPosition , Position);
                                if (Token.Value.Equals("var"))
                                {
                                    Token.Kind = SyntaxKind.VarKeyword;
                                }
                                else if (Token.Value.Equals("function"))
                                {
                                    Token.Kind = SyntaxKind.FunctionKeyword;
                                }
                                else if (Token.Value.Equals("declare"))
                                {
                                    Token.Kind = SyntaxKind.DeclareKeyword;
                                }
                                else if (Token.Value.Equals("interface"))
                                {
                                    Token.Kind = SyntaxKind.InterfaceKeyword;
                                }
                                else if (Token.Value.Equals("new"))
                                {
                                    Token.Kind = SyntaxKind.NewKeyword;
                                }
                                else if (Token.Value.Equals("if"))
                                {
                                    Token.Kind = SyntaxKind.IfKeyword;
                                }
                                else if (Token.Value.Equals("else"))
                                {
                                    Token.Kind = SyntaxKind.ElseKeyword;
                                }
                                else if (Token.Value.Equals("any"))
                                {
                                    Token.Kind = SyntaxKind.AnyKeyword;
                                }
                                else if (Token.Value.Equals("number"))
                                {
                                    Token.Kind = SyntaxKind.NumberKeyword;
                                }
                                else 
                                {
                                    Token.Kind = SyntaxKind.IdentifierToken;
                                }
                                return Token;
                            }
                            else if (Char.IsWhiteSpace(ch))
                            {
                                Position++;
                            }
                            else
                            {
                                throw new NotSupportedException();
                            }
                        }
                        break;
                }
            }

        }

        private bool IsIdentifierPart(char ch)
        {
            return IsIdentifierStart(ch) || (ch >= '0' && ch <= '9');
        }
        private bool IsIdentifierStart(char ch)
        {
            return (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || ch == '$' || ch == '_';
        }
    }
}
