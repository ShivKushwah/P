using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.Types;

namespace Plang.Compiler.TypeChecker.AST.Expressions
{
    public class FairNondetExpr : IPExpr
    {
        public FairNondetExpr(ParserRuleContext sourceLocation)
        {
            SourceLocation = sourceLocation;
        }

        public bool highSecurityLabel { get; set; } = false;

        public ParserRuleContext SourceLocation { get; }

        public PLanguageType Type { get; } = PrimitiveType.Bool;
    }
}