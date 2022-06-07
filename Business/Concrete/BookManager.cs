using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Abstract;
using Core.Utilities.Helpers;

namespace Business.Concrete {
    public class BookManager : IBookService {
        private IBookDal _bookDal;
        public BookManager(IBookDal bookDal) {
            this._bookDal = bookDal;
        }
        public Book Get(int id) {
            return this._bookDal.Get(id);
        }
        public Book GetByUniqueKey(string uniqueKey) {
            return this._bookDal.GetByUniqueKey(uniqueKey);
        }
        public List<Book> GetAll() {
            return this._bookDal.GetAll();
        }
        public string Add(Book book) {
            book.BookUniqueKey = UniqueKeyHelper.GenerateUniqueKey();
            this._bookDal.Add(book);
            return book.BookUniqueKey;
        }
        public void Delete(Book book) {
            this._bookDal.Delete(book);
        }
        public void Update(Book book) {
            this._bookDal.Update(book);
        }
    }
}
