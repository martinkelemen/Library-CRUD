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
                .Add(">> MODIFY A BOOK", () => this.ModifyBook(libraryLogic))
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
            Console.Write("ISBN: " + ' ');
            string isbn = Console.ReadLine();

            libraryLogic.DeleteBook(isbn);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ModifyBook(ILibraryLogic libraryLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> CHANGE BOOK'S LANGUAGE", () => this.ChangeBookLanguage(libraryLogic))
                .Add(">> CHANGE BOOK'S PUBLISHER", () => this.ChangeBookPublisher(libraryLogic))
                .Add(">> CHANGE BOOK'S PUBLISHING YEAR", () => this.ChangeBookYear(libraryLogic))
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private void ChangeBookLanguage(ILibraryLogic libraryLogic)
        {
            Console.Write("The book's ISBN number:" + ' ');
            string isbn = Console.ReadLine();
            Console.Write("The book's new language:" + ' ');
            string language = Console.ReadLine();

            libraryLogic.ChangeBookLanguage(isbn, language);
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ChangeBookPublisher(ILibraryLogic libraryLogic)
        {
            Console.Write("The book's ISBN number:" + ' ');
            string isbn = Console.ReadLine();
            Console.Write("The book's new publisher:" + ' ');
            string publisher = Console.ReadLine();

            libraryLogic.ChangeBookPublisher(isbn, publisher);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ChangeBookYear(ILibraryLogic libraryLogic)
        {
            Console.Write("The book's ISBN number:" + ' ');
            string isbn = Console.ReadLine();
            Console.Write("The book's new publishing year:" + ' ');
            int year = int.Parse(Console.ReadLine());

            libraryLogic.ChangeBookYear(isbn, year);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        public void WorkerMenu(IPersonLogic personLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL WORKERS", () => this.ListAllWorkers(personLogic))
                .Add(">> ADD A NEW WORKER", () => this.AddNewWorker(personLogic))
                .Add(">> DELETE A WORKER", () => this.DeleteWorker(personLogic))
                .Add(">> MODIFY A WORKER", () => this.ModifyWorker(personLogic))
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

        private void ModifyWorker(IPersonLogic personLogic)
        {
                var menu = new ConsoleMenu()
                    .Add(">> CHANGE WORKER'S ADDRESS", () => this.ChangeWorkerAddress(personLogic))
                    .Add(">> CHANGE WORKER'S EMAIL", () => this.ChangeWorkerEmail(personLogic))
                    .Add(">> CHANGE WORKER'S NAME", () => this.ChangeWorkerName(personLogic))
                    .Add(">> CHANGE WORKER'S SALARY", () => this.ChangeWorkerSalary(personLogic))
                    .Add(">> RETURN", ConsoleMenu.Close);

                menu.Show();
        }

        private void ChangeWorkerAddress(IPersonLogic personLogic)
        {
            Console.Write("The worker's ID:" + ' ');
            int id = int.Parse(Console.ReadLine());
            Console.Write("The worker's new address:" + ' ');
            string address = Console.ReadLine();

            personLogic.ChangeWorkerAddress(id, address);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ChangeWorkerEmail(IPersonLogic personLogic)
        {
            Console.Write("The worker's ID:" + ' ');
            int id = int.Parse(Console.ReadLine());
            Console.Write("The worker's new email:" + ' ');
            string email = Console.ReadLine();

            personLogic.ChangeWorkerEmail(id, email);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ChangeWorkerName(IPersonLogic personLogic)
        {
            Console.Write("The worker's ID:" + ' ');
            int id = int.Parse(Console.ReadLine());
            Console.Write("The worker's new name:" + ' ');
            string name = Console.ReadLine();

            personLogic.ChangeWorkerName(id, name);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ChangeWorkerSalary(IPersonLogic personLogic)
        {
            Console.Write("The worker's ID:" + ' ');
            int id = int.Parse(Console.ReadLine());
            Console.Write("The worker's new salary:" + ' ');
            int salary = int.Parse(Console.ReadLine());

            personLogic.ChangeWorkerSalary(id, salary);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        public void RenterMenu(IPersonLogic personLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL RENTERS", () => this.ListAllRenters(personLogic))
                .Add(">> ADD A NEW RENTER", () => this.AddNewRenter(personLogic))
                .Add(">> DELETE A RENTER", () => this.DeleteRenter(personLogic))
                .Add(">> MODIFY A RENTER", () => this.ModifyRenter(personLogic))
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
            Console.Write("\nType of membership:" + ' ');
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

        private void ModifyRenter(IPersonLogic personLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> CHANGE RENTER'S ADDRESS", () => this.ChangeRenterAddress(personLogic))
                .Add(">> CHANGE RENTER'S EMAIL", () => this.ChangeRenterEmail(personLogic))
                .Add(">> CHANGE RENTER'S NAME", () => this.ChangeRenterName(personLogic))
                .Add(">> CHANGE RENTER'S TYPE OF MEMBERSHIP", () => this.ChangeRenterMembershipType(personLogic))
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private void ChangeRenterAddress(IPersonLogic personLogic)
        {
            Console.Write("The renter's ID:" + ' ');
            int id = int.Parse(Console.ReadLine());
            Console.Write("The renter's new address:" + ' ');
            string address = Console.ReadLine();

            personLogic.ChangeRenterAddress(id, address);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ChangeRenterEmail(IPersonLogic personLogic)
        {
            Console.Write("The renter's ID:" + ' ');
            int id = int.Parse(Console.ReadLine());
            Console.Write("The renter's new email:" + ' ');
            string email = Console.ReadLine();

            personLogic.ChangeRenterEmail(id, email);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ChangeRenterName(IPersonLogic personLogic)
        {
            Console.Write("The renter's ID:" + ' ');
            int id = int.Parse(Console.ReadLine());
            Console.Write("The renter's new name:" + ' ');
            string name = Console.ReadLine();

            personLogic.ChangeRenterName(id, name);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ChangeRenterMembershipType(IPersonLogic personLogic)
        {
            Console.Write("The renter's ID:" + ' ');
            int id = int.Parse(Console.ReadLine());
            Console.Write("The renter's new type of membership:" + ' ');
            string membershipType = Console.ReadLine();

            personLogic.ChangeRenterMembershipType(id, membershipType);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        public void RentalMenu(ILibraryLogic libraryLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL BOOK RENTALS", () => this.ListAllRentals(libraryLogic))
                .Add(">> ADD A BOOK RENTAL", () => this.AddNewRental(libraryLogic))
                .Add(">> DELETE A BOOK RENTAL", () => this.DeleteRental(libraryLogic))
                .Add(">> MODIFY A BOOK RENTAL'S NUMBER OF DAYS", () => this.ModifyRentalDays(libraryLogic))
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

        private void ModifyRentalDays(ILibraryLogic libraryLogic)
        {
            Console.Write("The rental's ID:" + ' ');
            int id = int.Parse(Console.ReadLine());
            Console.Write("The rental's new number of days:" + ' ');
            int days = int.Parse(Console.ReadLine());

            libraryLogic.ChangeBookRentalDays(id, days);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }
    }
}
