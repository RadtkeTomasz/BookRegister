using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister.Domain
{
    public class BookGenre
    {
        [Key]
        public int GenreID { get; set; }
        [StringLength(20)]
        public string GenreName { get; set; } = string.Empty;
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
