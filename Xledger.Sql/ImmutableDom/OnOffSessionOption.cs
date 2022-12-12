using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OnOffSessionOption : SessionOption, IEquatable<OnOffSessionOption> {
        ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public OnOffSessionOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.SessionOptionKind optionKind = ScriptDom.SessionOptionKind.EventRetention) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.OnOffSessionOption ToMutableConcrete() {
            var ret = new ScriptDom.OnOffSessionOption();
            ret.OptionState = optionState;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OnOffSessionOption);
        } 
        
        public bool Equals(OnOffSessionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SessionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OnOffSessionOption left, OnOffSessionOption right) {
            return EqualityComparer<OnOffSessionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OnOffSessionOption left, OnOffSessionOption right) {
            return !(left == right);
        }
    
    }

}
