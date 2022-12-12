using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateExternalDataSourceStatement : ExternalDataSourceStatement, IEquatable<CreateExternalDataSourceStatement> {
        public CreateExternalDataSourceStatement(Identifier name = null, ScriptDom.ExternalDataSourceType dataSourceType = ScriptDom.ExternalDataSourceType.HADOOP, Literal location = null, ScriptDom.ExternalDataSourcePushdownOption? pushdownOption = null, IReadOnlyList<ExternalDataSourceOption> externalDataSourceOptions = null) {
            this.name = name;
            this.dataSourceType = dataSourceType;
            this.location = location;
            this.pushdownOption = pushdownOption;
            this.externalDataSourceOptions = externalDataSourceOptions is null ? ImmList<ExternalDataSourceOption>.Empty : ImmList<ExternalDataSourceOption>.FromList(externalDataSourceOptions);
        }
    
        public ScriptDom.CreateExternalDataSourceStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateExternalDataSourceStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.DataSourceType = dataSourceType;
            ret.Location = (ScriptDom.Literal)location.ToMutable();
            ret.PushdownOption = pushdownOption;
            ret.ExternalDataSourceOptions.AddRange(externalDataSourceOptions.Select(c => (ScriptDom.ExternalDataSourceOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
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
            return Equals(obj as CreateExternalDataSourceStatement);
        } 
        
        public bool Equals(CreateExternalDataSourceStatement other) {
            if (other is null) { return false; }
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
        
        public static bool operator ==(CreateExternalDataSourceStatement left, CreateExternalDataSourceStatement right) {
            return EqualityComparer<CreateExternalDataSourceStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateExternalDataSourceStatement left, CreateExternalDataSourceStatement right) {
            return !(left == right);
        }
    
    }

}
