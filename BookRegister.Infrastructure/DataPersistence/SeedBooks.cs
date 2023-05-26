using BookRegister.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister.Infrastructure.DataPersistence
{
    public class SeedBooks : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
              new Book { ISBN = 111111, Title = "1776", GenreID = 1 , Author = "George Washington", Description = "Independence"},
              new Book { ISBN = 222311, Title = "C# Programming", GenreID = 4, Author = "Bob Gymlan", Description = "Program" },
              new Book { ISBN = 654339, Author = "Maklowicz" , Description = "Gotowanie", GenreID = 5, Title = "Florencja na talerzu"}
              );
        }
    }
}
