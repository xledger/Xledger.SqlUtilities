using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryStoreSizeCleanupPolicyOption : QueryStoreOption, IEquatable<QueryStoreSizeCleanupPolicyOption> {
        ScriptDom.QueryStoreSizeCleanupPolicyOptionKind @value = ScriptDom.QueryStoreSizeCleanupPolicyOptionKind.OFF;
    
        public ScriptDom.QueryStoreSizeCleanupPolicyOptionKind Value => @value;
    
        public QueryStoreSizeCleanupPolicyOption(ScriptDom.QueryStoreSizeCleanupPolicyOptionKind @value = ScriptDom.QueryStoreSizeCleanupPolicyOptionKind.OFF, ScriptDom.QueryStoreOptionKind optionKind = ScriptDom.QueryStoreOptionKind.Desired_State) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueryStoreSizeCleanupPolicyOption ToMutableConcrete() {
            var ret = new ScriptDom.QueryStoreSizeCleanupPolicyOption();
            ret.Value = @value;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + @value.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueryStoreSizeCleanupPolicyOption);
        } 
        
        public bool Equals(QueryStoreSizeCleanupPolicyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.QueryStoreSizeCleanupPolicyOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueryStoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueryStoreSizeCleanupPolicyOption left, QueryStoreSizeCleanupPolicyOption right) {
            return EqualityComparer<QueryStoreSizeCleanupPolicyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueryStoreSizeCleanupPolicyOption left, QueryStoreSizeCleanupPolicyOption right) {
            return !(left == right);
        }
    
    }

}
