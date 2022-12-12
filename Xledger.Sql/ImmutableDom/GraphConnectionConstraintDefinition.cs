using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GraphConnectionConstraintDefinition : ConstraintDefinition, IEquatable<GraphConnectionConstraintDefinition> {
        protected IReadOnlyList<GraphConnectionBetweenNodes> fromNodeToNodeList;
        protected ScriptDom.DeleteUpdateAction deleteAction = ScriptDom.DeleteUpdateAction.NotSpecified;
    
        public IReadOnlyList<GraphConnectionBetweenNodes> FromNodeToNodeList => fromNodeToNodeList;
        public ScriptDom.DeleteUpdateAction DeleteAction => deleteAction;
    
        public GraphConnectionConstraintDefinition(IReadOnlyList<GraphConnectionBetweenNodes> fromNodeToNodeList = null, ScriptDom.DeleteUpdateAction deleteAction = ScriptDom.DeleteUpdateAction.NotSpecified, Identifier constraintIdentifier = null) {
            this.fromNodeToNodeList = fromNodeToNodeList is null ? ImmList<GraphConnectionBetweenNodes>.Empty : ImmList<GraphConnectionBetweenNodes>.FromList(fromNodeToNodeList);
            this.deleteAction = deleteAction;
            this.constraintIdentifier = constraintIdentifier;
        }
    
        public ScriptDom.GraphConnectionConstraintDefinition ToMutableConcrete() {
            var ret = new ScriptDom.GraphConnectionConstraintDefinition();
            ret.FromNodeToNodeList.AddRange(fromNodeToNodeList.SelectList(c => (ScriptDom.GraphConnectionBetweenNodes)c.ToMutable()));
            ret.DeleteAction = deleteAction;
            ret.ConstraintIdentifier = (ScriptDom.Identifier)constraintIdentifier.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + fromNodeToNodeList.GetHashCode();
            h = h * 23 + deleteAction.GetHashCode();
            if (!(constraintIdentifier is null)) {
                h = h * 23 + constraintIdentifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GraphConnectionConstraintDefinition);
        } 
        
        public bool Equals(GraphConnectionConstraintDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<GraphConnectionBetweenNodes>>.Default.Equals(other.FromNodeToNodeList, fromNodeToNodeList)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DeleteUpdateAction>.Default.Equals(other.DeleteAction, deleteAction)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ConstraintIdentifier, constraintIdentifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GraphConnectionConstraintDefinition left, GraphConnectionConstraintDefinition right) {
            return EqualityComparer<GraphConnectionConstraintDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GraphConnectionConstraintDefinition left, GraphConnectionConstraintDefinition right) {
            return !(left == right);
        }
    
    }

}
