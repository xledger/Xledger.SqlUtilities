using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IgnoreDupKeyIndexOption : IndexStateOption, IEquatable<IgnoreDupKeyIndexOption> {
        bool? suppressMessagesOption;
    
        public bool? SuppressMessagesOption => suppressMessagesOption;
    
        public IgnoreDupKeyIndexOption(bool? suppressMessagesOption = null, ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.suppressMessagesOption = suppressMessagesOption;
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.IgnoreDupKeyIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.IgnoreDupKeyIndexOption();
            ret.SuppressMessagesOption = suppressMessagesOption;
            ret.OptionState = optionState;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + suppressMessagesOption.GetHashCode();
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IgnoreDupKeyIndexOption);
        } 
        
        public bool Equals(IgnoreDupKeyIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool?>.Default.Equals(other.SuppressMessagesOption, suppressMessagesOption)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.IndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IgnoreDupKeyIndexOption left, IgnoreDupKeyIndexOption right) {
            return EqualityComparer<IgnoreDupKeyIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IgnoreDupKeyIndexOption left, IgnoreDupKeyIndexOption right) {
            return !(left == right);
        }
    
    }

}
