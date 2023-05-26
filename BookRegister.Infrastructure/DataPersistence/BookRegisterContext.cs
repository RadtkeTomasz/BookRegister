using BookRegister.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister.Infrastructure.DataPersistence
{
    public class BookRegisterContext : DbContext
    {
        public BookRegisterContext(DbContextOptions<BookRegisterContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BookRegisterDB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(k => k.Genre)
                .WithMany(k => k.Books)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookGenre>().HasMany(bg => bg.Books)
                .WithOne(b => b.Genre)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
