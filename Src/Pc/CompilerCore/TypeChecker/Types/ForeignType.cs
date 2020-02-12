using Plang.Compiler.TypeChecker.AST.Declarations;
using System;
using System.Collections.Generic;

namespace Plang.Compiler.TypeChecker.Types
{
    public class ForeignType : PLanguageType
    {
        public ForeignType(string name) : base(TypeKind.Foreign)
        {
            OriginalRepresentation = name;
            CanonicalRepresentation = name;
        }

        public override string OriginalRepresentation { get; }
        public override string CanonicalRepresentation { get; }

        public override Lazy<IReadOnlyList<PEvent>> AllowedPermissions { get; } = null;

        public override bool IsAssignableFrom(PLanguageType otherType)
        {
            //NOTE I added below
            if (CanonicalRepresentation == "secure_machine_handle") {
                bool check = (otherType.Canonicalize() is ForeignType other &&
                   CanonicalRepresentation == other.CanonicalRepresentation) 
                   || (otherType.CanonicalRepresentation.Equals("machine") && otherType.highSecurityLabel) ||
                           (otherType.CanonicalRepresentation.Equals("null") && otherType.highSecurityLabel) ||    
                           (otherType is PermissionType && otherType.highSecurityLabel);
                return check;


            } else if (CanonicalRepresentation == "machine_handle") {
                return (otherType.Canonicalize() is ForeignType other &&
                   CanonicalRepresentation == other.CanonicalRepresentation) 
                   || otherType.CanonicalRepresentation.Equals("machine") 
                   || otherType.CanonicalRepresentation.Equals("null")
                    ||   otherType is PermissionType; 
            } else {
                return (otherType.Canonicalize() is ForeignType other &&
                   CanonicalRepresentation == other.CanonicalRepresentation);
            }
            
            // return (otherType.Canonicalize() is ForeignType other &&
            //        CanonicalRepresentation == other.CanonicalRepresentation) || true;
            // return otherType.Canonicalize() is ForeignType other &&
            //        CanonicalRepresentation == other.CanonicalRepresentation;
        }

        public override PLanguageType Canonicalize()
        {
            return this;
        }
    }
}