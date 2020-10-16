using MyBooks.Domain.Entities;
using System;
using System.Linq;

namespace MyBooks.Domain.Repositories.Abstract
{
    public interface IMyLibraryRepository
    {
        IQueryable<MyLibrary> GetMyLibrary(string UserId);
       
        void DeleteMyLibrary(Guid id);

        void AddBookToMyLibrary(string bookId , string userId);
    }
}
