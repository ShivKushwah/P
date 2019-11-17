using Antlr4.Runtime;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    public class IfStmt : IPStmt
    {
        public IfStmt(ParserRuleContext sourceLocation, IPExpr condition, IPStmt thenBranch, IPStmt elseBranch)
        {
            SourceLocation = sourceLocation;
            Condition = condition;
            highSecurityLabel = condition.highSecurityLabel;
            ThenBranch = CompoundStmt.FromStatement(thenBranch);
            ElseBranch = elseBranch == null ? null : CompoundStmt.FromStatement(elseBranch);
        }

        public bool highSecurityLabel { get; set; } = false;

        public IPExpr Condition { get; }
        public CompoundStmt ThenBranch { get; }
        public CompoundStmt ElseBranch { get; }

        public ParserRuleContext SourceLocation { get; }
    }
}