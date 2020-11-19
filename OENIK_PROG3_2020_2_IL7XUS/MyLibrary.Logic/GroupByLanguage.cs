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
            return $"A book with {this.Language} language was rented for {this.Average} days on average.";
        }

        /// <summary>
        /// Determines whether the specified object instances are considered equal.
        /// </summary>
        /// <param name="obj">An object.</param>
        /// <returns>A bool.</returns>
        public override bool Equals(object obj)
        {
            if (obj is GroupByLanguage)
            {
                return (obj as GroupByLanguage).Average == this.Average &&
                    (obj as GroupByLanguage).Language == this.Language;
            }

            return false;
        }

        /// <summary>
        /// Gives back the object's hash code.
        /// </summary>
        /// <returns>An int.</returns>
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
