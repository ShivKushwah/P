using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.AST.Declarations;
using System.Collections.Generic;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    public class CtorStmt : IPStmt
    {
        public CtorStmt(ParserRuleContext sourceLocation, Interface @interface, IReadOnlyList<IPExpr> arguments, IPExpr otherMachineHandleWithLocInfo)
        {
            SourceLocation = sourceLocation;
            Interface = @interface;
            Arguments = arguments;
            otherMachineHandleWithLocationInfo = otherMachineHandleWithLocInfo;
        }

        public bool highSecurityLabel { get; set; } = false;

        public Interface Interface { get; }
        public IReadOnlyList<IPExpr> Arguments { get; }

        public ParserRuleContext SourceLocation { get; }

        public IPExpr otherMachineHandleWithLocationInfo { get; }
    }
}