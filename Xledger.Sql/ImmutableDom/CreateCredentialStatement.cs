using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateCredentialStatement : CredentialStatement, IEquatable<CreateCredentialStatement> {
        protected Identifier cryptographicProviderName;
    
        public Identifier CryptographicProviderName => cryptographicProviderName;
    
        public CreateCredentialStatement(Identifier cryptographicProviderName = null, Identifier name = null, Literal identity = null, Literal secret = null, bool isDatabaseScoped = false) {
            this.cryptographicProviderName = cryptographicProviderName;
            this.name = name;
            this.identity = identity;
            this.secret = secret;
            this.isDatabaseScoped = isDatabaseScoped;
        }
    
        public ScriptDom.CreateCredentialStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateCredentialStatement();
            ret.CryptographicProviderName = (ScriptDom.Identifier)cryptographicProviderName.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Identity = (ScriptDom.Literal)identity.ToMutable();
            ret.Secret = (ScriptDom.Literal)secret.ToMutable();
            ret.IsDatabaseScoped = isDatabaseScoped;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(cryptographicProviderName is null)) {
                h = h * 23 + cryptographicProviderName.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(identity is null)) {
                h = h * 23 + identity.GetHashCode();
            }
            if (!(secret is null)) {
                h = h * 23 + secret.GetHashCode();
            }
            h = h * 23 + isDatabaseScoped.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateCredentialStatement);
        } 
        
        public bool Equals(CreateCredentialStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.CryptographicProviderName, cryptographicProviderName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Identity, identity)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Secret, secret)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsDatabaseScoped, isDatabaseScoped)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateCredentialStatement left, CreateCredentialStatement right) {
            return EqualityComparer<CreateCredentialStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateCredentialStatement left, CreateCredentialStatement right) {
            return !(left == right);
        }
    
    }

}
