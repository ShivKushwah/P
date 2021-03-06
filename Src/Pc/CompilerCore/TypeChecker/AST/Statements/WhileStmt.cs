using Antlr4.Runtime;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    public class WhileStmt : IPStmt
    {
        public WhileStmt(ParserRuleContext sourceLocation, IPExpr condition, IPStmt body)
        {
            SourceLocation = sourceLocation;
            Condition = condition;
            Body = CompoundStmt.FromStatement(body);
            highSecurityLabel = condition.highSecurityLabel;
        }

        public bool highSecurityLabel { get; set; } = false;

        public IPExpr Condition { get; }
        public CompoundStmt Body { get; }

        public ParserRuleContext SourceLocation { get; }
    }
}