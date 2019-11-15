using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.AST.Declarations;
using Plang.Compiler.TypeChecker.Types;
using System.Collections.Generic;

namespace Plang.Compiler.TypeChecker.AST.Expressions
{
    public class CtorExpr : IPExpr
    {
        public CtorExpr(ParserRuleContext sourceLocation, Interface @interface, IReadOnlyList<IPExpr> arguments)
        {
            Interface = @interface;
            Arguments = arguments;
            SourceLocation = sourceLocation;
            Type = new PermissionType(Interface);
        }

        public bool highSecurityLabel { get; set; } = false;

        public Interface Interface { get; }
        public IReadOnlyList<IPExpr> Arguments { get; }

        public PLanguageType Type { get; }
        public ParserRuleContext SourceLocation { get; }
    }
}