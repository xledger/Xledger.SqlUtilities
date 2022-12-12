using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseModifyFileStatement : AlterDatabaseStatement, IEquatable<AlterDatabaseModifyFileStatement> {
        FileDeclaration fileDeclaration;
    
        public FileDeclaration FileDeclaration => fileDeclaration;
    
        public AlterDatabaseModifyFileStatement(FileDeclaration fileDeclaration = null, Identifier databaseName = null, bool useCurrent = false) {
            this.fileDeclaration = fileDeclaration;
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabaseModifyFileStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseModifyFileStatement();
            ret.FileDeclaration = (ScriptDom.FileDeclaration)fileDeclaration.ToMutable();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName.ToMutable();
            ret.UseCurrent = useCurrent;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(fileDeclaration is null)) {
                h = h * 23 + fileDeclaration.GetHashCode();
            }
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + useCurrent.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseModifyFileStatement);
        } 
        
        public bool Equals(AlterDatabaseModifyFileStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<FileDeclaration>.Default.Equals(other.FileDeclaration, fileDeclaration)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DatabaseName, databaseName)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.UseCurrent, useCurrent)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterDatabaseModifyFileStatement left, AlterDatabaseModifyFileStatement right) {
            return EqualityComparer<AlterDatabaseModifyFileStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseModifyFileStatement left, AlterDatabaseModifyFileStatement right) {
            return !(left == right);
        }
    
    }

}
