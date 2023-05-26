using BookRegister.Domain;
using BookRegister.Infrastructure.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister.Infrastructure.Helpers
{
    public static class BookUpdateValidator
    {
        public static bool BookUpdateRequestValid(BookDTO dto, Book book)
        {
            if (dto.ISBN != book.ISBN || dto.Title != book.Title)
            {
                return false;
            }
            return true;
        }
    }
}
