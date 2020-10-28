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

    public class Renter
    {
        public Renter()
        {
            this.Rentals = new HashSet<BookRental>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RenterId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        public string MembershipType { get; set; }

        public DateTime JoinDate { get; set; }

        [NotMapped]
        public virtual ICollection<BookRental> Rentals { get; }
    }
}
