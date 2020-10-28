// <copyright file="LibraryContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {
            this.Database.EnsureCreated();
        }

        public LibraryContext(DbContextOptions<LibraryContext> options) 
            : base (options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Renter> Renters { get; set; }

        public virtual DbSet<Worker> Workers { get; set; }

        public virtual DbSet<BookRental> Rentals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LibraryDatabase.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Renter r0 = new Renter() { RenterId = 1, Name = "Arnold McCarthy", Email = "arnold.mccarthy@gmail.com", Address = "1726 Turnpike Drive, Decatur", JoinDate = new DateTime(2020, 03, 01), MembershipType = "Gold" };
            Renter r1 = new Renter() { RenterId = 2, Name = "Isaac Freeman", Email = "isaac.freeman@gmail.com", Address = "1942  John Daniel Drive, Bourbon", JoinDate = new DateTime(2019, 05, 31), MembershipType = "Casual" };
            Renter r2 = new Renter() { RenterId = 3, Name = "Steve Rodriguez", Email = "steve.rodriguez@gmail.com", Address = "4780  Lynn Avenue, Eau Claire", JoinDate = new DateTime(2019, 07, 29), MembershipType = "Casual" };
            Renter r3 = new Renter() { RenterId = 4, Name = "Ramon Rodriguez", Email = "ramon.rodriguez@gmail.com", Address = "2655  Whispering Pines Circle, Prescott", JoinDate = new DateTime(2019, 11, 11), MembershipType = "Silver" };
            Renter r4 = new Renter() { RenterId = 5, Name = "Jack Estacado", Email = "jack.estacado@gmail.com", Address = "1619  Hidden Valley Road, Harrisburg", JoinDate = new DateTime(2020, 09, 25), MembershipType = "Gold" };

            Worker w0 = new Worker() { WorkerId = 1, Name = "Cynthia Sheehan", Email = "cynthia.sheehan@n-books.com", Address = "4069  Fairmont Avenue, Kansas City", BirthDate = new DateTime(1992, 05, 20), Gender = 'F', Salary = 2500, HireDate = new DateTime(2020, 01, 23) };
            Worker w1 = new Worker() { WorkerId = 2, Name = "Montel Smith", Email = "montel.smith@n-books.com", Address = "4057  Clover Drive, Colorado Springs", BirthDate = new DateTime(1985, 12, 07), Gender = 'M', Salary = 3500, HireDate = new DateTime(2018, 12, 13) };
            Worker w2 = new Worker() { WorkerId = 3, Name = "Zackery Berger", Email = "zackery.berger@n-books.com", Address = "132  Private Lane, Buena Vista", BirthDate = new DateTime(1979, 02, 28), Gender = 'M', Salary = 2000, HireDate = new DateTime(2020, 09, 22) };
            Worker w3 = new Worker() { WorkerId = 4, Name = "Emily-Rose Dunne", Email = "emily-rose.dunne@n-books.com", Address = "4553  Spruce Drive, Pittsburgh", BirthDate = new DateTime(1997, 07, 18), Gender = 'F', Salary = 3000, HireDate = new DateTime(2019, 05, 16) };

            Book b0 = new Book() { ISBN = "1-3458-6353-2", Title = "Party Going", AuthorName = "Henry Green", Category = "novel", Language = "English", PageNumber = 256, Year = 1939, Publisher = "The Hogarth Press" };
            Book b1 = new Book() { ISBN = "0-5156-3874-9", Title = "Buddha's Little Finger", AuthorName = "Victor Pelevin", Category = "novel", Language = "English", PageNumber = 352, Year = 2001, Publisher = "Penguin Books" };
            Book b2 = new Book() { ISBN = "0-9623-2897-9", Title = "The Paris Wife", AuthorName = "Paula McLain", Category = "novel", Language = "English", PageNumber = 352, Year = 2012, Publisher = "Central Publisher" };
            Book b3 = new Book() { ISBN = "0-7170-6711-4", Title = "Terug naar Oegstgeest", AuthorName = "Jan Wolkers", Category = "novel", Language = "Dutch", PageNumber = 236, Year = 1965, Publisher = "JM Meulenhoff" };
            Book b4 = new Book() { ISBN = "0-7963-8082-1", Title = "Sometimes a Great Notion", AuthorName = "Ken Kesey", Category = "novel", Language = "English", PageNumber = 715, Year = 1964, Publisher = "Viking Press" };
            Book b5 = new Book() { ISBN = "1-4539-2696-7", Title = "The Beautiful Room Is Empty", AuthorName = "Edmund White", Category = "semi-autobiographical novel", Language = "English", PageNumber = 227, Year = 1939, Publisher = "Alfred A. Knopf" };
            Book b6 = new Book() { ISBN = "1-4748-7967-4", Title = "I, Robot", AuthorName = "Isaac Asimov", Category = "fixup novel", Language = "English", PageNumber = 253, Year = 1950, Publisher = "Gnome Press" };
            Book b7 = new Book() { ISBN = "1-5788-2367-4", Title = "Aranymenes", AuthorName = "Janos Osi", Category = "novel", Language = "Hungarian", PageNumber = 265, Year = 2017, Publisher = "Rezbong Kiado" };

            BookRental br0 = new BookRental() { RentalId = 1, RentalDate = new DateTime(2020, 10, 01), Days = 7 };
            BookRental br1 = new BookRental() { RentalId = 2, RentalDate = new DateTime(2020, 10, 01), Days = 14 };
            BookRental br2 = new BookRental() { RentalId = 3, RentalDate = new DateTime(2020, 10, 02), Days = 10 };
            BookRental br3 = new BookRental() { RentalId = 4, RentalDate = new DateTime(2020, 10, 02), Days = 15 };
            BookRental br4 = new BookRental() { RentalId = 5, RentalDate = new DateTime(2020, 10, 02), Days = 5 };
            BookRental br5 = new BookRental() { RentalId = 6, RentalDate = new DateTime(2020, 10, 03), Days = 6 };
            BookRental br6 = new BookRental() { RentalId = 7, RentalDate = new DateTime(2020, 10, 03), Days = 7 };
            BookRental br7 = new BookRental() { RentalId = 8, RentalDate = new DateTime(2020, 10, 04), Days = 12 };
            BookRental br8 = new BookRental() { RentalId = 9, RentalDate = new DateTime(2020, 10, 05), Days = 14 };
            BookRental br9 = new BookRental() { RentalId = 10, RentalDate = new DateTime(2020, 10, 05), Days = 15 };
            BookRental br10 = new BookRental() { RentalId = 11, RentalDate = new DateTime(2020, 10, 06), Days = 20 };
            BookRental br11 = new BookRental() { RentalId = 12, RentalDate = new DateTime(2020, 10, 07), Days = 30 };

            br0.ISBN = b0.ISBN;
            br0.Renter_Id = r0.RenterId;
            br0.Worker_Id = w0.WorkerId;

            br1.ISBN = b6.ISBN;
            br1.Renter_Id = r2.RenterId;
            br1.Worker_Id = w0.WorkerId;

            br2.ISBN = b5.ISBN;
            br2.Renter_Id = r3.RenterId;
            br2.Worker_Id = w1.WorkerId;

            br3.ISBN = b4.ISBN;
            br3.Renter_Id = r3.RenterId;
            br3.Worker_Id = w1.WorkerId;

            br4.ISBN = b4.ISBN;
            br4.Renter_Id = r1.RenterId;
            br4.Worker_Id = w1.WorkerId;

            br5.ISBN = b0.ISBN;
            br5.Renter_Id = r4.RenterId;
            br5.Worker_Id = w2.WorkerId;

            br6.ISBN = b3.ISBN;
            br6.Renter_Id = r0.RenterId;
            br6.Worker_Id = w2.WorkerId;

            br7.ISBN = b3.ISBN;
            br7.Renter_Id = r1.RenterId;
            br7.Worker_Id = w3.WorkerId;

            br8.ISBN = b6.ISBN;
            br8.Renter_Id = r2.RenterId;
            br8.Worker_Id = w0.WorkerId;

            br9.ISBN = b2.ISBN;
            br9.Renter_Id = r4.RenterId;
            br9.Worker_Id = w0.WorkerId;

            br10.ISBN = b2.ISBN;
            br10.Renter_Id = r3.RenterId;
            br10.Worker_Id = w1.WorkerId;

            br11.ISBN = b7.ISBN;
            br11.Renter_Id = r0.RenterId;
            br11.Worker_Id = w2.WorkerId;

            modelBuilder.Entity<BookRental>(entity =>
            {
                entity.HasOne(rental => rental.Book)
                    .WithMany(book => book.Rentals)
                    .HasForeignKey(rental => rental.ISBN)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(rental => rental.Renter)
                    .WithMany(renter => renter.Rentals)
                    .HasForeignKey(rental => rental.Renter_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(rental => rental.Worker)
                    .WithMany(worker => worker.Rentals)
                    .HasForeignKey(rental => rental.Worker_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<BookRental>().HasData(br0, br1, br2, br3, br4, br5, br6, br7, br8, br9, br10, br11);
            modelBuilder.Entity<Renter>().HasData(r0, r1, r2, r3, r4);
            modelBuilder.Entity<Worker>().HasData(w0, w1, w2, w3);
            modelBuilder.Entity<Book>().HasData(b0, b1, b2, b3, b4, b5, b6, b7);
        }
    }
}
