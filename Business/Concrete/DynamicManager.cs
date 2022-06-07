using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using Core.Utilities.Helpers;
using System.Collections.Generic;

namespace Business.Concrete {
    public class DynamicManager : IDynamicService {

        IDynamicDal _dynamicDal;

        public DynamicManager(IDynamicDal dynamicDal) {
            this._dynamicDal = dynamicDal;
        }

        public dynamic GetByUniqueKey(string uniqueKey) {
            return this._dynamicDal.GetByUniqueKey(uniqueKey);
        }

        public string Add(Dynamic dynamicObject, List<string> properties) {
            dynamicObject["UniqueKey"] = UniqueKeyHelper.GenerateUniqueKey();
            this._dynamicDal.Add(dynamicObject, properties);
            return dynamicObject["UniqueKey"].ToString();
        }

        public List<string> GetAll() {
            return this._dynamicDal.GetSerializedObjectList();
        }
    }
}
