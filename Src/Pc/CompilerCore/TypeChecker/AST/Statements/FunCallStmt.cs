using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.AST.Declarations;
using System.Collections.Generic;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    public class FunCallStmt : IPStmt
    {
        public FunCallStmt(ParserRuleContext sourceLocation, Function function, IReadOnlyList<IPExpr> argsList)
        {
            SourceLocation = sourceLocation;
            Function = function;
            ArgsList = argsList;
        }
        
        public bool highSecurityLabel { get; set; } = false;

        public Function Function { get; }
        public IReadOnlyList<IPExpr> ArgsList { get; }

        public ParserRuleContext SourceLocation { get; }
    }
}