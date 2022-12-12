using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterAsymmetricKeyStatement : TSqlStatement, IEquatable<AlterAsymmetricKeyStatement> {
        Identifier name;
        Literal attestedBy;
        ScriptDom.AlterCertificateStatementKind kind = ScriptDom.AlterCertificateStatementKind.None;
        Literal encryptionPassword;
        Literal decryptionPassword;
    
        public Identifier Name => name;
        public Literal AttestedBy => attestedBy;
        public ScriptDom.AlterCertificateStatementKind Kind => kind;
        public Literal EncryptionPassword => encryptionPassword;
        public Literal DecryptionPassword => decryptionPassword;
    
        public AlterAsymmetricKeyStatement(Identifier name = null, Literal attestedBy = null, ScriptDom.AlterCertificateStatementKind kind = ScriptDom.AlterCertificateStatementKind.None, Literal encryptionPassword = null, Literal decryptionPassword = null) {
            this.name = name;
            this.attestedBy = attestedBy;
            this.kind = kind;
            this.encryptionPassword = encryptionPassword;
            this.decryptionPassword = decryptionPassword;
        }
    
        public ScriptDom.AlterAsymmetricKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterAsymmetricKeyStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.AttestedBy = (ScriptDom.Literal)attestedBy.ToMutable();
            ret.Kind = kind;
            ret.EncryptionPassword = (ScriptDom.Literal)encryptionPassword.ToMutable();
            ret.DecryptionPassword = (ScriptDom.Literal)decryptionPassword.ToMutable();
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
            if (!(attestedBy is null)) {
                h = h * 23 + attestedBy.GetHashCode();
            }
            h = h * 23 + kind.GetHashCode();
            if (!(encryptionPassword is null)) {
                h = h * 23 + encryptionPassword.GetHashCode();
            }
            if (!(decryptionPassword is null)) {
                h = h * 23 + decryptionPassword.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterAsymmetricKeyStatement);
        } 
        
        public bool Equals(AlterAsymmetricKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.AttestedBy, attestedBy)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AlterCertificateStatementKind>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.EncryptionPassword, encryptionPassword)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.DecryptionPassword, decryptionPassword)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterAsymmetricKeyStatement left, AlterAsymmetricKeyStatement right) {
            return EqualityComparer<AlterAsymmetricKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterAsymmetricKeyStatement left, AlterAsymmetricKeyStatement right) {
            return !(left == right);
        }
    
    }

}
