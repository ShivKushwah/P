using Antlr4.Runtime;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    public class ContinueStmt : IPStmt
    {
        public ContinueStmt(ParserRuleContext sourceLocation)
        {
            SourceLocation = sourceLocation;
        }

        public bool highSecurityLabel { get; set; } = false;

        public ParserRuleContext SourceLocation { get; }
    }
}