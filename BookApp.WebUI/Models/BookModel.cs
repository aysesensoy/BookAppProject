using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        public DateTime? ReleaseDate { get; set; }

    }
}
