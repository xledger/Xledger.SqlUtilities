using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AutomaticTuningDropIndexOption : AutomaticTuningOption, IEquatable<AutomaticTuningDropIndexOption> {
        public AutomaticTuningDropIndexOption(ScriptDom.AutomaticTuningOptionKind optionKind = ScriptDom.AutomaticTuningOptionKind.Force_Last_Good_Plan, ScriptDom.AutomaticTuningOptionState @value = ScriptDom.AutomaticTuningOptionState.Off) {
            this.optionKind = optionKind;
            this.@value = @value;
        }
    
        public ScriptDom.AutomaticTuningDropIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.AutomaticTuningDropIndexOption();
            ret.OptionKind = optionKind;
            ret.Value = @value;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            h = h * 23 + @value.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AutomaticTuningDropIndexOption);
        } 
        
        public bool Equals(AutomaticTuningDropIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AutomaticTuningOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AutomaticTuningOptionState>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AutomaticTuningDropIndexOption left, AutomaticTuningDropIndexOption right) {
            return EqualityComparer<AutomaticTuningDropIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AutomaticTuningDropIndexOption left, AutomaticTuningDropIndexOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AutomaticTuningDropIndexOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AutomaticTuningDropIndexOption FromMutable(ScriptDom.AutomaticTuningDropIndexOption fragment) {
            return (AutomaticTuningDropIndexOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
