using Antlr4.Runtime;
using System.Collections.Generic;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    public class CompoundStmt : IPStmt
    {
        private readonly List<IPStmt> statements;

        public CompoundStmt(ParserRuleContext sourceLocation, IEnumerable<IPStmt> statements)
        {
            SourceLocation = sourceLocation;
            this.statements = new List<IPStmt>();
            bool isHighSecurity = true;
            foreach (IPStmt statement in statements)
            {
                isHighSecurity = isHighSecurity && statement.highSecurityLabel;
                if (statement is CompoundStmt compound)
                {
                    this.statements.AddRange(compound.statements);
                }
                else if (!(statement is NoStmt))
                {
                    this.statements.Add(statement);
                }
            }
            highSecurityLabel = isHighSecurity;
        }

        public bool highSecurityLabel { get; set; } = false;

        public IReadOnlyList<IPStmt> Statements => statements;

        public ParserRuleContext SourceLocation { get; }

        public static CompoundStmt FromStatement(IPStmt statement)
        {
            if (statement is CompoundStmt compound)
            {
                return compound;
            }

            return new CompoundStmt(statement.SourceLocation, new[] { statement });
        }
    }
}