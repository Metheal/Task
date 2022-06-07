using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract {
    public interface IBookDal {
        Book Get(int id);
        Book GetByUniqueKey(string uniqueKey);
        List<Book> GetAll();
        void Add(Book book);
        void Delete(Book book);
        void Update(Book book);
    }
}
