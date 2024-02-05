using System;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Entities
{
    public class Book
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public DateTime? ReleaseDate { get; set; } 


        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
