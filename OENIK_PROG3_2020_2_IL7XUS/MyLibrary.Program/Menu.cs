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
    using MyLibrary.Repository;

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
        /// A non-crud method. Groups by languages with averages of the number of rental days.
        /// </summary>
        /// <param name="libraryLogic">The logic class of the library.</param>
        public static void GroupByLanguagesAsync(ILibraryLogic libraryLogic)
        {
            if (libraryLogic != null)
            {
                var result = libraryLogic.GetRentByLanguageAsync().Result;

                foreach (var item in result)
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
        /// A non-crud method. Groups by membership types and count them.
        /// </summary>
        /// <param name="libraryLogic">The logic class of the library.</param>
        public static void GroupByMembershipTypeAsync(ILibraryLogic libraryLogic)
        {
            if (libraryLogic != null)
            {
                var result = libraryLogic.GetRentByMembershipAsync().Result;

                foreach (var item in result)
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

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n" + RentalWithNames.ColumnInfo() + "\n");
                Console.ForegroundColor = ConsoleColor.White;

                foreach (var rent in rentals)
                {
                    Console.WriteLine(rent);
                }
            }

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        /// <summary>
        /// A non-crud method. List all of the book rentals with the book's, worker's and renter's names.
        /// </summary>
        /// <param name="libraryLogic">The logic class of the library.</param>
        public static void ListAllRentsWithNamesAsync(ILibraryLogic libraryLogic)
        {
            if (libraryLogic != null)
            {
                var rentals = libraryLogic.ListAllRentsAsync().Result;

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n" + RentalWithNames.ColumnInfo() + "\n");
                Console.ForegroundColor = ConsoleColor.White;

                foreach (var item in rentals)
                {
                    Console.WriteLine(item);
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
                .Add(">> GET ONE BOOK", () => GetOneBook(libraryLogic))
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
                .Add(">> GET ONE WORKER", () => GetOneWorker(personLogic))
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
                .Add(">> GET ONE RENTER", () => GetOneRenter(personLogic))
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
        /// <param name="personLogic">The logic class of the people.</param>
        public static void RentalMenu(ILibraryLogic libraryLogic, IPersonLogic personLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL BOOK RENTALS", () => ListAllRentals(libraryLogic))
                .Add(">> GET ONE BOOK RENTAL", () => GetOneRental(libraryLogic))
                .Add(">> ADD A BOOK RENTAL", () => AddNewRental(libraryLogic, personLogic))
                .Add(">> DELETE A BOOK RENTAL", () => DeleteRental(libraryLogic))
                .Add(">> MODIFY A BOOK RENTAL'S NUMBER OF DAYS", () => ModifyRentalDays(libraryLogic))
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private static void ListAllBooks(ILibraryLogic libraryLogic, bool cnt = true)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n" + Book.ColumnInfo() + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            libraryLogic.GetAllBooks().ToList().ForEach(x => Console.WriteLine(x.ToString()));

            if (cnt)
            {
                Console.WriteLine("\nPress a button to continue." + ' ');
                Console.ReadKey();
            }
        }

        private static void GetOneBook(ILibraryLogic libraryLogic)
        {
            Console.WriteLine("Please enter the ISBN number of the book." + ' ');
            Console.Write("ISBN:" + ' ');
            string isbn = Console.ReadLine();
            Book b = libraryLogic.GetBookById(isbn);

            if (b != null)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n" + Book.ColumnInfo() + "\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(b);
            }
            else
            {
                Console.WriteLine("\nThere is no such book with this ISBN number." + ' ');
            }

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void AddNewBook(ILibraryLogic libraryLogic)
        {
            bool success;

            try
            {
                Console.WriteLine("Please enter the details of the new book." + ' ');
                Console.Write("ISBN number:" + ' ');
                string isbn = Console.ReadLine();
                Console.Write("\nTitle:" + ' ');
                string title = Console.ReadLine();
                Console.Write("\nAuthor's name:" + ' ');
                string authorName = Console.ReadLine();
                int year;
                do
                {
                    Console.Write("\nThe year of publishing:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out year);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                }
                while (!success);
                Console.Write("\nLanguage:" + ' ');
                string language = Console.ReadLine();
                Console.Write("\nCategory:" + ' ');
                string category = Console.ReadLine();
                int pages;
                do
                {
                    Console.Write("\nNumber of pages:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out pages);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                }
                while (!success);
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
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("There is already a book with this ID in the table." + ' ');
            }

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void DeleteBook(ILibraryLogic libraryLogic)
        {
            ListAllBooks(libraryLogic, false);
            Console.WriteLine();

            try
            {
                Console.WriteLine("Please enter the ISBN number of the book." + ' ');
                Console.Write("ISBN: " + ' ');
                string isbn = Console.ReadLine();

                libraryLogic.DeleteBook(isbn);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("There is no book with this ISBN number." + ' ');
            }

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
            ListAllBooks(libraryLogic, false);
            Console.WriteLine();

            try
            {
                Console.Write("The book's ISBN number:" + ' ');
                string isbn = Console.ReadLine();
                Console.Write("The book's new language:" + ' ');
                string language = Console.ReadLine();

                libraryLogic.ChangeBookLanguage(isbn, language);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("There is no book with this ISBN number." + ' ');
            }

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeBookPublisher(ILibraryLogic libraryLogic)
        {
            ListAllBooks(libraryLogic, false);
            Console.WriteLine();

            try
            {
                Console.Write("The book's ISBN number:" + ' ');
                string isbn = Console.ReadLine();
                Console.Write("The book's new publisher:" + ' ');
                string publisher = Console.ReadLine();

                libraryLogic.ChangeBookPublisher(isbn, publisher);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("There is no book with this ISBN number." + ' ');
            }

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeBookYear(ILibraryLogic libraryLogic)
        {
            ListAllBooks(libraryLogic, false);
            Console.WriteLine();

            bool success;
            int year;

            try
            {
                Console.Write("The book's ISBN number:" + ' ');
                string isbn = Console.ReadLine();
                do
                {
                    Console.Write("The book's new publishing year:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out year);
                }
                while (!success);

                libraryLogic.ChangeBookYear(isbn, year);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("There is no book with this ISBN number." + ' ');
            }

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ListAllWorkers(IPersonLogic personLogic, bool cnt = true)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n" + Worker.ColumnInfo() + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            personLogic.GetAllWorkers().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();

            if (cnt)
            {
                Console.WriteLine("\nPress a button to continue." + ' ');
                Console.ReadKey();
            }
        }

        private static void GetOneWorker(IPersonLogic personLogic)
        {
            bool success;
            int id;

            do
            {
                Console.WriteLine("Please enter the ID of the worker." + ' ');
                Console.Write("ID:" + ' ');
                success = int.TryParse(Console.ReadLine(), out id);

                if (!success)
                {
                    Console.WriteLine("This is not a number." + ' ');
                }
                else
                {
                    try
                    {
                        Worker w = personLogic.GetWorkerById(id);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\n" + Worker.ColumnInfo() + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(w);
                    }
                    catch (IDOutOfRangeException e)
                    {
                        Console.WriteLine("\n" + e.Message);
                    }
                }
            }
            while (!success);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void AddNewWorker(IPersonLogic personLogic)
        {
            bool success;

            Console.WriteLine("Please enter the details of the new worker." + ' ');
            Console.Write("Worker's name:" + ' ');
            string name = Console.ReadLine();
            Console.Write("\nWorker's email:" + ' ');
            string email = Console.ReadLine();
            Console.Write("\nWorker's address:" + ' ');
            string address = Console.ReadLine();
            DateTime birthDate;
            do
            {
                Console.Write("\nWorker's birth date(Year, Month, Day):" + ' ');
                success = DateTime.TryParse(Console.ReadLine(), out birthDate);
                if (!success)
                {
                    Console.WriteLine("Wrong format." + ' ');
                }
            }
            while (!success);
            char gender;
            do
            {
                Console.Write("\nWorker's gender(M or F)" + ' ');
                success = char.TryParse(Console.ReadLine(), out gender);
                if (!success)
                {
                    Console.WriteLine("This is not a character." + ' ');
                }
            }
            while (!success || gender != 'F' || gender != 'M');
            int salary;
            do
            {
                Console.Write("\nWorker's salary:" + ' ');
                success = int.TryParse(Console.ReadLine(), out salary);
                if (!success)
                {
                    Console.WriteLine("This is not a number." + ' ');
                }
            }
            while (!success);
            DateTime hireDate;
            do
            {
                Console.Write("\nHire date:" + ' ');
                success = DateTime.TryParse(Console.ReadLine(), out hireDate);
                if (!success)
                {
                    Console.WriteLine("Wrong format." + ' ');
                }
            }
            while (!success);

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
            ListAllWorkers(personLogic, false);
            Console.WriteLine();

            bool success;
            int id;

            try
            {
                Console.WriteLine("Please enter the worker's id." + ' ');
                Console.Write("ID: " + ' ');
                success = int.TryParse(Console.ReadLine(), out id);
                if (!success)
                {
                    Console.WriteLine("This is not a number." + ' ');
                }
                else
                {
                    personLogic.DeleteWorker(id);
                }
            }
            catch (IDOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

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
            ListAllWorkers(personLogic, false);
            Console.WriteLine();

            bool success;
            int id;

            do
            {
                try
                {
                    Console.Write("The worker's ID:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out id);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                    else
                    {
                        Console.Write("The worker's new address:" + ' ');
                        string address = Console.ReadLine();

                        personLogic.ChangeWorkerAddress(id, address);
                    }
                }
                catch (IDOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    success = true;
                }
            }
            while (!success);
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeWorkerEmail(IPersonLogic personLogic)
        {
            ListAllWorkers(personLogic, false);
            Console.WriteLine();

            bool success;
            int id;

            do
            {
                try
                {
                    Console.Write("The worker's ID:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out id);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                    else
                    {
                        Console.Write("The worker's new email:" + ' ');
                        string email = Console.ReadLine();

                        personLogic.ChangeWorkerEmail(id, email);
                    }
                }
                catch (IDOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    success = true;
                }
            }
            while (!success);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeWorkerName(IPersonLogic personLogic)
        {
            ListAllWorkers(personLogic, false);
            Console.WriteLine();

            bool success;
            int id;

            do
            {
                try
                {
                    Console.Write("The worker's ID:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out id);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                    else
                    {
                        Console.Write("The worker's new name:" + ' ');
                        string name = Console.ReadLine();

                        personLogic.ChangeWorkerName(id, name);
                    }
                }
                catch (IDOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    success = true;
                }
            }
            while (!success);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeWorkerSalary(IPersonLogic personLogic)
        {
            ListAllWorkers(personLogic, false);
            Console.WriteLine();

            bool success;
            int id;
            int salary;

            do
            {
                try
                {
                    Console.Write("The worker's ID:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out id);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                    else
                    {
                        Console.Write("The worker's new salary:" + ' ');
                        success = int.TryParse(Console.ReadLine(), out salary);
                        if (!success)
                        {
                            Console.WriteLine("This is not a number." + ' ');
                        }
                        else
                        {
                            personLogic.ChangeWorkerSalary(id, salary);
                        }
                    }
                }
                catch (IDOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    success = true;
                }
            }
            while (!success);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ListAllRenters(IPersonLogic personLogic, bool cnt = true)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n" + Renter.ColumnInfo() + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            personLogic.GetAllRenters().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine($"\nPress a button to continue." + ' ');
            Console.ReadKey();

            if (cnt)
            {
                Console.WriteLine("\nPress a button to continue." + ' ');
                Console.ReadKey();
            }
        }

        private static void GetOneRenter(IPersonLogic personLogic)
        {
            bool success;
            int id;

            do
            {
                Console.WriteLine("Please enter the ID of the renter." + ' ');
                Console.Write("ID:" + ' ');
                success = int.TryParse(Console.ReadLine(), out id);

                if (!success)
                {
                    Console.WriteLine("This is not a number." + ' ');
                }
                else
                {
                    try
                    {
                        Renter r = personLogic.GetRenterById(id);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\n" + Renter.ColumnInfo() + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(r);
                    }
                    catch (IDOutOfRangeException e)
                    {
                        Console.WriteLine("\n" + e.Message);
                    }
                }
            }
            while (!success);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void AddNewRenter(IPersonLogic personLogic)
        {
            bool success;

            Console.WriteLine("Please enter the details of the new renter." + ' ');
            Console.Write("Renter's name:" + ' ');
            string name = Console.ReadLine();
            Console.Write("\nRenter's email:" + ' ');
            string email = Console.ReadLine();
            Console.Write("\nRenter's address:" + ' ');
            string address = Console.ReadLine();
            DateTime joinDate;
            do
            {
                Console.Write("\nDate of joining(Year, Month, Day):" + ' ');
                success = DateTime.TryParse(Console.ReadLine(), out joinDate);
                if (!success)
                {
                    Console.WriteLine("Wrong format." + ' ');
                }
            }
            while (!success);
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
            ListAllRenters(personLogic, false);
            Console.WriteLine();

            bool success;
            int id;

            do
            {
                try
                {
                    Console.WriteLine("Please enter the renter's id." + ' ');
                    Console.Write("ID: " + ' ');
                    success = int.TryParse(Console.ReadLine(), out id);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                    else
                    {
                        personLogic.DeleteRenter(id);
                    }
                }
                catch (IDOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    success = true;
                }
            }
            while (!success);

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
            ListAllRenters(personLogic, false);
            Console.WriteLine();

            bool success;
            int id;

            do
            {
                try
                {
                    Console.Write("The renter's ID:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out id);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                    else
                    {
                        Console.Write("The renter's new address:" + ' ');
                        string address = Console.ReadLine();

                        personLogic.ChangeRenterAddress(id, address);
                    }
                }
                catch (IDOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    success = true;
                }
            }
            while (!success);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeRenterEmail(IPersonLogic personLogic)
        {
            ListAllRenters(personLogic, false);
            Console.WriteLine();

            bool success;
            int id;

            do
            {
                try
                {
                    Console.Write("The renter's ID:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out id);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                    else
                    {
                        Console.Write("The renter's new email:" + ' ');
                        string email = Console.ReadLine();

                        personLogic.ChangeRenterEmail(id, email);
                    }
                }
                catch (IDOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    success = true;
                }
            }
            while (!success);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeRenterName(IPersonLogic personLogic)
        {
            ListAllRenters(personLogic, false);
            Console.WriteLine();

            bool success;
            int id;

            do
            {
                try
                {
                    Console.Write("The renter's ID:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out id);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                    else
                    {
                        Console.Write("The renter's new name:" + ' ');
                        string name = Console.ReadLine();

                        personLogic.ChangeRenterName(id, name);
                    }
                }
                catch (IDOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    success = true;
                }
            }
            while (!success);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ChangeRenterMembershipType(IPersonLogic personLogic)
        {
            ListAllRenters(personLogic, false);
            Console.WriteLine();

            bool success;
            int id;

            do
            {
                try
                {
                    Console.Write("The renter's ID:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out id);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                    else
                    {
                        Console.Write("The renter's new type of membership:" + ' ');
                        string membershipType = Console.ReadLine();
                        personLogic.ChangeRenterMembershipType(id, membershipType);
                    }
                }
                catch (IDOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    success = true;
                }
            }
            while (!success);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ListAllRentals(ILibraryLogic libraryLogic, bool cnt = true)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n" + BookRental.ColumnInfo() + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            libraryLogic.GetAllBookRentals().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();

            if (cnt)
            {
                Console.WriteLine("\nPress a button to continue." + ' ');
                Console.ReadKey();
            }
        }

        private static void GetOneRental(ILibraryLogic libraryLogic)
        {
            bool success;
            int id;

            do
            {
                Console.WriteLine("Please enter the ID of the rental." + ' ');
                Console.Write("ID:" + ' ');
                success = int.TryParse(Console.ReadLine(), out id);

                if (!success)
                {
                    Console.WriteLine("This is not a number." + ' ');
                }
                else
                {
                    try
                    {
                        BookRental br = libraryLogic.GetBookRentalById(id);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\n" + BookRental.ColumnInfo() + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(br);
                    }
                    catch (IDOutOfRangeException e)
                    {
                        Console.WriteLine("\n" + e.Message);
                    }
                }
            }
            while (!success);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void AddNewRental(ILibraryLogic libraryLogic, IPersonLogic personLogic)
        {
            bool success;

            Console.WriteLine("Please enter the details of the new book rental." + ' ');
            string isbn = string.Empty;
            do
            {
                try
                {
                    Console.Write("Book's ISBN number:" + ' ');
                    isbn = Console.ReadLine();
                    Book b = libraryLogic.GetBookById(isbn);
                    success = true;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("There is not a book with this ISBN number." + ' ');
                    success = false;
                }
            }
            while (!success);
            int renterId = int.MaxValue;
            do
            {
                try
                {
                    Console.Write("Renter's ID:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out renterId);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                    else
                    {
                        Renter r = personLogic.GetRenterById(renterId);
                    }
                }
                catch (IDOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    success = false;
                }
            }
            while (!success);
            int workerId = int.MaxValue;
            do
            {
                try
                {
                    Console.Write("Worker's ID:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out workerId);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                    else
                    {
                        Worker w = personLogic.GetWorkerById(workerId);
                    }
                }
                catch (IDOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    success = false;
                }
            }
            while (!success);
            DateTime date;
            do
            {
                Console.Write("The date of the rental(Year, Month, Day):" + ' ');
                success = DateTime.TryParse(Console.ReadLine(), out date);
                if (!success)
                {
                    Console.WriteLine("Wrong format." + ' ');
                }
            }
            while (!success);
            int days;
            do
            {
                Console.Write("Days:" + ' ');
                success = int.TryParse(Console.ReadLine(), out days);
                if (!success)
                {
                    Console.WriteLine("This is not a number." + ' ');
                }
            }
            while (!success);
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
            ListAllRentals(libraryLogic, false);
            Console.WriteLine();

            bool success;
            int id;

            do
            {
                try
                {
                    Console.WriteLine("Please enter the rental's id." + ' ');
                    Console.Write("ID: " + ' ');
                    success = int.TryParse(Console.ReadLine(), out id);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }

                    libraryLogic.DeleteRental(id);
                }
                catch (IDOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    success = true;
                }
            }
            while (!success);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ModifyRentalDays(ILibraryLogic libraryLogic)
        {
            ListAllRentals(libraryLogic, false);
            Console.WriteLine();

            bool success;
            int id;
            int days;

            do
            {
                try
                {
                    Console.Write("The rental's ID:" + ' ');
                    success = int.TryParse(Console.ReadLine(), out id);
                    if (!success)
                    {
                        Console.WriteLine("This is not a number." + ' ');
                    }
                    else
                    {
                        Console.Write("The rental's new number of days:" + ' ');
                        success = int.TryParse(Console.ReadLine(), out days);
                        if (!success)
                        {
                            Console.WriteLine("This is not a number." + ' ');
                        }
                        else
                        {
                            libraryLogic.ChangeBookRentalDays(id, days);
                        }
                    }
                }
                catch (IDOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    success = true;
                }
            }
            while (!success);

            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }
    }
}
