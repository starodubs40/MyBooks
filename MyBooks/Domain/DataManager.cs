using MyBooks.Domain.Repositories.Abstract;

namespace MyBooks.Domain
{
    public class DataManager
    {
        public IBookRepository Books { get; set; }

        public IMyLibraryRepository MyLibraries { get; set; }
       
        public DataManager(IBookRepository bookRepository , IMyLibraryRepository myLibraryRepository)
        {
            Books = bookRepository;
            MyLibraries = myLibraryRepository;
        }
    }
}
