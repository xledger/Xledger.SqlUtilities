using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropServerAuditSpecificationStatement : DropUnownedObjectStatement, IEquatable<DropServerAuditSpecificationStatement> {
        public DropServerAuditSpecificationStatement(Identifier name = null, bool isIfExists = false) {
            this.name = name;
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropServerAuditSpecificationStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropServerAuditSpecificationStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropServerAuditSpecificationStatement);
        } 
        
        public bool Equals(DropServerAuditSpecificationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropServerAuditSpecificationStatement left, DropServerAuditSpecificationStatement right) {
            return EqualityComparer<DropServerAuditSpecificationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropServerAuditSpecificationStatement left, DropServerAuditSpecificationStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropServerAuditSpecificationStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.isIfExists, othr.isIfExists);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static DropServerAuditSpecificationStatement FromMutable(ScriptDom.DropServerAuditSpecificationStatement fragment) {
            return (DropServerAuditSpecificationStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
