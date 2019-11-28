using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.Types;
using System.Diagnostics;

namespace Plang.Compiler.TypeChecker.AST.Expressions
{
    public class BinOpExpr : IPExpr
    {
        public BinOpExpr(ParserRuleContext sourceLocation, BinOpType operation, IPExpr lhs, IPExpr rhs)
        {
            SourceLocation = sourceLocation;
            Operation = operation;
            Lhs = lhs;
            Rhs = rhs;

            if (lhs.highSecurityLabel || rhs.highSecurityLabel) {
                highSecurityLabel = true;
            } else {
                highSecurityLabel = false;
            }
            
            if (IsArithmetic(operation))
            {
                Debug.Assert(Lhs.Type.IsSameTypeAs(Rhs.Type));
                if (highSecurityLabel) {
                    Type = PrimitiveType.Secure_Int; //TODO Shiv modify this when I add secure_float
                } else {
                    Type = Lhs.Type;
                }
            }
            else
            {
                if (highSecurityLabel) {
                    Type = PrimitiveType.Secure_Bool;
                } else {
                    Type = PrimitiveType.Bool;
                }
            }
        }

        public bool highSecurityLabel { get; set; } = false;

        public BinOpType Operation { get; }
        public IPExpr Lhs { get; }
        public IPExpr Rhs { get; }

        public ParserRuleContext SourceLocation { get; }

        public PLanguageType Type { get; }

        private static bool IsArithmetic(BinOpType operation)
        {
            return operation == BinOpType.Add || operation == BinOpType.Sub || operation == BinOpType.Mul ||
                   operation == BinOpType.Div;
        }
    }
}