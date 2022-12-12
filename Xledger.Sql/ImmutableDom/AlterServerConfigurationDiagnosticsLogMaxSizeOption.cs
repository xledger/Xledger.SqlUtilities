using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterServerConfigurationDiagnosticsLogMaxSizeOption : AlterServerConfigurationDiagnosticsLogOption, IEquatable<AlterServerConfigurationDiagnosticsLogMaxSizeOption> {
        protected ScriptDom.MemoryUnit sizeUnit = ScriptDom.MemoryUnit.Unspecified;
    
        public ScriptDom.MemoryUnit SizeUnit => sizeUnit;
    
        public AlterServerConfigurationDiagnosticsLogMaxSizeOption(ScriptDom.MemoryUnit sizeUnit = ScriptDom.MemoryUnit.Unspecified, ScriptDom.AlterServerConfigurationDiagnosticsLogOptionKind optionKind = ScriptDom.AlterServerConfigurationDiagnosticsLogOptionKind.None, OptionValue optionValue = null) {
            this.sizeUnit = sizeUnit;
            this.optionKind = optionKind;
            this.optionValue = optionValue;
        }
    
        public ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption ToMutableConcrete() {
            var ret = new ScriptDom.AlterServerConfigurationDiagnosticsLogMaxSizeOption();
            ret.SizeUnit = sizeUnit;
            ret.OptionKind = optionKind;
            ret.OptionValue = (ScriptDom.OptionValue)optionValue.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + sizeUnit.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            if (!(optionValue is null)) {
                h = h * 23 + optionValue.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterServerConfigurationDiagnosticsLogMaxSizeOption);
        } 
        
        public bool Equals(AlterServerConfigurationDiagnosticsLogMaxSizeOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.MemoryUnit>.Default.Equals(other.SizeUnit, sizeUnit)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AlterServerConfigurationDiagnosticsLogOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<OptionValue>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterServerConfigurationDiagnosticsLogMaxSizeOption left, AlterServerConfigurationDiagnosticsLogMaxSizeOption right) {
            return EqualityComparer<AlterServerConfigurationDiagnosticsLogMaxSizeOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterServerConfigurationDiagnosticsLogMaxSizeOption left, AlterServerConfigurationDiagnosticsLogMaxSizeOption right) {
            return !(left == right);
        }
    
    }

}
