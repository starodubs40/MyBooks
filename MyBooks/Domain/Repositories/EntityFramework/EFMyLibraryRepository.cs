using MyBooks.Domain.Entities;
using MyBooks.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Domain.Repositories.EntityFramework
{
    public class EFMyLibraryRepository : IMyLibraryRepository
    {
        private readonly MyBooksContext context;

        public EFMyLibraryRepository(MyBooksContext context)
        {
            this.context = context;
        }

        public void AddBookToMyLibrary(string bookId , string userId)
        {
            MyLibrary item = new MyLibrary { UserId = userId, BookId = bookId };
            context.MyLibraries.Add(item);
            context.SaveChanges();
        }

        public void DeleteMyLibrary(Guid id)
        {
            context.MyLibraries.Remove( context.MyLibraries.FirstOrDefault(x => x.BookId == id.ToString() ) );
            context.SaveChanges();
        }

        public IQueryable<MyLibrary> GetMyLibrary(string UserId)
        {
            return context.MyLibraries.Where(x => x.UserId == UserId);
        }
    }
}
