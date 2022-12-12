using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BeginConversationTimerStatement : TSqlStatement, IEquatable<BeginConversationTimerStatement> {
        ScalarExpression handle;
        ScalarExpression timeout;
    
        public ScalarExpression Handle => handle;
        public ScalarExpression Timeout => timeout;
    
        public BeginConversationTimerStatement(ScalarExpression handle = null, ScalarExpression timeout = null) {
            this.handle = handle;
            this.timeout = timeout;
        }
    
        public ScriptDom.BeginConversationTimerStatement ToMutableConcrete() {
            var ret = new ScriptDom.BeginConversationTimerStatement();
            ret.Handle = (ScriptDom.ScalarExpression)handle.ToMutable();
            ret.Timeout = (ScriptDom.ScalarExpression)timeout.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(handle is null)) {
                h = h * 23 + handle.GetHashCode();
            }
            if (!(timeout is null)) {
                h = h * 23 + timeout.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BeginConversationTimerStatement);
        } 
        
        public bool Equals(BeginConversationTimerStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Handle, handle)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Timeout, timeout)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BeginConversationTimerStatement left, BeginConversationTimerStatement right) {
            return EqualityComparer<BeginConversationTimerStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BeginConversationTimerStatement left, BeginConversationTimerStatement right) {
            return !(left == right);
        }
    
    }

}
