using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookRegister.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookGenres_GenreID",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "GenreName",
                table: "BookGenres",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookGenres_GenreID",
                table: "Books",
                column: "GenreID",
                principalTable: "BookGenres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookGenres_GenreID",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "GenreName",
                table: "BookGenres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookGenres_GenreID",
                table: "Books",
                column: "GenreID",
                principalTable: "BookGenres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
