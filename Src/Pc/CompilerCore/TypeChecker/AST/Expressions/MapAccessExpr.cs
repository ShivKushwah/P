using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.Types;

namespace Plang.Compiler.TypeChecker.AST.Expressions
{
    public class MapAccessExpr : IPExpr
    {
        public MapAccessExpr(ParserRuleContext sourceLocation, IPExpr mapExpr, IPExpr indexExpr, PLanguageType type)
        {
            SourceLocation = sourceLocation;
            MapExpr = mapExpr;
            IndexExpr = indexExpr;
            Type = type;
            highSecurityLabel = type.highSecurityLabel;
        }

        public bool highSecurityLabel { get; set; }

        public IPExpr MapExpr { get; }
        public IPExpr IndexExpr { get; }

        public ParserRuleContext SourceLocation { get; }
        public PLanguageType Type { get; }
    }
}