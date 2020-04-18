using Plang.Compiler.TypeChecker.AST.Declarations;
using System;
using System.Collections.Generic;

namespace Plang.Compiler.TypeChecker.Types
{
    public abstract class PLanguageType
    {
        protected PLanguageType(TypeKind kind)
        {
            TypeKind = kind;
        }

        public bool highSecurityLabel { get; set; } = false; //Overall type -> (int, secure_int) -> overall is a highSecurityLabel and should not be leaked
        public bool allSubtypesAreHighSecurityLabel { get; set; } = false; //Stronger property needed for Trusted Send Observational 
        // Determinism proof -> (int, secure_int) = false, (secure_int, secure_int) = true

        /// <summary>
        ///     The category of type this is (eg. sequence, map, base)
        /// </summary>
        public TypeKind TypeKind { get; }

        /// <summary>
        ///     Original representation of the type in P.
        /// </summary>
        public abstract string OriginalRepresentation { get; }

        /// <summary>
        ///     Representation of the type with typedefs and event sets expanded.
        /// </summary>
        public abstract string CanonicalRepresentation { get; }

        /// <summary>
        ///     represents the permissions embedded in a type
        /// </summary>
        public abstract Lazy<IReadOnlyList<PEvent>> AllowedPermissions { get; }

        public abstract bool IsAssignableFrom(PLanguageType otherType);

        public bool IsSameTypeAs(PLanguageType otherType)
        {
            return IsAssignableFrom(otherType) && otherType.IsAssignableFrom(this);
        }

        public override bool Equals(object obj)
        {
            return !(obj is null) && (this == obj || obj.GetType() == GetType() && IsSameTypeAs((PLanguageType)obj));
        }

        public override int GetHashCode()
        {
            return CanonicalRepresentation.GetHashCode();
        }

        public abstract PLanguageType Canonicalize();

        public static bool TypeIsOfKind(PLanguageType type, TypeKind kind)
        {
            return type.Canonicalize().TypeKind.Equals(kind);
        }
    }
}