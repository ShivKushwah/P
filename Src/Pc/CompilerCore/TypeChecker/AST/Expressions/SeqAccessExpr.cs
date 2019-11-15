using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.Types;

namespace Plang.Compiler.TypeChecker.AST.Expressions
{
    public class SeqAccessExpr : IPExpr
    {
        public SeqAccessExpr(ParserRuleContext sourceLocation, IPExpr seqExpr, IPExpr indexExpr, PLanguageType type)
        {
            SourceLocation = sourceLocation;
            SeqExpr = seqExpr;
            IndexExpr = indexExpr;
            Type = type;
        }

        public bool highSecurityLabel { get; set; } = false;

        public IPExpr SeqExpr { get; }
        public IPExpr IndexExpr { get; }

        public ParserRuleContext SourceLocation { get; }

        public PLanguageType Type { get; }
    }
}