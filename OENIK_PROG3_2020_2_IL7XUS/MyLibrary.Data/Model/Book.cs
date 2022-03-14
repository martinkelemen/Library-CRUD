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
    using System.Text.Json.Serialization;

    /// <summary>
    /// The table of books.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book()
        {
            this.Rentals = new HashSet<BookRental>();
        }

        /// <summary>
        /// Gets or sets ISBN number of the book, also key of the Book table.
        /// </summary>
        [Key]
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets title of the book.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the name of the book's author.
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets the year when the book was published.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the language of the book.
        /// </summary>
        [Required]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the category of the book.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the number of pages in the book.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the book's publisher's name.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets virtual connection between the Book table and the BookRental table.
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<BookRental> Rentals { get; }

        /// <summary>
        /// Gives back the column names from the ToString method.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public static string ColumnInfo()
        {
            return $"{"[ISBN NUMBER]",-14} {"[TITLE]",-37} {"[AUTHOR'S NAME]",-25} {"[YEAR]",-8} {"[LANGUAGE]",-12} {"[CATEGORY]",-12} {"[PAGE NUMBER]",-15} {"[PUBLISHER]",-15}";
        }

        /// <summary>
        /// Gives back all properties of the book.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public override string ToString()
        {
            return $"{this.ISBN,-14} {this.Title,-37} {this.AuthorName,-25} {this.Year,-8} {this.Language,-12} {this.Category,-12} {this.PageNumber,-15} {this.Publisher,-15}";
        }
    }
}
