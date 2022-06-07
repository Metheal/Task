using Entities.Concrete;
using DataAccess.Abstract;
using Core.Utilities.Helpers;
using System.Collections.Generic;

namespace DataAccess.Concrete.InMemory {

    public class InMemoryDynamicDal : IDynamicDal {

        private List<string> _serializedObjectList;

        public InMemoryDynamicDal() {
            this._serializedObjectList = new List<string>{ };
        }

        public string GetByUniqueKey(string uniqueKey) {
            foreach (var serializedObject in this._serializedObjectList) {
                if (serializedObject.Contains(uniqueKey)) {
                    return serializedObject;
                }
            }
            return "err";
        }

        public void Add(Dynamic dynamicObject, List<string> properties) {
            var result = SerilizationHelper.SerializeDynamic(dynamicObject, properties);
            this._serializedObjectList.Add(result);
            
        }

        public List<string> GetSerializedObjectList() {
           return this._serializedObjectList;
        }
    }
}
