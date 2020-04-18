using Plang.Compiler.TypeChecker.AST.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plang.Compiler.TypeChecker.Types
{
    internal class MapType : PLanguageType
    {
        public MapType(PLanguageType keyType, PLanguageType valueType) : base(TypeKind.Map)
        {
            KeyType = keyType;
            ValueType = valueType;
            if (KeyType.AllowedPermissions == null || ValueType.AllowedPermissions == null)
            {
                AllowedPermissions = null;
            }
            else
            {
                AllowedPermissions = new Lazy<IReadOnlyList<PEvent>>(() => KeyType
                    .AllowedPermissions.Value.Concat(ValueType.AllowedPermissions.Value)
                    .ToList());
            }
            if (keyType.highSecurityLabel  || valueType.highSecurityLabel) {
                highSecurityLabel = true;
            } else {
                highSecurityLabel = false;
            }
            if (keyType.allSubtypesAreHighSecurityLabel && valueType.allSubtypesAreHighSecurityLabel) {
                allSubtypesAreHighSecurityLabel = true;
            } else {
                allSubtypesAreHighSecurityLabel = false;
            }
        }

        public PLanguageType KeyType { get; }
        public PLanguageType ValueType { get; }

        public override string OriginalRepresentation =>
            $"map[{KeyType.OriginalRepresentation},{ValueType.OriginalRepresentation}]";

        public override string CanonicalRepresentation =>
            $"map[{KeyType.CanonicalRepresentation},{ValueType.CanonicalRepresentation}]";

        public override Lazy<IReadOnlyList<PEvent>> AllowedPermissions { get; }

        public override bool IsAssignableFrom(PLanguageType otherType)
        {
            // Copying semantics: both the other key and value types must be subtypes of this key/value type.
            return otherType.Canonicalize() is MapType other &&
                   KeyType.IsAssignableFrom(other.KeyType) &&
                   ValueType.IsAssignableFrom(other.ValueType);
        }

        public override PLanguageType Canonicalize()
        {
            return new MapType(KeyType.Canonicalize(), ValueType.Canonicalize());
        }
    }
}