using Entities.Concrete;
using System.Dynamic;
using System.Collections.Generic;

namespace DataAccess.Abstract {
    public interface IDynamicDal {
        string GetByUniqueKey(string uniqueKey);
        void Add(Dynamic dynamicObject, List<string> properties);
        List<string> GetSerializedObjectList();
    }
}
