using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AuditSpecificationPart : TSqlFragment, IEquatable<AuditSpecificationPart> {
        protected bool isDrop = false;
        protected AuditSpecificationDetail details;
    
        public bool IsDrop => isDrop;
        public AuditSpecificationDetail Details => details;
    
        public AuditSpecificationPart(bool isDrop = false, AuditSpecificationDetail details = null) {
            this.isDrop = isDrop;
            this.details = details;
        }
    
        public ScriptDom.AuditSpecificationPart ToMutableConcrete() {
            var ret = new ScriptDom.AuditSpecificationPart();
            ret.IsDrop = isDrop;
            ret.Details = (ScriptDom.AuditSpecificationDetail)details.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isDrop.GetHashCode();
            if (!(details is null)) {
                h = h * 23 + details.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AuditSpecificationPart);
        } 
        
        public bool Equals(AuditSpecificationPart other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsDrop, isDrop)) {
                return false;
            }
            if (!EqualityComparer<AuditSpecificationDetail>.Default.Equals(other.Details, details)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AuditSpecificationPart left, AuditSpecificationPart right) {
            return EqualityComparer<AuditSpecificationPart>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AuditSpecificationPart left, AuditSpecificationPart right) {
            return !(left == right);
        }
    
    }

}
