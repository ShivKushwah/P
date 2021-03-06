using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.AST.Declarations;
using Plang.Compiler.TypeChecker.Types;

namespace Plang.Compiler.TypeChecker.AST.Expressions
{
    public class ThisRefExpr : IStaticTerm<Machine>
    {
        public ThisRefExpr(ParserRuleContext sourceLocation, Machine value)
        {
            SourceLocation = sourceLocation;
            Value = value;
            Type = new ForeignType("machine_handle");//new PermissionType(value);
        }

        public bool highSecurityLabel { get; set; } = false;

        public Machine Value { get; }

        public ParserRuleContext SourceLocation { get; }

        public PLanguageType Type { get; }
    }
}