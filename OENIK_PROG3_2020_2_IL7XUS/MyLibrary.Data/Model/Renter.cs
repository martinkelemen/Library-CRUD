using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Data
{
    class Renter
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
