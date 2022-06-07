using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Abstract;

namespace DataAccess.Concrete.InMemory {
    public class InMemoryBookDal : IBookDal {
        List<Book> _books;
        public InMemoryBookDal() {
            this._books = new List<Book> {  };
        }
        public Book Get(int id) {
            foreach (var b in this._books) {
                if (id == b.BookId) {
                    return b;
                }
            }
            return new Book();
        }
        public Book GetByUniqueKey(string uniqueKey) {
            foreach (var b in this._books) {
                if (uniqueKey == b.BookUniqueKey) {
                    return b;
                }
            }
            return new Book();
        }
        public List<Book> GetAll() {
            return this._books;
        }
        public void Add(Book book) {
            this._books.Add(book);
        }
        public void Delete(Book book) {
            Book bookToDelete = this.Get(book.BookId);
            this._books.Remove(bookToDelete);
        }
        public void Update(Book book) {
            var bookToUpdate = this.Get(book.BookId);
            bookToUpdate.BookName = book.BookName;
            bookToUpdate.BookAuthorName = book.BookAuthorName;
        }
    }
}
