using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Dynamic;

namespace Core.Utilities.Helpers {
    public class SerilizationHelper {

        private static string seperator = "::";
        private static string seperator2 = "=";

        public static T Deserialize<T>(string serializedObj) where T : class, new() {  
            T obj = new T ();
            var index = 0;
            foreach (var key in obj.GetType().GetProperties().Select(x => x.Name))
            {
                dynamic val = serializedObj.Split(seperator)[index];
                if (key.Contains("Id")) {
                    val = Int32.Parse(val);
                }
                obj.GetType().GetProperty(key)!.SetValue(obj, val);
                index++;
            }
            return obj;
        }

        public static string Serialize<T>(T obj) {
            return string.Join(seperator, obj!.GetType().GetProperties().
                    Select(x => x!.GetValue(obj, null)!).ToArray());
        }

        public static string SerializeDynamic(dynamic dynamicObject, List<string> properties) {
            List<string> values = new List<string>() {  };
            foreach (var property in properties) {
                values.Add(dynamicObject[property].ToString());
            }
            var dictionary = properties.Zip(values, (k, v) => new { k, v })
                .ToDictionary(x => x.k, x => x.v);
            return string.Join(seperator, dictionary.Select(kv => kv.Key + seperator2 + kv.Value).ToArray());

        }

        public static dynamic DeserializeDynamic(string serializedObj) {
            dynamic obj = new ExpandoObject();
            foreach (var item in serializedObj.Split(seperator)) {
                var splitedItem = item.Split(seperator2);
                obj[splitedItem[0]] = splitedItem[1];
            }            
            return obj;
        }
    }
}
