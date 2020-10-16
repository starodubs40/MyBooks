using MyBooks.Areas.Identity.Data;
using MyBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBooks.Domain.Repositories.Abstract
{
    public interface IBookRepository
    {
        IQueryable<Book> GetBooks();
        Book GetBookById(string id);
        Book GetBookByName(string name);
        void SaveBook(Book entity);
        void DeleteBook(Guid id);
    }
}
