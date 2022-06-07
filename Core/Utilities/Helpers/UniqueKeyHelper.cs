using System;

namespace Core.Utilities.Helpers {
    public class UniqueKeyHelper {
        public static string GenerateUniqueKey() {
            return Guid.NewGuid().ToString();
        }
    }
}
