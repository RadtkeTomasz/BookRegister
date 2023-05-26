using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRegister.Domain
{
    public class Book
    {
        [Key]
        public int ISBN { get; set; }
        [Required]
        [StringLength(550)]
        public string Description { get; set; }
        [Required]
        [StringLength(90)]
        public string Title { get; set; }
        [Required]
        [StringLength(60)]
        public string Author { get; set; }
        public BookGenre Genre { get; set; } = new BookGenre();
        [Required]
        public int GenreID { get; set; }
    }
}