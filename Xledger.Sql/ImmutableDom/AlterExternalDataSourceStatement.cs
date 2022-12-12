using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterExternalDataSourceStatement : ExternalDataSourceStatement, IEquatable<AlterExternalDataSourceStatement> {
        protected ScriptDom.ExternalDataSourcePushdownOption previousPushDownOption = ScriptDom.ExternalDataSourcePushdownOption.ON;
    
        public ScriptDom.ExternalDataSourcePushdownOption PreviousPushDownOption => previousPushDownOption;
    
        public AlterExternalDataSourceStatement(ScriptDom.ExternalDataSourcePushdownOption previousPushDownOption = ScriptDom.ExternalDataSourcePushdownOption.ON, Identifier name = null, ScriptDom.ExternalDataSourceType dataSourceType = ScriptDom.ExternalDataSourceType.HADOOP, Literal location = null, ScriptDom.ExternalDataSourcePushdownOption? pushdownOption = null, IReadOnlyList<ExternalDataSourceOption> externalDataSourceOptions = null) {
            this.previousPushDownOption = previousPushDownOption;
            this.name = name;
            this.dataSourceType = dataSourceType;
            this.location = location;
            this.pushdownOption = pushdownOption;
            this.externalDataSourceOptions = externalDataSourceOptions is null ? ImmList<ExternalDataSourceOption>.Empty : ImmList<ExternalDataSourceOption>.FromList(externalDataSourceOptions);
        }
    
        public ScriptDom.AlterExternalDataSourceStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterExternalDataSourceStatement();
            ret.PreviousPushDownOption = previousPushDownOption;
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.DataSourceType = dataSourceType;
            ret.Location = (ScriptDom.Literal)location.ToMutable();
            ret.PushdownOption = pushdownOption;
            ret.ExternalDataSourceOptions.AddRange(externalDataSourceOptions.SelectList(c => (ScriptDom.ExternalDataSourceOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + previousPushDownOption.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + dataSourceType.GetHashCode();
            if (!(location is null)) {
                h = h * 23 + location.GetHashCode();
            }
            h = h * 23 + pushdownOption.GetHashCode();
            h = h * 23 + externalDataSourceOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterExternalDataSourceStatement);
        } 
        
        public bool Equals(AlterExternalDataSourceStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ExternalDataSourcePushdownOption>.Default.Equals(other.PreviousPushDownOption, previousPushDownOption)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalDataSourceType>.Default.Equals(other.DataSourceType, dataSourceType)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Location, location)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalDataSourcePushdownOption?>.Default.Equals(other.PushdownOption, pushdownOption)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExternalDataSourceOption>>.Default.Equals(other.ExternalDataSourceOptions, externalDataSourceOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterExternalDataSourceStatement left, AlterExternalDataSourceStatement right) {
            return EqualityComparer<AlterExternalDataSourceStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterExternalDataSourceStatement left, AlterExternalDataSourceStatement right) {
            return !(left == right);
        }
    
    }

}
