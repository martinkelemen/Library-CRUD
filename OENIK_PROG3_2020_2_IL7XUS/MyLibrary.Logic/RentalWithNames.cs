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
            return $"{"[ID]",-14} {"[TITLE]",-37} {"[RENTER'S NAME]",-30} {"[WORKER'S NAME]",-30} {"[RENTAL DATE]",-25} {"[DAYS]",-8}";
        }

        /// <summary>
        /// Gives back all of the properties of the query.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public override string ToString()
        {
            return $"{this.RentId,-14} {this.BookName,-37} {this.RenterName,-30} {this.WorkerName,-30} {this.RentDate.ToShortDateString(),-25} {this.Days,-8}";
        }

        /// <summary>
        /// Determines whether the specified object instances are considered equal.
        /// </summary>
        /// <param name="obj">An object.</param>
        /// <returns>A bool.</returns>
        public override bool Equals(object obj)
        {
            if (obj is RentalWithNames)
            {
                return (obj as RentalWithNames).RentId == this.RentId &&
                    (obj as RentalWithNames).WorkerName == this.WorkerName &&
                    (obj as RentalWithNames).RenterName == this.RenterName &&
                    (obj as RentalWithNames).BookName == this.BookName;
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
