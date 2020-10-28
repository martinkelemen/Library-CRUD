using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Data
{
    class BookRental
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
    }
}
