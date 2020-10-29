// <copyright file="Book.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Book
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

        public string ColumnInfo()
        {
            return "ISBN number - Title - AuthorName - Year - Language - Category - PageNumber - Publisher";
        }

        public override string ToString()
        {
            return $"{this.ISBN} - {this.Title} - {this.AuthorName} - {this.Year} - {this.Language} - {this.Category} - {this.PageNumber} - {this.Publisher}";
        }
    }
}
