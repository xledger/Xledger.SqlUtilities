using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QualifiedJoin : JoinTableReference, IEquatable<QualifiedJoin> {
        BooleanExpression searchCondition;
        ScriptDom.QualifiedJoinType qualifiedJoinType = ScriptDom.QualifiedJoinType.Inner;
        ScriptDom.JoinHint joinHint = ScriptDom.JoinHint.None;
    
        public BooleanExpression SearchCondition => searchCondition;
        public ScriptDom.QualifiedJoinType QualifiedJoinType => qualifiedJoinType;
        public ScriptDom.JoinHint JoinHint => joinHint;
    
        public QualifiedJoin(BooleanExpression searchCondition = null, ScriptDom.QualifiedJoinType qualifiedJoinType = ScriptDom.QualifiedJoinType.Inner, ScriptDom.JoinHint joinHint = ScriptDom.JoinHint.None, TableReference firstTableReference = null, TableReference secondTableReference = null) {
            this.searchCondition = searchCondition;
            this.qualifiedJoinType = qualifiedJoinType;
            this.joinHint = joinHint;
            this.firstTableReference = firstTableReference;
            this.secondTableReference = secondTableReference;
        }
    
        public ScriptDom.QualifiedJoin ToMutableConcrete() {
            var ret = new ScriptDom.QualifiedJoin();
            ret.SearchCondition = (ScriptDom.BooleanExpression)searchCondition.ToMutable();
            ret.QualifiedJoinType = qualifiedJoinType;
            ret.JoinHint = joinHint;
            ret.FirstTableReference = (ScriptDom.TableReference)firstTableReference.ToMutable();
            ret.SecondTableReference = (ScriptDom.TableReference)secondTableReference.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(searchCondition is null)) {
                h = h * 23 + searchCondition.GetHashCode();
            }
            h = h * 23 + qualifiedJoinType.GetHashCode();
            h = h * 23 + joinHint.GetHashCode();
            if (!(firstTableReference is null)) {
                h = h * 23 + firstTableReference.GetHashCode();
            }
            if (!(secondTableReference is null)) {
                h = h * 23 + secondTableReference.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QualifiedJoin);
        } 
        
        public bool Equals(QualifiedJoin other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.SearchCondition, searchCondition)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QualifiedJoinType>.Default.Equals(other.QualifiedJoinType, qualifiedJoinType)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.JoinHint>.Default.Equals(other.JoinHint, joinHint)) {
                return false;
            }
            if (!EqualityComparer<TableReference>.Default.Equals(other.FirstTableReference, firstTableReference)) {
                return false;
            }
            if (!EqualityComparer<TableReference>.Default.Equals(other.SecondTableReference, secondTableReference)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QualifiedJoin left, QualifiedJoin right) {
            return EqualityComparer<QualifiedJoin>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QualifiedJoin left, QualifiedJoin right) {
            return !(left == right);
        }
    
    }

}
