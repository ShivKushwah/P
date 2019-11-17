using Antlr4.Runtime;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    public class AssertStmt : IPStmt
    {
        public AssertStmt(ParserRuleContext sourceLocation, IPExpr assertion, string message)
        {
            SourceLocation = sourceLocation;
            Assertion = assertion;
            Message = message;
        }

        public bool highSecurityLabel { get; set; } = false;

        public IPExpr Assertion { get; }
        public string Message { get; }

        public ParserRuleContext SourceLocation { get; }
    }
}