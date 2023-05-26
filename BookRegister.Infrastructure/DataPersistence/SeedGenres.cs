using BookRegister.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRegister.Infrastructure.DataPersistence
{
    public class SeedGenres : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.HasData(
              new BookGenre { GenreID = 1, GenreName = "Fantasy" },
              new BookGenre { GenreID = 2, GenreName = "ScienceFiction" },
              new BookGenre { GenreID = 3, GenreName = "History" },
              new BookGenre { GenreID = 4, GenreName = "Science" },
              new BookGenre { GenreID = 5, GenreName = "Programming" },
              new BookGenre { GenreID = 6, GenreName = "Cooking" }
              );
        }
    }
}