using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Data
{
    class Book
    {
        public Book()
        {
            this.Rentals = new HashSet<BookRental>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public int Year { get; set; }

        [Required]
        public string Language { get; set; }

        public string Category { get; set; }

        public int PageNumber { get; set; }

        public string Publisher { get; set; }

        [NotMapped]
        public virtual ICollection<BookRental> Rentals { get; }
    }
}
