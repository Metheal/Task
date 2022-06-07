using Core.Entities;

namespace Entities.Concrete {
    public class Book : IEntity {
        public int BookId { get; set; }
        public string BookUniqueKey { get; set; }
        public string BookName { get; set; }
        public string BookAuthorName { get; set; }
    }
}
