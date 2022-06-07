using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract {
    public interface IDynamicService {
        dynamic GetByUniqueKey(string uniqueKey);
        string Add(Dynamic dynamicObject, List<string> properties);
        List<string> GetAll();
    }
}
