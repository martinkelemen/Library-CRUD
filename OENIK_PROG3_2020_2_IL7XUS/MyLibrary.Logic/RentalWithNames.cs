using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Logic
{
    public class RentalWithNames
    {
        public int RentId { get; set; }

        public string BookName { get; set; }

        public string RenterName { get; set; }

        public string WorkerName { get; set; }

        public DateTime RentDate { get; set; }

        public int Days { get; set; }

        public static string ColumnInfo()
        {
            return "Rental's id - Book's name - Renter's name - Worker's name - Date of rental - Days of rental";
        }

        public override string ToString()
        {
            return $"{this.RentId} - {this.BookName} - {this.RenterName} - {this.WorkerName} - {this.RentDate.ToShortDateString()} - {this.Days}";
        }
    }
}
