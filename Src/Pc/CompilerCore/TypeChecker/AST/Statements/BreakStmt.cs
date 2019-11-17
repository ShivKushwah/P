using Antlr4.Runtime;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    public class BreakStmt : IPStmt
    {
        public BreakStmt(ParserRuleContext sourceLocation)
        {
            SourceLocation = sourceLocation;
        }

        public bool highSecurityLabel { get; set; } = false;

        public ParserRuleContext SourceLocation { get; }
    }
}