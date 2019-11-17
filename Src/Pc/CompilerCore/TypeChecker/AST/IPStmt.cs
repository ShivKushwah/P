namespace Plang.Compiler.TypeChecker.AST
{
    public interface IPStmt : IPAST
    {
        bool highSecurityLabel { get; set; }
    }
}