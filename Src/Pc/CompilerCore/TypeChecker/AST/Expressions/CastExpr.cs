using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.Types;

namespace Plang.Compiler.TypeChecker.AST.Expressions
{
    public class CastExpr : IPExpr
    {
        public CastExpr(ParserRuleContext sourceLocation, IPExpr subExpr, PLanguageType type)
        {
            Type = type;
            SourceLocation = sourceLocation;
            SubExpr = subExpr;
            highSecurityLabel = type.highSecurityLabel;
        }
        
        public bool highSecurityLabel { get; set; } = false;

        public IPExpr SubExpr { get; }
        public PLanguageType Type { get; }
        public ParserRuleContext SourceLocation { get; }
    }
}