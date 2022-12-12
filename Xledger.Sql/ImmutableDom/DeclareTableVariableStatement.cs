using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DeclareTableVariableStatement : TSqlStatement, IEquatable<DeclareTableVariableStatement> {
        DeclareTableVariableBody body;
    
        public DeclareTableVariableBody Body => body;
    
        public DeclareTableVariableStatement(DeclareTableVariableBody body = null) {
            this.body = body;
        }
    
        public ScriptDom.DeclareTableVariableStatement ToMutableConcrete() {
            var ret = new ScriptDom.DeclareTableVariableStatement();
            ret.Body = (ScriptDom.DeclareTableVariableBody)body.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(body is null)) {
                h = h * 23 + body.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DeclareTableVariableStatement);
        } 
        
        public bool Equals(DeclareTableVariableStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DeclareTableVariableBody>.Default.Equals(other.Body, body)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DeclareTableVariableStatement left, DeclareTableVariableStatement right) {
            return EqualityComparer<DeclareTableVariableStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DeclareTableVariableStatement left, DeclareTableVariableStatement right) {
            return !(left == right);
        }
    
    }

}
