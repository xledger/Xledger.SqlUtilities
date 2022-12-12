using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FullTextTableReference : TableReferenceWithAlias, IEquatable<FullTextTableReference> {
        ScriptDom.FullTextFunctionType fullTextFunctionType = ScriptDom.FullTextFunctionType.None;
        SchemaObjectName tableName;
        IReadOnlyList<ColumnReferenceExpression> columns;
        ValueExpression searchCondition;
        ValueExpression topN;
        ValueExpression language;
        StringLiteral propertyName;
    
        public ScriptDom.FullTextFunctionType FullTextFunctionType => fullTextFunctionType;
        public SchemaObjectName TableName => tableName;
        public IReadOnlyList<ColumnReferenceExpression> Columns => columns;
        public ValueExpression SearchCondition => searchCondition;
        public ValueExpression TopN => topN;
        public ValueExpression Language => language;
        public StringLiteral PropertyName => propertyName;
    
        public FullTextTableReference(ScriptDom.FullTextFunctionType fullTextFunctionType = ScriptDom.FullTextFunctionType.None, SchemaObjectName tableName = null, IReadOnlyList<ColumnReferenceExpression> columns = null, ValueExpression searchCondition = null, ValueExpression topN = null, ValueExpression language = null, StringLiteral propertyName = null, Identifier alias = null, bool forPath = false) {
            this.fullTextFunctionType = fullTextFunctionType;
            this.tableName = tableName;
            this.columns = columns is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(columns);
            this.searchCondition = searchCondition;
            this.topN = topN;
            this.language = language;
            this.propertyName = propertyName;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.FullTextTableReference ToMutableConcrete() {
            var ret = new ScriptDom.FullTextTableReference();
            ret.FullTextFunctionType = fullTextFunctionType;
            ret.TableName = (ScriptDom.SchemaObjectName)tableName.ToMutable();
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            ret.SearchCondition = (ScriptDom.ValueExpression)searchCondition.ToMutable();
            ret.TopN = (ScriptDom.ValueExpression)topN.ToMutable();
            ret.Language = (ScriptDom.ValueExpression)language.ToMutable();
            ret.PropertyName = (ScriptDom.StringLiteral)propertyName.ToMutable();
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + fullTextFunctionType.GetHashCode();
            if (!(tableName is null)) {
                h = h * 23 + tableName.GetHashCode();
            }
            h = h * 23 + columns.GetHashCode();
            if (!(searchCondition is null)) {
                h = h * 23 + searchCondition.GetHashCode();
            }
            if (!(topN is null)) {
                h = h * 23 + topN.GetHashCode();
            }
            if (!(language is null)) {
                h = h * 23 + language.GetHashCode();
            }
            if (!(propertyName is null)) {
                h = h * 23 + propertyName.GetHashCode();
            }
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FullTextTableReference);
        } 
        
        public bool Equals(FullTextTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.FullTextFunctionType>.Default.Equals(other.FullTextFunctionType, fullTextFunctionType)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.TableName, tableName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.SearchCondition, searchCondition)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.TopN, topN)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.Language, language)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.PropertyName, propertyName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Alias, alias)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForPath, forPath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FullTextTableReference left, FullTextTableReference right) {
            return EqualityComparer<FullTextTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FullTextTableReference left, FullTextTableReference right) {
            return !(left == right);
        }
    
    }

}
