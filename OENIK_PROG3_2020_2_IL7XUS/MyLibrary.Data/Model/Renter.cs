// <copyright file="Renter.cs" company="PlaceholderCompany">
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
    /// The table of renters.
    /// </summary>
    public class Renter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Renter"/> class.
        /// </summary>
        public Renter()
        {
            this.Rentals = new HashSet<BookRental>();
        }

        /// <summary>
        /// Gets or sets the renter's id, also key of the Renter table.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RenterId { get; set; }

        /// <summary>
        /// Gets or sets the renter's name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the renter's address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the renter's email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the type of the renter's membership.
        /// </summary>
        public string MembershipType { get; set; }

        /// <summary>
        /// Gets or sets the date of the renter's joining to the library.
        /// </summary>
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// Gets the virtual connection between the BookRental and the Renter table.
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
            return $"{"[ID]",-4} {"[NAME]",-25} {"[ADDRESS]",-50} {"[EMAIL]",-30} {"[MEMBERSHIP TYPE]",-20} {"[JOIN DATE]",-15}";
        }

        /// <summary>
        /// Gives back all properties of the renter.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public override string ToString()
        {
            return $"{this.RenterId,-4} {this.Name,-25} {this.Address,-50} {this.Email,-30} {this.MembershipType,-20} {this.JoinDate.ToShortDateString(),-15}";
        }
    }
}
