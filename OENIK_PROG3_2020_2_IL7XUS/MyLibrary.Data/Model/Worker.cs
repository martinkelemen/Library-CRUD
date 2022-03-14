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
    using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual ICollection<BookRental> Rentals { get; }

        /// <summary>
        /// Gives back the column names from the ToString method.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public static string ColumnInfo()
        {
            return $"{"[ID]",-4} {"[NAME]",-20} {"[BIRTH DATE]",-15} {"[GENDER]",-8} {"[ADDRESS]",-40} {"[EMAIL]",-30} {"[SALARY]",-8} {"[HIRE DATE]",-15}";
        }

        /// <summary>
        /// Gives back all properties of the worker.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public override string ToString()
        {
            return $"{this.WorkerId,-4} {this.Name,-20} {this.BirthDate.ToShortDateString(),-15} {this.Gender,-8} {this.Address,-40} {this.Email,-30} {this.Salary,-8} {this.HireDate.ToShortDateString(),-15}";
        }

        /// <summary>
        /// Determines whether the specified object instances are considered equal.
        /// </summary>
        /// <param name="obj">An object.</param>
        /// <returns>A bool.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Worker)
            {
                return (obj as Worker).WorkerId == this.WorkerId;
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
