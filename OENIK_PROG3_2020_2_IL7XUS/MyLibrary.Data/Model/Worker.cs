// <copyright file="Worker.cs" company="PlaceholderCompany">
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
    /// The table of workers.
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Worker"/> class.
        /// </summary>
        public Worker()
        {
            this.Rentals = new HashSet<BookRental>();
        }

        /// <summary>
        /// Gets or sets the worker's id, also key of the Worker table.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkerId { get; set; }

        /// <summary>
        /// Gets or sets the worker's name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the worker's birth date.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the worker's gender.
        /// </summary>
        public char Gender { get; set; }

        /// <summary>
        /// Gets or sets the worker's address.
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the worker's email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the worker's salary.
        /// </summary>
        [Required]
        public int Salary { get; set; }

        /// <summary>
        /// Gets or sets the worker's date of hire.
        /// </summary>
        public DateTime HireDate { get; set; }

        /// <summary>
        /// Gets the virtual connection between the BookRental table and the Worker table.
        /// </summary>
        [NotMapped]
        public virtual ICollection<BookRental> Rentals { get; }

        /// <summary>
        /// Gives back the column names from the ToString method.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public static string ColumnInfo()
        {
            return "Id - Name - Birth date - Gender - Address - Email - Salary - Hire date";
        }

        /// <summary>
        /// Gives back all properties of the worker.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public override string ToString()
        {
            return $"{this.WorkerId} - {this.Name} - {this.BirthDate.ToShortDateString()} - {this.Gender} - {this.Address} - {this.Email} - {this.Salary} - {this.HireDate.ToShortDateString()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Worker)
            {
                return (obj as Worker).WorkerId == this.WorkerId;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
