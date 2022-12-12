using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnEncryptionDefinition : TSqlFragment, IEquatable<ColumnEncryptionDefinition> {
        protected IReadOnlyList<ColumnEncryptionDefinitionParameter> parameters;
    
        public IReadOnlyList<ColumnEncryptionDefinitionParameter> Parameters => parameters;
    
        public ColumnEncryptionDefinition(IReadOnlyList<ColumnEncryptionDefinitionParameter> parameters = null) {
            this.parameters = parameters is null ? ImmList<ColumnEncryptionDefinitionParameter>.Empty : ImmList<ColumnEncryptionDefinitionParameter>.FromList(parameters);
        }
    
        public ScriptDom.ColumnEncryptionDefinition ToMutableConcrete() {
            var ret = new ScriptDom.ColumnEncryptionDefinition();
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ColumnEncryptionDefinitionParameter)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + parameters.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnEncryptionDefinition);
        } 
        
        public bool Equals(ColumnEncryptionDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ColumnEncryptionDefinitionParameter>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnEncryptionDefinition left, ColumnEncryptionDefinition right) {
            return EqualityComparer<ColumnEncryptionDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnEncryptionDefinition left, ColumnEncryptionDefinition right) {
            return !(left == right);
        }
    
    }

}
