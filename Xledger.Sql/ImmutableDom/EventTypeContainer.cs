using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EventTypeContainer : EventTypeGroupContainer, IEquatable<EventTypeContainer> {
        ScriptDom.EventNotificationEventType eventType = ScriptDom.EventNotificationEventType.Unknown;
    
        public ScriptDom.EventNotificationEventType EventType => eventType;
    
        public EventTypeContainer(ScriptDom.EventNotificationEventType eventType = ScriptDom.EventNotificationEventType.Unknown) {
            this.eventType = eventType;
        }
    
        public ScriptDom.EventTypeContainer ToMutableConcrete() {
            var ret = new ScriptDom.EventTypeContainer();
            ret.EventType = eventType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + eventType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EventTypeContainer);
        } 
        
        public bool Equals(EventTypeContainer other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.EventNotificationEventType>.Default.Equals(other.EventType, eventType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EventTypeContainer left, EventTypeContainer right) {
            return EqualityComparer<EventTypeContainer>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EventTypeContainer left, EventTypeContainer right) {
            return !(left == right);
        }
    
    }

}
