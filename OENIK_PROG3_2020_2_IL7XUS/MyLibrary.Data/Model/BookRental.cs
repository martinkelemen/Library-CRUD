// <copyright file="BookRental.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// The table of rentals.
    /// </summary>
    public class BookRental
    {
        /// <summary>
        /// Gets or sets the id of the rental, also the key of BookRental.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentalId { get; set; }

        /// <summary>
        /// Gets or sets the date of the rental.
        /// </summary>
        [Required]
        public DateTime RentalDate { get; set; }

        /// <summary>
        /// Gets or sets the days of the rental.
        /// </summary>
        [Required]
        public int Days { get; set; }

        /// <summary>
        /// Gets or sets the foreign key that references to the Renter table.
        /// </summary>
        [ForeignKey(nameof(Renter))]
        public int RenterId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key that references to the Worker table.
        /// </summary>
        [ForeignKey(nameof(Worker))]
        public int WorkerId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key that references to the Book table.
        /// </summary>
        [ForeignKey(nameof(Book))]
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets the virtual connection between the BookRental and the Renter table.
        /// </summary>
        [NotMapped]
        public virtual Renter Renter { get; set; }

        /// <summary>
        /// Gets or sets the virtual connection between the BookRental and the Worker table.
        /// </summary>
        [NotMapped]
        public virtual Worker Worker { get; set; }

        /// <summary>
        /// Gets or sets the virtual connection between the BookRental and the Book table.
        /// </summary>
        [NotMapped]
        public virtual Book Book { get; set; }

        /// <summary>
        /// Gives back the column names from the ToString method.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public static string ColumnInfo()
        {
            return "Rental date - Number of days";
        }

        /// <summary>
        /// Gives back all properties of the rental.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public override string ToString()
        {
            return $"{this.RentalDate.ToShortDateString()} - {this.Days}";
        }
    }
}
