using Antlr4.Runtime;
using System.Collections.Generic;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    public class SecureSendStmt : IPStmt
    {
        public SecureSendStmt(ParserRuleContext sourceLocation, IPExpr machineExpr, IPExpr evt,
            IReadOnlyList<IPExpr> arguments)
        {
            SourceLocation = sourceLocation;
            MachineExpr = machineExpr;
            Evt = evt;
            Arguments = arguments;
            // bool isHighSecurity = false;
            // foreach (IPExpr argument in arguments) {
            //     isHighSecurity = isHighSecurity || argument.highSecurityLabel;
            // }
            // highSecurityLabel = isHighSecurity;
            highSecurityLabel = true; //Since this function only sends to trusted machines, it should be high security and not regarded to leak secrets
        }

        public bool highSecurityLabel { get; set; } = false;

        public IPExpr MachineExpr { get; }
        public IPExpr Evt { get; }
        public IReadOnlyList<IPExpr> Arguments { get; }

        public ParserRuleContext SourceLocation { get; }
    }
}