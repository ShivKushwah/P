using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.AST.Declarations;
using Plang.Compiler.TypeChecker.Types;

namespace Plang.Compiler.TypeChecker.AST.Expressions
{
    public class ThisSecureRefExpr : IStaticTerm<Machine>
    {
        public ThisSecureRefExpr(ParserRuleContext sourceLocation, Machine value)
        {
            SourceLocation = sourceLocation;
            Value = value;
            Type = new ForeignType("secure_machine_handle");//new PermissionType(value);
        }

        public bool highSecurityLabel { get; set; } = false;

        public Machine Value { get; }

        public ParserRuleContext SourceLocation { get; }

        public PLanguageType Type { get; }
    }
}