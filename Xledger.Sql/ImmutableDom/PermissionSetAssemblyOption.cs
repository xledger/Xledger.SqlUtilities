using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PermissionSetAssemblyOption : AssemblyOption, IEquatable<PermissionSetAssemblyOption> {
        protected ScriptDom.PermissionSetOption permissionSetOption = ScriptDom.PermissionSetOption.None;
    
        public ScriptDom.PermissionSetOption PermissionSetOption => permissionSetOption;
    
        public PermissionSetAssemblyOption(ScriptDom.PermissionSetOption permissionSetOption = ScriptDom.PermissionSetOption.None, ScriptDom.AssemblyOptionKind optionKind = ScriptDom.AssemblyOptionKind.PermissionSet) {
            this.permissionSetOption = permissionSetOption;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.PermissionSetAssemblyOption ToMutableConcrete() {
            var ret = new ScriptDom.PermissionSetAssemblyOption();
            ret.PermissionSetOption = permissionSetOption;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + permissionSetOption.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PermissionSetAssemblyOption);
        } 
        
        public bool Equals(PermissionSetAssemblyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.PermissionSetOption>.Default.Equals(other.PermissionSetOption, permissionSetOption)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AssemblyOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PermissionSetAssemblyOption left, PermissionSetAssemblyOption right) {
            return EqualityComparer<PermissionSetAssemblyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PermissionSetAssemblyOption left, PermissionSetAssemblyOption right) {
            return !(left == right);
        }
    
    }

}
