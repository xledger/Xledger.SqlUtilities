using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RetentionPeriodDefinition : TSqlFragment, IEquatable<RetentionPeriodDefinition> {
        IntegerLiteral duration;
        ScriptDom.TemporalRetentionPeriodUnit units = ScriptDom.TemporalRetentionPeriodUnit.Day;
        bool isInfinity = false;
    
        public IntegerLiteral Duration => duration;
        public ScriptDom.TemporalRetentionPeriodUnit Units => units;
        public bool IsInfinity => isInfinity;
    
        public RetentionPeriodDefinition(IntegerLiteral duration = null, ScriptDom.TemporalRetentionPeriodUnit units = ScriptDom.TemporalRetentionPeriodUnit.Day, bool isInfinity = false) {
            this.duration = duration;
            this.units = units;
            this.isInfinity = isInfinity;
        }
    
        public ScriptDom.RetentionPeriodDefinition ToMutableConcrete() {
            var ret = new ScriptDom.RetentionPeriodDefinition();
            ret.Duration = (ScriptDom.IntegerLiteral)duration.ToMutable();
            ret.Units = units;
            ret.IsInfinity = isInfinity;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(duration is null)) {
                h = h * 23 + duration.GetHashCode();
            }
            h = h * 23 + units.GetHashCode();
            h = h * 23 + isInfinity.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RetentionPeriodDefinition);
        } 
        
        public bool Equals(RetentionPeriodDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IntegerLiteral>.Default.Equals(other.Duration, duration)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TemporalRetentionPeriodUnit>.Default.Equals(other.Units, units)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsInfinity, isInfinity)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RetentionPeriodDefinition left, RetentionPeriodDefinition right) {
            return EqualityComparer<RetentionPeriodDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RetentionPeriodDefinition left, RetentionPeriodDefinition right) {
            return !(left == right);
        }
    
    }

}
