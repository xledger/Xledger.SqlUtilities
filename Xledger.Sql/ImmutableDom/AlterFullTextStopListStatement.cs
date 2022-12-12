using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterFullTextStopListStatement : TSqlStatement, IEquatable<AlterFullTextStopListStatement> {
        protected Identifier name;
        protected FullTextStopListAction action;
    
        public Identifier Name => name;
        public FullTextStopListAction Action => action;
    
        public AlterFullTextStopListStatement(Identifier name = null, FullTextStopListAction action = null) {
            this.name = name;
            this.action = action;
        }
    
        public ScriptDom.AlterFullTextStopListStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterFullTextStopListStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Action = (ScriptDom.FullTextStopListAction)action.ToMutable();
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
            if (!(action is null)) {
                h = h * 23 + action.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterFullTextStopListStatement);
        } 
        
        public bool Equals(AlterFullTextStopListStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<FullTextStopListAction>.Default.Equals(other.Action, action)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterFullTextStopListStatement left, AlterFullTextStopListStatement right) {
            return EqualityComparer<AlterFullTextStopListStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterFullTextStopListStatement left, AlterFullTextStopListStatement right) {
            return !(left == right);
        }
    
    }

}
