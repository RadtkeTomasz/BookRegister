using BookRegister.Domain;
using BookRegister.Infrastructure.DataTransferObjects;

namespace BookRegister.Infrastructure.Repositories
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        bool BookExists(int isbn);
        bool DeleteBook(int isbn);
        IEnumerable<BookDTO> GetAllBooks();
        BookDTO GetBook(int isbn);
        bool UpdateBook(BookDTO book);
    }
}