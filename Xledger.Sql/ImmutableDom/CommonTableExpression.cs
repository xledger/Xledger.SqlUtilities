using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CommonTableExpression : TSqlFragment, IEquatable<CommonTableExpression> {
        protected Identifier expressionName;
        protected IReadOnlyList<Identifier> columns;
        protected QueryExpression queryExpression;
    
        public Identifier ExpressionName => expressionName;
        public IReadOnlyList<Identifier> Columns => columns;
        public QueryExpression QueryExpression => queryExpression;
    
        public CommonTableExpression(Identifier expressionName = null, IReadOnlyList<Identifier> columns = null, QueryExpression queryExpression = null) {
            this.expressionName = expressionName;
            this.columns = columns is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(columns);
            this.queryExpression = queryExpression;
        }
    
        public ScriptDom.CommonTableExpression ToMutableConcrete() {
            var ret = new ScriptDom.CommonTableExpression();
            ret.ExpressionName = (ScriptDom.Identifier)expressionName.ToMutable();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.QueryExpression = (ScriptDom.QueryExpression)queryExpression.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(expressionName is null)) {
                h = h * 23 + expressionName.GetHashCode();
            }
            h = h * 23 + columns.GetHashCode();
            if (!(queryExpression is null)) {
                h = h * 23 + queryExpression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CommonTableExpression);
        } 
        
        public bool Equals(CommonTableExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ExpressionName, expressionName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<QueryExpression>.Default.Equals(other.QueryExpression, queryExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CommonTableExpression left, CommonTableExpression right) {
            return EqualityComparer<CommonTableExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CommonTableExpression left, CommonTableExpression right) {
            return !(left == right);
        }
    
    }

}
