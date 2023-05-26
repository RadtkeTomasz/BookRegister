using BookRegister.Domain;
using BookRegister.Infrastructure.DataPersistence;
using BookRegister.Infrastructure.DataTransferObjects;
using BookRegister.Infrastructure.Helpers;
using BookRegister.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookRegisterContext _context;


        public BookRepository(BookRegisterContext context)
        {
            _context = context;
        }

        public BookDTO GetBook(int isbn)
        {
            var book = _context.Books.Include(x => x.Genre).FirstOrDefault(x => x.ISBN == isbn);
            if (book == null)
            {
                return new BookDTO();
            }
            return ObjectMapper.MapBookToBookDTO(book);
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var list = new List<BookDTO>();
            foreach (var book in _context.Books.Include(x => x.Genre))
            {
                list.Add(ObjectMapper.MapBookToBookDTO(book));
            }
            return list;
        }

        public bool UpdateBook(BookDTO book)
        {
            if (BookExists(book.ISBN))
            {
                var dbBook = _context.Books.Include(x => x.Genre).FirstOrDefault(x => x.ISBN == book.ISBN);
                if (BookUpdateValidator.BookUpdateRequestValid(book, dbBook))
                {
                    dbBook.Description = book.Description;
                    if (_context.BookGenres.Any(x => x.GenreName == book.GenreName))
                    {
                        var genre = _context.BookGenres.FirstOrDefault(x => x.GenreName == book.GenreName);
                        dbBook.GenreID = genre.GenreID;
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        var newGenre = new BookGenre { GenreName = book.GenreName };
                        _context.BookGenres.Add(newGenre);
                        dbBook.Genre = newGenre;
                    }
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public void AddBook(Book book)
        {
            if (_context.BookGenres.Any(x => x.GenreID == book.GenreID))
            {
                _context.Books.Add(book);
            }
            else
            {
                var newGenre = new BookGenre { GenreID = book.GenreID, GenreName = book.Genre.GenreName };
                _context.BookGenres.Add(newGenre);
                book.Genre = newGenre;
                _context.Books.Add(book);
            }
            _context.SaveChanges();
        }

        public bool DeleteBook(int isbn)
        {
            if (BookExists(isbn))
            {
                _context.Books.Remove(_context.Books.First(x => x.ISBN == isbn));
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public bool BookExists(int isbn)
        {
            return (_context.Books?.Any(e => e.ISBN == isbn)).GetValueOrDefault();
        }
    }
}
