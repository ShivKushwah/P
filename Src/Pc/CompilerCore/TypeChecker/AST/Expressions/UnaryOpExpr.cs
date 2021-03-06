using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.Types;

namespace Plang.Compiler.TypeChecker.AST.Expressions
{
    public class UnaryOpExpr : IPExpr
    {
        public UnaryOpExpr(ParserRuleContext sourceLocation, UnaryOpType operation, IPExpr subExpr)
        {
            SourceLocation = sourceLocation;
            Operation = operation;
            SubExpr = subExpr;
            Type = subExpr.Type;
            highSecurityLabel = subExpr.highSecurityLabel;

        }

        public bool highSecurityLabel { get; set; } = false;

        public UnaryOpType Operation { get; }
        public IPExpr SubExpr { get; }

        public ParserRuleContext SourceLocation { get; }

        public PLanguageType Type { get; }
    }
}