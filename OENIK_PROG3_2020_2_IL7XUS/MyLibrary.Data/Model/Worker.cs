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

    public class Worker
    {
        public Worker()
        {
            this.Rentals = new HashSet<BookRental>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkerId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public char Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Salary { get; set; }

        public DateTime HireDate { get; set; }

        [NotMapped]
        public virtual ICollection<BookRental> Rentals { get; }

        public string ColumnInfo()
        {
            return "Id - Name - Birth date - Gender - Address - Email - Salary - Hire date";
        }

        public override string ToString()
        {
            return $"{this.WorkerId} - {this.Name} - {this.BirthDate.ToShortDateString()} - {this.Gender} - {this.Address} - {this.Email} - {this.Salary} - {this.HireDate.ToShortDateString()}";
        }
    }
}
