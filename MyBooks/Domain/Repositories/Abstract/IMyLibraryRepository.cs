using MyBooks.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Domain.Repositories.Abstract
{
    public interface IMyLibraryRepository
    {
        IQueryable<MyLibrary> GetMyLibrary(string UserId);
       
        void DeleteMyLibrary(Guid id);

        Task AddBookToMyLibrary(string bookId , string userId);
    }
}
