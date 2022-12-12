using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropEventSessionStatement : DropUnownedObjectStatement, IEquatable<DropEventSessionStatement> {
        ScriptDom.EventSessionScope sessionScope = ScriptDom.EventSessionScope.Server;
    
        public ScriptDom.EventSessionScope SessionScope => sessionScope;
    
        public DropEventSessionStatement(ScriptDom.EventSessionScope sessionScope = ScriptDom.EventSessionScope.Server, Identifier name = null, bool isIfExists = false) {
            this.sessionScope = sessionScope;
            this.name = name;
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropEventSessionStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropEventSessionStatement();
            ret.SessionScope = sessionScope;
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + sessionScope.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropEventSessionStatement);
        } 
        
        public bool Equals(DropEventSessionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.EventSessionScope>.Default.Equals(other.SessionScope, sessionScope)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropEventSessionStatement left, DropEventSessionStatement right) {
            return EqualityComparer<DropEventSessionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropEventSessionStatement left, DropEventSessionStatement right) {
            return !(left == right);
        }
    
    }

}
