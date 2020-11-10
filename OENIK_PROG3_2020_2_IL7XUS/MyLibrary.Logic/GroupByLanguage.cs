// <copyright file="GroupByLanguage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class for one of the non-crud methods. Contains information about how many was the rental days on average groupped by the language of the book.
    /// </summary>
    public class GroupByLanguage
    {
        /// <summary>
        /// Gets or sets the language of the books.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the number of rental days on average.
        /// </summary>
        public double Average { get; set; }

        /// <summary>
        /// Gives back all of the properties of the query.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public override string ToString()
        {
            return $"A book with {this.Language} language was rented {this.Average} days on average.";
        }
    }
}
