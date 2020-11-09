// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ConsoleTools;
    using MyLibrary.Data;
    using MyLibrary.Logic;

    public class Menu
    {
        public void BookMenu(ILibraryLogic libraryLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL BOOKS", () => this.ListAllBooks(libraryLogic))
                .Add(">> ADD A NEW BOOK", () => this.AddNewBook(libraryLogic))
                .Add(">> DELETE A BOOK", () => this.DeleteBook(libraryLogic))
                .Add(">> MODIFY A BOOK", () => this.ModifyBook())
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private void ListAllBooks(ILibraryLogic libraryLogic)
        {
            Console.WriteLine(Book.ColumnInfo());
            libraryLogic.GetAllBooks().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void AddNewBook(ILibraryLogic libraryLogic)
        {
            Console.WriteLine("Please enter the details of the new book." + ' ');
            Console.Write("ISBN number:" + ' ');
            string isbn = Console.ReadLine();
            Console.Write("\nTitle:" + ' ');
            string title = Console.ReadLine();
            Console.Write("\nAuthor's name:" + ' ');
            string authorName = Console.ReadLine();
            Console.Write("\nThe year of publishing:" + ' ');
            int year = int.Parse(Console.ReadLine());
            Console.Write("\nLanguage:" + ' ');
            string language = Console.ReadLine();
            Console.Write("\nCategory:" + ' ');
            string category = Console.ReadLine();
            Console.Write("\nNumber of pages:" + ' ');
            int pages = int.Parse(Console.ReadLine());
            Console.Write("\nPublisher's name:" + ' ');
            string publisher = Console.ReadLine();

            Book b = new Book()
            {
                ISBN = isbn,
                Title = title,
                AuthorName = authorName,
                Year = year,
                Language = language,
                Category = category,
                PageNumber = pages,
                Publisher = publisher,
            };

            libraryLogic.AddBook(b);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void DeleteBook(ILibraryLogic libraryLogic)
        {
            Console.WriteLine("Please enter the ISBN number of the book." + ' ');
            Console.Write("ID: " + ' ');
            string isbn = Console.ReadLine();

            libraryLogic.DeleteBook(isbn);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ModifyBook()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        public void WorkerMenu(IPersonLogic personLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL WORKERS", () => ListAllWorkers(personLogic))
                .Add(">> ADD A NEW WORKER", () => AddNewWorker(personLogic))
                .Add(">> DELETE A WORKER", () => DeleteWorker(personLogic))
                .Add(">> MODIFY A WORKER", () => ModifyBook())
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private void ListAllWorkers(IPersonLogic personLogic)
        {
            Console.WriteLine(Worker.ColumnInfo());
            personLogic.GetAllWorkers().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void AddNewWorker(IPersonLogic personLogic)
        {
            Console.WriteLine("Please enter the details of the new worker." + ' ');
            Console.Write("Worker's name:" + ' ');
            string name = Console.ReadLine();
            Console.Write("\nWorker's email:" + ' ');
            string email = Console.ReadLine();
            Console.Write("\nWorker's address:" + ' ');
            string address = Console.ReadLine();
            Console.Write("\nWorker's birth date:" + ' ');
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.Write("\nWorker's gender" + ' ');
            char gender = char.Parse(Console.ReadLine());
            Console.Write("\nWorker's salary:" + ' ');
            int salary = int.Parse(Console.ReadLine());
            Console.Write("\nHire date:" + ' ');
            DateTime hireDate = DateTime.Parse(Console.ReadLine());

            Worker w = new Worker()
            {
                Name = name,
                Email = email,
                Address = address,
                BirthDate = birthDate,
                Gender = gender,
                Salary = salary,
                HireDate = hireDate,
            };

            personLogic.AddWorker(w);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void DeleteWorker(IPersonLogic personLogic)
        {
            Console.WriteLine("Please enter the worker's id." + ' ');
            Console.Write("ID: " + ' ');
            int id = int.Parse(Console.ReadLine());

            personLogic.DeleteWorker(id);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ModifyWorker()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        public void RenterMenu(IPersonLogic personLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL RENTERS", () => ListAllRenters(personLogic))
                .Add(">> ADD A NEW RENTER", () => AddNewRenter(personLogic))
                .Add(">> DELETE A RENTER", () => DeleteRenter(personLogic))
                .Add(">> MODIFY A RENTER", () => ModifyRenter())
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private void ListAllRenters(IPersonLogic personLogic)
        {
            Console.WriteLine(Renter.ColumnInfo());
            personLogic.GetAllRenters().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine($"\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void AddNewRenter(IPersonLogic personLogic)
        {
            Console.WriteLine("Please enter the details of the new renter." + ' ');
            Console.Write("Renter's name:" + ' ');
            string name = Console.ReadLine();
            Console.Write("\nRenter's email:" + ' ');
            string email = Console.ReadLine();
            Console.Write("\nRenter's address:" + ' ');
            string address = Console.ReadLine();
            Console.Write("\nDate of joining:" + ' ');
            DateTime joinDate = DateTime.Parse(Console.ReadLine());
            Console.Write("\nType of membership: " + ' ');
            string membershipType = Console.ReadLine();

            Renter r = new Renter()
            {
                Name = name,
                Email = email,
                Address = address,
                JoinDate = joinDate,
                MembershipType = membershipType,
            };

            personLogic.AddRenter(r);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void DeleteRenter(IPersonLogic personLogic)
        {
            Console.WriteLine("Please enter the renter's id." + ' ');
            Console.Write("ID: " + ' ');
            int id = int.Parse(Console.ReadLine());

            personLogic.DeleteRenter(id);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ModifyRenter()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        public void RentalMenu(ILibraryLogic libraryLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL BOOK RENTALS", () => ListAllRentals(libraryLogic))
                .Add(">> ADD A BOOK RENTAL", () => AddNewRental(libraryLogic))
                .Add(">> DELETE A BOOK RENTAL", () => DeleteRental(libraryLogic))
                .Add(">> MODIFY A BOOK RENTAL", () => ModifyRental())
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private void ListAllRentals(ILibraryLogic libraryLogic)
        {
            Console.WriteLine(BookRental.ColumnInfo());
            libraryLogic.GetAllBookRentals().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void AddNewRental(ILibraryLogic libraryLogic)
        {
            Console.WriteLine("Please enter the details of the new book rental." + ' ');
            Console.Write("Book's ISBN number:" + ' ');
            string isbn = Console.ReadLine();
            Console.Write("Renter's ID:" + ' ');
            int renterId = int.Parse(Console.ReadLine());
            Console.Write("Worker's ID:" + ' ');
            int workerId = int.Parse(Console.ReadLine());
            Console.Write("The date of the rantal:" + ' ');
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Days:" + ' ');
            int days = int.Parse(Console.ReadLine());

            BookRental br = new BookRental()
            {
                ISBN = isbn,
                RenterId = renterId,
                WorkerId = workerId,
                RentalDate = date,
                Days = days,
            };

            libraryLogic.AddRental(br);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void DeleteRental(ILibraryLogic libraryLogic)
        {
            Console.WriteLine("Please enter the rental's id." + ' ');
            Console.Write("ID: " + ' ');
            int id = int.Parse(Console.ReadLine());

            libraryLogic.DeleteRental(id);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ModifyRental()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }
    }
}
