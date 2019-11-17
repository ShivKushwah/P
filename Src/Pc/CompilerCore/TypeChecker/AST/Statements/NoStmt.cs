using Antlr4.Runtime;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    public class NoStmt : IPStmt
    {
        public NoStmt(ParserRuleContext sourceLocation)
        {
            SourceLocation = sourceLocation;
        }

        public bool highSecurityLabel { get; set; } = false;

        public ParserRuleContext SourceLocation { get; }
    }
}