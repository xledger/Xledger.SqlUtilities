using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CatalogCollationOption : DatabaseOption, IEquatable<CatalogCollationOption> {
        ScriptDom.CatalogCollation? catalogCollation;
    
        public ScriptDom.CatalogCollation? CatalogCollation => catalogCollation;
    
        public CatalogCollationOption(ScriptDom.CatalogCollation? catalogCollation = null, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.catalogCollation = catalogCollation;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.CatalogCollationOption ToMutableConcrete() {
            var ret = new ScriptDom.CatalogCollationOption();
            ret.CatalogCollation = catalogCollation;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + catalogCollation.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CatalogCollationOption);
        } 
        
        public bool Equals(CatalogCollationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.CatalogCollation?>.Default.Equals(other.CatalogCollation, catalogCollation)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CatalogCollationOption left, CatalogCollationOption right) {
            return EqualityComparer<CatalogCollationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CatalogCollationOption left, CatalogCollationOption right) {
            return !(left == right);
        }
    
    }

}
