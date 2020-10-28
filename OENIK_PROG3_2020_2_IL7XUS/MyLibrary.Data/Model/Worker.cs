﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Data
{
    class Worker
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
    }
}