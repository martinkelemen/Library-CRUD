// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Program
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using ConsoleTools;
    using MyLibrary.Data;
    using MyLibrary.Logic;

    /// <summary>
    /// The class for the program's menu options.
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// A non-crud method. Groups by languages with averages of the number of rental days.
        /// </summary>
        /// <param name="libraryLogic">The logic class of the library.</param>
        public static void GroupByLanguages(ILibraryLogic libraryLogic)
        {
            if (libraryLogic != null)
            {
                var results = libraryLogic.GetRentByLanguage();

                foreach (var item in results)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        /// <summary>
        /// A non-crud method. Groups by membership types and count them.
        /// </summary>
        /// <param name="libraryLogic">The logic class of the library.</param>
        public static void GroupByMembershipType(ILibraryLogic libraryLogic)
        {
            if (libraryLogic != null)
            {
                var results = libraryLogic.GetRentByMembership();

                foreach (var item in results)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        /// <summary>
        /// A non-crud method. List all of the book rentals with the book's, worker's and renter's names.
        /// </summary>
        /// <param name="libraryLogic">The logic class of the library.</param>
        public static void ListAllRentsWithNames(ILibraryLogic libraryLogic)
        {
            if (libraryLogic != null)
            {
                var rentals = libraryLogic.ListAllRents();
                Console.WriteLine(RentalWithNames.ColumnInfo());

                foreach (var rent in rentals)
                {
                    Console.WriteLine(rent);
                }
            }

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        /// <summary>
        /// Lists the options of the books' collection.
        /// </summary>
        /// <param name="libraryLogic">The logic class of the library.</param>
        public static void BookMenu(ILibraryLogic libraryLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL BOOKS", () => ListAllBooks(libraryLogic))
                .Add(">> ADD A NEW BOOK", () => AddNewBook(libraryLogic))
                .Add(">> DELETE A BOOK", () => DeleteBook(libraryLogic))
                .Add(">> MODIFY A BOOK", () => ModifyBook(libraryLogic))
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        /// <summary>
        /// Lists the options of the worker' collection.
        /// </summary>
        /// <param name="personLogic">The logic class of the people.</param>
        public static void WorkerMenu(IPersonLogic personLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL WORKERS", () => ListAllWorkers(personLogic))
                .Add(">> ADD A NEW WORKER", () => AddNewWorker(personLogic))
                .Add(">> DELETE A WORKER", () => DeleteWorker(personLogic))
                .Add(">> MODIFY A WORKER", () => ModifyWorker(personLogic))
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        /// <summary>
        /// Lists the options of the renters' collection.
        /// </summary>
        /// <param name="personLogic">The logic class of the people.</param>
        public static void RenterMenu(IPersonLogic personLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL RENTERS", () => ListAllRenters(personLogic))
                .Add(">> ADD A NEW RENTER", () => AddNewRenter(personLogic))
                .Add(">> DELETE A RENTER", () => DeleteRenter(personLogic))
                .Add(">> MODIFY A RENTER", () => ModifyRenter(personLogic))
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        /// <summary>
        /// Lists the options of the rentals' collection.
        /// </summary>
        /// <param name="libraryLogic">The logic class of the library.</param>
        public static void RentalMenu(ILibraryLogic libraryLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL BOOK RENTALS", () => ListAllRentals(libraryLogic))
                .Add(">> ADD A BOOK RENTAL", () => AddNewRental(libraryLogic))
                .Add(">> DELETE A BOOK RENTAL", () => DeleteRental(libraryLogic))
                .Add(">> MODIFY A BOOK RENTAL'S NUMBER OF DAYS", () => ModifyRentalDays(libraryLogic))
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private static void ListAllBooks(ILibraryLogic libraryLogic)
        {
            Console.WriteLine(Book.ColumnInfo());
            libraryLogic.GetAllBooks().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void AddNewBook(ILibraryLogic libraryLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.WriteLine("Please enter the details of the new book." + ' ');
            Console.Write("ISBN number:" + ' ');
            string isbn = Console.ReadLine();
            Console.Write("\nTitle:" + ' ');
            string title = Console.ReadLine();
            Console.Write("\nAuthor's name:" + ' ');
            string authorName = Console.ReadLine();
            Console.Write("\nThe year of publishing:" + ' ');
            int year = int.Parse(Console.ReadLine(), ci);
            Console.Write("\nLanguage:" + ' ');
            string language = Console.ReadLine();
            Console.Write("\nCategory:" + ' ');
            string category = Console.ReadLine();
            Console.Write("\nNumber of pages:" + ' ');
            int pages = int.Parse(Console.ReadLine(), ci);
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

        private static void DeleteBook(ILibraryLogic libraryLogic)
        {
            Console.WriteLine("Please enter the ISBN number of the book." + ' ');
            Console.Write("ISBN: " + ' ');
            string isbn = Console.ReadLine();

            libraryLogic.DeleteBook(isbn);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ModifyBook(ILibraryLogic libraryLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> CHANGE BOOK'S LANGUAGE", () => ChangeBookLanguage(libraryLogic))
                .Add(">> CHANGE BOOK'S PUBLISHER", () => ChangeBookPublisher(libraryLogic))
                .Add(">> CHANGE BOOK'S PUBLISHING YEAR", () => ChangeBookYear(libraryLogic))
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private static void ChangeBookLanguage(ILibraryLogic libraryLogic)
        {
            Console.Write("The book's ISBN number:" + ' ');
            string isbn = Console.ReadLine();
            Console.Write("The book's new language:" + ' ');
            string language = Console.ReadLine();

            libraryLogic.ChangeBookLanguage(isbn, language);
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeBookPublisher(ILibraryLogic libraryLogic)
        {
            Console.Write("The book's ISBN number:" + ' ');
            string isbn = Console.ReadLine();
            Console.Write("The book's new publisher:" + ' ');
            string publisher = Console.ReadLine();

            libraryLogic.ChangeBookPublisher(isbn, publisher);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeBookYear(ILibraryLogic libraryLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.Write("The book's ISBN number:" + ' ');
            string isbn = Console.ReadLine();
            Console.Write("The book's new publishing year:" + ' ');
            int year = int.Parse(Console.ReadLine(), ci);

            libraryLogic.ChangeBookYear(isbn, year);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ListAllWorkers(IPersonLogic personLogic)
        {
            Console.WriteLine(Worker.ColumnInfo());
            personLogic.GetAllWorkers().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void AddNewWorker(IPersonLogic personLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.WriteLine("Please enter the details of the new worker." + ' ');
            Console.Write("Worker's name:" + ' ');
            string name = Console.ReadLine();
            Console.Write("\nWorker's email:" + ' ');
            string email = Console.ReadLine();
            Console.Write("\nWorker's address:" + ' ');
            string address = Console.ReadLine();
            Console.Write("\nWorker's birth date:" + ' ');
            DateTime birthDate = DateTime.Parse(Console.ReadLine(), ci);
            Console.Write("\nWorker's gender" + ' ');
            char gender = char.Parse(Console.ReadLine());
            Console.Write("\nWorker's salary:" + ' ');
            int salary = int.Parse(Console.ReadLine(), ci);
            Console.Write("\nHire date:" + ' ');
            DateTime hireDate = DateTime.Parse(Console.ReadLine(), ci);

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

        private static void DeleteWorker(IPersonLogic personLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.WriteLine("Please enter the worker's id." + ' ');
            Console.Write("ID: " + ' ');
            int id = int.Parse(Console.ReadLine(), ci);

            personLogic.DeleteWorker(id);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ModifyWorker(IPersonLogic personLogic)
        {
                var menu = new ConsoleMenu()
                    .Add(">> CHANGE WORKER'S ADDRESS", () => ChangeWorkerAddress(personLogic))
                    .Add(">> CHANGE WORKER'S EMAIL", () => ChangeWorkerEmail(personLogic))
                    .Add(">> CHANGE WORKER'S NAME", () => ChangeWorkerName(personLogic))
                    .Add(">> CHANGE WORKER'S SALARY", () => ChangeWorkerSalary(personLogic))
                    .Add(">> RETURN", ConsoleMenu.Close);

                menu.Show();
        }

        private static void ChangeWorkerAddress(IPersonLogic personLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.Write("The worker's ID:" + ' ');
            int id = int.Parse(Console.ReadLine(), ci);
            Console.Write("The worker's new address:" + ' ');
            string address = Console.ReadLine();

            personLogic.ChangeWorkerAddress(id, address);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeWorkerEmail(IPersonLogic personLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.Write("The worker's ID:" + ' ');
            int id = int.Parse(Console.ReadLine(), ci);
            Console.Write("The worker's new email:" + ' ');
            string email = Console.ReadLine();

            personLogic.ChangeWorkerEmail(id, email);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeWorkerName(IPersonLogic personLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.Write("The worker's ID:" + ' ');
            int id = int.Parse(Console.ReadLine(), ci);
            Console.Write("The worker's new name:" + ' ');
            string name = Console.ReadLine();

            personLogic.ChangeWorkerName(id, name);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeWorkerSalary(IPersonLogic personLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.Write("The worker's ID:" + ' ');
            int id = int.Parse(Console.ReadLine(), ci);
            Console.Write("The worker's new salary:" + ' ');
            int salary = int.Parse(Console.ReadLine(), ci);

            personLogic.ChangeWorkerSalary(id, salary);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ListAllRenters(IPersonLogic personLogic)
        {
            Console.WriteLine(Renter.ColumnInfo());
            personLogic.GetAllRenters().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine($"\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void AddNewRenter(IPersonLogic personLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.WriteLine("Please enter the details of the new renter." + ' ');
            Console.Write("Renter's name:" + ' ');
            string name = Console.ReadLine();
            Console.Write("\nRenter's email:" + ' ');
            string email = Console.ReadLine();
            Console.Write("\nRenter's address:" + ' ');
            string address = Console.ReadLine();
            Console.Write("\nDate of joining:" + ' ');
            DateTime joinDate = DateTime.Parse(Console.ReadLine(), ci);
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

        private static void DeleteRenter(IPersonLogic personLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.WriteLine("Please enter the renter's id." + ' ');
            Console.Write("ID: " + ' ');
            int id = int.Parse(Console.ReadLine(), ci);

            personLogic.DeleteRenter(id);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ModifyRenter(IPersonLogic personLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> CHANGE RENTER'S ADDRESS", () => ChangeRenterAddress(personLogic))
                .Add(">> CHANGE RENTER'S EMAIL", () => ChangeRenterEmail(personLogic))
                .Add(">> CHANGE RENTER'S NAME", () => ChangeRenterName(personLogic))
                .Add(">> CHANGE RENTER'S TYPE OF MEMBERSHIP", () => ChangeRenterMembershipType(personLogic))
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private static void ChangeRenterAddress(IPersonLogic personLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.Write("The renter's ID:" + ' ');
            int id = int.Parse(Console.ReadLine(), ci);
            Console.Write("The renter's new address:" + ' ');
            string address = Console.ReadLine();

            personLogic.ChangeRenterAddress(id, address);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeRenterEmail(IPersonLogic personLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.Write("The renter's ID:" + ' ');
            int id = int.Parse(Console.ReadLine(), ci);
            Console.Write("The renter's new email:" + ' ');
            string email = Console.ReadLine();

            personLogic.ChangeRenterEmail(id, email);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeRenterName(IPersonLogic personLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.Write("The renter's ID:" + ' ');
            int id = int.Parse(Console.ReadLine(), ci);
            Console.Write("The renter's new name:" + ' ');
            string name = Console.ReadLine();

            personLogic.ChangeRenterName(id, name);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeRenterMembershipType(IPersonLogic personLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.Write("The renter's ID:" + ' ');
            int id = int.Parse(Console.ReadLine(), ci);
            Console.Write("The renter's new type of membership:" + ' ');
            string membershipType = Console.ReadLine();

            personLogic.ChangeRenterMembershipType(id, membershipType);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ListAllRentals(ILibraryLogic libraryLogic)
        {
            Console.WriteLine(BookRental.ColumnInfo());
            libraryLogic.GetAllBookRentals().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void AddNewRental(ILibraryLogic libraryLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.WriteLine("Please enter the details of the new book rental." + ' ');
            Console.Write("Book's ISBN number:" + ' ');
            string isbn = Console.ReadLine();
            Console.Write("Renter's ID:" + ' ');
            int renterId = int.Parse(Console.ReadLine(), ci);
            Console.Write("Worker's ID:" + ' ');
            int workerId = int.Parse(Console.ReadLine(), ci);
            Console.Write("The date of the rantal:" + ' ');
            DateTime date = DateTime.Parse(Console.ReadLine(), ci);
            Console.Write("Days:" + ' ');
            int days = int.Parse(Console.ReadLine(), ci);

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

        private static void DeleteRental(ILibraryLogic libraryLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.WriteLine("Please enter the rental's id." + ' ');
            Console.Write("ID: " + ' ');
            int id = int.Parse(Console.ReadLine(), ci);

            libraryLogic.DeleteRental(id);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ModifyRentalDays(ILibraryLogic libraryLogic)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;

            Console.Write("The rental's ID:" + ' ');
            int id = int.Parse(Console.ReadLine(), ci);
            Console.Write("The rental's new number of days:" + ' ');
            int days = int.Parse(Console.ReadLine(), ci);

            libraryLogic.ChangeBookRentalDays(id, days);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }
    }
}
