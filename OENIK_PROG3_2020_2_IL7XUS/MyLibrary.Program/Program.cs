// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleTools;
    using MyLibrary.Data;
    using MyLibrary.Logic;

    public class Program
    {
        private static void BookMenu(ILibraryLogic libraryLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL BOOKS", () => ListAllBooks(libraryLogic))
                .Add(">> ADD A NEW BOOK", () => AddNewBook())
                .Add(">> DELETE A BOOK", () => DeleteBook())
                .Add(">> MODIFY A BOOK", () => ModifyBook())
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private static void ListAllBooks(ILibraryLogic libraryLogic)
        {
            Console.WriteLine(libraryLogic.GetAllBooks().Select(x => x.ColumnInfo()).FirstOrDefault());
            libraryLogic.GetAllBooks().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void AddNewBook()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void DeleteBook()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ModifyBook()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void WorkerMenu(IPersonLogic personLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL WORKERS", () => ListAllWorkers(personLogic))
                .Add(">> ADD A NEW WORKER", () => AddNewWorker())
                .Add(">> DELETE A WORKER", () => DeleteWorker())
                .Add(">> MODIFY A WORKER", () => ModifyBook())
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private static void ListAllWorkers(IPersonLogic personLogic)
        {
            Console.WriteLine(personLogic.GetAllWorkers().Select(x => x.ColumnInfo()).FirstOrDefault());
            personLogic.GetAllWorkers().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void AddNewWorker()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void DeleteWorker()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ModifyWorker()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void RenterMenu(IPersonLogic personLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL RENTERS", () => ListAllRenters(personLogic))
                .Add(">> ADD A NEW RENTER", () => AddNewRenter())
                .Add(">> DELETE A RENTER", () => DeleteRenter())
                .Add(">> MODIFY A RENTER", () => ModifyRenter())
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private static void ListAllRenters(IPersonLogic personLogic)
        {
            Console.WriteLine(personLogic.GetAllRenters().Select(x => x.ColumnInfo()).FirstOrDefault());
            personLogic.GetAllRenters().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine($"\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void AddNewRenter()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void DeleteRenter()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ModifyRenter()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void RentalMenu(ILibraryLogic libraryLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL BOOK RENTALS", () => ListAllRentals(libraryLogic))
                .Add(">> ADD A BOOK RENTAL", () => AddNewRental())
                .Add(">> DELETE A BOOK RENTAL", () => DeleteRental())
                .Add(">> MODIFY A BOOK RENTAL", () => ModifyRental())
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private static void ListAllRentals(ILibraryLogic libraryLogic)
        {
            Console.WriteLine(libraryLogic.GetAllBookRentals().Select(x => x.ColumnInfo()).FirstOrDefault());
            libraryLogic.GetAllBookRentals().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void AddNewRental()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void DeleteRental()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private static void ModifyRental()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        public static void Main(string[] args)
        {
            Factory factory = new Factory();
            Console.WindowWidth = 150;
            Console.WindowHeight = 25;

            var menu = new ConsoleMenu()
                .Add(">>BOOKS", () => BookMenu(factory.LibraryLogic))
                .Add(">>WORKERS", () => WorkerMenu(factory.PersonLogic))
                .Add(">>RENTERS", () => RenterMenu(factory.PersonLogic))
                .Add(">>BOOK RENTALS", () => RentalMenu(factory.LibraryLogic))
                .Add(">> EXIT", ConsoleMenu.Close);

            menu.Show();

        }
    }
}