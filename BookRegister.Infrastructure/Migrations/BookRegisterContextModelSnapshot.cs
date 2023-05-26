﻿// <auto-generated />
using BookRegister.Infrastructure.DataPersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookRegister.Infrastructure.Migrations
{
    [DbContext(typeof(BookRegisterContext))]
    partial class BookRegisterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookRegister.Domain.Book", b =>
                {
                    b.Property<int>("ISBN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ISBN"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.HasKey("ISBN");

                    b.HasIndex("GenreID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ISBN = 111111,
                            Author = "George Washington",
                            Description = "Independence",
                            GenreID = 1,
                            Title = "1776"
                        },
                        new
                        {
                            ISBN = 222311,
                            Author = "Bob Gymlan",
                            Description = "Program",
                            GenreID = 4,
                            Title = "C# Programming"
                        },
                        new
                        {
                            ISBN = 654339,
                            Author = "Maklowicz",
                            Description = "Gotowanie",
                            GenreID = 5,
                            Title = "Florencja na talerzu"
                        });
                });

            modelBuilder.Entity("BookRegister.Domain.BookGenre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreID"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("GenreID");

                    b.ToTable("BookGenres");

                    b.HasData(
                        new
                        {
                            GenreID = 1,
                            GenreName = "Fantasy"
                        },
                        new
                        {
                            GenreID = 2,
                            GenreName = "ScienceFiction"
                        },
                        new
                        {
                            GenreID = 3,
                            GenreName = "History"
                        },
                        new
                        {
                            GenreID = 4,
                            GenreName = "Science"
                        },
                        new
                        {
                            GenreID = 5,
                            GenreName = "Programming"
                        },
                        new
                        {
                            GenreID = 6,
                            GenreName = "Cooking"
                        });
                });

            modelBuilder.Entity("BookRegister.Domain.Book", b =>
                {
                    b.HasOne("BookRegister.Domain.BookGenre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BookRegister.Domain.BookGenre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
