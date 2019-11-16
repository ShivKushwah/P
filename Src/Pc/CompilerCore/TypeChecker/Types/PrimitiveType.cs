using Plang.Compiler.TypeChecker.AST.Declarations;
using System;
using System.Collections.Generic;

namespace Plang.Compiler.TypeChecker.Types
{
    public class PrimitiveType : PLanguageType
    {
        public static readonly PrimitiveType Bool = new PrimitiveType("bool");
        public static readonly PrimitiveType Secure_Bool = new PrimitiveType("secure_bool");
        public static readonly PrimitiveType Int = new PrimitiveType("int");
        public static readonly PrimitiveType Secure_Int = new PrimitiveType("secure_int");
        public static readonly PrimitiveType Float = new PrimitiveType("float");
        public static readonly PrimitiveType Event = new PrimitiveType("event");
        public static readonly PrimitiveType Machine = new PrimitiveType("machine");
        public static readonly DataType Data = new DataType(null);
        public static readonly PrimitiveType Any = new PrimitiveType("any");
        public static readonly PrimitiveType Null = new PrimitiveType("null");

        private PrimitiveType(string name) : base(TypeKind.Base)
        {
            OriginalRepresentation = name;
            CanonicalRepresentation = name;
            switch (name)
            {
                case "any":
                case "machine":
                    AllowedPermissions = null;
                    break;
                case "secure_int":
                case "secure_bool":
                    highSecurityLabel = true;
                    break;

                default:
                    AllowedPermissions = new Lazy<IReadOnlyList<PEvent>>(() => new List<PEvent>());
                    break;
            }
        }

        public bool highSecurityLabel { get; set; } = false;

        public override string OriginalRepresentation { get; }
        public override string CanonicalRepresentation { get; }

        public override Lazy<IReadOnlyList<PEvent>> AllowedPermissions { get; }

        public override bool IsAssignableFrom(PLanguageType otherType)
        {
            // if this type is "any", then it's always good. Otherwise, the types have to match exactly.
            switch (CanonicalRepresentation)
            {
                case "any":
                    return true;

                case "machine":
                    return otherType.CanonicalRepresentation.Equals("machine") ||
                           otherType.CanonicalRepresentation.Equals("null") ||                           
                           otherType is PermissionType;

                case "int":
                    //return otherType.CanonicalRepresentation.Equals("int");
                    return otherType.CanonicalRepresentation.Equals("secure_int") || otherType.CanonicalRepresentation.Equals("int");

                
                case "secure_int":
                    return otherType.CanonicalRepresentation.Equals("secure_int") || otherType.CanonicalRepresentation.Equals("int");

                case "event":
                    return otherType.CanonicalRepresentation.Equals("event") ||
                           otherType.CanonicalRepresentation.Equals("null");
                
                case "bool":
                    return otherType.CanonicalRepresentation.Equals("bool") ||
                           otherType.CanonicalRepresentation.Equals("secure_bool");
                
                case "secure_bool":
                    return otherType.CanonicalRepresentation.Equals("bool") ||
                           otherType.CanonicalRepresentation.Equals("secure_bool");

                default:
                    return CanonicalRepresentation.Equals(otherType.CanonicalRepresentation);
            }
        }

        public override PLanguageType Canonicalize()
        {
            return this;
        }
    }
}