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

    public class BookRental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentalId { get; set; }

        [Required]
        public DateTime RentalDate { get; set; }

        [Required]
        public int Days { get; set; }

        [ForeignKey(nameof(Renter))]
        public int Renter_Id { get; set; }

        [ForeignKey(nameof(Worker))]
        public int Worker_Id { get; set; }

        [ForeignKey(nameof(Book))]
        public string ISBN { get; set; }

        [NotMapped]
        public virtual Renter Renter { get; set; }

        [NotMapped]
        public virtual Worker Worker { get; set; }

        [NotMapped]
        public virtual Book Book { get; set; }

        public string ColumnInfo()
        {
            return "Rental date - Number of days";
        }

        public override string ToString()
        {
            return $"{this.RentalDate.ToShortDateString()} - {this.Days}";
        }
    }
}
