// <copyright file="RentalWithNames.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class for one of the non-crud methods. Contains information about a rental with the book's, worker's and renter's name.
    /// </summary>
    public class RentalWithNames
    {
        /// <summary>
        /// Gets or sets the ID of the rental.
        /// </summary>
        public int RentId { get; set; }

        /// <summary>
        /// Gets or sets the book's name.
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// Gets or sets the renter's name.
        /// </summary>
        public string RenterName { get; set; }

        /// <summary>
        /// Gets or sets the worker's name.
        /// </summary>
        public string WorkerName { get; set; }

        /// <summary>
        /// Gets or sets the date of the rental.
        /// </summary>
        public DateTime RentDate { get; set; }

        /// <summary>
        /// Gets or sets the number of the rental days.
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// Gives back the column names from the ToString method.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public static string ColumnInfo()
        {
            return "Rental's id - Book's name - Renter's name - Worker's name - Date of rental - Days of rental";
        }

        /// <summary>
        /// Gives back all of the properties of the query.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public override string ToString()
        {
            return $"{this.RentId} - {this.BookName} - {this.RenterName} - {this.WorkerName} - {this.RentDate.ToShortDateString()} - {this.Days}";
        }
    }
}
