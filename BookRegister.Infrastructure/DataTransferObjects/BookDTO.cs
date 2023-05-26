using BookRegister.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister.Infrastructure.DataTransferObjects
{
    public class BookDTO
    {
        public int ISBN { get; set; }
        [Required]
        [StringLength(90)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(550)]
        public string Description { get ; set; } = string.Empty;
        [StringLength(20)]
        public string GenreName { get; set; } = string.Empty;
    }
}
