using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UpdateSpecification : UpdateDeleteSpecificationBase, IEquatable<UpdateSpecification> {
        IReadOnlyList<SetClause> setClauses;
    
        public IReadOnlyList<SetClause> SetClauses => setClauses;
    
        public UpdateSpecification(IReadOnlyList<SetClause> setClauses = null, FromClause fromClause = null, WhereClause whereClause = null, TableReference target = null, TopRowFilter topRowFilter = null, OutputIntoClause outputIntoClause = null, OutputClause outputClause = null) {
            this.setClauses = setClauses is null ? ImmList<SetClause>.Empty : ImmList<SetClause>.FromList(setClauses);
            this.fromClause = fromClause;
            this.whereClause = whereClause;
            this.target = target;
            this.topRowFilter = topRowFilter;
            this.outputIntoClause = outputIntoClause;
            this.outputClause = outputClause;
        }
    
        public ScriptDom.UpdateSpecification ToMutableConcrete() {
            var ret = new ScriptDom.UpdateSpecification();
            ret.SetClauses.AddRange(setClauses.Select(c => (ScriptDom.SetClause)c.ToMutable()));
            ret.FromClause = (ScriptDom.FromClause)fromClause.ToMutable();
            ret.WhereClause = (ScriptDom.WhereClause)whereClause.ToMutable();
            ret.Target = (ScriptDom.TableReference)target.ToMutable();
            ret.TopRowFilter = (ScriptDom.TopRowFilter)topRowFilter.ToMutable();
            ret.OutputIntoClause = (ScriptDom.OutputIntoClause)outputIntoClause.ToMutable();
            ret.OutputClause = (ScriptDom.OutputClause)outputClause.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + setClauses.GetHashCode();
            if (!(fromClause is null)) {
                h = h * 23 + fromClause.GetHashCode();
            }
            if (!(whereClause is null)) {
                h = h * 23 + whereClause.GetHashCode();
            }
            if (!(target is null)) {
                h = h * 23 + target.GetHashCode();
            }
            if (!(topRowFilter is null)) {
                h = h * 23 + topRowFilter.GetHashCode();
            }
            if (!(outputIntoClause is null)) {
                h = h * 23 + outputIntoClause.GetHashCode();
            }
            if (!(outputClause is null)) {
                h = h * 23 + outputClause.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UpdateSpecification);
        } 
        
        public bool Equals(UpdateSpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<SetClause>>.Default.Equals(other.SetClauses, setClauses)) {
                return false;
            }
            if (!EqualityComparer<FromClause>.Default.Equals(other.FromClause, fromClause)) {
                return false;
            }
            if (!EqualityComparer<WhereClause>.Default.Equals(other.WhereClause, whereClause)) {
                return false;
            }
            if (!EqualityComparer<TableReference>.Default.Equals(other.Target, target)) {
                return false;
            }
            if (!EqualityComparer<TopRowFilter>.Default.Equals(other.TopRowFilter, topRowFilter)) {
                return false;
            }
            if (!EqualityComparer<OutputIntoClause>.Default.Equals(other.OutputIntoClause, outputIntoClause)) {
                return false;
            }
            if (!EqualityComparer<OutputClause>.Default.Equals(other.OutputClause, outputClause)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UpdateSpecification left, UpdateSpecification right) {
            return EqualityComparer<UpdateSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UpdateSpecification left, UpdateSpecification right) {
            return !(left == right);
        }
    
    }

}
