using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BulkInsertOption : TSqlFragment, IEquatable<BulkInsertOption> {
        protected ScriptDom.BulkInsertOptionKind optionKind = ScriptDom.BulkInsertOptionKind.None;
    
        public ScriptDom.BulkInsertOptionKind OptionKind => optionKind;
    
        public BulkInsertOption(ScriptDom.BulkInsertOptionKind optionKind = ScriptDom.BulkInsertOptionKind.None) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.BulkInsertOption ToMutableConcrete() {
            var ret = new ScriptDom.BulkInsertOption();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BulkInsertOption);
        } 
        
        public bool Equals(BulkInsertOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.BulkInsertOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BulkInsertOption left, BulkInsertOption right) {
            return EqualityComparer<BulkInsertOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BulkInsertOption left, BulkInsertOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BulkInsertOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static BulkInsertOption FromMutable(ScriptDom.BulkInsertOption fragment) {
            return (BulkInsertOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
