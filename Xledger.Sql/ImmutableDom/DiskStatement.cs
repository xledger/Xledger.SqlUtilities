using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DiskStatement : TSqlStatement, IEquatable<DiskStatement> {
        protected ScriptDom.DiskStatementType diskStatementType = ScriptDom.DiskStatementType.Init;
        protected IReadOnlyList<DiskStatementOption> options;
    
        public ScriptDom.DiskStatementType DiskStatementType => diskStatementType;
        public IReadOnlyList<DiskStatementOption> Options => options;
    
        public DiskStatement(ScriptDom.DiskStatementType diskStatementType = ScriptDom.DiskStatementType.Init, IReadOnlyList<DiskStatementOption> options = null) {
            this.diskStatementType = diskStatementType;
            this.options = options is null ? ImmList<DiskStatementOption>.Empty : ImmList<DiskStatementOption>.FromList(options);
        }
    
        public ScriptDom.DiskStatement ToMutableConcrete() {
            var ret = new ScriptDom.DiskStatement();
            ret.DiskStatementType = diskStatementType;
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.DiskStatementOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + diskStatementType.GetHashCode();
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DiskStatement);
        } 
        
        public bool Equals(DiskStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DiskStatementType>.Default.Equals(other.DiskStatementType, diskStatementType)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<DiskStatementOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DiskStatement left, DiskStatement right) {
            return EqualityComparer<DiskStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DiskStatement left, DiskStatement right) {
            return !(left == right);
        }
    
    }

}
