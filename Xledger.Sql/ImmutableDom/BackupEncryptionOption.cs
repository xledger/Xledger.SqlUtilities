using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BackupEncryptionOption : BackupOption, IEquatable<BackupEncryptionOption> {
        protected ScriptDom.EncryptionAlgorithm algorithm = ScriptDom.EncryptionAlgorithm.None;
        protected CryptoMechanism encryptor;
    
        public ScriptDom.EncryptionAlgorithm Algorithm => algorithm;
        public CryptoMechanism Encryptor => encryptor;
    
        public BackupEncryptionOption(ScriptDom.EncryptionAlgorithm algorithm = ScriptDom.EncryptionAlgorithm.None, CryptoMechanism encryptor = null, ScriptDom.BackupOptionKind optionKind = ScriptDom.BackupOptionKind.None, ScalarExpression @value = null) {
            this.algorithm = algorithm;
            this.encryptor = encryptor;
            this.optionKind = optionKind;
            this.@value = @value;
        }
    
        public ScriptDom.BackupEncryptionOption ToMutableConcrete() {
            var ret = new ScriptDom.BackupEncryptionOption();
            ret.Algorithm = algorithm;
            ret.Encryptor = (ScriptDom.CryptoMechanism)encryptor.ToMutable();
            ret.OptionKind = optionKind;
            ret.Value = (ScriptDom.ScalarExpression)@value.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + algorithm.GetHashCode();
            if (!(encryptor is null)) {
                h = h * 23 + encryptor.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BackupEncryptionOption);
        } 
        
        public bool Equals(BackupEncryptionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.EncryptionAlgorithm>.Default.Equals(other.Algorithm, algorithm)) {
                return false;
            }
            if (!EqualityComparer<CryptoMechanism>.Default.Equals(other.Encryptor, encryptor)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.BackupOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BackupEncryptionOption left, BackupEncryptionOption right) {
            return EqualityComparer<BackupEncryptionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BackupEncryptionOption left, BackupEncryptionOption right) {
            return !(left == right);
        }
    
    }

}
