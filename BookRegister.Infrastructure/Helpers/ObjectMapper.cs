using BookRegister.Domain;
using BookRegister.Infrastructure.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister.Infrastructure.Mappers
{
    public static class ObjectMapper
    {
        public static BookDTO MapBookToBookDTO(Book book)
        {
            return new BookDTO() {
                Description = book.Description,
                GenreName = book.Genre.GenreName,
                ISBN = book.ISBN,
                Title = book.Title,
            };
        }
    }
}
