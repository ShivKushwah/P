using Antlr4.Runtime;
using System.Collections.Generic;

namespace Plang.Compiler.TypeChecker.AST.Statements
{
    public class UntrustedSendStmt : IPStmt
    {
        public UntrustedSendStmt(ParserRuleContext sourceLocation, IPExpr machineExpr, IPExpr evt,
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
            highSecurityLabel = false; //Since this function only sends to untrusted machines, it should be low security and regarded to leak secrets
        }

        public bool highSecurityLabel { get; set; } = false;

        public IPExpr MachineExpr { get; }
        public IPExpr Evt { get; }
        public IReadOnlyList<IPExpr> Arguments { get; }

        public ParserRuleContext SourceLocation { get; }
    }
}