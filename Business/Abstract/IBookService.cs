using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract {
    public interface IBookService {
        Book Get(int id);
        Book GetByUniqueKey(string uniqueKey);
        List<Book> GetAll();
        string Add(Book book);
        void Delete(Book book);
        void Update(Book book);
    }
}
