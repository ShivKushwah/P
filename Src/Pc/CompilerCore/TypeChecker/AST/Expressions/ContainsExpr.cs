using Antlr4.Runtime;
using Plang.Compiler.TypeChecker.Types;

namespace Plang.Compiler.TypeChecker.AST.Expressions
{
    public class ContainsExpr : IPExpr
    {
        public ContainsExpr(ParserRuleContext sourceLocation, IPExpr item, IPExpr collection)
        {
            SourceLocation = sourceLocation;
            Item = item;
            Collection = collection;
            highSecurityLabel = collection.Type.allSubtypesAreHighSecurityLabel;
            if (highSecurityLabel) {
                Type = PrimitiveType.Secure_Bool;
            } else {
                Type = PrimitiveType.Bool;
            }
        }

        public bool highSecurityLabel { get; set; } = false;

        public IPExpr Item { get; }
        public IPExpr Collection { get; }

        public PLanguageType Type { get; set; }
        public ParserRuleContext SourceLocation { get; }
    }
}