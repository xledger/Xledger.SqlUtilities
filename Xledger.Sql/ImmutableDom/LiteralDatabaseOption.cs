using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralDatabaseOption : DatabaseOption, IEquatable<LiteralDatabaseOption> {
        protected Literal @value;
    
        public Literal Value => @value;
    
        public LiteralDatabaseOption(Literal @value = null, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LiteralDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.LiteralDatabaseOption();
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LiteralDatabaseOption);
        } 
        
        public bool Equals(LiteralDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralDatabaseOption left, LiteralDatabaseOption right) {
            return EqualityComparer<LiteralDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralDatabaseOption left, LiteralDatabaseOption right) {
            return !(left == right);
        }
    
    }

}
