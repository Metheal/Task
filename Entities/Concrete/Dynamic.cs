using Core.Entities;
using System.Dynamic;
using System.Collections.Generic;

namespace Entities.Concrete {
    public class Dynamic : DynamicObject, IEntity {

        Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public object this[string propertyName] {
            get { return _dictionary[propertyName]; }
            set { AddProperty(propertyName, value); }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            return _dictionary.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value) {
            AddProperty(binder.Name, value);
            return true;
        }

        public void AddProperty(string name, object value) {
            _dictionary[name] = value;
        }
    }
}
